// (c) Copyright 2023 Davide Barbieri (a.k.a. 'PeevishDave')
// Low-Resource (18 LUTs / 12 REGs on Tang9K) UART Send Module
// 2,700,000 Baud rate, 1 stop cycle, no parity

`default_nettype none

module uart_send
#(
     // 27,000,000 (27Mhz) : 10 --> 2,700,000 Baud rate (270 KB/s)
    parameter WAIT_CYCLES = 10
)
(
    input wire clk,
    output wire uart_tx,
    input wire [7:0] data,
    input wire transmitByte,
    output wire ready
);
    localparam WAIT_CYCLES_MSB = $clog2(WAIT_CYCLES + 1) - 1;

    reg [WAIT_CYCLES_MSB:0] delayCounter = 0;
    reg [3:0] sndState = STATE_READY;
    reg [7:0] dataBuffer = 0;

    reg uart_tx_value = 1;

    assign uart_tx = uart_tx_value;
    assign ready = sndState == STATE_READY;

    localparam STATE_READY      = 4'b1001;
    localparam STATE_IDLE       = 4'b1010;
    localparam STATE_START_BIT  = 4'b1111;
    localparam STATE_WRITE      = 4'b0000; // 0000 to 0111 it's sending bits
    localparam STATE_STOP_BIT   = 4'b1000;

    always @(posedge clk) 
    begin
        delayCounter <= delayCounter + 1;

        case (sndState)
            STATE_READY: begin
                uart_tx_value <= 1;
                sndState <= sndState + 1;
            end
            STATE_IDLE: begin
                uart_tx_value <= 1;
                if (transmitByte) begin
                    delayCounter <= 1;
                    dataBuffer <= data;
                    sndState <= STATE_START_BIT;
                end
                else
                    sndState <= STATE_READY;
            end 
            STATE_START_BIT: begin
                uart_tx_value <= 0;
                if (delayCounter == WAIT_CYCLES) begin
                    delayCounter <= 1;
                    sndState <= sndState + 1;
                end
            end
            default: begin
                uart_tx_value <= dataBuffer[sndState[2:0]];
                if (delayCounter == WAIT_CYCLES) begin
                    delayCounter <= 1;
                    sndState <= sndState + 1;
                end
            end
            STATE_STOP_BIT: begin
                uart_tx_value <= 1;
                if (delayCounter == WAIT_CYCLES) begin
                    delayCounter <= 1;
                    sndState <= sndState + 1;
                end
            end
        endcase
    end
endmodule