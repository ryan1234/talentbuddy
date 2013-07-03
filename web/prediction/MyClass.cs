using System;

class MyClass {
    public void compute_prediction(int n, int w) {
        double total = n;

        for (int i = 0; i < w; i++) {
            total += (total * 0.07);
        }
        
        Console.WriteLine(Math.Floor(total));
    }
}
