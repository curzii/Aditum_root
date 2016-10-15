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
#include <cstdio>
#include <memory>
#include <stdexcept>
#include <ncurses.h>

using namespace std;

//Global Variables
const string hex_characters = "0123456789ABCDEF";	
static string data_template; 
static string detect_template;
vector<vector<string>> database;
vector<string> logbuffer;
long long blocks_read, blocks_lost;
string logged_user = "";
			
//Function Prototypes
vector<string> 	dash_parser(string data_string, const string template_string);		//parses a string, returning a vector of all data found in the -- postions of the string template
vector<char>  	slave_read(string read_address);									//reads data from specified slave and returns data as a char vector
void 			slave_write(string write_address, vector<char> slave_data);			//writes specified data to specified slave
string			exec_sys(const char* cmd); 											//executes a system command and returns the output to a string
void load_templates();																//loads the templates of system outputs to be used in parsing functions
string logostring();																//reads logo from file			
string timestamp();																	//returns current time as a timestamp string
vector<vector<string>> database_read();												//reads all credentials entries from database
bool authenticate_slave(vector<char> data);											//authenticates slave in database
int checksum(vector<char> data);													//calculate checksum
void write_log(vector<string> log);

//read + parse database
	//find + parse slaves
	//service all slaves 1000 times
		//read + parse from slave
		//determine service action
			//write/nop
		//log activity

int main()
{
	load_templates();			//*IMPORTANT - loads spefic file templates used in the parsing of system responses.
	initscr();					//initiates ncurses window
	curs_set(0);				//hides console cursor
	blocks_read = 0;
	blocks_lost = 0;
	
	/*MAIN LOOP+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
	while(1)
	{
		database = database_read();	//load the credentials database
		vector<string> slave_addresses = dash_parser(exec_sys("i2cdetect -y 1"), detect_template);	//find all slaves connected to master
		mvprintw(0,0, "%s", logostring().c_str());	//print an insanely slick banner
		if (slave_addresses.empty())
		{
			mvprintw(10,0, "No devices are connected.");
			refresh();
		}
		else
		{
			mvprintw(10,0, "The following slaves where found:\n");
			for (int i = 0; i < slave_addresses.size(); i++)
			{
				printw("%s ", slave_addresses[i].c_str());
				refresh();
			}
			/*SERVICE LOOP++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
			for (int n_iterations = 0; n_iterations < 1000; n_iterations++)
			{
				vector<char> write_data;
				if ((n_iterations%100) == 0)
				{
					mvprintw(7,0, "%s", timestamp().c_str());	//print the current time every 100 iterations
					write_log(logbuffer);						//write and clear the log buffers every 100 iterations
					logbuffer.clear();
					refresh();									//refresh display every 100 iterations
				}
				for (int i = 0; i < slave_addresses.size(); i++)
				{
					mvprintw(13,0, "This is iteration number:  [%d]\t", n_iterations);
					mvprintw(14,0, "Current device:            [%s]\t", slave_addresses[i].c_str());
					refresh();
					logged_user = "";
					write_data.clear();
					if (authenticate_slave(slave_read(slave_addresses[i]))) //read 32 bytes from slave and authenticate with database
					{
						write_data.push_back(static_cast<char>(0xA1));	//A1, means authentications succeeded.
						for (int p = 0; ((p < logged_user.length())&&(p < 16)); p++)
							write_data.push_back(logged_user[p]);
						while(write_data.size() != 32)
							write_data.push_back(' ');
						slave_write(slave_addresses[i], write_data);
					}
					else
					{
						write_data.push_back(static_cast<char>(0xA0));	//A0, means authentications failed.
						while(write_data.size() != 32)
							write_data.push_back(' ');
						slave_write(slave_addresses[i], write_data);
					}
				}
			}
		}
		/*END SERVICE LOOP++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
		clear();	//clear ncurses display
	}
	/*END MAIN LOOP+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
	getch();
	endwin();
	return 0;
}

vector<char> slave_read(string read_address)											//reads data from specified slave and returns data as a char vector
{
	vector<char> data;
	int devID = 16*hex_characters.find(toupper(read_address[0]))+hex_characters.find(toupper(read_address[1]));
	mvprintw(19,0, "Service ID (string):       %s", read_address.c_str());
	mvprintw(20,0, "Service ID (int):          %d", devID);
	refresh();
	try 
	{ 
		int fd = wiringPiI2CSetup(devID);	//select i2c device
		for (int i = 0; i < 32; i++)		//read 32 bytes form slave
		{
			char c_data = wiringPiI2CReadReg8(fd, i); 	//read byte from specified address
			data.push_back(c_data);						//add data to vector
			if (data[0] == '-' )					 	//if first value is - assume the device does not need ot be serviced
			{
				for (int e = 1; e < 32; e++)
					data.push_back('-');
				//data.push_back(checksum(data));
				break;
			}	
		} 
		close(fd); //Close File descriptors to fix too many open files error
	} 
	catch (...) { ; }
	return data;
}

void slave_write(string write_address, vector<char> slave_data)								//writes specified data to specified slave
{
	int devID = 16*hex_characters.find(toupper(write_address[0]))+hex_characters.find(toupper(write_address[1]));	//convert string to int for wiringPi
	//int chk = checksum(slave_data);
	try 
	{ 
		int fd = wiringPiI2CSetup(devID);				//select i2c device
		for (int i = 0; ((i < slave_data.size())&&(i < 32)); i++)		//write vector to slave
		{
			int w = wiringPiI2CWriteReg8(fd, i, static_cast<int>(slave_data[i]));	//write byte to specified address
		} 
		close(fd); //Close File descriptors to fix too many open files error
	} 
	catch (...) { ; }
	return;
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
    while (!feof(pipe.get()))
        if (fgets(buffer, 128, pipe.get()) != NULL)
            result += buffer;
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

string timestamp()
{
	time_t rawtime;
	struct tm * timeinfo;
	time ( &rawtime );
	timeinfo = localtime ( &rawtime );
	string t_stamp = static_cast<string>(asctime(timeinfo));
	return t_stamp;
}

vector<vector<string>> database_read()
{
	vector<string> row;
	vector<vector<string>> data;
	std::string::size_type x,y,z = 0;					//variable used for finding all the "," occurences		
	std::ifstream file("database.csv");					//open database file
    std::string raw; 
    while (std::getline(file, raw))
    {
		string id, pin, name;
        x = raw.find(",");
		id = raw.substr(0, x);								//Student Number
		y = raw.find(",", x + 1);
		pin = raw.substr(x + 1, raw.find(",", y) - x - 1);	//Password
		z = raw.find(",", y + 1);
		name = raw.substr(y + 1, raw.length() - y - 1);		//Surname and Initials
		int l = id.length();
		for (int u = 0; u < (9 - l); u++)					//Add leading zeros
			id.insert(0, "0");
		l = pin.length();
		for (int u = 0; u < (9 - l); u++)					//Add leading zeros
			pin.insert(0, "0");
		row.push_back(id);
		row.push_back(pin);
		row.push_back(name);
		data.push_back(row);
		row.clear();
	}
	file.close();
	return data;
}

bool authenticate_slave(vector<char> data)											//authenticates slave in database
{
	if (data[0] == '-')	//empty block
		return false;
	bool result = false;
	char buffer[200];
	string id = "?????????", pin = "?????????", name;
	for (int i = 0; i < 9; i++)
	{
		id[i] = data[i];
		pin[i] = data[9+i];
	}
	bool foundid = false, foundpin = false;
	for (int i = 0; i < database.size(); i++)	//find id in database
			if (id == database[i][0])
			{
				foundid = true;
				name = database[i][2];
				if (pin == database[i][1])		//find pin in database matching id
					foundpin = true;
				break;
			}
	/*for (int i = 0; i < database.size(); i++) 	
			if (pin == database[i][1])
			{
				foundpin = true;			
				break;
			}*/
	int chk = checksum(data);
	bool checksum_good = false;
	if (chk == (int)data[31])
		checksum_good = true;
	if ((checksum_good)&&(foundid)&&(foundpin))	//verify data integrity as well as credentials
	{
		int trash = sprintf(buffer, "[   LOGIN    ] - [    %s    |    %s    |    %-16s    ] ---> %s", id.c_str(), pin.c_str(), name.c_str(), timestamp().c_str());
		logbuffer.push_back(buffer);
		logged_user = name;
		result = true;	
	}	
	else if (!checksum_good)
	{
		result = false;	//Do nothing, corrupted packet.
	}
	else if ((checksum_good)&&(!foundid))
	{
		int trash = sprintf(buffer, "[UNREGISTERED] - [    %s    |    %s    |    UNREGISTERED        ] ---> %s", id.c_str(), pin.c_str(), timestamp().c_str());
		logbuffer.push_back(buffer);
	}
	else if ((checksum_good)&&(foundid)&&(!foundpin))
	{
		int trash = sprintf(buffer, "[ WRONG  PIN ] - [    %s    |    %s    |    %-16s    ] ---> %s", id.c_str(), pin.c_str(), name.c_str(), timestamp().c_str());
		logbuffer.push_back(buffer);
	}
	mvprintw(21,0, "Data stream:");
	for (int i = 0; i < 32; i++)
		mvprintw(22,i, "%c", data[i]);
	mvprintw(23,0, "Received Checksum: %d", (int)data[31]);
	mvprintw(24,0, "Actual Checksum:   %d", chk);
	mvprintw(25,0, "Username:          %s", id.c_str());
	mvprintw(26,0, "Pin                %s", pin.c_str());
	mvprintw(27,0, "Authenticated:     %d", result);
	if (result)
		mvprintw(28,0, "%s has been authenticated.", name.c_str());
	refresh();
	return result;
}

int checksum(vector<char> data)
{
	/*CHECKSUM ALGORITHM*/
	int chk = 0;
	for (int i = 0; i < 31; i++)
	{
		chk += (int)data[i];
	}
	chk /= 32;
	/*END CHECKSUM ALGORITHM*/
	return chk;
}

void write_log(vector<string> log)
{
	ofstream file("log.txt", ios_base::out | ios_base::app );
	for (int i = 0; i < log.size(); i++)
		file << log[i];
	return;
}
