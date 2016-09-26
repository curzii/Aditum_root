; PIC16F1937
; I2C MASTER DRIVER CODE
; Author: Chris Best
; Microchip Technologies
; DATE: 07/11/2013
;-----------------------------------------------------------------------------------------------
; Software License Agreement
;
; The software supplied herewith by Microchip Technology Incorporated (the 'Company') is
; intended and supplied to you, the Company?s customer, for use solely and exclusively with
; products manufactured by the Company.
;
; The software is owned by the Company and/or its supplier, and is protected under applicable
; copyright laws. All rights are reserved. Any use in violation of the foregoing restrictions
; may subject the user to criminal sanctions under applicable laws, as well as to civil
; liability for the breach of the terms and conditions of this license.
;
; THIS SOFTWARE IS PROVIDED IN AN 'AS IS' CONDITION. NO WARRANTIES, WHETHER EXPRESS,
; IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, IMPLIED WARRANTIES OF MERCHANTABILITY
; AND FITNESS FOR A PARTICULAR PURPOSE APPLY TO THIS SOFTWARE. THE COMPANY SHALL NOT, IN ANY
; CIRCUMSTANCES, BE LIABLE FOR SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES, FOR ANY REASON WHATSOEVER.
;
; INTEGRATED DEVELOPMENT ENVIRONMENT: MPLABX IDE v1.80
; PROGRAMMER/DEBUGGER: PICKIT 3
; LANGUAGE TOOLSUITE: MICROCHIP MPASMWIN (v5.49)
;
; NOTES:
; This code was developed for use with the PIC16F1937, but can be used with other enhanced
; mid-range devices. Please check the specific part's data sheet for register names, such
; as SSPBUF, since some parts may have multiple I2C modules, or they may use a slightly
; different name (SSP1BUF). Also, the CONFIG words may need to be adjusted.
;
; CODE FUNCTION:
; The code implements the MSSP (or SSP) module as an I2C master.
; The master will transmit a set up data from an array to the slave, and after each byte
; is transmitted, that location in the array is overwritten with a value of 0xCC. This
; helps to make sure that the data was transmitted properly. After the data is transmitted,
; the master then reads data from an array in the slave, and loads the data into another
; array within the master.
; It is important to keep in mind that this code is for demonstration
; of the MSSP module for slave I2C communications. It does not include
; other interrupt possibilities, which would need to be added, and may require
; this code to be modified. The code is written to work directly
; with the 'I2C SLAVE CODE VERSION 2' and can be used either the assembly or C
; versions since they both do the same thing.
;------------------------------------------------------------------------------------------------


#include <p16F1937.inc>
; CONFIG1
 ; __config 0xFE5C
__CONFIG _CONFIG1, _FOSC_INTOSC & _WDTE_ON & _PWRTE_ON & _MCLRE_ON & _CP_ON & _CPD_ON & _BOREN_ON & _CLKOUTEN_OFF & _IESO_ON & _FCMEN_ON
; __config 0xFFFF
 __CONFIG _CONFIG2, _WRT_OFF & _VCAPEN_OFF & _PLLEN_ON & _STVREN_ON & _BORV_LO & _LVP_ON

#define	RX_ELEMENTS		.32					; number of allowable array elements
#define WRITE_ADD       0x30                ; slave write address
#define READ_ADD        0x31                ; slave read address
#define BRG_VAL         0x27                ; baud rate setting = 100kHz
#define CLEAR           0xCC                ; place in transmit array after transmit complete
#define LOAD            0xAA                ; value to load into array to transmit to slave

    cblock 0x70								; set up in shared memory for easy access
		INDEX_I2C							; index used to point to array location
		JUNK								; used to dump buffer
        INIT_START                          ; used to set bit for start sequence
        STOP                                ; used to set bit for stop sequence
        WRITE_TO_SLAVE                      ; used for write sequence
        TRANS_WRT_ADD                       ; bit sets up write address transmission
        INIT_TRANS_DATA                     ; bit sets up data transmission
        TRANS_DATA                          ; used to monitor transmission
        TRANS_COMPLETE                      ; set when transmission is complete
        TRANS_RD_ADD                        ; sets up read address transmission
        READ_FROM_SLAVE                     ; used for read sequence
    endc
		udata
        I2C_ARRAY_TX        res RX_ELEMENTS     ; array to transmit to slave
        I2C_ARRAY_RX 		res RX_ELEMENTS 	; array to receive from slave
        INIT_MSTR_REC       res 1               ; initializes reception
        SET_RCEN            res 1               ; initializes RCEN bit to receive data
        REC_BYTE            res 1               ; sets up receive byte sequence
        READ_REC_BYTE       res 1               ; read and store data
        SET_ACKEN           res 1               ; sets up acknowledge sequence
        REC_COMPLETE        res 1               ; set when reception is complete
        COUNTERL            res 1               ; used in delay routine
        COUNTERH            res 1               ; used in delay routine


;-----------------------------------------------------------------------------------------------
; The macro LOADFSR loads FSR1 with the I2C address and the I2C index value to read or write to
; and makes code easier to read.
;------------------------------------- LOADFSR macro -------------------------------------------

LOADFSR macro 	ADDRESS,INDEX 				; ADDRESS = I2C_ARRAY, INDEX = INDEX_I2C
		movlw 	ADDRESS 					; load address
		addwf	INDEX,W						; add the index value to determine location in array
		movwf 	FSR1L						; load FSR1L with pointer info
		clrf	FSR1H                       ; clear FSR1H
		endm                                ; end macro
;-----------------------------------------------------------------------------------------------


;----------------------------------- start vector ----------------------------------------------
 		ORG    	0x0000          			; reset vector
    	goto   	Main                    	; jump to main
;-----------------------------------------------------------------------------------------------

;----------------------------------- interrupt vector ------------------------------------------
    	ORG    	0x0004          			; interrupt vector
		banksel	PIR1
		btfss 	PIR1,SSPIF 					; Is this a SSP interrupt?
		goto 	BUS_COLL 					; if not, bus collision int occurred
    	banksel	WRITE_TO_SLAVE
		btfsc	WRITE_TO_SLAVE,0			; is it a write sequence?
		goto	WRITE						; if so go here
        goto    READ                        ; if not, it is a read sequence
;-----------------------------------------------------------------------------------------------

;-----------------------------------------------------------------------------------------------
;											Main
;-----------------------------------------------------------------------------------------------
		ORG		0x0040        				; start of Flash memory

Main
		call	INITIALIZE					; set up uC

LOOP                                        ; infinite while loop
		clrwdt								; clear WDT to prevent hangups
        banksel	WRITE_TO_SLAVE
		btfss	WRITE_TO_SLAVE,0			; is it a write sequence?
		goto	SET_READ					; if not set up master to read
        btfss   INIT_START,0                ; is start bit set?
        goto    INIT_TRANSMIT               ; if not, check if transmission ready
        clrf    INIT_START                  ; if so, clear start bit
        banksel SSPCON2
        bsf     SSPCON2,SEN                 ; set start enable bit
        goto    LOOP
INIT_TRANSMIT                               ; set up transmit sequence
        banksel INIT_TRANS_DATA
        btfss   INIT_TRANS_DATA,0           ; is bit set?
        goto    SET_PEN_BIT                 ; if not, transmit of data complete
        clrf    INIT_TRANS_DATA             ; if so, clear bit
        bsf     TRANS_DATA,0                ; set bit for transmission seq in INT routine
        goto    LOOP
SET_PEN_BIT                                 ; set up stop sequence
        banksel TRANS_COMPLETE
        btfss   TRANS_COMPLETE,0            ; is transmission complete?
        goto    LOOP                        ; if not, go back to LOOP
        clrf    TRANS_COMPLETE
        bsf     STOP,0                      ; if so, set stop bit
        banksel SSPCON2
        bsf     SSPCON2,PEN                 ; enable stop sequence
        call    DELAY                       ; short delay while stop sequence is performed
        goto    LOOP

SET_READ                                    ; set up READ routines
        banksel WRITE_TO_SLAVE
        btfsc   WRITE_TO_SLAVE,0            ; make sure write is complete
        goto    LOOP                        ; if not, go back to LOOP
        btfsc   READ_FROM_SLAVE,0           ; is READ sequence bit set?
        goto    READ_SEQUENCE               ; if so, go read
        call    DELAY                       ; if not, short delay
        clrf    REC_COMPLETE                ; clear receive complete bit
        clrf    INDEX_I2C                   ; clear index
        bsf     INIT_START,0                ; set start bit
        bsf     READ_FROM_SLAVE,0           ; set read sequence bit
        goto    LOOP

READ_SEQUENCE                               ; start read sequence
        banksel READ_FROM_SLAVE
        btfss   READ_FROM_SLAVE,0           ; make sure read sequence is set
        goto    LOOP                        ; if not, go back to LOOP
        btfss   INIT_START,0                ; is start bit set?
        goto    PREP_TO_REC                 ; if not, go get ready to read
        clrf    INIT_START                  ; if so, clear bit
        banksel SSPCON2
        bsf     SSPCON2,SEN                 ; set SEN bit to begin start sequence
        goto    LOOP
PREP_TO_REC                                 ; get ready to receive data
        banksel INIT_MSTR_REC
        btfss   INIT_MSTR_REC,0             ; is bit set?
        goto    RECEIVE_BYTE                ; if not, go receive data
        clrf    INIT_MSTR_REC               ; if so, clear bit
        bsf     SET_RCEN,0                  ; set this to so in next INT RCEN is set
        goto    LOOP
RECEIVE_BYTE                                ; receive data byte
        banksel REC_BYTE
        btfss   REC_BYTE,0                  ; is bit set?
        goto    ACKNOWLEDGE                 ; if not, byte received so go acknowledge
        bsf     READ_REC_BYTE,0             ; if so, go receive data
        goto    LOOP
ACKNOWLEDGE
        banksel SET_ACKEN
        btfss   SET_ACKEN,0                 ; is bit set?
        goto    RECEIVE_COMPLETE            ; if not, finish read routines
        clrf    SET_ACKEN
        bsf     INIT_MSTR_REC,0
        banksel SSPCON2
        bsf     SSPCON2,ACKEN               ; if so, set ACK bit to acknowledge slave
        goto    LOOP
RECEIVE_COMPLETE                            ; finish up read routine
        banksel REC_COMPLETE
        btfss   REC_COMPLETE,0              ; is bit set?
        goto    LOOP                        ; if not, go back to LOOP
        bsf     STOP,0                      ; if so, set up stop
        banksel SSPCON2
        bsf     SSPCON2,PEN                 ; set stop bit to begin stop sequence
        call    DELAY
        goto    LOOP
DELAY                                       ; delay routine
	decfsz	COUNTERL,F
	goto	DELAY
	decfsz	COUNTERH,F
	goto	DELAY
	return                              

;------------------------------------- end main ------------------------------------------------

;-----------------------------------------------------------------------------------------------
;	Initialize: Sets up register values
;-----------------------------------------------------------------------------------------------
INITIALIZE
;uC set up
		banksel	OSCCON
		movlw	b'01111010'					; Internal OSC @ 16MHz
		movwf	OSCCON
		movlw	b'11010111'
		movwf	OPTION_REG					; load W into OPTION_REG
		movlw	b'00010111'					; WDT prescaler 1:65536 period is 2 sec (RESET value)
		movwf	WDTCON
		banksel PORTC
    	clrf    PORTC
		banksel TRISC                   	; switch to BANK containing TRISB
    	movlw   b'00011000'                 ; set RC3 and RC4 as inputs for I2C
    	movwf  	TRISC						; load W into TRISC
        banksel INDEX_I2C
        clrf    INDEX_I2C
 LOADV                                      ; load transmit array with val to transmit
        clrf	JUNK						; clear JUNK
		movlw	RX_ELEMENTS					; load array elements value
		banksel STATUS
		btfsc	STATUS,Z					; is Z clear?
		subwf	INDEX_I2C,W					; if Z = 1, subtract index from number of elements
		banksel	STATUS
		btfsc	STATUS,0					; did a carry occur after subtraction?
		goto	FIN_LOAD                    ; if so, Master is trying to write to many bytes
		LOADFSR	I2C_ARRAY_TX,INDEX_I2C		; call LOADFSR macro
		movlw	LOAD						; move the contents of the buffer into W
		movwf 	INDF1						; load INDF1 with data to write
        incf	INDEX_I2C,F					; increment INDEX_I2C 'pointer'
        goto    LOADV                       ; keep loading until array is full
 FIN_LOAD
        banksel INDEX_I2C
        clrf    INDEX_I2C                   ; clear index
        clrf    JUNK                        ; clear junk file
        bsf     INIT_START,0                ; set start bit
        clrf    STOP                        ; clear stop bit
        bsf     WRITE_TO_SLAVE,0            ; set WRITE bit
        bsf     TRANS_WRT_ADD,0             ; set bit to ready write add seq.
        clrf    INIT_TRANS_DATA
        clrf    TRANS_DATA
        clrf    TRANS_COMPLETE
        bsf     TRANS_RD_ADD,0
        clrf    READ_FROM_SLAVE
        clrf    INIT_MSTR_REC
        clrf    SET_RCEN
        clrf    REC_BYTE
        clrf    READ_REC_BYTE
        clrf    SET_ACKEN
        clrf    REC_COMPLETE
        clrf    COUNTERL
        clrf    COUNTERH

;I2C set up
		banksel	SSPSTAT
		bsf		SSPSTAT,SMP					; Slew rate control disabled for standard speed mode
		movlw	b'00101000'					; Enable serial port, I2C master mode, 7-bit address
		movwf	SSPCON1
		bsf		SSPCON3,SDAHT				; Minimum of 300 ns hold time
		movlw	BRG_VAL                     ; load thE baud rate value
		movwf	SSPADD

		banksel	PIR1
		bcf		PIR1,SSPIF					; clear the SSP interrupt flag
		banksel	PIE1
		bsf		PIE1,SSPIE					; enable SSP interrupts
		banksel	PIR2
		bcf		PIR2,BCLIF					; clear the SSP interrupt flag
		banksel	PIE2
		bsf		PIE2,BCLIE					; enable SSP interrupts
		bsf		INTCON,PEIE					; enable peripheral interrupts
		bsf		INTCON,GIE					; enable global interrupts
		return
;------------------------------------- END INITIALIZE ------------------------------------------

;-----------------------------------------------------------------------------------------------
; 								Interrupt Service Routine (ISR)
;-----------------------------------------------------------------------------------------------

WRITE                                       ; DATA TRANSMISSION SEQUENCE OF EVENTS
        banksel TRANS_COMPLETE
        btfsc   TRANS_COMPLETE,0            ; is transmission complete?
        goto    END_TRANSMISSION            ; if so, finish transmission
        btfss   TRANS_WRT_ADD,0             ; if not, has trans add been sent?
        goto    TRANSMIT_DATA               ; if so, go start to transmit
        clrf    TRANS_WRT_ADD               ; if not, send trans add
        bsf     INIT_TRANS_DATA,0
        banksel SSPBUF
        movlw   WRITE_ADD
        movwf   SSPBUF
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
        retfie
TRANSMIT_DATA
        banksel TRANS_DATA
        btfss   TRANS_DATA,0                ; is transmission complete?
        goto    END_TRANSMISSION            ; if so, go finish sequence
        clrf	JUNK						; clear JUNK
		movlw	RX_ELEMENTS					; load array elements value
		banksel STATUS
		btfsc	STATUS,Z					; is Z clear?
		subwf	INDEX_I2C,W					; if Z = 1, subtract index from number of elements
		banksel	STATUS
		btfsc	STATUS,0					; did a carry occur after subtraction?
		goto	COMP_TRANS                  ; if so, array limit reached
        LOADFSR	I2C_ARRAY_TX,INDEX_I2C		; call LOADFSR macro
		movf	INDF1,W						; move value into W to load to SSP buffer
		banksel	SSPBUF
		movwf	SSPBUF						; load SSP buffer
		LOADFSR	I2C_ARRAY_TX,INDEX_I2C		; call LOADFSR macro
		movLw	CLEAR						; move the contents of the buffer into W
		movwf 	INDF1						; load INDF1 with data to write
        incf	INDEX_I2C,F					; increment INDEX_I2C 'pointer'
        banksel	SSPCON1
		btfsc	SSPCON1,WCOL				; did a write collision occur?
		goto  	WRITE_COLL					; if so, go clear bit
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
		retfie 								; Return from interrupt.
COMP_TRANS
        banksel TRANS_DATA                  ; is transmission complete?
        clrf    TRANS_DATA                  ; clear bit
        bsf     TRANS_COMPLETE,0            ; get ready to end sequence
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
		retfie 								; Return from interrupt.
END_TRANSMISSION                            ; finish transmit sequence
        banksel STOP
        btfss   STOP,0                      ; is stop set?
        goto    $+3                         ; if  not, clear int flag
        clrf    STOP                        ; if so, clear stop
        clrf    WRITE_TO_SLAVE              ; clear bit to prevent more transmissions
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
		retfie 								; Return from interrupt.

; end of write routine

READ                                        ; READ FROM SLAVE SEQUENCE OF EVENTS
		banksel	REC_COMPLETE
		btfsc	REC_COMPLETE,0				; finished reading?
		goto	END_RECEPTION				; if so, end read sequence
        btfss   TRANS_RD_ADD,0              ; if not, was read add transmitted to slave?
        goto    ENABLE_REC                  ; if so, set master to receive
        clrf    TRANS_RD_ADD                ; clear bit
        bsf     INIT_MSTR_REC,0             ; set bit to get ready next INT
        banksel SSPBUF
        movlw   READ_ADD                    ; transmit read address to slave
        movwf   SSPBUF
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
		retfie 								; Return from interrupt.
ENABLE_REC                                  ; sets up master as a receiver
        banksel SET_RCEN
        btfss   SET_RCEN,0                  ; is bit set?
        goto    READ_DATA_BYTE              ; if not, master is in receive mode
        clrf    SET_RCEN                    ; otherwise, get set up
        bsf     REC_BYTE,0
        banksel SSPCON2
        bsf     SSPCON2,RCEN                ; set RCEN to enable master receive mode
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
        retfie 								; Return from interrupt.
READ_DATA_BYTE                              ; read the data byte from slave
        banksel READ_REC_BYTE
        btfss   READ_REC_BYTE,0             ; was all data received?
        goto    COMP_RECEIVE                ; if so, finish sequence
        clrf    READ_REC_BYTE               ; otherwise, read data and store in array
        clrf    REC_BYTE
        ;bsf     INIT_MSTR_REC,0
        clrf	JUNK						; clear JUNK
		movlw	RX_ELEMENTS					; load array elements value
		banksel STATUS
		btfsc	STATUS,Z					; is Z clear?
		subwf	INDEX_I2C,W					; if Z = 1, subtract index from number of elements
		banksel	STATUS
		btfsc	STATUS,0					; did a carry occur after subtraction?
		goto	COMP_RECEIVE                ; if so, Master is trying to write to many bytes
		LOADFSR	I2C_ARRAY_RX,INDEX_I2C      ; call LOADFSR macro
		banksel	SSPBUF
		movfw	SSPBUF						; move the contents of the buffer into W
		movwf 	INDF1						; load INDF1 with data to write
        incf	INDEX_I2C,F					; increment INDEX_I2C 'pointer'
        banksel SET_ACKEN
        bsf     SET_ACKEN,0                 ; set up ack sequence in MAIN
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
        retfie 								; Return from interrupt.
COMP_RECEIVE                                ; get ready to wrap things up
        banksel INIT_MSTR_REC
        clrf    INIT_MSTR_REC
        clrf    REC_BYTE
        clrf    READ_REC_BYTE
        banksel	REC_COMPLETE
		bsf 	REC_COMPLETE,0
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
        retfie 								; Return from interrupt.
END_RECEPTION
        banksel STOP
        btfsc   STOP,0
        goto    $+2
        clrf    READ_FROM_SLAVE
        banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
		retfie 								; Return from interrupt.
        
WRITE_COLL                                  ; write collision clearing
		banksel	SSPCON1
		bcf		SSPCON1,WCOL				; clear WCOL bit
		banksel	PIR1
		bcf 	PIR1,SSPIF					; clear the SSP interrupt flag
		retfie 								; Return from interrupt.

BUS_COLL
		banksel	SSPBUF
		clrf	SSPBUF						; clear the SSP buffer
		banksel	PIR2
		bcf		PIR2,BCLIF					; clear the SSP interrupt flag
		retfie								; Return from interrupt.
		end									; END OF PROGRAM


