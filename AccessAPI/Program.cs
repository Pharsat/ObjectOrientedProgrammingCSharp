namespace AccessAPI
{
    using System;
    using System.Text.Json;
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                // Crear una instancia de HttpClient
                using (var client = new HttpClient())
                {
                    // Hacer una solicitud GET a la URL especificada
                    var response = await client
                        .GetAsync("https://api-colombia.com/api/v1/Region")
                        .ConfigureAwait(false);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena
                        var content = await response.Content.ReadAsStringAsync();

                        // Acceder a los datos del objeto JSON
                        // ...

                        var listaDeRegiones = JsonSerializer.Deserialize<List<Region>>(content);

                        foreach (var region in listaDeRegiones)
                        {
                            if (region.name.StartsWith('C'))
                            {
                                Console.WriteLine(region.name);
                                Console.WriteLine(region.description);
                            }
                        }
                    }
                }
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
            finally
            {

            }

        }
    }
}