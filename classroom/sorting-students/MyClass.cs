using System;
using System.Linq;

class MyClass {
    public void sort_students(int[] numbers) {
        Console.WriteLine(String.Join(" ", numbers.ToList().OrderBy(n => n)));
        
    }
}
