using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ARRAYS//
            //int[] numeros=new int[3];
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine("Ingrese un numero:");
            //    numeros[i]=int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("\nNumeros ingresados:");
            //foreach (var item in numeros)
            //{
            //    Console.WriteLine(item);
            //}
            //int suma=0;
            //for (int i = 0; i < 3; i++)
            //{
            //    suma+=numeros[i];
            //}
            //Console.WriteLine("\nLa suma de los numeros es: "+suma);

            //LISTAS//
            //List<int> numeros = new List<int>();
            //numeros.Add(10);
            //numeros.Add(20);
            //numeros.Add(30);
            //Console.WriteLine("Numeros en la lista:");
            //foreach (int item in numeros)
            //{
            //    Console.WriteLine(item);
            //}
            ////acceder a un elemento por su indice
            //int primerNumero = numeros[1];
            //Console.WriteLine($"El segundo numero en la lista es:  {primerNumero}");
            ////modificar un elemento por su indice
            //numeros[2] = 50;
            //Console.WriteLine($"Numero Modificado:{numeros[2]}");
            ////insertar un elemento en una posicion especifica
            //numeros.Insert(2, 15);
            //Console.WriteLine($"Numero Modificado:{numeros[2]}");
            ////eliminar un elemento por posicion
            //numeros.RemoveAt(1);//elimina la posicion 1

            ////eliminar un elemento por su valor
            //numeros.Remove(10);//elimina el numero 10

            //EJERCICIO #1: GESTION DE PRODUCTOS 

        }
          class Producto
        {
            public string Nombre { get; set; }
            public double Precio { get; set; }
        }

        static void Main()
        {
            List<Producto> productos = new List<Producto>(); // Lista vacía
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ DE PRODUCTOS =====");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar productos");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Salir");
                Console.WriteLine("=============================");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("\n❌ Opción inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarProducto(productos);
                        break;
                    case 2:
                        MostrarProductos(productos);
                        break;
                    case 3:
                        ActualizarProducto(productos);
                        break;
                    case 4:
                        EliminarProducto(productos);
                        break;
                    case 5:
                        Console.WriteLine("\n👋 Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción no válida. Intente nuevamente.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresione una tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        // === MÉTODOS ===

        // 1️ Agregar producto
        static void AgregarProducto(List<Producto> productos)
        {
            Console.Write("\nIngrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el precio del producto: ");
            if (double.TryParse(Console.ReadLine(), out double precio))
            {
                productos.Add(new Producto { Nombre = nombre, Precio = precio });
                Console.WriteLine("✅ Producto agregado correctamente.");
            }
            else
            {
                Console.WriteLine("❌ Precio inválido.");
            }
        }

        // 2️ Mostrar productos
        static void MostrarProductos(List<Producto> productos)
        {
            Console.WriteLine("\n=== LISTA DE PRODUCTOS ===");

            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return;
            }

            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productos[i].Nombre} - ${productos[i].Precio:F2}");
            }
        }

        // 3️ Actualizar producto
        static void ActualizarProducto(List<Producto> productos)
        {
            MostrarProductos(productos);
            if (productos.Count == 0) return;

            Console.Write("\nIngrese el número del producto a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= productos.Count)
            {
                Producto producto = productos[index - 1];

                Console.Write($"Nuevo nombre ({producto.Nombre}): ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                    producto.Nombre = nuevoNombre;

                Console.Write($"Nuevo precio ({producto.Precio}): ");
                if (double.TryParse(Console.ReadLine(), out double nuevoPrecio))
                    producto.Precio = nuevoPrecio;

                Console.WriteLine("✅ Producto actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("❌ Número inválido.");
            }
        }

        // 4️ Eliminar producto
        static void EliminarProducto(List<Producto> productos)
        {
            MostrarProductos(productos);
            if (productos.Count == 0) return;

            Console.Write("\nIngrese el número del producto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= productos.Count)
            {
                productos.RemoveAt(index - 1);
                Console.WriteLine("🗑️ Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("❌ Número inválido.");
            }


        }


        }
    }
