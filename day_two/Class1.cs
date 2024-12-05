namespace day_two;

public static class ReactorBoi
{
    public static int DoWorkSon()
    {
        var data = File.ReadAllLines("./input");
        var nonExplodeyReactors = 0;
       
        foreach (var reactor in data)
        {
            var dataRow = reactor.Split(" ");
            bool? isIncreasing = null;
            var isExploding = false;

            for (int i = 0; i < dataRow.Length - 1; i++)
            {
                var n = int.Parse(dataRow[i]) - int.Parse(dataRow[i+1]);
                
                if (Math.Abs(n) > 3 || n == 0)
                {
                    isExploding = true;
                    break;
                }
                 
                if (n < 0)
                {
                    if (isIncreasing == null)
                    {
                        isIncreasing = true;
                    }
                    else
                    {
                        if (isIncreasing == false)
                        {
                            isExploding = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (isIncreasing == null)
                    {
                        isIncreasing = false;
                    }
                    else
                    {
                        if (isIncreasing == true)
                        {
                            isExploding = true;
                            break;
                        }
                    }
                }
            }

            if (!isExploding)
            {
                nonExplodeyReactors++;
            }
        }
       
        return nonExplodeyReactors;
    }
    
    public static int DoWorkSon2()
    {
        var data = File.ReadAllLines("./input");
        var nonExplodeyReactors = 0;
           
        foreach (var reactor in data)
        {
            var dataRow = reactor.Split(" ");
            var isExploding = false;
            var res = int.Parse(dataRow[0]) - int.Parse(dataRow[1]);
            var isIncreasing = res < 0;
               
            if (Math.Abs(res) > 3 || res == 0)
            {
                continue;
            }

            for (int i = 1; i < dataRow.Length - 1; i++)
            {
                var n = int.Parse(dataRow[i]) - int.Parse(dataRow[i+1]);
                if (Math.Abs(n) > 3 || n == 0)
                {
                    isExploding = true;
                    break;
                }

                isExploding = (n < 0) != isIncreasing;
                if (isExploding)
                {
                    break;
                }
            }

            if (!isExploding)
            {
                nonExplodeyReactors++;
            }
        }
           
        return nonExplodeyReactors;
    }
     
    public static int DoWorkSon3()
    {
        var data = File.ReadAllLines("./input");
        var nonExplodeyReactors = 0;
                
        foreach (var reactor in data)
        {
            var dataRow = reactor.Split(" ");
            var isExploding = false;
            var res = int.Parse(dataRow[0]) - int.Parse(dataRow[1]);
            var isIncreasing = true;

            if (Math.Abs(res) > 3 || res == 0)
            {
                isExploding = true;
            }
              
            if (res > 0)
            {
                isIncreasing = false;
            }
     
            for (int i = 1; i < dataRow.Length - 1; i++)
            {
                var n = int.Parse(dataRow[i]) - int.Parse(dataRow[i+1]);
                if (Math.Abs(n) > 3 || n == 0)
                {
                    isExploding = true;
                }
     
                var currentlyBeingAShitAss = (n < 0) != isIncreasing;
                if (currentlyBeingAShitAss)
                {
                    isExploding = true;
                }
            }
     
            if (!isExploding)
            {
                foreach (var num in dataRow)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
                nonExplodeyReactors++;
            }
            else
            {
                var anySuccesses = false;
                var newTests = new List<List<string>>();
                for (int i = 0; i < dataRow.Length; i++)
                {
                    var dr = dataRow.ToList();
                    dr.RemoveAt(i);
                    newTests.Add(dr);
                }
                //redo it with each index out
                for (int i = 0; i < newTests.Count; i++)
                {
                    var subsetIncreasing = true;
                    var subsetIsExploding = false;
                    var subsetTest = newTests[i];
                    var subsetVal = int.Parse(subsetTest[0]) - int.Parse(subsetTest[1]);
                      
                    if (Math.Abs(subsetVal) > 3 || subsetVal == 0)
                    {
                        subsetIsExploding = true;
                        continue;
                    }
                                    
                    if (subsetVal > 0)
                    {
                        subsetIncreasing = false;
                    }

                    for (int j = 1; j < subsetTest.Count - 1; j++)
                    {
                        var n = int.Parse(subsetTest[j]) - int.Parse(subsetTest[j+1]);
                        if (Math.Abs(n) > 3 || n == 0)
                        {
                            subsetIsExploding = true;
                        }
                                                 
                        var currentlyBeingAShitAss = (n < 0) != subsetIncreasing;
                        if (currentlyBeingAShitAss)
                        {
                            subsetIsExploding = true;
                            break;
                        }
                    }

                    if (!subsetIsExploding)
                    {
                        anySuccesses = true;
                    }
                }

                if (anySuccesses)
                {
                    foreach (var num in dataRow)
                    {
                        Console.Write($"{num} ");
                    }
                    Console.WriteLine();
                    nonExplodeyReactors++;
                }
            }
        }
                
        return nonExplodeyReactors;
    }

    public static int DoWorkSon4()
    {
        var data = File.ReadAllLines("./input");
        var nonExplodeyReactors = 0;
                
        foreach (var reactor in data)
        {
            var dataRow = reactor.Split(" ");
            var isExploding = false;
            var res = int.Parse(dataRow[0]) - int.Parse(dataRow[1]);
            var isIncreasing = true;

            if (Math.Abs(res) > 3 || res == 0)
            {
                isExploding = true;
            }
              
            if (res > 0)
            {
                isIncreasing = false;
            }
     
            for (int i = 1; i < dataRow.Length - 1; i++)
            {
                var n = int.Parse(dataRow[i]) - int.Parse(dataRow[i+1]);
                if (Math.Abs(n) > 3 || n == 0)
                {
                    isExploding = true;
                }
     
                var currentlyBeingAShitAss = (n < 0) != isIncreasing;
                if (currentlyBeingAShitAss)
                {
                    isExploding = true;
                }
            }
     
            if (!isExploding)
            {
                nonExplodeyReactors++;
            }
            else
            {
                var anySuccesses = false;
                var subsetIsExploding = false;
                var newTests = new List<List<string>>();
                for (int i = 0; i < dataRow.Length; i++)
                {
                    var dr = dataRow.ToList();
                    dr.RemoveAt(i);
                    newTests.Add(dr);
                }
                //redo it with each index out
                for (int i = 0; i < newTests.Count; i++)
                {
                    var subsetIncreasing = false;
                    var subsetTest = newTests[i];
                    var subsetVal = int.Parse(subsetTest[0]) - int.Parse(subsetTest[1]);
                      
                    if (Math.Abs(subsetVal) > 3 || subsetVal == 0)
                    {
                        subsetIsExploding = true;
                    }
                                    
                    if (subsetVal > 0)
                    {
                        subsetIncreasing = false;
                    }

                    for (int j = 1; j < subsetTest.Count - 1; j++)
                    {
                        var n = int.Parse(subsetTest[j]) - int.Parse(subsetTest[j+1]);
                        if (Math.Abs(n) > 3 || n == 0)
                        {
                            subsetIsExploding = true;
                        }
                                                 
                        var currentlyBeingAShitAss = (n < 0) != subsetIncreasing;
                        if (currentlyBeingAShitAss)
                        {
                            subsetIsExploding = true;
                        }
                    }

                    if (!subsetIsExploding)
                    {
                        anySuccesses = true;
                    }
                }

                if (anySuccesses)
                {
                    nonExplodeyReactors++;
                }
            }
        }
                
        return nonExplodeyReactors;
    }
}

