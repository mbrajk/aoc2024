using day_six;

var guardMap = new GuardMap();
var map = guardMap.GetMap;

Console.WriteLine("fmt: x, y");
while (true)
{
    var xy = Console.ReadLine();
    var xyCoords = xy?.Split(",") ?? [];

    if (xyCoords.Length != 2)
    {
        continue;
    }
    var (x, y) = (xyCoords[0].Trim(), xyCoords[1].Trim());

    var yInt = int.MinValue;
    var result = int.TryParse(x, out var xInt);
    result = result && int.TryParse(y, out yInt);
    if (result)
    {
        
        Console.WriteLine($"{map[xInt - 1, yInt - 1]}  {map[xInt - 1, yInt]}  {map[xInt - 1, yInt + 1]}");
        Console.WriteLine($"{map[xInt, yInt - 1]} [{map[xInt, yInt]}] {map[xInt, yInt + 1]}");
        Console.WriteLine($"{map[xInt + 1, yInt -1]}  {map[xInt + 1, yInt]}  {map[xInt + 1, yInt + 1]}");
    }
}