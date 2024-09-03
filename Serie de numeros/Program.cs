using System;

public class Program
{
    public static void Main(string[] args)
    {
        int numero;
        int n = 100;
        int[] numeros = new int[n];
        int i = 0;

        Console.WriteLine("Ingrese una serie de numeros (Introduzca 0 para parar)");

        do
        {
            Console.Write("Ingrese un número: ");
            numero = int.Parse(Console.ReadLine());

            if (numero != 0 && i < n)
            {
                numeros[i] = numero;
                i++;
            }
        }
        while (numero != 0 && i < n);

        if (i == 0)
        {
            Console.WriteLine("No se ingresaron números válidos.");
          
        }

      
        int maximo = numeros[0];
        int minimo = numeros[0];

        /*el ciclo recorre cada ekemento del arreglo, empezando desde el 1, se excluye el 0 porque con ese se empieza a comparar y
         durante cada iteracion se hace una comparacion y si el valor es menor o mayor, el valor de maximo o minimo se actualiza 
        hasta recorrer todo el arreglo y encontrar los valores maximos y minimos*/

        for (int j = 1; j < i; j++)
        {
            if (numeros[j] > maximo)
                maximo = numeros[j];
            if (numeros[j] < minimo)
                minimo = numeros[j];
        }

        Console.WriteLine($"El número máximo es: {maximo}");
        Console.WriteLine($"El número mínimo es: {minimo}");


    }
}