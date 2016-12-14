all:
	@echo This makefile builds the gui and nogui versions of the Aditum server.;
	@echo To run the gui version: make run;
	@echo To run the nogui version: make run GUI=_nogui;
Aditum.out: Aditum.cpp
	g++ -std=c++11 -o3 Aditum.cpp -o Aditum.out -lwiringPi -lncurses
Aditum_nogui.out: Aditum_nogui.cpp
	g++ -std=c++11 -o3 Aditum_nogui.cpp -o Aditum_nogui.out -lwiringPi
run: Aditum${GUI}.out
	./Aditum${GUI}.out
