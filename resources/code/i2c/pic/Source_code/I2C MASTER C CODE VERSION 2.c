/*****************************************************************************  
PIC16F1937 
I2C MASTER DRIVER CODE 
Author: Chris Best 
Microchip Technologies
DATE: 07/11/2013
------------------------------------------------------------------------------  
 Software License Agreement

 The software supplied herewith by Microchip Technology Incorporated 
 (the 'Company') is intended and supplied to you, the Company?s customer, for
 use solely and exclusively with products manufactured by the Company.

 The software is owned by the Company and/or its supplier, and is protected 
 under applicable copyright laws. All rights are reserved. Any use in violation
 of the foregoing restrictions may subject the user to criminal sanctions under
 applicable laws, as well as to civil liability for the breach of the terms and
 conditions of this license.

 THIS SOFTWARE IS PROVIDED IN AN 'AS IS' CONDITION. NO WARRANTIES, WHETHER
 EXPRESS, IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, IMPLIED
 WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE APPLY TO
 THIS SOFTWARE. THE COMPANY SHALL NOT, IN ANY CIRCUMSTANCES, BE LIABLE FOR
 SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES, FOR ANY REASON WHATSOEVER.
----------------------------------------------------------------------------------

 INTEGRATED DEVELOPMENT ENVIRONMENT: MPLABX IDE v1.80
 PROGRAMMER/DEBUGGER: PICKIT 3
 LANGUAGE TOOLSUITE: MICROCHIP XC8 v1.20

 NOTES:
 This code was developed for use with the PIC16F1937, but can be used with 
 other enhanced mid-range devices. Please check the specific part's data sheet
 for register names, such as SSPBUF, since some parts may have multiple I2C
 modules, or they may use a slightly different name (SSP1BUF). Also, the CONFIG
 words may need to be adjusted.

 CODE FUNCTION:
 The code implements the MSSP (or SSP) module as an I2C master.
 The master will transmit a set up data from an array to the slave, and after 
 each byte is transmitted, that location in the array is overwritten with a
 value of 0x00. This helps to make sure that the data was transmitted properly.
 After the data is transmitted, the master then reads data from an array in the
 slave, and loads the data into another array within the master.

 It is important to keep in mind that this code is for demonstration of the MSSP
 module for slave I2C communications. It does not include other interrupt
 possibilities, which would need to be added, and may require this code to be
 modified. The code is written to work directly with the
 'I2C SLAVE CODE VERSION 2' and can be used either the assembly or C versions
 since they both do the same thing.
 */

#include <xc.h>

// CONFIG1
#pragma config FOSC = INTOSC    // INTOSC oscillator: I/O function on CLKIN pin
#pragma config WDTE = ON        // Watchdog Timer Enable (WDT enabled)
#pragma config PWRTE = ON       // Power-up Timer Enable (PWRT enabled)
#pragma config MCLRE = ON       // MCLR/VPP pin function is MCLR
#pragma config CP = ON          // Program memory code protection is enabled
#pragma config CPD = ON         // Data memory code protection is enabled
#pragma config BOREN = ON       // Brown-out Reset enabled
#pragma config CLKOUTEN = OFF   // CLKOUT function is disabled.
                                // I/O or oscillator function on the CLKOUT pin
#pragma config IESO = ON        // Internal/External Switch-over mode is enabled
#pragma config FCMEN = ON       // Fail-Safe Clock Monitor is enabled

// CONFIG2
#pragma config WRT = OFF        // Flash Memory Self-Write Protection off
#pragma config VCAPEN = OFF     // All VCAP pin functionality is disabled
#pragma config PLLEN = ON       // PLL Enable (4x PLL enabled)
#pragma config STVREN = ON      // Stack Overflow/Underflow will cause a Reset
#pragma config BORV = LO        // Brown-out Reset Voltage (Vbor),
                                // low trip point selected.
#pragma config LVP = ON         // Low-voltage programming enabled

#define RX_ELMNTS	32

// array for master to write data from slave
volatile unsigned char I2C_Array_Rx[RX_ELMNTS] = 0;

// array for master to write to
volatile unsigned char I2C_Array_Tx[RX_ELMNTS] = 	
{0x09,0x09,0x13,0x14,0x15,0x16,0x17,0x18,
 0x19,0x1A,0x1B,0x1C,0x1D,0x1E,0x1F,0xCF,
 0xCE,0xCD,0xCC,0xCB,0xCA,0xC9,0xC8,0xC7,
 0xC6,0xC5,0xC4,0xC3,0xC2,0xC1,0xC0,0xAA};

unsigned char I2C_slave_write_add = 0x30;      // slave address R/nW = 0 (write)
unsigned char I2C_slave_read_add = 0x31;       // slave address R/nW = 1 (read)
unsigned char BRG_val = 0x27;                // 0x27 sets the SCL freq to 100kHz


unsigned int index_i2c = 0;                 // index pointer
unsigned char junk = 0;                     // place to put unnecessary data
unsigned char clear = 0x00;                 // used to clear array location
unsigned char init_start = 1;               // used to get start bit set
unsigned char stop = 0;                     // used to know when to stop
unsigned char write_to_slave = 1;           // used to set up master transmission
unsigned char trans_wrt_add = 1;            // used to set up address for write
unsigned char init_trans_data = 0;          // used to set up data transmission
unsigned char init_mstr_rec = 0;            // used to set up master reception
unsigned char rec_byte = 0;                 // used to know when byte received
unsigned char set_RCEN = 0;                 // used to set RCEN bit
unsigned char trans_data = 0;               // used to get transmission going
unsigned char done = 0;                     // used to know when finished
unsigned char read_from_slave = 0;          // used to set up reception routine
unsigned char trans_rd_add = 1;             // used to set up address for read
unsigned char read_rec_byte = 0;            // used to read data into array
unsigned char set_ACKEN = 0;                // used to set ACKEN bit


void initialize(void);                      // initialize micro routine

/****************************** MAIN ROUTINE **********************************/
void main(void)
{
    initialize();                           	// go get initialized
    while(1)                                	// main while() loop
    {
        asm("CLRWDT");                      	// clear WDT
        if(write_to_slave)                  	// get set to go write to slave
        {
            if(init_start)                      // get ready to start
            {
                SSPCON2bits.SEN = 1;            // Initiate START condition
                init_start = 0;
            }
            if(init_trans_data)               	// get ready to transmit data
            {
                trans_data = 1;
                init_trans_data = 0;
            }
            if(done)                          // when all data is transferred
            {                                 // send stop bit
                stop = 1;
                done = 0;
                SSPCON2bits.PEN = 1;          // stop bit set
            }

        }// end transmission
		
        if((!write_to_slave) && (!read_from_slave))  // get ready to now read
        {
            read_from_slave = 1;                    // get read routines going
            done = 0;
            index_i2c = 0;
            init_start = 1;                         // get ready to start
        }
 
        if(read_from_slave)                         // read from slave
        {
            if(init_start)                         // set up start condition
            {
                SSPCON2bits.SEN = 1;                // Initiate START condition
                init_start = 0;
            }
            if(init_mstr_rec)                     // get ready to receive data
            {
                set_RCEN = 1;                     // set master into receive mode
                init_mstr_rec = 0;
            }
            if(rec_byte)                          // check to see if data arrived
            {
                read_rec_byte = 1;
            }
            if(set_ACKEN)                         // set up ACKEN bit
            {
                set_ACKEN = 0;
                init_mstr_rec = 1;
                ACKEN = 1;
            }
            if(done)                              // if array is full time to stop
            {
                stop = 1;
                SSPCON2bits.PEN = 1;              // set stop bit
            }

        }//end read routine
        
       
    }//end while()

}//end main
/******************************************************************************/

/********************************INITIALIZE ROUTINE ***************************/
void initialize(void)
{
//uC SET UP
    OSCCON = 0b01111010; 		     			// Internal OSC @ 16MHz
    OPTION_REG = 0b11010111;
    WDTCON = 0b00010111;						// prescaler 1:65536
												// period is 2 sec (RESET value)
    PORTC = 0x00;                       		// Clear PORTC
    LATC = 0x00;                        		// Clear PORTC latches
    TRISC = 0b00011000;                 		// Set RC3, RC4 as inputs for I2C

//I2C MASTER MODULE SET UP
    SSPSTAT = 0b10000000;						// Slew rate control disabled for 
												// standard speed mode (100 kHz, 1 MHz)
    SSPCON1 = 0b00101000; 						// Enable serial port, I2C master mode,
												// clock=Fosc/(4*(SSPAD+1))
    SSPCON3bits.SDAHT = 1;						// Minimum of 300 ns hold time on SDA
												// after the falling edge of SCL
    SSPADD = BRG_val;                   		// This sets Baud rate
    SSPIF = 0; 									// Clear the serial port interrupt flag
    BCLIF = 0;                          		// Clear the bus coll interrupt flag
    BCLIE = 1;                          		// Enable bus collision interrupts
    SSPIE = 1; 									// Enable serial port interrupts
    PEIE = 1; 									// Enable peripheral interrupts
    GIE = 1; 									// Enable global interrupts
}
/******************************************************************************/

/****************************** ISR ROUTINE ***********************************/
void interrupt ISR(void)
{
    if(SSPIF)                                   		// is it an SSP interrupt?
    {
        if(write_to_slave)                      		// write to slave
        {
            if(!done)                           		// if not done, continue
            {
                if(trans_wrt_add)               		// get ready to transmit
                {                              			// address with write bit enabled
                    SSPBUF = I2C_slave_write_add; 		// load buffer with write address
                    trans_wrt_add = 0;
                    init_trans_data = 1;
                }
                if(trans_data)              				// ready to transmit
                {  
                    if(index_i2c < RX_ELMNTS) 				// make sure valid data
                    {
                        SSPBUF = I2C_Array_Tx[index_i2c]; 		// load buffer with data
                        I2C_Array_Tx[index_i2c++] = clear; 		// clear that location
                    }                                     		// and increment index
                    else
                    {
                        trans_data = 0;                 		// done transmitting
                        done = 1;
                    }       
                }
            }
            if(stop)                            			// done transmitting
            {
                write_to_slave = 0;             		// clear so no more data transmitted
                stop = 0;
            }
        }
        if(read_from_slave)                 				// read from slave
		{
            if(!done)                       				// if not done continue
			{
                if(trans_rd_add)            				// set up read address
				{
                    SSPBUF = I2C_slave_read_add; 			// address and read bit
					trans_rd_add = 0;
					init_mstr_rec = 1;
				}
				if(set_RCEN)                    			// set up module for read
				{
                    set_RCEN = 0;
                    SSPCON2bits.RCEN = 1;      				// set RCEN to enable read
                    rec_byte = 1;
				}
				if(read_rec_byte)              				// reading data
				{
                    if(index_i2c < RX_ELMNTS) 				// make sure valid location
                    {
                        read_rec_byte = 0;
                        rec_byte = 0;
                        I2C_Array_Rx[index_i2c] = SSPBUF; 	// load array with data
                        index_i2c++;                    	// increment counter
                        set_ACKEN = 1;                  	// get ready to ACK
                    }
                    else
                    {                               		// received all data
                        init_mstr_rec = 0;
                        rec_byte = 0;
                        read_rec_byte = 0;
                        done = 1;
                    }
                }
            }
            if(stop)
            {
                read_from_slave = 0;    			// clear so no more data is received
            }
        }
    }
    
    if(BCLIF)                       				// Did a bus collision occur?
    {
        junk = SSPBUF;              				// dummy read to clear BF bit
		BCLIF = 0;                  				// clear BCLIF flag bit
    }
    SSPIF = 0;                      				// clear SSPIF flag bit
}// end of ISR 
    
