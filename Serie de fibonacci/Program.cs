using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n;
        int a = 0; 
        int b = 1;

        Console.WriteLine("Ingrese el valor de n hasta donde quiera que se ejecute la serie de Fibonacci:");
        n = int.Parse(Console.ReadLine());

        if (n >= 1)
        {
            Console.WriteLine("El valor de 1 es igual a: {0}", a);
        }

        if (n >= 2)
        {
            Console.WriteLine("El valor de 2 es igual a: {0}", b);
        }

        int c; 
        for (int i = 3; i <= n; i++) 
        {
            c = a + b; 
            Console.WriteLine("El valor de {0} es igual a: {1}", i, c); 
            a = b;   
            b = c;    
        }

        Console.ReadLine(); 
    }
}
