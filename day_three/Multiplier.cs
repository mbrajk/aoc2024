using System.Text.RegularExpressions;

namespace day_three;

public static class Multiplier
{
    public static int Run()
    {
        var data = File.ReadAllText("./three_input");
        var regex = new Regex(@"mul\([0-9]+,[0-9]+\)");
        var total = 0;
        var matches = regex.Matches(data);
        foreach (Match match in matches)
        {
            var withoutMul = match.Value.Substring(4);
            var withoutEnd = withoutMul.Substring(0, withoutMul.Length - 1);
            var values = withoutEnd.Split(","); 
            var a = int.Parse(values[0]);
            var b = int.Parse(values[1]);
            total += a * b;
        }

        return total;
    }
    public static int Run2()
    {
        var data = File.ReadAllText("./three_input");
        var regex = new Regex(@"(mul\([0-9]+,[0-9]+\)|do\(\)|don't\(\))");
        var total = 0;
        var matches = regex.Matches(data);
        var doing = true;
        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                doing = true;
                continue;
            } 
            
            if(match.Value == "don't()")
            {
                doing = false;
                continue;
            }

            if (doing)
            {
                var withoutMul = match.Value.Substring(4);
                var withoutEnd = withoutMul.Substring(0, withoutMul.Length - 1);
                var values = withoutEnd.Split(",");
                var a = int.Parse(values[0]);
                var b = int.Parse(values[1]);
                total += a * b;
            }
        }
    
        return total;
    }
}
