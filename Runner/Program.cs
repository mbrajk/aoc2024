
// ----- day whatever day this was ------
//var res = PaperPrinter.Print2();
//Console.WriteLine(res);

//75,97,47,61,53
//61,13,29
//97,13,75,29,47


// ----- day 6 ------
/*using System.Text;
using day_six;

var map = new GuardMap();
//map.PrintMap(abbreviated: true);
Console.WriteLine(map.GuardLocation);
Console.ReadLine();
while (true)
{
    if (!map.WalkStep())
    {
        Console.WriteLine($"Guard has left the map after visiting {map.VisitedLocations} locations");
        break;
    }

    var mapString = map.GetMapString(abbreviated: true, relative: true);
    var sb = new StringBuilder(mapString);
    sb.Append($"Coordinates: {map.GuardLocation} - ");
    sb.Append($"Guard facing: {map.GuardDirection} - ");
    sb.Append($"Current Step: {map.TotalSteps} - ");
    sb.Append($"Distinct visits: {map.VisitedLocations}");
    Console.Clear();
    Console.WriteLine(sb.ToString());
    
    //Console.ReadLine(); // remove to run all the way though, leave to step through the map by pressing enter
    //Thread.Sleep(405);
    //Console.WriteLine();
}

var visitedSpaces = map.VisitedSpaces;
var baddies = 0;
// part 2 - still runs part 1 to generate the list of spaces visited by the guard to limit the search space
foreach (var space in visitedSpaces)
{
    Console.WriteLine($"{space.x}, {space.y}");
    var map2 = new GuardMap();
    map2.SetObstacleAt(space);
    var steps = 0;
    var tooLong = map2.x_width * map2.y_width;
    
    while (true)
    {
        if (steps > tooLong)
        {
            baddies++;
            Console.WriteLine("infinite loop detected");
            break;
        }
        if (!map2.WalkStep())
        {
            //Console.WriteLine($"Guard has left the map after visiting {map.VisitedLocations} locations");
            break;
        }

        steps++;
    }
}

Console.WriteLine(baddies);*/

// ----- day 7 ------

/*using day_seven;

var bridgeRepair = new BridgeRepair();
var res = bridgeRepair.GetTotalCalibrationResult();
Console.WriteLine(res);*/


// ----- day 8 -----
// using day_eight;
//
// var locator = new AntennaAntinodeLocator();
// var res = locator.GetAntinodeCount2();
// Console.WriteLine(res);


// ---- day 9 ----
using day_nine;

var fragmenter = new DiskFragmenter();
var res = fragmenter.FragIt();
Console.WriteLine(res);