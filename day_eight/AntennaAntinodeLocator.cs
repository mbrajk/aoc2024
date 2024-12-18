namespace day_eight;

public enum AntennaDirection
{
    NE, // x > 0, y <= 0
    SE, // x > 0, y > 0
    SW, // x <= 0, y > 0
    NW, // x <= 0, y <=0
}

public class AntennaAntinodeLocator
{
    private readonly char[,] _array;
    private Dictionary<char, List<(int x, int y)>> _antennas;

    public AntennaAntinodeLocator()
    {
        var data = File.ReadAllLines("H:/source/coding_challenges/2024advent_of_code_test_cases/eight_input.txt");
        var numCols = data[0].Length;
        var numRows = data.Length;
        _array = new char[numCols, numRows];
        _antennas = new Dictionary<char, List<(int x, int y)>>();
                             
        for (int i = 0; i < data.Length; i++)
        {
            var cols = data[i].ToCharArray();
            for (var j = 0; j < cols.Length; j++)
            {
                var character = cols[j];
                if (char.IsDigit(character) || char.IsLetter(character))
                {
                    if (_antennas.ContainsKey(cols[j]))
                    {
                        _antennas[cols[j]].Add((i, j));
                    }
                    else
                    {
                        _antennas[cols[j]] = new List<(int x, int y)> {(i, j)};
                    }
                }

                _array[i, j] = cols[j];
            }
        }
    }

    public int GetAntinodeCount()
    {
        var antennaPoints = new List<(int x, int y)>();
        foreach (var antennaType in _antennas)
        {
            if (antennaType.Value.Count <= 1)
            {
                //there is as yet insufficient antennas for a meaningful answer
                continue;
            }

            var antennas = antennaType.Value;
            for (int i = 0; i < antennas.Count; i++)
            {
                for (int j = 0; j < antennas.Count; j++)
                {
                    if(i == j) continue;
                    var firstAntenna = antennas[i];
                    var secondAntenna = antennas[j];
                    (int x, int y) distance = ((secondAntenna.x - firstAntenna.x),
                        (secondAntenna.y - firstAntenna.y));
                    
                    var antinodeX = (firstAntenna.x - distance.x);
                    var antinodeY = (firstAntenna.y - distance.y);
                    if(antinodeX >= 0 && antinodeY >= 0 && antinodeX < _array.GetLength(0) && antinodeY < _array.GetLength(1))
                    antennaPoints.Add((antinodeX, antinodeY));
                    
                }
            }
        }
        
        return antennaPoints.Distinct().Count();
    }
}
