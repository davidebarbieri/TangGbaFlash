# GBA Cartridge Dumper on Tang Nano 20K

A GBA Cartridge Flash tool that operates using a Tang Nano 20K FPGA alongside a Windows client built with WinForms.

The Tang Nano 20K connects directly to the GBA cartridge socket, while ROM data is transferred using the UART protocol (COM via USB). 
The WinForms client enumerates available COM ports, lets the user select the appropriate serial port (typically the only available one), 
and proceeds to display the cartridge header. It then provides an option to download and save the entire ROM to disk.

<p float="left">
  <img src="https://github.com/davidebarbieri/TangGbaFlash/blob/main/images/fpga.jpg?raw=true" alt="FPGA & Socket" width="500"/>
  <img src="https://github.com/davidebarbieri/TangGbaFlash/blob/main/images/client.png?raw=true" alt="Client" width="350"/>
</p>
