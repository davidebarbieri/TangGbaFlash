// (C) 2024 PeevishDave. Peevo.art

namespace TGBAFlasher
{
    public class GBALogoDecoder
    {
        public static Bitmap? DecodeLogo(byte[] header)
        {
            byte[] encodedLogo = new byte[HuffmanHeaderBios.Length + 156];
            Array.Copy(HuffmanHeaderBios, encodedLogo, HuffmanHeaderBios.Length);
            Array.Copy(header, 4, encodedLogo, HuffmanHeaderBios.Length, 156);

            byte[]? logo = Decrypt(HuffmanDecode(encodedLogo));

            if (logo == null)
            {
                return null;
            }

            Bitmap bmp = new Bitmap(LogoWidth, LogoHeight);

            for (int y = 0; y < LogoHeight; y++)
            {
                for (int x = 0; x < LogoWidth; x++)
                {
                    int index = (y / 8) * (LogoWidth / 8) * 64 + (x / 8) * 64 + (y % 8) * 8 + (x % 8);
                    int pixel = (logo[index / 8] >> (index % 8)) & 1;

                    bmp.SetPixel(x, y, pixel != 0 ? Color.Black : Color.Transparent);
                }
            }

            return bmp;
        }

        static byte[]? Decrypt(byte[]? encrypted)
        {
            if (encrypted == null)
                return null;

            uint size = (uint)encrypted[1] + ((uint)encrypted[2] << 8) + ((uint)encrypted[3] << 16);

            byte[] buffer = new byte[size];
            ushort sum = 0;

            for (int i = 0, j = 4; i < size; i += 2, j += 2)
            {
                sum += (ushort)(encrypted[j] | (encrypted[j + 1] << 8));
                buffer[i] = (byte)(sum & 0xFF);
                buffer[i + 1] = (byte)((sum >> 8) & 0xFF);
            }

            return buffer;
        }

        static byte[]? HuffmanDecode(byte[] encoded)
        {
            int codePosition = 4;
            int treePosition = 5;
            int bufferPosition = 0;

            uint currentCode = 0;
            byte codeShift = 0;
            byte decodedBits = 0;

            uint header = (uint)(encoded[0] | (encoded[1] << 8) | (encoded[2] << 16) | (encoded[3] << 24));
            byte symbolType = (byte)(header & 0xF);
            uint decompressedSize = header >> 8;

            byte[] decodedBuffer = new byte[decompressedSize];

            int nodeCount = encoded[codePosition] + 1;
            codePosition += (nodeCount << 1);

            while (bufferPosition < decompressedSize)
            {
                if (codeShift == 0x00)
                {
                    if (codePosition < 0 || (codePosition + 3 >= encoded.Length))
                        return null;

                    currentCode = (uint)(encoded[codePosition] | (encoded[codePosition + 1] << 8) |
                                         (encoded[codePosition + 2] << 16) | (encoded[codePosition + 3] << 24));
                    codePosition += 4;
                    codeShift = 0x20;
                }

                codeShift--;
                byte bitFromCode = (byte)((currentCode >> codeShift) & 1);

                byte currentNode = encoded[treePosition];
                int increment = (currentNode & 0x3F) + 1;
                increment <<= 1;

                currentNode <<= bitFromCode;

                if ((treePosition & 1) != 0) increment--;
                treePosition += (increment + bitFromCode);

                if ((currentNode & 0x80) != 0)
                {
                    decodedBuffer[bufferPosition] |= (byte)(encoded[treePosition] << decodedBits);
                    decodedBits += symbolType;

                    if (decodedBits == 0x8)
                    {
                        bufferPosition++;
                        decodedBits = 0;
                    }

                    treePosition = 5;
                }
            }

            return decodedBuffer;
        }

        // Huffman header present in GBA Bios
        static byte[] HuffmanHeaderBios = {
            0x24, 0xD4, 0x00, 0x00, 0x0F, 0x40,
            0x00, 0x00, 0x00, 0x01, 0x81, 0x82,
            0x82, 0x83, 0x0F, 0x83, 0x0C, 0xC3,
            0x03, 0x83, 0x01, 0x83, 0x04, 0xC3,
            0x08, 0x0E, 0x02, 0xC2, 0x0D, 0xC2,
            0x07, 0x0B, 0x06, 0x0A, 0x05, 0x09
        };

        const int LogoWidth = 104;
        const int LogoHeight = 16;
    }
}