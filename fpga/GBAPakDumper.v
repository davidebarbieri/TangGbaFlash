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
    //output wire pin_gbaClk,
    //output wire pin_gbaIRQ,
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
    GBAPakReader pakReader (pin_clk, pak_cartridgeSize, pak_startDump, pak_dumpCompleted, uart_DataOut, uart_sendData, uart_sendReady, 
        meta_gbaRD, meta_gbaWR, meta_gbaCS, meta_gbaCS2, pin_gbaDataAddressLo, pin_gbaAddressHi);

    wire [7:0] queue_DataIn;
    wire [7:0] queue_DataOut;
    wire queue_PushData;
    reg queue_PopData;
    wire queue_HasData;
    wire queue_IsFull;

    reg [3:0] pak_cartridgeSize = 4'b0;
    reg pak_startDump;
    wire pak_dumpCompleted;

    wire meta_gbaRD;
    wire meta_gbaWR;
    wire meta_gbaCS;
    wire meta_gbaCS2;

    //assign pin_gbaIRQ = 0;
    //assign pin_gbaClk = 0;

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
                    pak_cartridgeSize <= 4'b0001;
                    pak_startDump <= 1;
                end
                8'd98: begin  // 'b' --> dump cartridge 8MB
                    pak_cartridgeSize <= 4'b0010;
                    pak_startDump <= 1;
                end
                8'd99: begin  // 'c' --> dump cartridge 16MB
                    pak_cartridgeSize <= 4'b0100;
                    pak_startDump <= 1;
                end
                8'd100: begin  // 'd' --> dump cartridge 32MB
                    pak_cartridgeSize <= 4'b1000;
                    pak_startDump <= 1;
                end
                8'd104: begin  // 'h' --> just dump header
                    pak_cartridgeSize <= 4'b0;
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