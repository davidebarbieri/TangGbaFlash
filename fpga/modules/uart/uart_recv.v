// (c) Copyright 2023 Davide Barbieri (a.k.a. 'PeevishDave')
// Low-Resource (13 LUTs / 16 REGs on Tang9K) UART Receive Module
// 2,700,000 Baud rate, 1 stop cycle, no parity

`default_nettype none

module uart_recv
#(
    // 27Mhz : 10 cycles
    // 2,700,000 Baud rate (270 actual KB/s)
    parameter WAIT_CYCLES = 10
)
(
    input wire clk,
    input wire uartRx,
    output reg [7:0] data,
    output wire dataReceived
);

    localparam STATE_IDLE  = 4'b1001;
    localparam STATE_START = 4'b1111;
    localparam STATE_DATA  = 4'b1000;
    // State receiving bit = 0000 to 0111

    localparam HALF_WAIT_CYCLES = WAIT_CYCLES / 2;
    localparam WAIT_CYCLES_MSB = $clog2(WAIT_CYCLES + 1) - 1;
    reg [WAIT_CYCLES_MSB:0] waitCounter = 0;

    reg [3:0] rcvState = STATE_IDLE;

    assign dataReceived = rcvState[3] && ~rcvState[0] && (waitCounter == 1);

    always @(posedge clk) 
    begin
        if (waitCounter != WAIT_CYCLES)
        begin
            // locked
            waitCounter <= waitCounter + 1;
        end else
        begin
            if (rcvState[3] & ~rcvState[2]) // IDLE OR DATA
            begin
                // Wait for incoming data
                if (uartRx == 0)
                begin
                    waitCounter <= HALF_WAIT_CYCLES;
                    rcvState <= STATE_START;
                end
            end
            else
            begin                    
                waitCounter <= 1;
                rcvState <= rcvState + 1;
                
                if (rcvState[3] == 0)
                    data <= {uartRx, data[7:1]}; // Read bit
            end
        end
    end
endmodule