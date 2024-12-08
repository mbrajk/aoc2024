using System.Text;

namespace day_six;

public enum MapCellObject
{
    _____,
    Guard,
    Block,
    Seent,
    Unknown
}

public enum GuardFacing
{
    North,
    East,
    South,
    West
}

public static class GuardMovementOptions
{
    public static Dictionary<GuardFacing, (int x, int y)> GuardMovements = new()
    {
        {
            GuardFacing.North, (-1, 0)
        },
        {
            GuardFacing.East, (0, 1)
        },
        {
            GuardFacing.South, (1, 0)
        },
        {
            GuardFacing.West, (0, -1)
        }
    };
}

public class GuardMap
{
    //only using this to store movement for part 2
    public List<(int x, int y)> VisitedSpaces = new();
    //easiest way to set up an obstacle
    public void SetObstacleAt((int x, int y) space)
    {
        _map[space.x, space.y] = MapCellObject.Block;
    }
    
    //there are enough guard properties that it should be its own class
    public int x_width => _map.GetLength(0);
    public int y_width => _map.GetLength(1);
    public (int x, int y) GuardLocation => _guardLocation;
    public GuardFacing GuardDirection => _guardDirection;
    public MapCellObject[,] GetMap => _map;
    public int VisitedLocations => _visitedLocations;
    public int TotalSteps => _totalSteps;
    
    private MapCellObject[,] _map;
    private (int x, int y) _guardLocation = (int.MinValue, int.MinValue);
    private GuardFacing _guardDirection;
    private int _visitedLocations = 1; //the guard has visited the location they are standing on
    private int _totalSteps = 0;
    private bool _guardOffMap = false;

    public GuardMap()
    {
        var data = File.ReadAllLines("./six_input.txt");
        var numCols = data[0].Length;
        var numRows = data.Length;
        var arr = new MapCellObject[numRows, numCols];
                      
        for (int i = 0; i < data.Length; i++)
        {
            var cols = data[i].ToCharArray();
            for (var j = 0; j < cols.Length; j++)
            {
                var (objectType, guardDirection) = cols[j] switch
                {
                    '.' => (MapCellObject._____, _guardDirection),
                    '#' => (MapCellObject.Block, _guardDirection),
                    '<' => (MapCellObject.Guard, GuardFacing.West),
                    '^' => (MapCellObject.Guard, GuardFacing.North),
                    '>' => (MapCellObject.Guard, GuardFacing.East),
                    'v' => (MapCellObject.Guard, GuardFacing.South),
                    _ => (MapCellObject.Unknown, _guardDirection)
                };

                if (objectType == MapCellObject.Guard)
                {
                    _guardDirection = guardDirection;
                    _guardLocation = (i, j);
                }

                arr[i, j] = objectType;
            }
        }

        _map = arr;
    }

    public string GetMapString(bool abbreviated = false, bool relative = false, int scale = 20)
    {
        var xStart = 0;
        var yStart = 0;
        var xEnd = _map.GetLength(0);
        var yEnd = _map.GetLength(1);
        if (relative)
        {
            xStart = _guardLocation.x - (scale / 2); //111
            xEnd = _guardLocation.x + (scale / 2);   //131
            yStart = _guardLocation.y - (scale / 2);
            yEnd = _guardLocation.y + (scale / 2);
        }

        var sb = new StringBuilder();
        for (int i = xStart; i < xEnd; i++)
        {
            for (int j = yStart; j < yEnd; j++)
            {
                string toPrint;
                if (i < 0 || i >= _map.GetLength(0) || j < 0 || j >= _map.GetLength(1))
                {
                    toPrint = "XXXXX";
                }
                else
                {
                    toPrint = _map[i, j].ToString();
                }
                
                if (abbreviated)
                {
                    sb.Append($"{toPrint[0]} ");
                    continue;
                }
                sb.Append($"{toPrint} ");
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }

    public bool WalkStep()
    {
        if (_guardOffMap)
        {
            return false;
        }
        
        var movementOption = GuardMovementOptions.GuardMovements[_guardDirection];
        var (newX, newY) = (_guardLocation.x + movementOption.x, _guardLocation.y + movementOption.y);
        
        if (newX >= _map.GetLength(0) ||
            newY >= _map.GetLength(1) ||
            newX < 0 ||
            newY < 0)
        {
            _guardOffMap = true;
            return false;
        }
        
        if (_map[newX, newY] == MapCellObject.Block)
        {
           // change direction 
           _guardDirection = (GuardFacing)(((int)_guardDirection + 1) % 4);
           //_map[_guardLocation.x, _guardLocation.y] =  // need to change if we show direction on printed map
           return true;
        }

        
        _map[_guardLocation.x, _guardLocation.y] = MapCellObject.Seent;
        _guardLocation = (newX, newY);
        if (_map[_guardLocation.x, _guardLocation.y] != MapCellObject.Seent)
        {
            _visitedLocations++;
            VisitedSpaces.Add((_guardLocation.x, _guardLocation.y));
        }
        _map[_guardLocation.x, _guardLocation.y] = MapCellObject.Guard;
        
        _totalSteps++;
        return true;
    }
}
