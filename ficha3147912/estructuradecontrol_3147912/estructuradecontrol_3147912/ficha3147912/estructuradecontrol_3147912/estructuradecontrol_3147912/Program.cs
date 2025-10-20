using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estructuradecontrol_3147912
{
    internal class Program
    {
        static void Main(string[] args)  //punto de partida
        {
            ////tipos de datos
            //int numero1 = 10;
            //string nombre = "juan"; //siempre con comillas dobles
            //char letra = 'a';  //siempre con comillas simples
            //decimal precio = 20.5m; //siempre con la m al final
            //float altura = 30.5f; //siempre con la f al final
            //bool esverdadero = true;//true o false
            //DateTime fecha = DateTime.Now; //fecha y hora actual


            ////estructura de control//
            //Console.WriteLine("ingrese su edad: ");
            //int numero = int.Parse(Console.ReadLine()); //readline para leer la entrada del usuario
            //Console.WriteLine("su edad es: " + numero);
            //Console.WriteLine($"su edad es: {numero}");



            //Console.WriteLine("ingrese su nota 1: ");
            //float nota1 = float.Parse(Console.ReadLine());
            //Console.WriteLine("ingrese su nota 2: ");
            //float nota2 = float.Parse(Console.ReadLine());
            //Console.WriteLine("ingrese su nota 3: ");
            //float nota3 = float.Parse(Console.ReadLine());
            //if (nota1 < 0 | nota1 > 5 | nota2 < 0 | nota2 > 5 | nota3 < 0 | nota3 > 5)
            //{
            //    Console.WriteLine("nota invalida");
            //    return; 
            //}

            //float promedio = (nota1 * 0.2f) + (nota2 * 0.3f) + (nota3 * 0.5f);
            //if (promedio >= 3)
            //{
            //    Console.WriteLine("aprobado");
            //}
            //else
            //{
            //    Console.WriteLine("reprobado");
            //}

            Console.Write("Ingrese el precio del producto: ");
            double precio = Convert.ToDouble(Console.ReadLine());

            double descuento = 0;
            double precioFinal;

            // Aplicar el descuento si cumple la condición
            if (precio >= 100000)
            {
                descuento = precio * 0.20;
                precioFinal = precio - descuento;
                Console.WriteLine($"\nSe aplicó un descuento del 10%.");
            }
            else
            {
                precioFinal = precio;
                Console.WriteLine($"\nNo se aplica descuento.");
            }

            // Mostrar el precio final
            Console.WriteLine($"El precio final del producto es: ${precioFinal:N2}");


        }
    }
}
