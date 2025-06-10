class Program
{
    const string block = "[]";
    const string noBlock = " ";

    static void Main(string[] args)
    {
        var startingRows = 18;
        var allBlocks = new List<List<string>>();

        for (int i = 0; i < startingRows; i++)
        {
            allBlocks.Add(new List<string>() { block, block, block });
        }

        MoveBlocks(allBlocks);
    }

    public static void PrintBlocks(List<List<string>> allBlocks)
    {
        for (int i = 0; i < allBlocks.Count; i++)
        {
            for (int j = 0; j < allBlocks[i].Count; j++)
            {
                Console.Write(allBlocks[i][j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void MoveBlocks(List<List<string>> allBlocks)
    {
        var iteration = 0;
        while (true)
        {   
            PrintBlocks(allBlocks);

            if (allBlocks.Count == 1)
            {
                Console.WriteLine("Maximum number of possible rows is: 1");
                break;
            }    

            if (allBlocks.Count > 2 && allBlocks[0].All(x => x == block) && allBlocks[1].Where(x => x == block).Count() == 1)
            {
                Console.WriteLine($"Maximum number of possible rows is: {allBlocks.Count}");
                break;
            }

            if(allBlocks.Count > 2 && allBlocks[1].All(x => x == block) && allBlocks[2].Where(x => x == block).Count() == 1 && !allBlocks[0].All(x => x == block))
            {
                Console.WriteLine($"Maximum number of possible rows is: {allBlocks.Count}");
                break;
            }

            for (int i = allBlocks.Count - 1 - iteration; i > allBlocks.Count - 2 - iteration; i--)
            {
                allBlocks[i][0] = noBlock;
                allBlocks[i][2] = noBlock;

                if (allBlocks[0].FirstOrDefault(x => x == noBlock) is null)
                {
                    allBlocks = allBlocks.Prepend(new List<string>() { noBlock, noBlock, noBlock }).ToList();
                }
                allBlocks[0][allBlocks[0].IndexOf(noBlock)] = block;

                if (allBlocks[0].FirstOrDefault(x => x == noBlock) is null)
                {
                    allBlocks = allBlocks.Prepend(new List<string>() { noBlock, noBlock, noBlock }).ToList();
                }
                allBlocks[0][allBlocks[0].IndexOf(noBlock)] = block;
            }

            iteration++;
        }
    }
}
