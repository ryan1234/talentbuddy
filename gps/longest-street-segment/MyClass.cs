using System.Linq;
using System;

class MyClass {
    public void longest_street(string[] segments) {
        double maxDistance = 0;
        
        foreach (string segment in segments.ToList())
        {
            string[] tokens = segment.Split(',');
            int x1 = int.Parse(tokens[0]);
            int y1 = int.Parse(tokens[1]);
            int x2 = int.Parse(tokens[2]);
            int y2 = int.Parse(tokens[3]);
            
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            
            if (distance > maxDistance)
            {
                maxDistance = distance;
            }
        }
        
        System.Console.WriteLine(maxDistance);
    }
}
