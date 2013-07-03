using System;
using System.Linq;

class MyClass {
    public void count_successful_students(int[] grades, int min_grade) {
        int counted = 0;
        
        foreach (var grade in grades.ToList()) {
            if (grade >= min_grade) {
                counted++;
            }
        }    
        
        Console.WriteLine(counted);
        
    }
}
