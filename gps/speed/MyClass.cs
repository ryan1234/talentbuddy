using System;
using System.Linq;

class MyClass {
    public void vehicle_speed(string[] positions) {
        // Write your code here.
        string firstPosition = positions.ToList().First();
        
        string[] firstTokens = firstPosition.Split(',');        
        int x1 = int.Parse(firstTokens[0]);
        int y1 = int.Parse(firstTokens[1]);
        int speed1 = int.Parse(firstTokens[2]);
        
        foreach (string position in positions.ToList().Skip(1))
        {
            string[] tokens = position.Split(',');
            int x2 = int.Parse(tokens[0]);
            int y2 = int.Parse(tokens[1]);
            int speed2 = int.Parse(tokens[2]);
            
            double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double velocity = distance / (speed2 - speed1);
            System.Console.WriteLine(velocity.ToString("0.00"));
            
            x1 = x2;
            y1 = y2;
            speed1 = speed2;
        }
    }
}
