using System.Linq;
using System.Collections;
using System.Collections.Generic;

class MyClass {
    public void intersecting_segments(string[] segments) {
        // Write your code here.
        Dictionary<string, int> ht = new Dictionary<string, int>();
        
        foreach (string segment in segments.ToList())
        {
            string[] tokens = segment.Split(',');
            string pair1 = tokens[0] + "," + tokens[1];
            string pair2 = tokens[2] + "," + tokens[3];
            
            if (ht.ContainsKey(pair1)) 
            {
                ht[pair1] = ht[pair1] + 1;
            }
            else
            {
                ht.Add(pair1, 1);
            }
            
            if (ht.ContainsKey(pair2))
            {
                ht[pair2] = ht[pair2] + 1;
            }
            else
            {
                ht.Add(pair2, 1);
            }
        }
        
        foreach (string segment in segments.ToList())
        {
            string[] tokens = segment.Split(',');
            string pair1 = tokens[0] + "," + tokens[1];
            string pair2 = tokens[2] + "," + tokens[3];
            
            int total = 0;
            
            if (ht.ContainsKey(pair1))
            {
                total += ht[pair1] - 1;
            }
            
            if (ht.ContainsKey(pair2))
            {
                total += ht[pair2] - 1;
            }
            
            System.Console.WriteLine(total);
        }
    }
}
