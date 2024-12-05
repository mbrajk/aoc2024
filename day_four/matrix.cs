using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace day_four;

public enum Direction
{
    NW = 0,
    NN = 1,
    NE = 2,
    WW = 3,
    EE = 4,
    SW = 5,
    SS = 6,
    SE = 7,
}
public static class matrix
{
    private static Dictionary<Direction, (int, int)> directionLookup = new()
    {
        {Direction.NW, (-1, -1) },
        {Direction.NN, (-1, 0) },
        {Direction.NE, (-1, 1) },
        {Direction.WW, (0, -1) },
        {Direction.EE, (0, 1) },
        {Direction.SW, (1, -1) },
        {Direction.SS, (1, 0) },
        {Direction.SE, (1, 1) }
    };
    public static bool DoIHaveThisCharacter(char c, int i, int j, string[] data)
    {
        if (i < 0 || j < 0 || i >= data.Length || j >= data[i].Length)
        {
            return false;
        }
            
        if (data[i][j] == c)
        {
            return true;
        }

        return false;
    }
    
    public static int GetCount()
    {
        var data = File.ReadAllLines("./four_input");
        var numCols = data[0].Length;
        var numRows = data.Length;
        var arr = new char[numRows, numCols];
        var count = 0;
        
        for (int i = 0; i < data.Length; i++)
        {
            var cols = data[i].ToCharArray();
            for (var j = 0; j < cols.Length; j++)
            {
                arr[i,j] = cols[j];
            }
        }
        
         for (int i = 0; i < data.Length; i++)
         {
             for (var j = 0; j < data[i].Length; j++)
             {
                 if (data[i][j] == 'X')
                 {
                     // instead of doing this, could just iterate on the directions
                     var currentDirection = Direction.NW;
                     var foundXmas = false;
                     Console.WriteLine("Found X");
                     for (int i2 = i - 1; i2 <= i + 1; i2++)
                     {
                         for (int j2 = j - 1; j2 <= j + 1; j2++)
                         {
                             if (i2 == i && j2 == j)
                             {
                                 //currentDirection = (Direction)(((int)currentDirection+1) % 7);
                                 continue;
                             }

                             //var newI = i2 + directionLookup[currentDirection].Item1;
                             //var newJ = j2 + directionLookup[currentDirection].Item2;
                             if (DoIHaveThisCharacter('M', i2, j2, data))
                             {
                                 //Console.WriteLine("found M");
                                 //Console.WriteLine(currentDirection);
                                 //Console.WriteLine($"m at {i2}, {j2}");
                                 var newI = i2 + directionLookup[currentDirection].Item1;
                                 var newJ = j2 + directionLookup[currentDirection].Item2;
                                 
                                 if (DoIHaveThisCharacter('A', newI, newJ, data))
                                 {
                                     Console.WriteLine($"A at {newI}, {newJ}");
                                      newI = newI + directionLookup[currentDirection].Item1;
                                      newJ = newJ + directionLookup[currentDirection].Item2;
                                     Console.WriteLine("found A");
                                     if (DoIHaveThisCharacter('S', newI, newJ, data))
                                     {
                                         Console.WriteLine(currentDirection);
                                         Console.WriteLine($"x at {i}, {j}");
                                         Console.WriteLine($"S at {newI}, {newJ}");
                                         Console.WriteLine("Found XMAS");
                                         foundXmas = true;
                                         count++;
                                     }
                                 }
                             }
                             if (i2 < 0 || j2 < 0 || i2 >= data.Length || j2 >= data[i].Length)
                             {
                                 currentDirection = (Direction)(((int)currentDirection+1) % 7);
                                 continue;
                             }

                             currentDirection = (Direction)(((int)currentDirection+1) % 8);
                         }
                     }

                     // characters to check
                     // data[i - 1][j];
                     // data[i - 1][j-1];
                     // data[i - 1][j+1];
                     // data[i][j+1];
                     // data[i][j-1];
                     // data[i + 1][j+1];
                     // data[i + 1][j];
                     // data[i + 1][j-1];
                 }
             }
         }
        return count;
    }
    public static int GetCount2()
    {
        var data = File.ReadAllLines("./four_input");
        var numCols = data[0].Length;
        var numRows = data.Length;
        var arr = new char[numRows, numCols];
        var count = 0;
            
        for (int i = 0; i < data.Length; i++)
        {
            var cols = data[i].ToCharArray();
            for (var j = 0; j < cols.Length; j++)
            {
                arr[i,j] = cols[j];
            }
        }
            
        for (int i = 1; i < data.Length - 1; i++)
        {
            for (var j = 1; j < data[i].Length - 1; j++)
            {
                if (data[i][j] == 'A')
                {
                    if ((data[i-1][j-1] == 'M' && data[i+1][j+1] == 'S') || (data[i-1][j-1] == 'S' && data[i+1][j+1] == 'M'))
                    {
                        if ((data[i - 1][j + 1] == 'M' && data[i + 1][j - 1] == 'S') ||
                            (data[i - 1][j + 1] == 'S' && data[i + 1][j - 1] == 'M'))
                        {
                            count++;
                        }
                    }
                }
            }
        }
        return count;
    }
}
