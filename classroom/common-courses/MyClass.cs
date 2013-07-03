using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void get_common_courses(int[] courses1, int[] courses2)                         
    {
        var items = new List<int>();
        foreach (var course1 in courses1) {
            if (courses2.ToList().Contains(course1)) {
                items.Add(course1);
            }
        }
        
        foreach (var item in items.Distinct().OrderBy(i => i)) {
            Console.WriteLine(item);
        }
    }
}
