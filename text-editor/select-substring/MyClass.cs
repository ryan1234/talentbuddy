using System;

class MyClass {
    public void select_substring(string s, int p1, int p2) {
        Console.WriteLine(s.Substring(p1 - 1, p2 - p1 + 1));        
    }
}
