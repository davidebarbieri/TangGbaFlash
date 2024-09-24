// (c) Copyright 2023 Davide Barbieri (a.k.a. 'PeevishDave')

`default_nettype none

module GBAPakReader
(
    input wire clk,
    input wire [3:0] cartridgeSize,
    input wire startDump,
    output wire dumpCompleted,

    output reg [7:0] output_Data,
    output reg output_Send,
    input wire output_IsReady,

    output wire pin_gbaRD,
    output wire pin_gbaWR,
    output wire pin_gbaCS,
    output wire pin_gbaCS2,
    inout wire [15:0] pin_gbaDataAddressLo,
    output wire [7:0] pin_gbaAddressHi
);

    localparam STATE_IDLE               = 0;
    localparam STATE_ENABLE_ADDRESS     = 1 + STATE_IDLE;
    localparam STATE_SET_ADDRESS        = 1 + STATE_ENABLE_ADDRESS;
    localparam STATE_SEND_ADDRESS       = 10 + STATE_SET_ADDRESS;
    localparam STATE_DISABLE_ADDRESS    = 10 + STATE_SEND_ADDRESS;
    localparam STATE_FETCH_DATA         = 1 + STATE_DISABLE_ADDRESS;
    localparam STATE_READ_DATA          = 12 + STATE_FETCH_DATA;
    localparam STATE_READ_DATA_0        = 1 + STATE_READ_DATA;
    localparam STATE_READ_DATA_1        = 1 + STATE_READ_DATA_0;
    localparam STATE_ADDRESS_INCREMENT  = 1 + STATE_READ_DATA_1;
    
    localparam STATE_MSB = $clog2(STATE_ADDRESS_INCREMENT + 1) - 1;
    reg [STATE_MSB:0] state = STATE_IDLE;

    reg rd_value = 1;
    reg cs_value = 1;

    reg [15:0] gbaDAOutput = 0;
    reg [7:0] gbaAddressHiOutput = 0;
    reg isGbaDAOutputMode = 0;

    reg [24:0] wordsToRead = 0;

    assign pin_gbaRD = rd_value;
    assign pin_gbaCS = cs_value;
    assign pin_gbaWR = 1;
    assign pin_gbaCS2 = 1;

    assign pin_gbaDataAddressLo = isGbaDAOutputMode ? gbaDAOutput : 16'dz;
    assign pin_gbaAddressHi = gbaAddressHiOutput;

    assign dumpCompleted = state == STATE_IDLE;

    always @(posedge clk) 
    begin
        case (state)
            STATE_IDLE: begin
                if (cartridgeSize == 0)
                    wordsToRead <= 96; // just header
                else
                    wordsToRead <= {cartridgeSize, 21'b0};
                output_Send <= 0;
                cs_value <= 1;
                if (startDump)
                    state <= state + 1;
            end
            STATE_ENABLE_ADDRESS: begin
                isGbaDAOutputMode <= 1;
                state <= state + 1;
            end
            STATE_SET_ADDRESS: begin
                // set address
                gbaDAOutput <= 0;
                gbaAddressHiOutput <= 0;
                state <= state + 1;
            end
            // DELAY
            STATE_SEND_ADDRESS: begin
                cs_value <= 0;
                state <= state + 1;
            end
            // DELAY
            STATE_DISABLE_ADDRESS: begin
                isGbaDAOutputMode <= 0;
                gbaAddressHiOutput <= 0;
                state <= state + 1;
            end
            // DELAY
            STATE_FETCH_DATA:  begin
                // RD to 0
                rd_value <= 0;
                state <= state + 1;
            end
            // DELAY
            STATE_READ_DATA: begin
                gbaDAOutput <= pin_gbaDataAddressLo;
                state <= state + 1;
            end
            STATE_READ_DATA_0: begin
                rd_value <= 1;
                if (output_IsReady) begin
                    // Read data
                    output_Data <= gbaDAOutput[7:0];
                    output_Send <= 1;

                    state <= state + 1;
                end
                else
                    output_Send <= 0;
            end
            STATE_READ_DATA_1: begin
                if (output_IsReady) begin
                    // Read data
                    output_Data <= gbaDAOutput[15:8];
                    output_Send <= 1;
                    wordsToRead <= wordsToRead - 1;

                    state <= state + 1;
                end
                else
                    output_Send <= 0;
            end
            STATE_ADDRESS_INCREMENT: begin
                output_Send <= 0;

                if (wordsToRead == 0)
                    state <= STATE_IDLE;
                else
                    state <= STATE_SEND_ADDRESS + 1; // wait and restart
                
            end
            default: // Wait
                state <= state + 1;
        endcase
    end
endmodule