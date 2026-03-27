using System;
using System.IO;
using System.Text.Json;

const string configFile = "appsettings.json";

Console.WriteLine("Simulación de cadena de conexión");

if (!File.Exists(configFile))
{
    Console.WriteLine($"No se encontró el archivo de configuración '{configFile}'.");
    return;
}

string json = File.ReadAllText(configFile);
using JsonDocument doc = JsonDocument.Parse(json);
string? connectionString = doc.RootElement
    .GetProperty("ConnectionStrings")
    .GetProperty("DefaultConnection")
    .GetString();

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("No se encontró la cadena de conexión en la configuración.");
    return;
}

Console.WriteLine($"Cadena de conexión leída: {connectionString}");
SimularConexion(connectionString);

static void SimularConexion(string connectionString)
{
    Console.WriteLine("\n-- Simulando conexión --");
    Console.WriteLine("Intentando conectar con la siguiente cadena:");
    Console.WriteLine(connectionString);
    Console.WriteLine("Resultado: Conexión simulada exitosa.");
}
