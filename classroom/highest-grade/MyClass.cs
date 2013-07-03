using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void max_grade(int[] grades) {
        var list = grades.ToList();
        
        int max = list.OrderByDescending(l => l).First();
        Console.WriteLine(max);
    }
}
