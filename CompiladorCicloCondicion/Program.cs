using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese el nombre del archivo:");
        string nombreArchivo = Console.ReadLine();
        string rutaArchivo = $"{nombreArchivo}.txt";

        while (true)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Añadir al archivo");
            Console.WriteLine("2. Leer desde el archivo");
            Console.WriteLine("3. Borrar el archivo");
            Console.WriteLine("4. Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese el texto para añadir al archivo:");
                    string texto = Console.ReadLine();
                    File.AppendAllText(rutaArchivo, texto + Environment.NewLine);
                    Console.WriteLine("Texto añadido correctamente.");
                    break;

                case "2":
                    if (File.Exists(rutaArchivo))
                    {
                        Console.WriteLine("Contenido del archivo:");
                        string contenido = File.ReadAllText(rutaArchivo);
                        Console.WriteLine(contenido);

                        // Verificar y mostrar la estructura de los ciclos
                        MostrarResultadoVerificacion(contenido);
                    }
                    else
                    {
                        Console.WriteLine("El archivo no existe. Primero, añada contenido al archivo.");
                    }
                    break;

                case "3":
                    if (File.Exists(rutaArchivo))
                    {
                        File.Delete(rutaArchivo);
                        Console.WriteLine("Archivo borrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El archivo no existe. No se puede borrar.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Saliendo del programa.");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void MostrarResultadoVerificacion(string texto)
    {
        // Expresiones regulares específicas para cada tipo de ciclo
        string patronSi = @"(?<!\w)si\s*\([^)]*\)\s*\{\s*.*;\s*\}";
        string patronMientras = @"(?<!\w)mientras\s*\([^)]*\)\s*\{\s*.*;\s*\}";
        string patronPara = @"(?<!\w)para\s*\([^;]*;\s*[^;]*;\s*[^)]*\)\s*\{\s*.*;\s*\}";

        // Verificar y mostrar la estructura de los ciclos
        if (Regex.IsMatch(texto, patronSi))
        {
            Console.WriteLine("El ciclo 'si' está bien estructurado en el archivo.");
        }
        else if (Regex.IsMatch(texto, patronMientras))
        {
            Console.WriteLine("El ciclo 'mientras' está bien estructurado en el archivo.");
        }
        else if (Regex.IsMatch(texto, patronPara))
        {
            Console.WriteLine("El ciclo 'para' está bien estructurado en el archivo.");
        }
        else
        {
            Console.WriteLine("No se encontraron ciclos bien estructurados en el archivo.");
        }
    }
}


/*si(condicion) { imprimir("hola"); }
mientras(condicion = verdadera) { imrpimir("hola"); }
para(i = 0; i < 1; i++) { imprimir = ("hola"); }*/