using System;
using System.IO;

namespace MesaPartesDigital
{
    static class Archivos
    {
        const string RUTA = "expedientes.txt";

        // Una línea por expediente, con los ocho datos separados por |
        public static void GuardarExpedientes()
        {
            if (Expedientes.contador == 0)
            {
                Console.WriteLine("No hay expedientes para guardar");
                return;
            }

            string[] lineas = new string[Expedientes.contador];
            for (int i = 0; i < Expedientes.contador; i++)
            {
                lineas[i] = Expedientes.codigos[i] + "|" + Expedientes.fechas[i] + "|"
                          + Expedientes.documentos[i] + "|" + Expedientes.solicitantes[i] + "|"
                          + Expedientes.tiposTramite[i] + "|" + Expedientes.periodos[i] + "|"
                          + Expedientes.ubicaciones[i] + "|" + Expedientes.celulares[i];
            }
            File.WriteAllLines(RUTA, lineas);
            Console.WriteLine("Datos guardados");
        }

        // Omite las líneas que no tienen los ocho campos
        public static void CargarExpedientes()
        {
            if (!File.Exists(RUTA))
            {
                Console.WriteLine("Archivo no encontrado: se inicia sin expedientes");
                return;
            }

            Expedientes.contador = 0;
            int omitidas = 0;
            string[] lineas = File.ReadAllLines(RUTA);

            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i].Trim().Length == 0) continue;

                string[] partes = lineas[i].Split('|');
                if (partes.Length == 8 && Expedientes.contador < Expedientes.CAPACIDAD)
                {
                    int p = Expedientes.contador;
                    Expedientes.codigos[p] = partes[0];
                    Expedientes.fechas[p] = partes[1];
                    Expedientes.documentos[p] = partes[2];
                    Expedientes.solicitantes[p] = partes[3];
                    Expedientes.tiposTramite[p] = partes[4];
                    Expedientes.periodos[p] = partes[5];
                    Expedientes.ubicaciones[p] = partes[6];
                    Expedientes.celulares[p] = partes[7];
                    Expedientes.contador++;
                }
                else
                {
                    omitidas++;
                }
            }

            Console.WriteLine(Expedientes.contador + " expedientes cargados");
            if (omitidas > 0) Console.WriteLine(omitidas + " líneas omitidas");
        }
    }
}
