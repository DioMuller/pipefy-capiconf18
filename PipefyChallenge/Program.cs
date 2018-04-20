using System;

namespace PipefyChallenge
{
    class Program
    {
        // BCD Segments
        private const int a = 0;
        private const int b = 1;
        private const int c = 2;
        private const int d = 3;
        private const int e = 4;
        private const int f = 5;
        private const int g = 6;


        static void Main(string[] args)
        {
            Console.WriteLine("DESAFIO PIPEFY - CAPICONF 2018");
            Console.WriteLine();
            Console.WriteLine("Esta solução converte os números entre 1-9 utilizando");
            Console.WriteLine("a mesma lógica que os displays de sete segmentos reais.");
            Console.WriteLine();
            Console.WriteLine("Nos casos de números sem segmentos no meio e no fim (1 e 7),");
            Console.WriteLine("as colunas são impressas apenas uma vez.");
            PrintSpacer();
                   
            while (true)
            {
                Console.WriteLine("Por favor, digite um número entre 1 e 9. Digite 0 para finalizar.");
                var value = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Space after Character.

                if (value == '0') break;

                if (value < '1' || value > '9')
                {
                    Console.WriteLine("Valor Inválido!");
                    PrintSpacer();
                    continue;
                }

                byte val = (byte) ( value - '0');
                PrintSpacer();
                PrintNumber(value, val, val);
                PrintSpacer();
            }
        }

        #region Print Methods
        /// <summary>
        /// Prints the given number.
        /// </summary>
        /// <param name="character">Character to be print.</param>
        /// <param name="value">Value to be print (1-9).</param>
        /// <param name="size">Line/Column size.</param>
        private static void PrintNumber(char character, byte value, int size)
        {
            int i = 0;
            var segments = BCDToSeven(value);

            // Top
            if( segments[a] ) PrintLine(character, size);
            // Top Columns
            PrintColumns(segments[f] ? character : ' ', segments[b] ? character : ' ', size);

            // If there is no Separator, do not print the rest.
            // This guarantees that 1 and 7 won't have repeat columns.
            // If Segment 'd' (bottom segment) should be print (such as if the number was 0), it continues.
            if (!segments[g] && !segments[d]) return;

            // Middle
            if(segments[g]) PrintLine(segments[g] ? character : ' ', size);

            // Bottom Columns
            PrintColumns(segments[e] ? character : ' ', segments[c] ? character : ' ', size);

            //Bottom
            if(segments[d]) PrintLine( character, size);
        }

        /// <summary>
        /// Prints the segment line.
        /// </summary>
        /// <param name="character">Character to be used.</param>
        /// <param name="size">Line Size.</param>
        private static void PrintLine(char character, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(character);

            Console.Write("\n");
        }

        /// <summary>
        /// Prints up to two segment columns.
        /// </summary>
        /// <param name="startChar">Leftmost segment character.</param>
        /// <param name="endChar">Right segment character.</param>
        /// <param name="size">Column size.</param>
        private static void PrintColumns(char startChar, char endChar, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(startChar);

                for (int j = 0; j < size - 2; j++)
                    Console.Write(' ');

                Console.Write(endChar);
                Console.Write("\n");
            }
        }

        /// <summary>
        /// Prints a spacer.
        /// </summary>
        private static void PrintSpacer()
        {
            Console.WriteLine();
            Console.WriteLine("---");
            Console.WriteLine();
        }
        #endregion // Print Methods


        /// <summary>
        /// BCD to Seven Decoder.
        /// Formulas obtained from: https://www.electronicshub.org/bcd-7-segment-led-display-decoder-circuit/
        /// </summary>
        /// <returns>Boolean array with segment values.</returns>
        /// <param name="value">Value to be converted, between 0 and 9.</param>
        private static bool[] BCDToSeven(byte value)
        {
            var result = new bool[] { false, false, false, false, false, false, false };

            if (value < 0 || value > 9) return result;

            bool A = (value & 0b00001000) != 0;
            bool B = (value & 0b00000100) != 0;
            bool C = (value & 0b00000010) != 0;
            bool D = (value & 0b00000001) != 0;

            result[a] = A || C || (B && D) || (!B && !D);
            result[b] = !B || (!C && !D) || (C && D);
            result[c] = B || !C || D;
            result[d] = (!B && !D) || (C && !D) || (B && !C && D) || (!B && C) || A;
            result[e] = (!B && !D) || (C && !D);
            result[f] = A || (!C && !D) || (B && !C) || (B && !D);
            result[g] = A || (B && !C) || (!B && C) || (C && !D);

            return result;
        }
    }
}
