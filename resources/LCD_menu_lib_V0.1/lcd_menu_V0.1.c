// ***********************************************************************
// LCD menu
// ***********************************************************************



//************************************************************************
// MPLAB/HITECH-C includes
//************************************************************************
#include <htc.h>
#include <stdlib.h>

//************************************************************************
// Projekt includes						// Include your own functions here
//************************************************************************
#include "debounce.h"					// Debouncefunctions
#include "delay.h"						// Delayfunctions
#include "lcd_menu.h"					// Menu
#include "lcd_with_hd44780.h"			// HD44780

// ***********************************************************************
// Macros
// ***********************************************************************
// Debounce macros
#define UP_KEY					get_key_press (1<<OBEN)
#define DOWN_KEY				get_key_press (1<<UNTEN)
#define ENTER_KEY				get_key_press (1<<ENTER)

// Delay macro
#define DELAY_MS(a)				DelayMs(a)

// LCD macros
#define LCDWriteChar(a)  		LCDWriteData(a)
#define LCDWriteFromROM(a,b,c) 	LCDWriteStringROM(a,b,c,1)

// ***********************************************************************
// Variable definitions
// ***********************************************************************
// General
static unsigned char selected = 1;			// Start with first entry (apart from header)

// Menu strings
const char menu_000[] = " [Main Screen]";  	// 0
const char menu_001[] = "  Options1";  		// 1
const char menu_002[] = "  Options2";  		// 2
const char menu_003[] = "  Options3";  		// 3
const char menu_004[] = "  Options4";  		// 4
const char menu_005[] = "  Options5";  		// 5
const char menu_006[] = "  Options6";  		// 6
const char menu_007[] = "  Options7";  		// 7
const char menu_008[] = "  Options8";  		// 8
const char menu_009[] = "  Options9";  		// 9
const char menu_010[] = "  return";  		// 10

const char menu_100[] = " [Header1]";  		// 11
const char menu_101[] = "  Option101";  	// 12
const char menu_102[] = "  Option102";  	// 13
const char menu_103[] = "  Option103";  	// 14
const char menu_104[] = "  Option104";  	// 15
const char menu_105[] = "  Option105";  	// 16
const char menu_106[] = "  Option106";  	// 17
const char menu_107[] = "  Option107";  	// 18
const char menu_108[] = "  return";  		// 19

const char menu_200[] = " [Header2]";  		// 20
const char menu_201[] = "  Option201";  	// 21
const char menu_202[] = "  Option202";  	// 22	
const char menu_203[] = "  Option203";  	// 23
const char menu_204[] = "  Option204";  	// 24
const char menu_205[] = "  Option205";  	// 25
const char menu_206[] = "  Option206";  	// 26
const char menu_207[] = "  Option207";  	// 27
const char menu_208[] = "  return";  		// 28

const char menu_300[] = " [Header3]";  		// 29
const char menu_301[] = "  Option301";  	// 30
const char menu_302[] = "  Option302";  	// 31
const char menu_303[] = "  Option303";  	// 32
const char menu_304[] = "  Option304";  	// 33
const char menu_305[] = "  return";  		// 34


// Array of entries
MenuEntry menu[] =
{
	{menu_000, 11,  0,  0,  0,  0}, 		// 0
	{menu_001, 11,  1,  2, 12,  0},
	{menu_002, 11,  1,  3, 21,  0},
	{menu_003, 11,  2,  4, 30,  0},
	{menu_004, 11,  3,  5,  4,  0},
	{menu_005, 11,  4,  6,  5,  0},
	{menu_006, 11,  5,  7,  6,  0},
	{menu_007, 11,  6,  8,  7,  0},
	{menu_008, 11,  7,  9,  8,  0},
	{menu_009, 11,  8, 10,  9,  0},
	{menu_010, 11,  9, 10, 10,  0}, 		// 10

	{menu_100,  9,  0,  0,  0,  0},			// 11
	{menu_101,  9, 12, 13, 12,  0},
	{menu_102,  9, 12, 14, 13,  0},
	{menu_103,  9, 13, 15, 14,  0},
	{menu_104,  9, 14, 16, 15,  0},
	{menu_105,  9, 15, 17, 16,  0},
	{menu_106,  9, 16, 18, 17,  0},
	{menu_107,  9, 17, 19, 18,  0},
	{menu_108,  9, 18, 19,  1,  0},			// 19

	{menu_200,  9,  0,  0,  0,  0},			// 20
	{menu_201,  9, 21, 22, 21,  0},
	{menu_202,  9, 21, 23, 22,  0},
	{menu_203,  9, 22, 24, 23,  0},
	{menu_204,  9, 23, 25, 24,  0},
	{menu_205,  9, 24, 26, 25,  0},
	{menu_206,  9, 25, 27, 26,  0},
	{menu_207,  9, 26, 28, 27,  0},
	{menu_208,  9, 27, 28,  2,  0},			// 28

	{menu_300,  6,  0,  0,  0,  0},			// 29
	{menu_301,  6, 30, 31, 30,  0},
	{menu_302,  6, 30, 32, 31,  0},
	{menu_303,  6, 31, 33, 32,  0},
	{menu_304,  6, 32, 34, 33,  0},
	{menu_305,  6, 33, 34,  3,  0}			// 34
};


// ***********************************************************************
// Show menu function
// ***********************************************************************
void show_menu(void)
{	unsigned char line_cnt;					// Count up lines on LCD
 	unsigned char from;
 	unsigned char till = 0;

	unsigned char temp;						// Save "from" temporarily for always visible header and cursor position
 
	 // Get beginning and end of current (sub)menu
 	while (till <= selected)
 	{	till += menu[till].num_menupoints;
 	}
	from = till - menu[selected].num_menupoints;
 	till--;

	temp = from;							// Save from for later use


	//--------------------------------------------------------------------
	// Always visible Header
	//--------------------------------------------------------------------
#if         defined USE_ALWAYS_VISIBLE_HEADER

	line_cnt = 1;							// Set line counter to one since first line is reserved for header

	// Write header
	LCDWriteFromROM(0,0,menu[temp].text);
	

	// Output for two row display becomes fairly easy
	#if defined USE_TWO_ROW_DISPLAY

		LCDWriteFromROM(0,UPPER_SPACE,menu[selected].text);
		gotoxy(0,UPPER_SPACE);
		LCDWriteChar(SELECTION_CHAR);

	#endif	// USE_TWO_ROW_DISPLAY


	// Output for four row display
	#if defined USE_FOUR_ROW_DISPLAY	||	defined		USE_THREE_ROW_DISPLAY

		// Output formatting for selection somewhere in between (sub)menu top and bottom
		if ( (selected >= (from + UPPER_SPACE)) && (selected <= (till - LOWER_SPACE)) )
    	{	from = selected - (UPPER_SPACE - 1);
			till = from + (DISPLAY_ROWS - 2);

	 		for (from; from<=till; from++)
	 		{	LCDWriteFromROM(0,line_cnt,menu[from].text);
	 	 	 	line_cnt++;
			}
	
			gotoxy(0, UPPER_SPACE);
			LCDWriteChar(SELECTION_CHAR);
		}

		// Output formatting for selection close to (sub)menu top and bottom 
		// (distance between selection and top/bottom defined as UPPER- and LOWER_SPACE)
		else
		{	// Top of (sub)menu
			if (selected < (from + UPPER_SPACE))
			{	from = selected;
				till = from + (DISPLAY_ROWS - 2);
	 			
				for (from; from<=till; from++)
	 			{	LCDWriteFromROM(0,line_cnt,menu[from].text);
	 	 	 		line_cnt++;
				}
	
				gotoxy(0, (UPPER_SPACE-1));
				LCDWriteChar(SELECTION_CHAR);
			}
		
			// Bottom of (sub)menu
			if (selected == till)
			{	from = till - (DISPLAY_ROWS - 2);
	
				for (from; from<=till; from++)
	 			{	LCDWriteFromROM(0,line_cnt,menu[from].text);
	 	 	 		line_cnt++;
				}
	
				gotoxy(0, (DISPLAY_ROWS - 1));
				LCDWriteChar(SELECTION_CHAR);
			}
		}

	#endif	// USE_FOUR_ROW_DISPLAY


	//--------------------------------------------------------------------
	// Header not always visible
	//--------------------------------------------------------------------
#else	// !defined USE_ALWAYS_VISIBLE_HEADER

	line_cnt = 0;							// Set line counter to zero since all rows will be written

	// Output formatting for selection somewhere in between (sub)menu top and bottom
	if ( (selected >= (from + UPPER_SPACE)) && (selected <= (till - LOWER_SPACE)) )
    {	from = selected - UPPER_SPACE;
		till = from + (DISPLAY_ROWS - 1);

 		for (from; from<=till; from++)
 		{	LCDWriteFromROM(0,line_cnt,menu[from].text);
 	 	 	line_cnt++;
		}
	
		gotoxy(0, UPPER_SPACE);
		LCDWriteChar(SELECTION_CHAR);
	}

	// Output formatting for selection close to (sub)menu top and bottom 
	// (distance between selection and top/bottom defined as UPPER- and LOWER_SPACE)
	else
	{	// Top of (sub)menu
		if (selected < (from + UPPER_SPACE))
		{	till = from + (DISPLAY_ROWS - 1);
 			
			for (from; from<=till; from++)
 			{	LCDWriteFromROM(0,line_cnt,menu[from].text);
 	 	 		line_cnt++;
			}

			gotoxy(0, (selected-temp));
			LCDWriteChar(SELECTION_CHAR);
		}
	
		// Bottom of (sub)menu
		if (selected == till)
		{	from = till - (DISPLAY_ROWS - 1);

			for (from; from<=till; from++)
 			{	LCDWriteFromROM(0,line_cnt,menu[from].text);
 	 	 		line_cnt++;
			}

			gotoxy(0, (DISPLAY_ROWS - 1));
			LCDWriteChar(SELECTION_CHAR);
		}
	}

#endif	// !defined USE_ALWAYS_VISIBLE_HEADER

}

// ***********************************************************************
// Browse menu function
// ***********************************************************************
void browse_menu(void)
{
	do
 	{	show_menu();
	
	 	if (UP_KEY)
	 	{selected = menu[selected].up;
	 	}

     	if (DOWN_KEY)
	 	{selected = menu[selected].down;
	 	}

	 	if (ENTER_KEY)
	 	{
	   	 if (menu[selected].fp != 0)
	  	 menu[selected].fp();

	  	 selected = menu[selected].enter;
	 	}

	 	DELAY_MS(50);

 	}while(!leave_menu);
}



// ***********************************************************************
// Add user functions & variables
// ***********************************************************************
