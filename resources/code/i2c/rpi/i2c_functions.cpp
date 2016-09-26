#include <wiringSerial.h>
#include <wiringPiI2C.h>
#include <iostream>
#include <stdlib.h>
#include <iomanip>

char i2c_read(char slave_address, char master_command, int &fd)
{
	fd = wiringPiI2CSetup(slave_address);
	int w  = wiringPiI2CWrite(fd, master_command);
	int r  = wiringPiI2CRead(fd);
	char c = r;
	return c;
}

void i2c_write(char slave_address, char master_command, int &fd)
{
	fd = wiringPiI2CSetup(slave_address);
	int w = wirinPiI2CWrite(fd, master_command);
	return;
}

void i2c_block_read(char slave_address, char block[])
{
	fd = wiringPiI2CSetup(slave_address);
	int w = wirinPiI2CWrite(fd, 50);
	int r = 0;
	for (int i = 0; i < 32; i++)
	{
		w = wiringPiI2CWrite(fd, i);
		r = wiringPiI2CRead(fd);
		block[i] = r;
	}
	
}