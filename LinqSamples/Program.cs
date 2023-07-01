using System.Text.Json;

namespace LinqSamples
{
    using System.Linq.Expressions;

    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // Crear una lista de estudiantes
            List<Student> students = new List<Student>()
            {
                new Student { Name = "Juan", Age = 19, Major = "Computer Science" },
                new Student { Name = "Maria", Age = 21, Major = "Mathematics" },
                new Student { Name = "Pedro", Age = 22, Major = "Physics" },
                new Student { Name = "Cristian", Age = 25, Major = "Physics" },
                new Student { Name = "Ana", Age = 20, Major = "Computer Science" }
            };

            var departamentos = JsonSerializer
                .Deserialize<List<Departamento>>((await CallAPI("https://api-colombia.com/api/v1/Department").ConfigureAwait(false))!);

            Console.WriteLine("La cantidad de departamentos cuya poblacion es menor a 80.000 es: " + departamentos.Count(departamento => departamento.population < 80000));

            foreach (var departamento in departamentos
                         .OrderBy(departamento => departamento.name)
                         .Where(departamento=> departamento.population < 80000))
            {
                Console.WriteLine(departamento.id + " --- " + departamento.name);
            }

            Console.WriteLine("Digite el Id del departamento del cual quiere ver los sitios turisticos");
            var idDepartamento = int.Parse(Console.ReadLine());

            var sitiosTuristicos = JsonSerializer
                .Deserialize<List<SitiosTuristicos>>((await CallAPI($"https://api-colombia.com/api/v1/Department/{idDepartamento}/touristicattractions").ConfigureAwait(false))!);

            foreach (var sitio in sitiosTuristicos.OrderBy(sitio => sitio.name))
            {
                Console.WriteLine(sitio.name);
                Console.WriteLine(sitio.description);
                Console.WriteLine();
            }

            /*
             * LINQ (Language Integrated Query) proporciona una serie de operadores estándar
             * para realizar operaciones comunes en colecciones de datos.
             * Algunas de las funciones más comunes en LINQ incluyen:
             *
                Where: filtra una secuencia de valores basándose en un predicado.
                Select: proyecta cada elemento de una secuencia en un nuevo formulario.
                OrderBy: ordena los elementos de una secuencia en orden ascendente.
                GroupBy: agrupa los elementos de una secuencia según una clave especificada.
                First: devuelve el primer elemento de una secuencia.
                FirstOrDefault: devuelve el primer elemento de una secuencia o un valor predeterminado si la secuencia no contiene elementos.
                Single: devuelve el único elemento de una secuencia.
                SingleOrDefault: devuelve el único elemento de una secuencia o un valor predeterminado si la secuencia no contiene elementos.
                Any: determina si algún elemento de una secuencia satisface una condición.
                Count: devuelve el número de elementos en una secuencia.
             */
        }

        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Major { get; set; }
        }

        class Departamento
        {
            public int id { get; set; }
            public string name { get; set; }
            public int population { get; set; }

        }

        class SitiosTuristicos
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
        }

        public static async Task<string?> CallAPI(string url)
        {
            try
            {
                // Crear una instancia de HttpClient
                using var client = new HttpClient();

                // Hacer una solicitud GET a la URL especificada
                var response = await client
                    .GetAsync(url)
                    .ConfigureAwait(false);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }

                return null;
            }
            catch (System.Text.Json.JsonException jsonException)
            {
                Console.WriteLine("Ocurrio un error con los datos que llegaron del servidor " + jsonException.Message);
            }
            catch (HttpRequestException jsonException)
            {
                Console.WriteLine("Ocurrio un error con la direccion del servidor o la URL " + jsonException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ocurrio un error en el servidor " + exception.Message);
            }

            return null;

        }
    }
}