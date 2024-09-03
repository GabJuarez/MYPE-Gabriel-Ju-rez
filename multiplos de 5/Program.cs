using System;

public class Program
{
    public static void Main(string[] args)
    {
        int numero;
        int contadorMultiplos = 0;

        Console.WriteLine("Ingrese un número, se le mostrarán los números múltiplos de 5 entre 1 y el número ingresado:");
        numero = int.Parse(Console.ReadLine());

        for (int cont = 1; cont < numero; cont++)
        {
            if (cont % 5 == 0)
            {
                contadorMultiplos++;
                Console.WriteLine("El {0}º múltiplo de 5 entre 1 y {1} es: {2}", contadorMultiplos, numero, cont);
            }
        }

        // Mostrar el total final de múltiplos de 5
        Console.WriteLine("El total de múltiplos de 5 entre 1 y {0} es: {1}", numero, contadorMultiplos);
    }
}
