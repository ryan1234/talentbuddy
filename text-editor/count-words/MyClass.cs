using System;
using System.Collections.Generic;
using System.Linq;

class MyClass {
    public void count_words(string s) {
        List<string> tokens = new List<string>();
        
        foreach (var tokenSpace in s.Split(' ').ToList()) {
            foreach (var tokenComma in tokenSpace.Split(',').ToList()) {
                if (tokenComma.Trim().Length > 0) {
                    tokens.Add(tokenComma);
                }
            }
        }
        
        Console.WriteLine(tokens.Count());
    }
}
