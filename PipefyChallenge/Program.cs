using System;

namespace PipefyChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
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

        private static void PrintNumber(char character, byte value, int size)
        {
            int i = 0;
            var segments = GetSegment(value);

            // Top
            PrintLine(segments[0] ? character : ' ', size);
            // Top Columns
            PrintColumns(segments[1] ? character : ' ', segments[2] ? character : ' ', size);

            // If there is no Separator, do not print the rest.
            // This guarantees that 1 and 7 won't have repeat columns.
            if (!segments[3]) return;

            // Middle
            PrintLine(segments[3] ? character : ' ', size);
            // Bottom Columns
            PrintColumns(segments[4] ? character : ' ', segments[5] ? character : ' ', size);

            //Bottom
            PrintLine(segments[6] ? character : ' ', size);
        }

        private static void PrintLine(char character, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(character);

            Console.Write("\n");
        }

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

        private static void PrintSpacer()
        {
            Console.WriteLine();
            Console.WriteLine("---");
            Console.WriteLine();
        }

        private static bool[] GetSegment(byte value)
        {
            switch(value)
            {
                case 1:
                    return new bool[] { true, false, false, false, false, false, false };
                case 2:
                    return new bool[] { true, false, true, true, true, false, true };
                case 3:
                    return new bool[] { true, false, true, true, false, true, true };
                case 4:
                    return new bool[] { false, true, true, true, false, true, false };
                case 5:
                    return new bool[] { true, true, false, true, false, true, true };
                case 6:
                    return new bool[] { true, true, false, true, true, true, true };
                case 7:
                    return new bool[] { true, false, true, false, false, true, false };
                case 8:
                    return new bool[] { true, true, true, true, true, true, true };
                case 9:
                    return new bool[] { true, true, true, true, false, true, true };
                default:
                    return new bool[]{ false, false, false, false, false, false, false };
            }
        }
    }
}
