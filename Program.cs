using System;
using System.Text;

namespace MesaPartesDigital
{
    class Program
    {
        static void Main()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.InputEncoding = Encoding.UTF8;

            Archivos.CargarExpedientes();

            int opcion = 0;
            while (opcion != 5)
            {
                MostrarMenu();
                opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        Expedientes.RegistrarExpediente();
                        break;
                    case 2:
                        Expedientes.BuscarExpediente();
                        break;
                    case 3:
                        Expedientes.OrdenarExpedientes();
                        Expedientes.ListarExpedientes();
                        break;
                    case 4:
                        Archivos.GuardarExpedientes();
                        break;
                    case 5:
                        Archivos.GuardarExpedientes();
                        Console.WriteLine("Hasta pronto");
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== MESA DE PARTES DIGITAL - I.E. N.° 80914 ===");
            Console.WriteLine("1. Registrar expediente");
            Console.WriteLine("2. Buscar expediente por código");
            Console.WriteLine("3. Ordenar por código y listar");
            Console.WriteLine("4. Guardar en archivo");
            Console.WriteLine("5. Salir");
            Console.Write("Elija una opción: ");
        }

        static int LeerOpcion()
        {
            string texto = Console.ReadLine() ?? "";
            if (texto.Length == 1 && texto[0] >= '1' && texto[0] <= '5')
            {
                return texto[0] - '0';
            }
            return 0; // opción no válida
        }
    }
}
