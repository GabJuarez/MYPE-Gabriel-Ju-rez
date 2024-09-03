using System;

public class Program
{
    public static void Main(string[] args)
    {
        int numero;
        int factorial = 1;
        int i = 1;

        Console.WriteLine("Ingrese el numero al que le desea calcular el factorial: ");
        numero = int.Parse(Console.ReadLine());

        if (numero < 0)
        {
            Console.WriteLine("El factorial de un numero negativo no esta definido");
        }
        else while (i <= numero) 
            {
                factorial *= i;
                i++;
            }

        Console.Clear();
        Console.WriteLine("El factorial de {0} es: {1}", numero, factorial);
    }
}