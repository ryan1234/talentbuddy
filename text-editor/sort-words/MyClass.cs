using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void sort_words(string s) {
        List<string> tokens = new List<string>();
        
        foreach (var tokenSpace in s.Split(' ').ToList()) {
            foreach (var tokenComma in tokenSpace.Split(',').ToList()) {
                if (tokenComma.Trim().Length > 0) {
                    tokens.Add(tokenComma);
                }
            }
        }
        
        foreach (var token in tokens.OrderBy(t => t, StringComparer.Ordinal))
        {
            Console.WriteLine(token);
        }
    }
}
