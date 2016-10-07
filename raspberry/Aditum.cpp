//C++ Headers
//#include <wiringSerial.h>
#include <wiringPiI2C.h>
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
//Custom headers
//#include "headers/parse.h"
//#include "headers/log.h"


using namespace std;

const string hex_characters = "0123456789ABCDEF";
				
			
//Functions
vector<string> 	parse_file(string file_name, string template_name);				//parses a file, returning a vector of all data found in the -- postions of the template file.
vector<char>  	slave_read(string read_address);								//reads data from specified slave and returns data as a char vector
void			slave_write(string write_address, vector<string> slave_data);	//writes specified data to specified slave
			


int main()
{
	//read + parse database
	//find + parse slaves
	//service all slaves 1000 times
		//read + parse from slave
		//determine service action
			//write/nop
		//log activity
		
	vector<string> slave_addresses = parse_file("detect.dat", "detect_template.dat");

		
	return 0;
}

vector<string> 	parse_file(string file_name, string template_name)				//parses a file, returning a vector of all data found in the -- postions of the template file.
{
	vector<string> 	data;
	vector<int>		positions;
	ifstream data_file 				{ file_name };
	ifstream template_file 			{ template_name };
	string data_file_contents 		{ istreambuf_iterator<char>(data_file), 	istreambuf_iterator<char>() };
	string template_file_contents 	{ istreambuf_iterator<char>(template_file), istreambuf_iterator<char>() };	
	int start_pos = 0;
	while( std::string::npos != ( start_pos = template_file_contents.find("--", start_pos ) ) )
	{
		if (!(data_file_contents.substr(start_pos,2) == "--"))
			data.push_back(data_file_contents.substr(start_pos,2));
		start_pos++;
	}
	return data;
}










