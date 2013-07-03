using System;

class MyClass {
    public void remove_substring(string s, int p, int n) {
        string str1 = s.Substring(0, p - 1);
        string str2 = s.Substring(p - 1 + n, s.Length - str1.Length - n);
        Console.WriteLine(str1 + str2);
        //Console.WriteLine(str2);
    }
}
