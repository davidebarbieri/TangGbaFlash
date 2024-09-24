# GBA Cartridge Dumper on Tang Nano 20K

A GBA Cartridge Flash tool that operates using a Tang Nano 20K FPGA alongside a Windows client built with WinForms.

The Tang Nano 20K connects directly to the GBA cartridge socket, while ROM data is transferred using the UART protocol (COM via USB). 
The WinForms client enumerates available COM ports, lets the user select the appropriate serial port (typically the only available one), 
and proceeds to display the cartridge header. It then provides an option to download and save the entire ROM to disk.

<p float="left">
  <img src="https://github.com/davidebarbieri/TangGbaFlash/blob/main/images/fpga.jpg?raw=true" alt="FPGA & Socket" width="400"/>
  <img src="https://github.com/davidebarbieri/TangGbaFlash/blob/main/images/client.png?raw=true" alt="Client" width="280"/>
</p>

## GPIO Connections


| GBAPak   | GPIO PIN |
| -------- | -------- |
| A23      | 86       |
| A22      | 79       |
| A21      | 72       |
| A20      | 71       |
| A19      | 53       |
| A18      | 52       |
| A17      | 73       |
| A16      | 74       |
| A/D15    | 75       |
| A/D14    | 85       |
| A/D13    | 77       |
| A/D12    | 15       |
| A/D11    | 16       |
| A/D10    | 27       |
| A/D9     | 28       |
| A/D8     | 25       |
| A/D7     | 26       |
| A/D6     | 29       |
| A/D5     | 30       |
| A/D4     | 31       |
| A/D3     | 17       |
| A/D2     | 20       |
| A/D1     | 19       |
| A/D0     | 18       |
| WR       | 51       |
| RD       | 48       |
| CS       | 55       |
| CS2      | 49       |
