using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void longest_improvement(int[] grades) {
        List<int> runs = new List<int>();
        
        int lastGrade = 0;
        int runCount = 1;
        foreach (var grade in grades.ToList()) {
            if (grade >= lastGrade) { runCount++; }
            else { runs.Add(runCount); runCount = 1; }
            lastGrade = grade;
        }
        runs.Add(runCount);
        
        Console.WriteLine(runs.OrderByDescending(r => r).First());
    } 
}
