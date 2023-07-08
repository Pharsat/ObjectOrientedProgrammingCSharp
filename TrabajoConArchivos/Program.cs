
namespace TrabajoConArchivos
{
    using System.Runtime.Serialization.Formatters.Binary;
    using System;
    using System.IO;
    using Modelo;

    internal class Program
    {
        static void Main(string[] args)
        {
            var cliente = new ClienteNatural("David")
            {
                Cuenta = new CuentaBancaria(456123, 0)
            };

            cliente.Cuenta.Movimientos = LeerMovimientos(cliente.Cuenta.NumeroDeCuenta);

            MostrarMovimientos(cliente);

            while (true)
            {
                Console.WriteLine("Quieres depositar o retirar, digite D o R segun el caso:");
                string? respuestaDelUsuario = Console.ReadLine();
                string movimiento;
                int multiplicador = 1;

                if (respuestaDelUsuario?.ToUpper() == "D")
                {
                    movimiento = "depositar";
                }
                else if (respuestaDelUsuario?.ToUpper() == "R")
                {
                    movimiento = "retirar";
                    multiplicador *= -1;
                }
                else
                {
                    continue;
                }

                Console.WriteLine($"Cuanto quiere {movimiento}?");
                var cantidad = int.Parse(Console.ReadLine() ?? "0");

                if (cantidad != 0)
                {
                    var movimientoEjecutado = cliente.EjecutarMovimiento(cantidad * multiplicador);
                    GuardarMovimiento(cliente.Cuenta.NumeroDeCuenta, movimientoEjecutado);

                }
                else
                {
                    Console.WriteLine($"La cantidad a {movimiento} es incorrecta");
                }


                MostrarMovimientos(cliente);
            }

            // Obtener los directorios actualmente en la unidad C.
            //DirectoryInfo[] cDirs = new DirectoryInfo(@"C:\xampp").GetDirectories();

            // Escribir cada nombre de directorio en un archivo.
            //using (StreamWriter sw = new StreamWriter("ArchivosEnElDirectorio.txt"))
            //{
            //    foreach (DirectoryInfo dir in cDirs)
            //    {
            //        sw.WriteLine(dir.Name);
            //    }

            //    sw.Flush(); // Guarda los cambios en el archivo explicitamente.
            //}

            //// Leer y mostrar cada línea del archivo.
            //string? line = "";
            //using (StreamReader sr = new StreamReader("ArchivosEnElDirectorio.txt"))
            //{
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}

            //***********************************************************************
            // Escribir datos en formato CSV
            //string[] data = new string[] { "Alice", "Bob", "Charlie" };
            //using (StreamWriter sw = new StreamWriter("data.csv"))
            //{
            //    foreach (string name in data)
            //    {
            //        sw.WriteLine(string.Join(",", name, "Hello " + name + "!"));
            //    }
            //}

            //// Leer datos en formato CSV
            //using (StreamReader sr = new StreamReader("data.csv"))
            //{
            //    string line;
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] values = line.Split(',');
            //        string name = values[0];
            //        string message = values[1];
            //        Console.WriteLine(name + ": " + message);
            //    }
            //}

            //*************************************************************************
            //Person person = new Person { Name = "Alice", Age = 30 };
            //using (Stream stream = File.Open("data.bin", FileMode.Create))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(stream, person);
            //}

            //// Deserializar un objeto desde un archivo
            //using (Stream stream = File.Open("data.bin", FileMode.Open))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    Person person2 = (Person)formatter.Deserialize(stream);
            //    Console.WriteLine(person2.Name + ", " + person2.Age);
            //}

            //**************************************************************************
            // Escribir datos en un archivo binario
            //int[] data = new int[] { 1, 2, 3 };
            //using (BinaryWriter bw = new BinaryWriter(File.Open("data.bin", FileMode.Create)))
            //{
            //    foreach (int value in data)
            //    {
            //        bw.Write(value);
            //    }
            //}

            //// Leer datos desde un archivo binario
            //using (BinaryReader br = new BinaryReader(File.Open("data.bin", FileMode.Open)))
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        int value = br.ReadInt32();
            //        Console.WriteLine(value);
            //    }
            //}

            //*************************************************************************
            //try
            //{
            //    if (Directory.Exists("nonexistent.txt"))
            //    {
            //        using (StreamReader sr = new StreamReader("nonexistent.txt"))
            //        {
            //            // ...
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Cree el archivo primero");
            //    }
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine("El archivo no fue encontrado: " + ex.FileName);
            //}
            //catch (UnauthorizedAccessException ex)
            //{
            //    Console.WriteLine("No tienes permiso para acceder al archivo: " + ex.Message);
            //}

            //**********************************************************************
            // Serializar un objeto en una cadena codificada en base64
            //Person person = new Person { Name = "Alice", Age = 30 };
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    formatter.Serialize(stream, person);
            //    string encodedData = Convert.ToBase64String(stream.ToArray());
            //    Console.WriteLine(encodedData);
            //}

            //// Deserializar un objeto desde una cadena codificada en base64
            //string encodedData = "AAEAAAD/////AQAAAAAAAAAMAgAAAFhNaWNyb3NvZnQuQmluZy5Bc3Npc3RhbnQuTW9kZWxzLCBWZXJzaW9uPTAuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49bnVsbAUBAAAACU1vZGVscy5QZXJzb24BAAAACgBJZABOYW1lA0FnZQMAAAAGAwAAAAxNaWNyb3NvZnQuQmluZwEAAAAHAAAACw==";
            //byte[] data = Convert.FromBase64String(encodedData);
            //using (MemoryStream stream = new MemoryStream(data))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    Person person = (Person)formatter.Deserialize(stream);
            //    Console.WriteLine(person.Name + ", " + person.Age);
            //}
        }

        private static void MostrarMovimientos(ClienteNatural cliente)
        {
            foreach (var movimientoEnCuenta in cliente.Cuenta.Movimientos.OrderByDescending(movimientoBancario =>
                         movimientoBancario.Valor))
            {
                Console.WriteLine($"El dia {movimientoEnCuenta.Fecha:dd/MM/yyyy hh:ss} usted {(movimientoEnCuenta.Valor < 0 ? "retiró" : "depositó")} {movimientoEnCuenta.Valor:N0}");
            }

            var saldo = cliente.Cuenta.Movimientos
                .Sum(movimientoBancario => movimientoBancario.Valor);

            Console.WriteLine("Su nuevo saldo es de: " + saldo);
        }

        public static void GuardarMovimiento(int numeroDeCuenta, MovimientoBancario movimiento)
        {
            var nombreArchivo = NombreArchivo(numeroDeCuenta);
            using (StreamWriter writer = new StreamWriter(nombreArchivo, File.Exists(nombreArchivo)))
            {
                writer.WriteLine($"{movimiento.Fecha},{movimiento.Valor}");
            }
        }

        private static string NombreArchivo(int numeroDeCuenta)
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string exeDir = System.IO.Path.GetDirectoryName(exePath);
            return Path.Combine(exeDir, $"{numeroDeCuenta}.csv");
        }

        public static List<MovimientoBancario> LeerMovimientos(int numeroDeCuenta)
        {
            var movimientos = new List<MovimientoBancario>();
            var nombreArchivo = NombreArchivo(numeroDeCuenta);
            if (File.Exists(nombreArchivo))
            {
                using (StreamReader reader = new StreamReader(nombreArchivo))
                {
                    var textoMovimeinto = reader.ReadLine();
                    while (!string.IsNullOrEmpty(textoMovimeinto))
                    {
                        var arrayMovimiento = textoMovimeinto.Split(',');
                        var fecha = DateTime.Parse(arrayMovimiento[0]);
                        var valor = int.Parse(arrayMovimiento[1]);
                        var movimiento = new MovimientoBancario(fecha, valor);

                        movimientos.Add(movimiento);

                        textoMovimeinto = reader.ReadLine();
                    }
                }
            }
            return movimientos;
        }
    }
}