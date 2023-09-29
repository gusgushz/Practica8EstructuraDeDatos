using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Practica8
{
public class Programa
{
    static void Main(){
        Console.WriteLine ("Defina el tamaño del cuadro mágico");
        int respuesta = int.Parse(Console.ReadLine()!);
        int[,] numerosCuadro = new int[respuesta, respuesta];
        Console.WriteLine("Ingrese numeros consevutivos de 1:");
        for (int i = 0; i < respuesta; i++)
        {
            for (int j = 0; j < respuesta; j++)
            {
                numerosCuadro[i,j] = int.Parse(Console.ReadLine()!);
            }

        }
        for (int i = 0; i < numerosCuadro.GetLength(0); i++)
        {
            for (int j = 0; j < numerosCuadro.GetLength(1); j++)
            {
                Console.Write("{0} ",numerosCuadro[i, j]);
            }
            Console.WriteLine();
        }

        Cuadro cuadrito = new();
        cuadrito.SumarFila(numerosCuadro);
        cuadrito.CompararSumas(numerosCuadro);
        Console.WriteLine(cuadrito.EsMagico);
        Console.WriteLine("La constante mágica de este cuadro es "+cuadrito.CalcularConstanteMagica(numerosCuadro));
    }
}
public class Cuadro{
    public int SumaFila = 0;
    public string EsMagico = "";
    public void SumarFila (int[,] numerosCuadro){

        for (int i = 0; i < numerosCuadro.GetLength(0); i++)
        {
            SumaFila += numerosCuadro[0,i];
        }
    }
    public void CompararSumas (int[,] numerosCuadro){
        for (int i = 0; i < numerosCuadro.GetLength(0); i++)
        {
            int suma = 0;
            int sumaColumna = 0;
            for (int j = 0; j < numerosCuadro.GetLength(1); j++)
            {
                suma += numerosCuadro[i, j];
                sumaColumna += numerosCuadro[j, i];
            }
            if (suma != sumaColumna || suma != SumaFila)
            {
                EsMagico = "No es un cuadro mágico, las sumas no dan";
            } else {
                EsMagico = "Si es un cuadro mágico, las sumas dan el mismo numero";
            }

            int sumaDiagonalPrincipal = 0;
            int sumaDiagonalSecundaria = 0;
            for (int j = 0; j < numerosCuadro.GetLongLength(0); j++)
            {
                sumaDiagonalPrincipal += numerosCuadro[i, i];
                sumaDiagonalSecundaria += numerosCuadro[i, numerosCuadro.GetLongLength(0) - i - 1];
            }
            if (sumaDiagonalPrincipal == sumaDiagonalSecundaria && sumaDiagonalPrincipal == SumaFila){
                Console.WriteLine("La constante mágica es la misma en la diagonal");
            }
        }
    }
    public int CalcularConstanteMagica(int[,] numerosCuadro)
    {
        int n = numerosCuadro.GetLength(0);
        return (n * (n * n + 1)) / 2;
    }
}
}
