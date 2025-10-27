//// EJERCICIO 1
//using System;

//class Program1
//{
//    static void Main()
//    {
//        Console.Write("Ingrese el monto del préstamo: ");
//        if (!decimal.TryParse(Console.ReadLine(), out decimal principal)) return;
//        decimal annualRate = 0.05m;
//        int years = 5;

//        // Intereses
//        decimal interestPerYear = principal * annualRate;
//        decimal interestThirdQuarter = principal * annualRate * (3m / 12m); // 3 meses
//        decimal interestFirstMonth = principal * annualRate / 12m;
//        decimal totalInterest = interestPerYear * years;
//        decimal totalToPay = principal + totalInterest;

//        Console.WriteLine($"\nInterés pagado en un año: {interestPerYear:C}");
//        Console.WriteLine($"Interés pagado en el tercer trimestre (3 meses): {interestThirdQuarter:C}");
//        Console.WriteLine($"Interés pagado en el primer mes: {interestFirstMonth:C}");
//        Console.WriteLine($"Total pagado incluyendo intereses (a {years} años, interés simple): {totalToPay:C}");
//    }
//}


// EJERCICIO 2
//using System;

//class Program2
//{
//    static void Main()
//    {
//        Console.Write("Ingrese salario del empleado: ");
//        if (!decimal.TryParse(Console.ReadLine(), out decimal salario)) return;
//        Console.Write("Ingrese valor de ahorro mensual programado: ");
//        if (!decimal.TryParse(Console.ReadLine(), out decimal ahorro)) return;

//        decimal epsRate = 0.125m;
//        decimal pensionRate = 0.16m;

//        decimal descuentoEPS = salario * epsRate;
//        decimal descuentoPension = salario * pensionRate;
//        decimal totalDeducciones = descuentoEPS + descuentoPension + ahorro;
//        decimal totalRecibir = salario - descuentoEPS - descuentoPension - ahorro;

//        Console.WriteLine("\n--- Colilla de Pago ---");
//        Console.WriteLine($"Salario: {salario:C}");
//        Console.WriteLine($"Ahorro mensual programado: {ahorro:C}");
//        Console.WriteLine($"Descuento EPS (12.5%): {descuentoEPS:C}");
//        Console.WriteLine($"Descuento Fondo de Pensiones (16%): {descuentoPension:C}");
//        Console.WriteLine($"Total deducciones: {totalDeducciones:C}");
//        Console.WriteLine($"Total a recibir: {totalRecibir:C}");
//    }
//}


// EJERCICIO 3
//using System;

//class Persona
//{
//    public string Nombre { get; set; }
//    public int Edad { get; set; }
//    public char Genero { get; set; } // 'F' o 'M'
//    public string Telefono { get; set; }

//    public Persona(string nombre, int edad, char genero, string telefono)
//    {
//        Nombre = nombre; Edad = edad; Genero = genero; Telefono = telefono;
//    }

//    public void Editar(string nombre, int edad, char genero, string telefono)
//    {
//        Nombre = nombre; Edad = edad; Genero = genero; Telefono = telefono;
//    }

//    public void ImprimirDetalles()
//    {
//        Console.WriteLine($"Nombre: {Nombre}");
//        Console.WriteLine($"Edad: {Edad}");
//        Console.WriteLine($"Género: {Genero}");
//        Console.WriteLine($"Teléfono: {Telefono}");
//    }

//    public int CalcularEdadEnDias()
//    {
//        return Edad * 365; // aproximación sencilla
//    }
//}

//class Program3
//{
//    static void Main()
//    {
//        Console.WriteLine("Ingrese nombre: "); string nombre = Console.ReadLine();
//        Console.WriteLine("Ingrese edad: "); int edad = int.Parse(Console.ReadLine());
//        Console.WriteLine("Ingrese género (F/M): "); char gen = char.ToUpper(Console.ReadLine()[0]);
//        Console.WriteLine("Ingrese teléfono: "); string tel = Console.ReadLine();

//        Persona p = new Persona(nombre, edad, gen, tel);

//        while (true)
//        {
//            Console.WriteLine("\n1) Imprimir detalles\n2) Calcular edad en días\n3) Editar\n4) Salir");
//            string opt = Console.ReadLine();
//            if (opt == "1") p.ImprimirDetalles();
//            else if (opt == "2") Console.WriteLine($"Edad en días (aprox): {p.CalcularEdadEnDias()} días");
//            else if (opt == "3")
//            {
//                Console.Write("Nuevo nombre: "); string nn = Console.ReadLine();
//                Console.Write("Nueva edad: "); int ne = int.Parse(Console.ReadLine());
//                Console.Write("Nuevo género (F/M): "); char ng = char.ToUpper(Console.ReadLine()[0]);
//                Console.Write("Nuevo teléfono: "); string nt = Console.ReadLine();
//                p.Editar(nn, ne, ng, nt);
//                Console.WriteLine("Datos actualizados.");
//            }
//            else break;
//        }
//    }
//}



// EJERCICIO 4
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Libro
//{
//    public string Titulo { get; set; }
//    public string Autor { get; set; }
//    public string Editorial { get; set; }
//    public int AnioPublicacion { get; set; }
//    public Libro(string t, string a, string e, int an)
//    {
//        Titulo = t; Autor = a; Editorial = e; AnioPublicacion = an;
//    }
//}

//class Biblioteca
//{
//    private List<Libro> libros = new List<Libro>();
//    public void AgregarLibro(Libro l) => libros.Add(l);
//    public void ListarLibros()
//    {
//        if (!libros.Any()) { Console.WriteLine("No hay libros."); return; }
//        foreach (var l in libros) Console.WriteLine($"{l.Titulo} - {l.Autor} ({l.AnioPublicacion}) - {l.Editorial}");
//    }
//    public Libro BuscarPorNombre(string nombre) => libros.FirstOrDefault(x => x.Titulo.Equals(nombre, StringComparison.OrdinalIgnoreCase));
//}

//class Program4
//{
//    static void Main()
//    {
//        Biblioteca b = new Biblioteca();
//        while (true)
//        {
//            Console.WriteLine("\n1) Agregar libro\n2) Listar libros\n3) Buscar libro\n4) Salir");
//            string op = Console.ReadLine();
//            if (op == "1")
//            {
//                Console.Write("Titulo: "); var t = Console.ReadLine();
//                Console.Write("Autor: "); var a = Console.ReadLine();
//                Console.Write("Editorial: "); var e = Console.ReadLine();
//                Console.Write("Año publicación: "); var an = int.Parse(Console.ReadLine());
//                b.AgregarLibro(new Libro(t, a, e, an));
//                Console.WriteLine("Libro agregado.");
//            }
//            else if (op == "2") b.ListarLibros();
//            else if (op == "3")
//            {
//                Console.Write("Nombre a buscar: "); var q = Console.ReadLine();
//                var res = b.BuscarPorNombre(q);
//                Console.WriteLine(res == null ? "No encontrado." : $"{res.Titulo} - {res.Autor} ({res.AnioPublicacion})");
//            }
//            else break;
//        }
//    }
//}

// EJERCICIO 5
//using System;
//using System.Collections.Generic;

//class Program5
//{
//    static void Main()
//    {
//        var programas = new Dictionary<int, (string nombre, int creditos, decimal descuento)> {
//            {1,("Ingeniería de sistemas",20,0.18m)},
//            {2,("Psicología",16,0.12m)},
//            {3,("Economía",18,0.10m)},
//            {4,("Comunicación Social",18,0.05m)},
//            {5,("Administración de Empresas",20,0.15m)}
//        };
//        const decimal valorCredito = 200000m;

//        Console.Write("¿Cuántos estudiantes desea matricular? ");
//        int n = int.Parse(Console.ReadLine());

//        var inscritosPorPrograma = new int[6]; // indices 1..5
//        int totalCreditos = 0;
//        decimal totalSinDescuento = 0m;
//        decimal totalDescuentos = 0m;

//        for (int i = 0; i < n; i++)
//        {
//            Console.WriteLine($"\nEstudiante {i + 1}:");
//            foreach (var p in programas) Console.WriteLine($"{p.Key}) {p.Value.nombre} - {p.Value.creditos} créditos - {p.Value.descuento:P} descuento efectivo");
//            Console.Write("Seleccione programa (1-5): "); int key = int.Parse(Console.ReadLine());
//            Console.Write("Forma de pago (Efectivo/Linea): "); string forma = Console.ReadLine().Trim().ToLower();
//            var prog = programas[key];
//            inscritosPorPrograma[key]++;
//            totalCreditos += prog.creditos;
//            decimal valor = prog.creditos * valorCredito;
//            totalSinDescuento += valor;
//            if (forma == "efectivo")
//            {
//                decimal desc = valor * prog.descuento;
//                totalDescuentos += desc;
//            }
//        }

//        decimal valorNeto = totalSinDescuento - totalDescuentos;
//        Console.WriteLine("\n--- Resultados ---");
//        for (int k = 1; k <= 5; k++) Console.WriteLine($"{programas[k].nombre}: {inscritosPorPrograma[k]} inscritos");
//        Console.WriteLine($"Total créditos inscritos: {totalCreditos}");
//        Console.WriteLine($"Valor total sin descuentos: {totalSinDescuento:C}");
//        Console.WriteLine($"Valor total descuentos aplicados: {totalDescuentos:C}");
//        Console.WriteLine($"Valor neto de inscripciones: {valorNeto:C}");
//    }
//}


// EJERCICIOO 6
//using System;
//using System.Collections.Generic;

//class Program6
//{
//    static void Main()
//    {
//        const decimal pagoBasico = 500000m;
//        Console.Write("¿Cuántos empleados? ");
//        int n = int.Parse(Console.ReadLine());
//        for (int i = 1; i <= n; i++)
//        {
//            Console.WriteLine($"\nEmpleado {i}:");
//            Console.Write("¿Cuántas ventas realizó hoy? ");
//            int m = int.Parse(Console.ReadLine());
//            int contMenorIgual300 = 0, cont300_800 = 0, contMayorIgual800 = 0;
//            decimal totalVentas = 0m, totalBonificacion = 0m;
//            for (int j = 0; j < m; j++)
//            {
//                Console.Write($"Valor venta {j + 1}: ");
//                decimal v = decimal.Parse(Console.ReadLine());
//                totalVentas += v;
//                if (v <= 300000) contMenorIgual300++;
//                else if (v > 300000 && v < 800000) cont300_800++;
//                else contMayorIgual800++;

//                // Bonificación según tabla del enunciado
//                decimal bon = 0m;
//                if (v >= 800000) bon = v * 0.10m;
//                else if (v >= 400001 && v <= 800000) bon = v * 0.05m;
//                else if (v >= 400000) bon = v * 0.03m; // note: enunciado conflictivo; adaptado conservadoramente
//                totalBonificacion += bon;
//            }
//            decimal pagoTotal = pagoBasico + totalBonificacion;
//            Console.WriteLine($"\nEmpleado {i} - Resumen:");
//            Console.WriteLine($"Ventas <= 300.000: {contMenorIgual300}");
//            Console.WriteLine($"Ventas entre 300.001 y 799.999: {cont300_800}");
//            Console.WriteLine($"Ventas >= 800.000: {contMayorIgual800}");
//            Console.WriteLine($"Monto total ventas: {totalVentas:C}");
//            Console.WriteLine($"Bonificaciones totales: {totalBonificacion:C}");
//            Console.WriteLine($"Pago básico: {pagoBasico:C} - Pago total a recibir: {pagoTotal:C}");
//        }
//    }
//}


// EJERCICIO 7
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program7
//{
//    static void Main()
//    {
//        Console.Write("¿Cuántos conductores registrados? ");
//        int n = int.Parse(Console.ReadLine());
//        int menores30 = 0, hombres = 0, mujeres = 0, hombres12a30 = 0, fueraBogota = 0;
//        for (int i = 0; i < n; i++)
//        {
//            Console.Write($"\nAño de nacimiento conductor {i + 1}: "); int an = int.Parse(Console.ReadLine());
//            int edad = DateTime.Now.Year - an;
//            Console.Write("Sexo (1=Femenino, 2=Masculino): "); int s = int.Parse(Console.ReadLine());
//            Console.Write("Registro del carro (1=Bogotá, 2=Otras): "); int reg = int.Parse(Console.ReadLine());

//            if (edad < 30) menores30++;
//            if (s == 2)
//            {
//                hombres++;
//                if (edad >= 12 && edad <= 30) hombres12a30++;
//            }
//            else mujeres++;
//            if (reg == 2) fueraBogota++;
//        }

//        Console.WriteLine("\n--- Resultados ---");
//        Console.WriteLine($"% conductores menores de 30: {(double)menores30 / n * 100:F2}%");
//        Console.WriteLine($"% conductores masculinos: {(double)hombres / n * 100:F2}%");
//        Console.WriteLine($"% conductores femeninos: {(double)mujeres / n * 100:F2}%");
//        Console.WriteLine($"% conductores masculinos entre 12 y 30: {(double)hombres12a30 / n * 100:F2}%");
//        Console.WriteLine($"% conductores con carro fuera de Bogotá: {(double)fueraBogota / n * 100:F2}%");
//    }
//}


// EJERCICIO 8
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;

//class Program8
//{
//    static void Main()
//    {
//        Console.Write("¿Cuántos empleados registrar? ");
//        int n = int.Parse(Console.ReadLine());
//        var mesesCount = new int[13]; // 1..12
//        int totalValidos = 0;
//        int sumaEdades = 0;
//        const decimal bono = 150000m;

//        for (int i = 0; i < n; i++)
//        {
//            Console.Write($"\nFecha de nacimiento empleado {i + 1} (yyyy-MM-dd): ");
//            DateTime fn = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
//            int edad = DateTime.Now.Year - fn.Year;
//            if (fn > DateTime.Now.AddYears(-edad)) edad--;
//            if (edad > 18 && edad < 50)
//            {
//                totalValidos++;
//                sumaEdades += edad;
//                mesesCount[fn.Month]++;
//            }
//        }

//        Console.WriteLine("\n--- Resultados ---");
//        if (totalValidos > 0) Console.WriteLine($"Promedio de edades (empleados con bono): {(double)sumaEdades / totalValidos:F2}");
//        else Console.WriteLine("No hay empleados con edad entre 19 y 49 (incl.).");

//        decimal totalBonos = 0m;
//        for (int m = 1; m <= 12; m++)
//        {
//            decimal dineroMes = mesesCount[m] * bono;
//            totalBonos += dineroMes;
//            Console.WriteLine($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m)}: {mesesCount[m]} empleados - Dinero en bonos: {dineroMes:C}");
//        }
//        Console.WriteLine($"Total a provisionar en bonos: {totalBonos:C}");
//    }
//}


// Problem9_CargaCamiones.cs
using System;

class Program9
{
    static void Main()
    {
        Console.Write("¿Cuántos camiones se cargarán hoy? (máx 20): ");
        int num = int.Parse(Console.ReadLine());
        if (num > 20) num = 20;

        for (int i = 1; i <= num; i++)
        {
            Console.WriteLine($"\nCamión {i}:");
            Console.Write("Capacidad del camión (litros): ");
            int capacidad = int.Parse(Console.ReadLine());
            Console.Write("¿Cuántas sacas llegan en esta tanda? ");
            int sacas = int.Parse(Console.ReadLine());
            int cargado = 0;
            for (int s = 1; s <= sacas; s++)
            {
                Console.Write($"Litros saca {s}: ");
                int litros = int.Parse(Console.ReadLine());
                if (cargado + litros <= capacidad)
                {
                    cargado += litros;
                    Console.WriteLine($"Saca cargada. Carga actual: {cargado}/{capacidad}");
                }
                else
                {
                    Console.WriteLine("Al cargar esta saca se excede la capacidad. Despache el camión y comience a cargar otro.");
                    break;
                }
            }
            Console.WriteLine($"Camión {i} terminó con {cargado} litros cargados (capacidad {capacidad}).");
        }
    }
}
