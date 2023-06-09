﻿// See https://aka.ms/new-console-template for more information

using Modelo;

/*
Conceptos fundamentales de la programación orientada a objetos
Definición de programación orientada a objetos (POO)
Objetos y clases
 */

var cliente = new ClienteEmpresarial("Cristian")
{
    Cuenta = new CuentaBancaria(12345, 0)
};

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

    if (LaCantidadEsCorrecta(cantidad))
    {
        cliente.EjecutarMovimiento(cantidad * multiplicador);
    }
    else
    {
        Console.WriteLine($"La cantidad a {movimiento} es incorrecta");
    }


    foreach (var movimientoEnCuenta in cliente.Cuenta.Movimientos.OrderByDescending(movimientoBancario => movimientoBancario.Valor))
    {

        Console.WriteLine($"El dia {movimientoEnCuenta.Fecha} usted {(movimientoEnCuenta.Valor < 0 ? "retiró" : "depositó")} {movimientoEnCuenta.Valor}");
    }

    var saldo = cliente.Cuenta.Movimientos
        .Sum(movimientoBancario => movimientoBancario.Valor);

    Console.WriteLine("Su nuevo saldo es de: " + saldo);
}


static bool LaCantidadEsCorrecta(int valor)
{
    if (valor == 0)
    {
        return false;
    }
    else
    {
        return true;
    }
}

/*
Ejemplo práctico:
Supongamos que queremos modelar una aplicación de biblioteca. 
Podemos crear una clase llamada "Libro" con propiedades como título, autor y año de publicación. 
Los objetos de la clase "Libro" serán instancias individuales con sus propios valores para esas propiedades. 
De esta manera, podemos representar y manipular libros de manera eficiente utilizando POO.
 */

/*
Características de C#
Tipos de datos
Variables y constantes
Funciones y métodos
Bibliotecas y espacios de nombres
 */

/*
bool: representa un valor booleano (verdadero o falso).
byte: representa un entero sin signo de 8 bits.
char: representa un carácter Unicode de 16 bits.
decimal: representa un número decimal de 128 bits con una precisión de 28 dígitos.
double: representa un número en coma flotante de 64 bits.
float: representa un número en coma flotante de 32 bits.
int: representa un entero con signo de 32 bits.
long: representa un entero con signo de 64 bits.
sbyte: representa un entero con signo de 8 bits.
short: representa un entero con signo de 16 bits.
uint: representa un entero sin signo de 32 bits.
ulong: representa un entero sin signo de 64 bits.
ushort: representa un entero sin signo de 16 bits.
 */