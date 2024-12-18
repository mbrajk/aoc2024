using System.Text;

namespace day_nine;

public enum DataType
{
    File = 0,
    Free = 1
}

public class DiskFragmenter
{
    private readonly string _diskData;
    private readonly char[] _expandedDiskData;

    public DiskFragmenter()
    {
        var data = File.ReadAllLines("H:/source/coding_challenges/2024advent_of_code_test_cases/nine_input.txt");
        var diskData = data[0];
        var expandedDisk = new StringBuilder();
        var type = DataType.File;
        var fileId = 0;
        foreach (var dataBit in diskData)
        {
            int num = dataBit - '0';
            
            for (int i = 0; i < num; i++)
            {
                expandedDisk.Append(type == DataType.File ? fileId : ".");
            }
            type = (DataType)(((int)type + 1) % 2);
            if (type == DataType.File)
            {
                fileId++;
            }
        }

        _expandedDiskData = expandedDisk.ToString().ToCharArray();
    }
        
    public Int64 FragIt()
    {
        //Console.WriteLine(_expandedDiskData);
        
        var left = 0;
        var right = _expandedDiskData.Length - 1;
        
        // get first free hole starting from left
        // get first occupied space starting from right
        // swap, increment right, repeat until left == right

        while (left < right)
        {
            if (_expandedDiskData[left] != '.')
            {
                left++;
            }
            else
            {
                (_expandedDiskData[left], _expandedDiskData[right]) = (_expandedDiskData[right], _expandedDiskData[left]);
                right--;
            }
        }
        
        //Console.WriteLine(_expandedDiskData);

        var block = 0;
        Int64 checksum = 0;
        while (_expandedDiskData[block] != '.' && block < _expandedDiskData.Length)
        {
            checksum += block * (_expandedDiskData[block] - '0');
            block++;
        }
        return checksum;
    }
}
