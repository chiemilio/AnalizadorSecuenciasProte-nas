using System;
using System.Collections.Generic;

public class Aminoacido
{
    // Diccionario que contiene la información de los aminoácidos
    private static Dictionary<string, string[]> _aminoacidos = new Dictionary<string, string[]>()
    {
        {"ALA", new [] {"No Polar", "No Cargado", "Hidrofóbico"}},
        {"ARG", new [] {"Polar", "Cargado Positivo", "No Hidrofóbico"}},
        {"ASN", new [] {"Polar", "No Cargado", "No Hidrofóbico"}},
        {"ASP", new [] {"Polar", "Cargado Negativo", "No Hidrofóbico"}},
        {"CYS", new [] {"Polar", "No Cargado", "Hidrofóbico"}},
        {"GLN", new [] {"Polar", "No Cargado", "No Hidrofóbico"}},
        {"GLU", new [] {"Polar", "Cargado Negativo", "No Hidrofóbico"}},
        {"GLY", new [] {"No Polar", "No Cargado", "Hidrofóbico"}},
        {"HIS", new [] {"Polar", "Cargado Positivo", "No Hidrofóbico"}},
        {"ILE", new [] {"No Polar", "No Cargado", "Hidrofóbico"}},
        {"LEU", new [] {"No Polar", "No Cargado", "Hidrofóbico"}},
        {"LYS", new [] {"Polar", "Cargado Positivo", "No Hidrofóbico"}},
        {"MET", new [] {"No Polar", "No Cargado", "Hidrofóbico"}},
        {"PHE", new [] {"No Polar", "No Cargado", "Hidrofóbico"}},
        {"PRO", new [] {"No Polar", "No Cargado", "Hidrofóbico"}},
        {"SER", new [] {"Polar", "No Cargado", "No Hidrofóbico"}},
        {"THR", new [] {"Polar", "No Cargado", "No Hidrofóbico"}},
        {"TRP", new [] {"No Polar", "No Cargado", "Hidrofóbico"}},
        {"TYR", new [] {"Polar", "No Cargado", "No Hidrofóbico"}},
        {"VAL", new [] {"No Polar", "No Cargado", "Hidrofóbico"}}
    };

    // Propiedades de la clase
    public string Nombre { get; set; }
    public string Polaridad { get; set; }
    public string Carga { get; set; }
    public string Hidrofilicidad { get; set; }

    // Método para validar si un aminoácido es válido
    public static bool EsAminoacidoValido(string nombre)
    {
        return _aminoacidos.ContainsKey(nombre);
    }

    // Métodos para obtener las propiedades de un aminoácido
    public static string ObtenerPolaridad(string nombre)
    {
        return EsAminoacidoValido(nombre) ? _aminoacidos[nombre][0] : "Desconocida";
    }

    public static string ObtenerCarga(string nombre)
    {
        return EsAminoacidoValido(nombre) ? _aminoacidos[nombre][1] : "Desconocida";
    }

    public static string ObtenerHidrofilicidad(string nombre)
    {
        return EsAminoacidoValido(nombre) ? _aminoacidos[nombre][2] : "Desconocida";
    }
}

public class Programa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al Analizador de Secuencias de Aminoácidos.");
        Console.WriteLine("Ingrese una secuencia de aminoácidos separados por guiones (Ejemplo: ALA-GLY-VAL):");
        string entrada = Console.ReadLine();

        List<string> secuencia = new List<string>(entrada.Split('-'));
        List<string> secuenciaValida = new List<string>();

        foreach (var amino in secuencia)
        {
            if (Aminoacido.EsAminoacidoValido(amino))
            {
                secuenciaValida.Add(amino);
            }
            else
            {
                Console.WriteLine($"Aminoácido inválido encontrado: {amino}");
            }
        }

        if (secuenciaValida.Count > 0)
        {
            Console.WriteLine("\nAnálisis de Secuencia:");
            Console.WriteLine($"Secuencia: {string.Join("-", secuenciaValida)}");
            Console.WriteLine($"Total de Aminoácidos: {secuenciaValida.Count}");

            // Proporciones de cada categoría
            int cargados = 0, polares = 0, hidrofobicos = 0;
            foreach (var amino in secuenciaValida)
            {
                if (Aminoacido.ObtenerCarga(amino).Contains("Cargado")) cargados++;
                if (Aminoacido.ObtenerPolaridad(amino).Contains("Polar")) polares++;
                if (Aminoacido.ObtenerHidrofilicidad(amino).Contains("Hidrofóbico")) hidrofobicos++;
            }

            Console.WriteLine($"Cargados: {cargados}/{secuenciaValida.Count} ({(cargados * 100.0 / secuenciaValida.Count):0.##}%)");
            Console.WriteLine($"Polares: {polares}/{secuenciaValida.Count} ({(polares * 100.0 / secuenciaValida.Count):0.##}%)");
            Console.WriteLine($"Hidrofóbicos: {hidrofobicos}/{secuenciaValida.Count} ({(hidrofobicos * 100.0 / secuenciaValida.Count):0.##}%)");
        }
        else
        {
            Console.WriteLine("La secuencia ingresada no contiene aminoácidos válidos.");
        }
    }
}

