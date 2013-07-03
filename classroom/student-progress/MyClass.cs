using System;
using System.Linq;

class MyClass {
    public void is_sorted(int[] grades) {        
        Console.WriteLine(Ascending(grades));
    }
    
    public int Ascending(int[] grades) {
        int lastGrade = 0;
        foreach (var grade in grades.ToList()) {
            if (grade < lastGrade) { return 0; }
            lastGrade = grade;
        }
        
        return 1;
    }
}
