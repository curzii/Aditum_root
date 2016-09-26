/* 
 * File: menu.h   
 * Author: Jaco Kampman
 * Comments: Header file for menus
 * Revision history: N/A 
 */

#ifndef MENU_H
#define	MENU_H

#include <xc.h>
#include "lcd.h"
#include <stdlib.h>
#include <string.h>

/*
 * Student Nr               Time logged in   
 * Machine ID/I2C Address   Animation
 * 
 * 0123456789ABCDEF
 * 15011420 
 * ID: 21       [_]
 */

//prototypes
void menu_seconds_to_mmss(unsigned int s, char* t);
void menu_main(char* user_id, unsigned int user_time, unsigned char i2c_address);
void menu_animation_i2c(void);
void menu_progress_bar(unsigned short load_time_ms);

void menu_main(char* user_id, unsigned int user_time, unsigned char i2c_address)
{
    
    //Converts seconds to string in format HH:MM:SS
    char time[5] = {'0','0',':','0','0'};
    menu_seconds_to_mmss(user_time, time);
    
    Lcd_Set_Cursor(1, 1);
    for(int i = 0; user_id[i]!= '\0'; i++)
	   Lcd_Write_Char(user_id[i]);
    Lcd_Set_Cursor(1, 1);
    for(int i = 0; i < 5; i++)
        Lcd_Write_Char(time[i]);
    //Lcd_Set_Cursor(2, 1);    
    //Lcd_Write_Char(i2c_address);
    
    return;
}


void menu_animation_i2c(void)
{
    Lcd_Set_Cursor(1,15);
    Lcd_Write_String(0xFF);
    for (int d = 0; d < 50; d++)
        __delay_ms(10);
    Lcd_Set_Cursor(2,14);
    Lcd_Write_String(" ");
    return;
}

void menu_seconds_to_mmss(unsigned int s, char* t)
{
    char n[] = {'0','1','2','3','4','5','6','7','8','9'};     
    if ((s/600)!= 0)
    {
        t[0] = n[(s / 600)];
        s   -= (s / 600) * 600;
    }
    if ((s/60)!= 0)
    {
        t[1] =   n[(s / 60)];
        s   -=  (s / 60) * 60;
    }
    t[2] =   (':');
    if ((s/10)!= 0)
    {
        t[3] =   n[(s / 10)];
        s   -=  (s / 10) * 10;
    }
    t[4] =   n[(s)];
    return;
}

void menu_progress_bar(unsigned short load_time_ms)
{
    Lcd_Set_Cursor(2,1);
    unsigned long d = (((load_time_ms/16)/20)*20);
    for (int i = 0; i < 16; i++)
    {
        Lcd_Write_Char(0xFF);
        for (int ii = 0; ii < d; ii+=20)
            __delay_ms(20);        
    }
    Lcd_Set_Cursor(2,1);
    Lcd_Write_String("                ");
    for (int i = 0; i < 5; i++)
    {
        __delay_ms(20);          
    }
    Lcd_Set_Cursor(2,1);
    for (int i = 0; i < 16; i++)
    {
        Lcd_Write_Char(0xFF);          
    }
    for (int i = 0; i < 5; i++)
    {
        __delay_ms(20);          
    }        
    Lcd_Clear();
}

#endif	/* MENU_H */

