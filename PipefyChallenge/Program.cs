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

                if (value == '0') break;

                if (value < '1' || value > '9')
                {
                    Console.WriteLine("Valor Inválido!");
                    Console.WriteLine("---");
                    continue;
                }

                byte val = (byte) ( value - '0');
                PrintNumber(value, val, val);
                Console.WriteLine("---");
            }

        }

        private static void PrintNumber(char character, byte value, int size)
        {
            int i = 0;
            var segments = GetSegment(value);

            // Top
            PrintLine(segments[1] ? character : ' ', size);
            // Top Columns
            PrintColumns(segments[0] ? character : ' ', segments[2] ? character : ' ', size);
            // Middle
            PrintLine(segments[3] ? character : ' ', size);
            // Bottom Columns
            PrintColumns(segments[4] ? character : ' ', segments[5] ? character : ' ', size);
            //Bottom
            PrintLine(segments[6] ? character : ' ', size);
        }

        private static void PrintLine(char character, int size)
        {

        }

        private static void PrintColumns(char startChar, char endChar, int size)
        {

        }

        private static bool[] GetSegment(byte value)
        {
            switch(value)
            {
                case 1:
                    return new bool[] { false, true, false, false, false, false, false };
                case 2:
                    return new bool[] { false, true, true, true, true, true, false };
                case 3:
                    return new bool[] { false, true, true, true, false, true, true };
                case 4:
                    return new bool[] { true, false, true, true, false, false, true };
                case 5:
                    return new bool[] { true, true, false, true, false, true, true };
                case 6:
                    return new bool[] { true, true, false, true, true, true, true };
                case 7:
                    return new bool[] { false, true, true, true, false, false, true };
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
