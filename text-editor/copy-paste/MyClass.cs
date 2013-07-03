using System;

class MyClass {
    public void copy_string(string s1, string s2, int p) {
        string str1 = s1.Substring(0, p);
        string str2 = s1.Substring(p, s1.Length - p);
        Console.WriteLine(str1 + s2 + str2);
    }
}
