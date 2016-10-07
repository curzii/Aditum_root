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
const string detect_template[] = {	"     0  1  2  3  4  5  6  7  8  9  a  b  c  d  e  f",
									"00:          -- -- -- -- -- -- -- -- -- -- -- -- --",
									"10: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --",
									"20: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --",
									"30: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --",
									"40: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --",
									"50: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --",
									"60: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --",
									"70: -- -- -- -- -- -- -- --"};
									
const string dump_template[] = {	"     0  1  2  3  4  5  6  7  8  9  a  b  c  d  e  f    0123456789abcdef",
									"00: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    0000000000000000",
									"10: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    000.............",
									"20: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    0000000000000000",
									"30: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    000.............",
									"40: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    0000000000000000",
									"50: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    000.............",
									"60: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    0000000000000000",
									"70: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    000.............",
									"80: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    0000000000000000",
									"90: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    000.............",
									"a0: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    0000000000000000",
									"b0: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    000.............",
									"c0: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    0000000000000000",
									"d0: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    000.............",
									"e0: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    0000000000000000",
									"f0: -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --    000............."};

vector<string> slaves;

static int slave_r_reg[32] = {0}; 
const int MAX_SLAVES = 100; 

int find_slaves (string slaves[]);
void service_slave(string slave);
void slave_read(char slave_data_read[32], string slave_id);
void slave_write(char slave_data_write[32], string slave_id);
void database_read(string database[][3], string database_raw[], int n_database);


int main()
{
	long long n_iterations = 0;
	bool exit_loop = false;
	string slaves[];
	
	ifstream fin;
	fin.open("database.csv"); 						// open a file
	string  database_raw[100000];						// string array containing entire file	
	int n_lines = 0;
	while (getline(fin, database_raw[n_lines]))				// read entire file into memory
	{
		n_lines++;
	}
	string database[n_lines][3];
	fin.close();
	
	int n_slaves = find_slaves(slaves);
	database_read(database, database_raw, n_lines);
	
	cout << "\n\n[info]\t\t[Starting Aditum.]";
	cout << "\n[info]\t\t[Aditum is running]\n\n";
	while (!exit_loop)
	{
		n_iterations++;	
		//cout << "\n[operation]\t[Scanning For Slaves]";		
		if (n_slaves != 0)
		{
			//cout << "\n[info]\t\t[Performing Service Routine\t|\tIteration number\t"<< n_iterations <<"]\n";
			for (int i = 0; i < n_slaves; i++)				//service all slaves found in the slaves array
			{
				service_slave(slaves[i]);
			}
		}
		else
			;//cout << "\n[info]\t\t[No slaves connected.\t|\tSystem Idle.]\n";
	}
	cout << "\n\n[info]\t\t[Exiting Aditum]\n";
	return 0;
}




void service_slave(string slave)
{
	//+++++++++++++++++++++++++++++++
	//read device
	//+++++++++++++++++++++++++++++++
	string cmd = "i2cdump -y 1 0x"+slave+" i > dump.dat";
	system(cmd.c_str());								// dump data to a file in running directory UNCOMMENT THIS ON PI
	ifstream fin;										// create a file-reading object
	fin.open("dump.dat"); 								// open a file
	if (!fin.good()) 
		return; 										// exit if file not found (should never happen)
	string  dump[1000];									// string array containing entire file	
	int  n_lines = 0, s = 0;
	while (getline(fin, dump[n_lines]))					// read entire file into memory to get amount of lines
	{
		n_lines++;
	}
	int dump_positions[n_lines][MAX_SLAVES];			// array of all data positions in dump string array
	int p[n_lines+1] = {0};								// array of the amount of occurences of "--" in each dump string array element
	std::string::size_type start_pos = 0;				// variable used for finding all the "--" occurences		
	for (int k = 0; k < n_lines; k++)					// find all the positions of "--" in the dump_template array elements and put them in the p[] array of positions
	{
		start_pos = 0;
		while( std::string::npos != ( start_pos = dump_template[k].find("--", start_pos ) ) )
		{
			dump_positions[k][p[k]] = start_pos;
			p[k]++;
			++start_pos;
		}
	}
	string slave_data[500];
	int n_data = 0;										// number of datas
	for (int a = 0; a < n_lines; a++)					// seperate the "--" from actual dataesses
	{
		for (int b = 0; b < p[a]; b++)
		{
			string temp = dump[a].substr(dump_positions[a][b], 2);
			if (temp != "--")
			{
				slave_data[n_data] = temp;		
				n_data++;		
			}				
		}
	}
	char slave_chars[n_data];
	for (int i = 0; i < n_data; i++)					//converts the string dump array to an array of chars
	{
		slave_chars[i] =  static_cast<char>(16*hex_characters.find(toupper(slave_data[i][0]))+hex_characters.find(toupper(slave_data[i][1])));
	}
	fin.close();
	//If the entire read data array is empty dont do anything further.
	bool empty_device = true;
	for (int i = 0; i < n_data; i++)
		if (slave_chars[i] != '0')
			empty_device = false;
	if (empty_device)
		return;

	//+++++++++++++++++++++++++++++++
	//read database
	//+++++++++++++++++++++++++++++++
	fin.open("database.csv"); 							// open a file
	if (!fin.good()) 
		return; 										// exit if file not found (should never happen)
	string  database_raw[100000];						// string array containing entire file	
	n_lines = 0;
	while (getline(fin, database_raw[n_lines]))			// read entire file into memory
	{
		n_lines++;
	}
	string database[n_lines][3];
	std::string::size_type x,y,z = 0;					// variable used for finding all the "," occurences		
	for (int k = 0; k < n_lines; k++)					// parse csv file into array
	{
		x = database_raw[k].find(",");
		database[k][0] = database_raw[k].substr(0, x);
		y = database_raw[k].find(",", x + 1);
		database[k][1] = database_raw[k].substr(x + 1, database_raw[k].find(",", y) - x - 1);
		z = database_raw[k].find(",", y + 1);
		database[k][2] = database_raw[k].substr(y + 1, database_raw[k].length() - y - 1);
	}
	//the csv parsed array needs have elements  each element i's [0] and [1] at a length 9 with leading zero chars.
	for (int i = 0; i < n_lines; i++)
	{
		for (int r = 0; r < 2; r++)
		{
			int l = database[i][r].length();
			for (int u = 0; u < (9 - l); u++)
				database[i][r].insert(0, "0");
		}
	}
	
	//+++++++++++++++++++++++++++++++
	//search device data in database
	//+++++++++++++++++++++++++++++++
	string read_id = "", read_pin = "", read_username = "";
	bool found_id = true, found_pin = true;
	for (int a = 0; a < n_lines; a++)
	{
		read_id = "";
		read_pin = "";
		read_username = database[a][2];
		found_id = true;
		found_pin = true;
		for (int b = 0; b < 9; b++)
		{
			read_id += slave_chars[b];
			if (!(database[a][0][b] == slave_chars[b]))
				found_id = false;
		}
		if (found_id)
		{
			for (int c = 0; c < 9; c++)
			{
				{
					read_pin += slave_chars[9+c];
					if (!(database[a][1][c] == slave_chars[9+c]))
						found_pin = false;
				}
			}
		}
		if (found_id&&found_pin)
		{
			cmd = "i2cset -y 1 0x"+slave+" 0x00 0xA1 > debug.txt";
			system(cmd.c_str());
			break;
		}
	}
	
	time_t rawtime;
	struct tm * timeinfo;
	time ( &rawtime );
	timeinfo = localtime ( &rawtime );
	string timestamp = static_cast<string>(asctime(timeinfo));
	ofstream log_file("log.txt", ios_base::out | ios_base::app );
	if (found_id&&found_pin)
		log_file<<left<<setw(10)<<"[login]"	<<setw(30)<<"[OK]"					<<setw(2)<<"[ " <<setw(10)<<read_id	<<setw(3)<<" | "<<setw(15)<<read_username	<<setw(6)<<" ]"<<setw(27)<< timestamp;
	else
	{
		cmd = "i2cset -y 1 0x"+slave+" 0x00 0xA0 > debug.txt";
		system(cmd.c_str());
	}
	if (!found_id)
	{
		log_file<<left<<setw(10)<<"[login]"	<<setw(30)<<"[ID not in database]"	<<setw(2)<<"[ " <<setw(10)<<read_id <<setw(3)<<" | "<<setw(15)<<"unregistered"	<<setw(6)<<" ]"<<setw(27)<< timestamp;
	}
	if (!found_pin)
	{
		log_file<<left<<setw(10)<<"[login]"	<<setw(30)<<"[PIN not in database]"	<<setw(2)<<"[ " <<setw(10)<<read_id	<<setw(3)<<" | "<<setw(15)<<read_username	<<setw(6)<<" ]"<<setw(27)<< timestamp;
	}
	log_file.close();
	fin.close();
	return;
}


void slave_read(char slave_data_read[32], string slave_id)
{
	int devID = 16*hex_characters.find(toupper(slave_id[0]))+hex_characters.find(toupper(slave_id[1]));
    int fd = wiringPiI2CSetup(devID);
	for (int i =0; i < 32; i++)
			slave_data_read[i] = wiringPiI2CRead(fd);
	return;
}
void slave_write(char slave_data_write[32], string slave_id)
{
    return;
}

int find_slaves (string slaves[])
{
	string slave_addr[MAX_SLAVES];
	system("i2cdetect -y 1 > detect.dat");				// dump all addresses to a file in running directory UNCOMMENT THIS ON PI
	ifstream fin;										// create a file-reading object
	fin.open("detect.dat"); 							// open a file
	if (!fin.good()) 
		return 0; 										// exit if file not found (should never happen)
	string  detect[1000];								// string array containing entire file	
	int  n_lines = 0, s = 0;
	while (getline(fin, detect[n_lines]))				// read entire file into memory
	{
		n_lines++;
	}
	int detect_positions[n_lines][MAX_SLAVES];			// array of all address positions in detect string array
	int p[n_lines] = {0};								// array of the amount of occurences of "--" in each detect string array element
	std::string::size_type start_pos = 0;				// variable used for finding all the "--" occurences		
	for (int k = 0; k < n_lines; k++)					// find all the positions of "--" in the detect_template array elements and put them in the p[] array of positions
	{
		start_pos = 0;
		while( std::string::npos != ( start_pos = detect_template[k].find("--", start_pos ) ) )
		{
			detect_positions[k][p[k]] = start_pos;
			p[k]++;
			++start_pos;
		}
	}
	int n_addr = 0;										// number of addresses
	for (int a = 0; a < n_lines; a++)					// seperate the "--" from actual addresses
	{
		for (int b = 0; b < p[a]; b++)
		{
			string temp = detect[a].substr(detect_positions[a][b], 2);
			if (temp != "--")
			{
				slave_addr[n_addr] = temp;		
				n_addr++;		
			}				
		}
	}
	fin.close();
	int number_slaves = 0;								// find the amount of actual addresses
	for (int w = 0; w < (sizeof(slave_addr)/sizeof(slave_addr[0])); w++)
		if (slave_addr[w] != "")
			number_slaves++;
	slaves[number_slaves];					// array containing slave address for direct system command line injection 
	for (int i = 0; i < number_slaves; i++)				// load all actual addresses into slaves array
	{
		slaves[i] = slave_addr[i];
	}
	return number_slaves;
}

void database_read(string database[][3], string database_raw[], int n_database)
{
	std::string::size_type x,y,z = 0;					// variable used for finding all the "," occurences		
	for (int k = 0; k < n_database; k++)					// parse csv file into array
	{
		x = database_raw[k].find(",");
		database[k][0] = database_raw[k].substr(0, x);
		y = database_raw[k].find(",", x + 1);
		database[k][1] = database_raw[k].substr(x + 1, database_raw[k].find(",", y) - x - 1);
		z = database_raw[k].find(",", y + 1);
		database[k][2] = database_raw[k].substr(y + 1, database_raw[k].length() - y - 1);
	}
	//the csv parsed array needs have elements  each element i's [0] and [1] at a length 9 with leading zero chars.
	for (int i = 0; i < n_database; i++)
	{
		for (int r = 0; r < 2; r++)
		{
			int l = database[i][r].length();
			for (int u = 0; u < (9 - l); u++)
				database[i][r].insert(0, "0");
		}
	}
	return;
}























