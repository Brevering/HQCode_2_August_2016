namespace DancingMoves
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class DancingMove
    {
        private static void Main()
        {
            var inputarr = Console.ReadLine()
                .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            BigInteger sum = 0;
            var inputLength = inputarr.Length;
            var instruction = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToArray();
            var currentPos = 0;
            var count = 0;
            while (instruction.Length != 1)
            {
                var delta = instruction[1] == "right" ? 1 : -1;
                var deltamove = delta * int.Parse(instruction[2]);
                var dm = 0;
                if (deltamove < 0)
                {
                    dm = deltamove * -1;
                }
                else
                {
                    dm = deltamove;
                }

                if (dm > inputLength)
                {
                    deltamove %= inputarr.Length;
                }

                for (var i = 0; i < int.Parse(instruction[0]); i++)
                {
                    if (currentPos + deltamove >= 0 && currentPos + deltamove <= inputLength - 1)
                    {
                        currentPos += deltamove;
                    }
                    else if (currentPos + deltamove < 0)
                    {
                        currentPos = currentPos + deltamove + inputLength;
                    }
                    else
                    {
                        currentPos = currentPos - inputLength + deltamove;
                    }

                    sum += inputarr[currentPos];
                }

                count++;
                instruction = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine("{0:0.0}", (double)sum / count);
        }
    }
}
