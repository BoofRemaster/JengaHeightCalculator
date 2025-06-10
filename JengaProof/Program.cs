class Program
{
    const string Block = "[]";
    const string NoBlock = " ";

    static void Main(string[] args)
    {
        int startingRows;

        Console.WriteLine("Enter the number of starting rows (minimum 1):");
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out startingRows) && startingRows >= 1)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a number greater than or equal to 2.");
        }
        
        var startingBlocks = new List<List<string>>();
        for (int i = 0; i < startingRows; i++)
        {
            startingBlocks.Add([Block, Block, Block]);
        }

        MoveBlocks(startingBlocks);
    }

    public static void PrintBlocks(List<List<string>> allBlocks)
    {
        // print the tower from top to bottom
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
        // https://www.youtube.com/watch?v=s2NkEYVp_44 
        var iteration = 0;
        
        // Yummy infinite loop if all goes wrong
        while (true)
        {
            PrintBlocks(allBlocks);

            if (allBlocks.Count == 1)
            {
                Console.WriteLine("Maximum number of possible rows is: 1");
                break;
            }

            // check if the number of rows is more than 2, because if it is not then we will get an index out of range exception
            // if the top row is complete, and the 2nd row only has one block, then we can no longer move blocks as per the rules of Jenga
            if (allBlocks.Count > 2 && allBlocks[0].All(x => x == Block) && allBlocks[1].Where(x => x == Block).Count() == 1)
            {
                Console.WriteLine($"Maximum number of possible rows is: {allBlocks.Count}");
                break;
            }

            // check if the number of rows is more than 2, because if it is not then we will get an index out of range exception
            // if the 2nd row is complete, and the 3rd row only has one block, and the top row is not complete, 
            // then we can no longer move blocks as per the rules of Jenga
            if (allBlocks.Count > 2 && allBlocks[1].All(x => x == Block) && allBlocks[2].Where(x => x == Block).Count() == 1 && !allBlocks[0].All(x => x == Block))
            {
                Console.WriteLine($"Maximum number of possible rows is: {allBlocks.Count}");
                break;
            }

            // include this iteration count into the for loop because we want to keep moving up rows until we reach the top
            for (int i = allBlocks.Count - 1 - iteration; i > allBlocks.Count - 2 - iteration; i--)
            {
                // Remove the 2 outside blocks of the bottom most complete row
                allBlocks[i][0] = NoBlock;
                allBlocks[i][2] = NoBlock;

                // if the top row is complete, add a new row at the top
                if (allBlocks[0].FirstOrDefault(x => x == NoBlock) is null)
                {
                    allBlocks = allBlocks.Prepend([NoBlock, NoBlock, NoBlock]).ToList();
                }
                allBlocks[0][allBlocks[0].IndexOf(NoBlock)] = Block;

                // duplicate code to above because I cheat at Jenga and move the blocks in pairs for simplicity of this code implementation
                if (allBlocks[0].FirstOrDefault(x => x == NoBlock) is null)
                {
                    allBlocks = allBlocks.Prepend([NoBlock, NoBlock, NoBlock]).ToList();
                }
                allBlocks[0][allBlocks[0].IndexOf(NoBlock)] = Block;
            }

            iteration++;
        }
    }
}
