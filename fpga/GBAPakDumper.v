// (c) Copyright 2023 Davide Barbieri (a.k.a. 'PeevishDave') 

`default_nettype none

module GBAPakDumper
(
    input wire pin_clk,
    input wire pin_uart_rx,
    output wire pin_uart_tx,

    output reg pin_gbaRD,
    output reg pin_gbaWR,
    output reg pin_gbaCS,
    output reg pin_gbaCS2,
    inout wire [15:0] pin_gbaDataAddressLo,
    output wire [7:0] pin_gbaAddressHi
);
    reg meta_uart_rx = 1'b1;
    reg uart_rx = 1'b1;

    wire uart_byteReady;
    wire [7:0] uart_DataIn;
    wire [7:0] uart_DataOut;
    wire uart_sendData;
    wire uart_sendReady;

    // sub-modules
    // WAIT_CYCLES 100 --> 270,000 baud rate
    uart_recv #(.WAIT_CYCLES(100)) u_rx (pin_clk, uart_rx, uart_DataIn, uart_byteReady);
    uart_send #(.WAIT_CYCLES(100)) u_tx (pin_clk, pin_uart_tx, uart_DataOut, uart_sendData, uart_sendReady);
    GBAPakReader pakReader (pin_clk, pak_startAddress, pak_endAddress, pak_startDump, pak_dumpCompleted, uart_DataOut, uart_sendData, uart_sendReady, 
        meta_gbaRD, meta_gbaWR, meta_gbaCS, meta_gbaCS2, pin_gbaDataAddressLo, pin_gbaAddressHi);

    wire [7:0] queue_DataIn;
    wire [7:0] queue_DataOut;
    wire queue_PushData;
    reg queue_PopData;
    wire queue_HasData;
    wire queue_IsFull;

    reg [23:0] pak_startAddress = 0;
    reg [23:0] pak_endAddress = 0;
    reg pak_startDump;
    wire pak_dumpCompleted;

    wire meta_gbaRD;
    wire meta_gbaWR;
    wire meta_gbaCS;
    wire meta_gbaCS2;

    always @(posedge pin_clk) 
    begin

        pin_gbaRD <= meta_gbaRD;
        pin_gbaWR <= meta_gbaWR;
        pin_gbaCS <= meta_gbaCS;
        pin_gbaCS2 <= meta_gbaCS2;

        // Stable UART
        meta_uart_rx <= pin_uart_rx;
        uart_rx <= meta_uart_rx;

        if (~pak_startDump && uart_byteReady)
        begin
            case (uart_DataIn)
                8'd97: begin  // 'a' --> dump cartridge 4MB
                    pak_startAddress <= 0;
                    pak_endAddress <= 2097151;
                    pak_startDump <= 1;
                end
                8'd98: begin  // 'b' --> dump cartridge 8MB
                    pak_startAddress <= 0;
                    pak_endAddress <= 4194303;
                    pak_startDump <= 1;
                end
                8'd99: begin  // 'c' --> dump cartridge 16MB
                    pak_startAddress <= 0;
                    pak_endAddress <= 8388607;
                    pak_startDump <= 1;
                end
                8'd100: begin  // 'd' --> dump cartridge 32MB
                    pak_startAddress <= 0;
                    pak_endAddress <= 16777215;
                    pak_startDump <= 1;
                end
                8'd104: begin  // 'h' --> just dump header
                    pak_startAddress <= 0;
                    pak_endAddress <= 95;
                    pak_startDump <= 1;
                end
                8'd106: begin  // 'j' --> dump duplicate header for 4MB cartridges
                    pak_startAddress <= 2097151;
                    pak_endAddress <= 2097247;
                    pak_startDump <= 1;
                end
                8'd107: begin  // 'k' --> dump duplicate header for 8MB cartridges
                    pak_startAddress <= 4194303;
                    pak_endAddress <= 4194399;
                    pak_startDump <= 1;
                end
                8'd108: begin  // 'l' --> dump duplicate header for 16MB cartridges
                    pak_startAddress <= 8388607;
                    pak_endAddress <= 8388703;
                    pak_startDump <= 1;
                end
                default: begin
                    pak_startDump <= 0;
                end
            endcase
        end
        else
        begin
            pak_startDump <= 0;
        end
    end

endmodule