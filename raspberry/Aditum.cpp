#include <cstring>
#include <iostream>
#include <iomanip>
#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <string>
#include <unistd.h>
#include <ctime>
#include <time.h>
#include <vector>
#include <algorithm>
#include <iterator>
#include <cstdio>
#include <memory>
#include <stdexcept>
#include <ncurses.h>

using namespace std;

//Global Variables
const string hex_characters = "0123456789ABCDEF";	
static string data_template; 
static string detect_template;
			
//Function Prototypes
vector<string> 	dash_parser(string data_string, const string template_string);		//parses a string, returning a vector of all data found in the -- postions of the string template
vector<char>  	slave_read(string read_address);									//reads data from specified slave and returns data as a char vector
void			slave_write(string write_address, vector<string> slave_data);		//writes specified data to specified slave
string			exec_sys(const char* cmd); 											//executes a system command and returns the output to a string
void load_templates();																//loads the templates of system outputs to be used in parsing functions
string logostring();																//reads logo from file			

//read + parse database
	//find + parse slaves
	//service all slaves 1000 times
		//read + parse from slave
		//determine service action
			//write/nop
		//log activity

int main()
{
	load_templates();
	initscr();
	mvprintw(0,0, "%s", logostring().c_str());	
	/*MAIN LOOP+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
	while(1)
	{
		vector<string> slave_addresses = dash_parser(exec_sys("i2cdetect -y 1"), detect_template);
		mvprintw(10,0, "The following slaves where found:");
		for (int i = 0; i < slave_addresses.size(); i++)
		{
			printw("%s ", slave_addresses[i].c_str());
			refresh();
		}
		/*SERVICE LOOP++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
		for (int n_iterations = 0; n_iterations < 1000; n_iterations++)
		{
			mvprintw(12,0, "This is iteration number: \t\t%d", n_iterations);
			mvprintw(14,0, "%s", exec_sys("ls").c_str());
			refresh();
		}
		/*END SERVICE LOOP++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
	}
	/*END MAIN LOOP+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
	
	
	getch();
	endwin();
	
	return 0;
}

vector<string> 	dash_parser(string data_string, const string template_string)			//parses a string, returning a vector of all data found in the -- postions of the string template
{
	vector<string> 	data;
	int start_pos = 0;
	while( std::string::npos!=(start_pos=template_string.find("--", start_pos )))
	{
		string temp = data_string.substr(start_pos-1,2);
		if (temp != "--")
			data.push_back(temp);
		start_pos++;
	}
	return data;
}

string exec_sys(const char* cmd) 
{
    char buffer[128];
    std::string result = "";
    std::shared_ptr<FILE> pipe(popen(cmd, "r"), pclose);
    if (!pipe) throw std::runtime_error("popen() failed!");
    while (!feof(pipe.get())) {
        if (fgets(buffer, 128, pipe.get()) != NULL)
            result += buffer;
    }
    return result;
}

void load_templates()
{
	ifstream f_detect_template 	{ "detect_template.dat" };
	ifstream f_data_template 	{ "dump_template.dat" };
	string t_detect_template	{ istreambuf_iterator<char>(f_detect_template), istreambuf_iterator<char>() };
	string t_data_template 		{ istreambuf_iterator<char>(f_data_template), istreambuf_iterator<char>() }; 
	detect_template = t_detect_template;
	data_template = t_data_template;
	return;
}

string logostring()
{
	ifstream logo 	{ "logo.dat" };
	string s_logo	{ istreambuf_iterator<char>(logo), istreambuf_iterator<char>() };
	return "            _ _   \n   /\\      | (_)_               \n  /  \\   _ | |_| |_ _   _ ____  \n / /\\ \\ / || | |  _) | | |    \\ \n| |__| ( (_| | | |_| |_| | | | |\n|______|\\____|_|\\___)____|_|_|_|";
}




