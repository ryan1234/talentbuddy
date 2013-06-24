using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void mr_reduce(string[] docs) {
        List<int> uniques = new List<int>();
        
        foreach (string doc in docs.ToList()) {
            uniques.AddRange(doc.Split(',').Select(d => Int32.Parse(d)));
        }
        
        foreach (int unique in uniques.Distinct().OrderBy(u => u)) {
        Console.Write(unique + " ");        
        }
    }
}
