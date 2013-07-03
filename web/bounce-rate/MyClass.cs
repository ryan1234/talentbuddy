using System;

class MyClass {
    public void compute_active_users(int n, int b) {
        double percent = (b / 100.0);
        double answer = Math.Floor(n - (n * percent));
        Console.Write(answer);
        
    }
}
