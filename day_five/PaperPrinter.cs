namespace day_five;

public class PaperComparer : IComparer<string>{
    private readonly List<string> _rules = new();
    
    public PaperComparer(List<string> rules)
    {
        _rules = rules;
    }
    public int Compare(string? x, string? y)
    {
        if (_rules.Contains($"{x}|{y}"))
        {
            return -1;
        } 
        else if (_rules.Contains($"{y}|{x}"))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
public static class PaperPrinter
{
    public static int Print2()
    {
        var lines = File.ReadAllLines("./five_input.txt");
        
        var dict = new Dictionary<string, List<string>>();
        var rules = new List<string>();
        var updates = new List<string>();
        var working = false;
        var total = 0;
        
        foreach (var line in lines)
        {
            if (line.Contains('|'))
            {
                rules.Add(line);
                 var lr = line.Split('|');
                 if (dict.ContainsKey(lr[0]))
                 {
                     dict[lr[0]].Add(lr[1]);
                 }
                 else
                 {
                     dict.Add(lr[0], new List<string>{ lr[1] });
                 }
                continue;
            }
           
            if (line == "")
            {
                continue;
            }
            
            updates.Add(line); 
        }

        var pc = new PaperComparer(rules);
        
        foreach (var update in updates)
        {
            var lineValid = true;
            var visited = new HashSet<string>();
            var visiting = new List<string>();
            var pages = update.Split(',');
            for (int page = 0; page < pages.Length; page++)
            {
                if (!visited.Any())
                {
                    visited.Add(pages[page]);
                    continue;
                }
                if (!lineValid)
                {
                    break;
                }
                if (visited.Add(pages[page]) == false)
                {
                    //Console.WriteLine("seen before");
                }
                if (dict.ContainsKey(pages[page]))
                {
                    visiting.AddRange(dict[pages[page]]); 
                    while (lineValid && visiting.Any())
                    {
                        var currentlyVisiting = visiting[0];
                        if (visited.Contains(currentlyVisiting))
                        {
                            lineValid = false;
                        }
                        visiting.RemoveAt(0);
                    }
                }
            }
            if (lineValid)
            {
                //ignore
                //Console.WriteLine("VALID LINE FOUND!!!!!!!!!!!!!!!!");
                //total += int.Parse(pages[pages.Length / 2]);
            }

            if (!lineValid)
            {
                Array.Sort(pages, pc); 
                var theValue = int.Parse(pages[pages.Length / 2]);
                Console.WriteLine(theValue);
                total += theValue;
            }
        }
        
        return total;
    }
    public static int Print()
    {
        var lines = File.ReadAllLines("./five_input_test.txt");
        
        var dict = new Dictionary<string, List<string>>();
        var working = false;
        var total = 0;
        foreach (var line in lines)
        {
            var lineValid = true;
            if (line == "")
            {
                Console.WriteLine("time to run");
                Console.WriteLine(line);
                working = true;
            }
            else if(!working)
            {
                var lr = line.Split('|');
                if (dict.ContainsKey(lr[0]))
                {
                    dict[lr[0]].Add(lr[1]);
                }
                else
                {
                    dict.Add(lr[0], new List<string>{ lr[1] });
                }
            }
            else
            {
                var visited = new HashSet<string>();
                var visiting = new List<string>();
                var pages = line.Split(',');
                foreach (var page in pages)
                {
                    if (!visited.Any())
                    {
                        visited.Add(page);
                        continue;
                    }
                    if (!lineValid)
                    {
                        break;
                    }
                    if (visited.Add(page) == false)
                    {
                        Console.WriteLine("seen before");
                    }
                    
                    if (dict.ContainsKey(page))
                    {
                        visiting.AddRange(dict[page]); 
                        while (lineValid && visiting.Any())
                        {
                            var currentlyVisiting = visiting[0];
                            if (visited.Contains(currentlyVisiting))
                            {
                                lineValid = false;
                            }
                            if (dict.ContainsKey(currentlyVisiting))
                            {
                                //visiting.AddRange(dict[currentlyVisiting]); 
                            }

                            //visiting = visiting.Distinct().ToList();
                            visiting.RemoveAt(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("no rules for me");
                    }
                }
                if (lineValid)
                {
                    foreach (var page in pages)
                    {
                        Console.Write($"- {page} ");
                    }
                     
                    Console.WriteLine("-");
                    Console.WriteLine("VALID LINE FOUND!!!!!!!!!!!!!!!!");
                    total += int.Parse(pages[pages.Length / 2]);
                }
            }
        }
        
        return total;
    }

}
