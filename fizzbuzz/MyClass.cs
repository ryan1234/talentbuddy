class MyClass {
    public void fizzbuzz(int n) {
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0) {
                System.Console.WriteLine("FizzBuzz");
            } 
            else if (i % 3 == 0 || i % 5 == 0)
            {
                if (i % 3 == 0) {
                    System.Console.WriteLine("Fizz");
                }
            
                if (i % 5 == 0) {
                    System.Console.WriteLine("Buzz");
                }
            }
            else
            {
                System.Console.WriteLine(i);
            }
        }
        
    }
}
