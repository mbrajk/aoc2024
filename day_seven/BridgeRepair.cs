namespace day_seven;

public class BridgeRepair
{
    private readonly List<(long total, long[] values)> _equations = new();
    private readonly string[] _operations = new[] {"*", "+", "||"};
    
    public BridgeRepair()
    {
        var equations = File.ReadAllLines("H:/source/coding_challenges/2024advent_of_code_test_cases/seven_input.txt");
        foreach (var equation in equations)
        {
            var eq = equation.Split(":");
            var values = eq[1].Trim().Split(" ").Select(v => Int64.Parse(v)).ToArray();
            _equations.Add((Int64.Parse(eq[0]), values));
        }
    }

    public long GetTotalCalibrationResult()
    {
        var results = new List<long>();
        
        foreach (var equation in _equations)
        {
            var target = equation.total;
            var values = equation.values;
            
            var expressions = new string[values.Length - 1];
            if (TryGetClibrationResults(target, values, 0, expressions))
            {
                results.Add(target);
            }
        }
       
        return results.Sum();
    }

    private bool TryGetClibrationResults(long desiredTotal, long[] values, int index, string[] expressions)
    {
        if (index == values.Length - 1)
        {
            var result = Evaluate(values, expressions);
            if (result == desiredTotal)
            {
                return true;
            }

            return false;
        }

        foreach (var operation in _operations)
        {
            expressions[index] = operation;
            if (TryGetClibrationResults(desiredTotal, values, index + 1, expressions))
            {
                return true;
            }
        }

        return false;
    }

    private long Evaluate(long[] values, string[] expressions)
    {
        long result = values[0];

        for (int i = 0; i < expressions.Length; i++)
        {
            switch (expressions[i])
            {
                case "+":
                    result += values[i + 1];
                    break;
                case "*":
                    result *= values[i + 1];
                    break;
                case "||":
                    result = long.Parse(result.ToString() + values[i + 1].ToString());
                    break;
            }
        }

        return result;
    }
    
}
