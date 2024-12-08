namespace day_seven;

public class BridgeRepair
{
    private readonly List<(int, List<int>)> _equations = new();
    public BridgeRepair()
    {
        var equations = File.ReadAllLines("./seven_input_test.txt");
        foreach (var equation in equations)
        {
            var eq = equation.Split(":");
            var values = eq[1].Trim().Split(" ").Select(v => int.Parse(v)).ToList();
            _equations.Add((equation[0], values));
        }
    }

    public int GetTotalCalibrationResult()
    {
        return 0;
    }
}
