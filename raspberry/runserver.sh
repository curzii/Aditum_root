#!/bin/bash
# Script to build and run Aditum server
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
echo " "
echo "---------------------------"
echo "This script runs the Aditum"
echo "server c++ executable."
echo "---------------------------"
echo "Initializing..."
echo "Changing directory..."
cd /home/pi/Aditum/
#cd /home/pi/ 
echo "Done."
echo "Building from source..."
make
echo "Done." 
echo "Executing..."
#nohup sudo ./Aditum_nogui.out &
sudo ./Aditum_nogui.out
echo "Done."
echo "End of script."
echo "---------------------------"
