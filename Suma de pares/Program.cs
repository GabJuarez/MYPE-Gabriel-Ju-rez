using System;

public class Program
{
    public static void Main(string[] args)
    {
        int numero;
        int suma = 0;

        Console.WriteLine("Ingrese un número hasta donde quiera que termine la suma de sus pares anteriores:");
        numero = int.Parse(Console.ReadLine());

        for (int cont = 1; cont <= numero; cont++)
        {
            if (cont % 2 == 0)
            {
                suma += cont;
            }
        }

        Console.WriteLine("La suma de los pares hasta {0} es: {1}", numero, suma);
    }
}
