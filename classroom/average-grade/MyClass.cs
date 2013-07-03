using System;
using System.Linq;

class MyClass {
    public void compute_average_grade(int[] grades) {
        double total = 0;
        
        foreach (var grade in grades.ToList()) {
            total += grade;
        }
        
        Console.WriteLine(Math.Floor(total / grades.Length));
    }
}
