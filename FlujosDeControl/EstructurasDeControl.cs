namespace FlujosDeControl
{
    public class EstructurasDeControl
    {
        public void EstructurasDeFlujo()
        {
            // Ejemplo de un loop for
            for (int indice = 0; indice < 5; indice = indice + 1)
            {
                Console.WriteLine(indice);
            }

            // Ejemplo de un loop while
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine(j);
                j++;
            }

            //Ejemplo de un loop foreach
            //                        1  2  3  4  5
            var numeros = new int[] { 0, 1, 2, 3, 4 };
            foreach(var numero in numeros)
            {
                Console.WriteLine(numero);
            }

            for (var i = 0; i < numeros.Length; i++)
            {
                var numero = numeros[i];
                Console.WriteLine(numero);
            }

            // Ejemplo de uso de break
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    break; // Esto interrumpirá el loop cuando i sea igual a 5
                }
                Console.WriteLine(i);
            }

            // Ejemplo de uso de continue
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    continue; // Esto saltará a la siguiente iteración del loop cuando i sea par
                }

                //Resto del ciclo.....
                Console.WriteLine(i);
            }
        }

        public void EstructurasDeControlCondicionales()
        {
            int x = 5;

            // Ejemplo de un if-else
            if (x > 3)
            {
                Console.WriteLine("x es mayor que 3");
            }

            // Ejemplo de un switch
            switch (x)
            {
                case 1:
                case 2:
                    Console.WriteLine("x es igual a 1 o a 2");
                    break;
                default:
                    Console.WriteLine("x no es igual a 1 ni a 2");
                    break;
            }

            // Ejemplo de un operador ternario
            string result = x > 3 
                ? "x es mayor que 3" 
                : x == 3 
                    ? "x es igual a 3"
                    : "x no es mayor que 3 ni igual a 3";
            Console.WriteLine(result);
        }

        public void ControlDeExcepciones()
        {
            try
            {
                int y = 5 / int.Parse("0"); // Esto generará una excepción
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Ocurrió una excepción: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Este bloque se ejecutará siempre, independientemente de si ocurrió una excepción o no.");
            }
        }
    }
}