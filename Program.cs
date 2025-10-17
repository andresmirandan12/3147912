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

            //Console.Write("Ingrese el precio del producto: ");
            //double precio = Convert.ToDouble(Console.ReadLine());

            //double descuento = 0;
            //double precioFinal;

            //// Aplicar el descuento si cumple la condición
            //if (precio >= 100000)
            //{
            //    descuento = precio * 0.20;
            //    precioFinal = precio - descuento;
            //    Console.WriteLine($"\nSe aplicó un descuento del 10%.");
            //}
            //else
            //{
            //    precioFinal = precio;
            //    Console.WriteLine($"\nNo se aplica descuento.");
            //}

            //// Mostrar el precio final
            //Console.WriteLine($"El precio final del producto es: ${precioFinal:N2}");



            //BANCO DE PROBLEMAS 
            //1. un estudiante realiza un prestamo a un plazo de 5 años, donde la tasa fija de interes es del 5% anual
            //    , se debe solicitar el monto del prestamo y se desea calcular la siguiente informacion:
            //    Cuanto dinero se ha pagado de interes en un año
            //    cuanto dinero se ha pagado de desinteres en el tercer trimestre del año 
            //    cuanto dinero se ha pagado de interes en el primer mes
            //    cuanto dinero se paga en total del prestamo solicitado incluyendo intereses


            //Console.Write("Ingrese el monto del préstamo: ");
            //float monto = float.Parse(Console.ReadLine());

            //float tasa = 0.05f; 
            //int plazo = 5; 

            //float interesAnual = monto * tasa;
            //float interesTercerTrimestre = monto * tasa * (3f / 12f);
            //float interesPrimerMes = monto * tasa / 12f;
            //float interesTotal = monto * tasa * plazo;
            //float pagoTotal = monto + interesTotal;

            //Console.WriteLine();
            //Console.WriteLine($"Interés pagado en un año: {interesAnual}");
            //Console.WriteLine($"Interés pagado en el tercer trimestre del año: {interesTercerTrimestre}");
            //Console.WriteLine($"Interés pagado en el primer mes: {interesPrimerMes}");
            //Console.WriteLine($"Pago total del préstamo incluyendo intereses: {pagoTotal}");

            //punto 1
            //Console.Write("Ingrese el salario del empleado: ");
            //float salario = float.Parse(Console.ReadLine());

            //Console.Write("Ingrese el valor del ahorro mensual programado: ");
            //float ahorro = float.Parse(Console.ReadLine());

            //float descuentoSalud = salario * 0.125f;
            //float descuentoPension = salario * 0.16f;
            //float totalDescuentos = descuentoSalud + descuentoPension + ahorro;
            //float totalRecibir = salario - totalDescuentos;

            //Console.WriteLine("\n===== COLILLA DE PAGO =====");
            //Console.WriteLine($"Salario del empleado: {salario}");
            //Console.WriteLine($"Ahorro mensual programado: {ahorro}");
            //Console.WriteLine($"Descuento por Salud (12.5%): {descuentoSalud}");
            //Console.WriteLine($"Descuento por Pensión (16%): {descuentoPension}");
            //Console.WriteLine($"Total de descuentos: {totalDescuentos}");
            //Console.WriteLine($" Total a recibir: {totalRecibir}");

            // punto 2//
            //Console.WriteLine("ingrrese el valor de su matricula:");
            //double matricula = double.Parse(Console.ReadLine());

            //double cuota1= matricula * 0.40;
            //double cuota2 = matricula * 0.25;
            //double cuota3 = matricula * 0.20;
            //double cuota4 = matricula * 0.15;

            //Console.WriteLine("\n===== DETALLES DE PAGOS =====");
            //Console.WriteLine($"Valor de la primera cuota: {cuota1}");
            //Console.WriteLine($"Valor de la segunda cuota: {cuota2}");
            //Console.WriteLine($"Valor de la tercera cuota: {cuota3}");
            //Console.WriteLine($"Valor de la cuarta cuota: {cuota4}");


            //Console.WriteLine("=== EJERCICIO 3 ===");
            //Console.Write("Ingrese su nombre: ");
            //string nombre = Console.ReadLine();

            //Console.Write("Ingrese su dirección: ");
            //string direccion = Console.ReadLine();

            //Console.Write("Ingrese su año de nacimiento: ");
            //int anioNacimiento = int.Parse(Console.ReadLine());

            //int anioActual = DateTime.Now.Year;
            //int edad = anioActual - anioNacimiento;

            //Console.WriteLine($"\nNombre: {nombre}");
            //Console.WriteLine($"Dirección: {direccion}");
            //Console.WriteLine($"Año de nacimiento: {anioNacimiento}");
            //Console.WriteLine($"Edad: {edad} años");

            //Console.WriteLine("=== EJERCICIO 4 ===");

            //double tiempo1L = 1.5; 
            //double proporcion = tiempo1L / 1.0;

            //double tiempo3L = 3 * proporcion;
            //double tiempo5L = 5 * proporcion;

            //Console.WriteLine($"Tiempo para llenar balde de 1 litro: {tiempo1L} horas");
            //Console.WriteLine($"Tiempo para llenar balde de 3 litros: {tiempo3L} horas");
            //Console.WriteLine($"Tiempo para llenar balde de 5 litros: {tiempo5L} horas");


            //Console.WriteLine("=== EJERCICIO 5 ===");

            //double tiempo7m = 5; // horas
            //double altura7m = 7; // metros

            //double velocidad = tiempo7m / altura7m; // horas por metro

            //Console.Write("Ingrese la altura que desea subir (en metros): ");
            //double nuevaAltura = double.Parse(Console.ReadLine());

            //double nuevoTiempo = velocidad * nuevaAltura;

            //Console.WriteLine($"El tiempo estimado para subir {nuevaAltura} metros es de {nuevoTiempo:F2} horas");

            Console.WriteLine("=== EJERCICIO 6 ===\n");

         
            Console.Write("Ingrese el monto del préstamo: ");
            double monto = double.Parse(Console.ReadLine());

            
            double tasaAnual = 0.05; 
            int plazoAnios = 5;

            
            double interesAnual = monto * tasaAnual;
            double interesTrimestre = interesAnual / 4;
            double interesMensual = interesAnual / 12;  
            double totalIntereses = interesAnual * plazoAnios;
            double totalPagar = monto + totalIntereses;

            
            Console.WriteLine($"\n--- Resultados ---");
            Console.WriteLine($"Interés pagado en un año: ${interesAnual:F2}");
            Console.WriteLine($"Interés pagado en el tercer trimestre: ${interesTrimestre:F2}");
            Console.WriteLine($"Interés pagado en el primer mes: ${interesMensual:F2}");
            Console.WriteLine($"Total a pagar al finalizar el préstamo (incluyendo intereses): ${totalPagar:F2}");


        }
    }
}
