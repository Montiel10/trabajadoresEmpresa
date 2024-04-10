using System;
using System.Collections.Generic;

class Empleado
{
    public string Nombre { get; set; }
    public double SueldoBruto { get; set; }
    public char Categoria { get; set; }
    public double MontoAumento { get; set; }
    public double SueldoNeto { get; set; }

    public Empleado(string nombre, double sueldoBruto, char categoria)
    {
        Nombre = nombre;
        SueldoBruto = sueldoBruto;
        Categoria = categoria;
        MontoAumento = CalcularAumento(sueldoBruto);
        SueldoNeto = sueldoBruto + MontoAumento;
    }

    private double CalcularAumento(double sueldo)
    {
        if (sueldo <= 1000) return sueldo * 0.10;
        if (sueldo <= 2000) return sueldo * 0.20;
        if (sueldo <= 4000) return sueldo * 0.30;
        return sueldo * 0.40; // Para sueldos mayores a 4000
    }
}

class Empresa
{
    private List<Empleado> empleados = new List<Empleado>();

    public void AgregarEmpleado(Empleado empleado)
    {
        empleados.Add(empleado);
    }

    public void Reportar()
    {
        double totalNeto = 0;
        Console.WriteLine("Nombre - Sueldo Bruto - Monto Aumento - Sueldo Neto");
        foreach (var empleado in empleados)
        {
            Console.WriteLine($"{empleado.Nombre} - {empleado.SueldoBruto} - {empleado.MontoAumento} - {empleado.SueldoNeto}");
            totalNeto += empleado.SueldoNeto;
        }
        Console.WriteLine($"Total Sueldos Netos: {totalNeto}");
    }
}

class Program
{
    static void Main()
    {
        Empresa empresa = new Empresa();

        // Aquí puedes añadir empleados de prueba o implementar una interfaz de usuario para ingresarlos
        empresa.AgregarEmpleado(new Empleado("Juan Perez", 1500, 'A'));
        empresa.AgregarEmpleado(new Empleado("Ana Lopez", 2500, 'B'));
        // ... más empleados

        empresa.Reportar();
    }
}