using System;

class MyClass {
    public void count_configurations(int a, int b, int c, int n) {
        int counted = 0;
        
        for (int i = 0; i <= a; i++) {
            for (int j = 0; j <= b; j++) {
                for (int k = 0; k <= c; k++) {
                    if (i + j + k == n) { counted++; }
                }
            }
        }
        
        Console.WriteLine(counted);
    }
}
