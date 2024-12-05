//Class1.DoWorkSon();
Class1.DoWorkSon2();

public static class Class1
{
   public static void DoWorkSon()
   {
       var data = File.ReadAllLines("./input");
       var arr1 = new List<int>();
       var arr2 = new List<int>();

       foreach (var line in data)
       {
           var lr = line.Trim().Split();
           if (lr.Length > 1)
           {
               arr1.Add(int.Parse(lr[0]));
               arr2.Add(int.Parse(lr[3]));
           }
       }
       
       arr1.Sort();
       arr2.Sort();

       var count = arr1.Count;

       var total = 0;
       for (int i = 0; i < count; i++)
       {
           total += Math.Abs(arr1[i] - arr2[i]);
       }

       Console.WriteLine(total);
   }

   public static void DoWorkSon2()
   {
       var data = File.ReadAllLines("./input");
       var arr1 = new List<int>();
       var arr2 = new List<int>();
       
       foreach (var line in data)
       {
           var lr = line.Trim().Split();
           if (lr.Length > 1)
           {
               arr1.Add(int.Parse(lr[0]));
               arr2.Add(int.Parse(lr[3]));
           }
       }
              
       var count = arr1.Count;
       var dic = new Dictionary<int, int>();
       
       for (int i = 0; i < count; i++)
       {
           if (!dic.ContainsKey(arr2[i]))
           {
               dic.Add(arr2[i], 1);
           }
           else
           {
               dic[arr2[i]]++;
           }
       }

       var total = 0;
        for (int i = 0; i < count; i++)
        {
            if (dic.ContainsKey(arr1[i]))
            {
               total += arr1[i] * dic[arr1[i]];
            }
            else
            {
                total += 0;
            }
        }
        
       Console.WriteLine(total);
   }
}

