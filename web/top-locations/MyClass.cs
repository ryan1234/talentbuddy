using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void sort_locations(int a, int b, int c) {
        List<int> ints = new List<int>();
        ints.Add(a);
        ints.Add(b);
        ints.Add(c);
        
        foreach (var i in ints.OrderBy(z => z)) {
            Console.Write(i + " ");
        }
    }
}
