using System;

namespace MesaPartesDigital
{
    static class Expedientes
    {
        public const int CAPACIDAD = 100;

        // Arreglos paralelos: la posición i de los ocho arreglos es un mismo expediente
        public static string[] codigos = new string[CAPACIDAD];
        public static string[] fechas = new string[CAPACIDAD];
        public static string[] documentos = new string[CAPACIDAD];
        public static string[] solicitantes = new string[CAPACIDAD];
        public static string[] tiposTramite = new string[CAPACIDAD];
        public static string[] periodos = new string[CAPACIDAD];
        public static string[] ubicaciones = new string[CAPACIDAD];
        public static string[] celulares = new string[CAPACIDAD];

        public static int contador = 0;

        public static void RegistrarExpediente()
        {
            if (contador == CAPACIDAD)
            {
                Console.WriteLine("No hay espacio para más expedientes");
                return;
            }

            Console.Write("Código (EXP-AAAA-NNN): ");
            string codigo = (Console.ReadLine() ?? "").Trim().ToUpper();
            if (!Validaciones.ValidarCodigo(codigo))
            {
                Console.WriteLine("Código con formato inválido");
                return;
            }
            if (BuscarIndice(codigo) != -1)
            {
                Console.WriteLine("El código ya existe");
                return;
            }

            Console.Write("Fecha de recepción (dd/mm/aaaa): ");
            string fecha = (Console.ReadLine() ?? "").Trim();
            if (!Validaciones.ValidarFecha(fecha))
            {
                Console.WriteLine("Fecha inválida");
                return;
            }

            Console.Write("DNI (8 dígitos) o RUC (11 dígitos): ");
            string documento = (Console.ReadLine() ?? "").Trim();
            if (!Validaciones.ValidarDocumento(documento))
            {
                Console.WriteLine("DNI o RUC inválido");
                return;
            }

            Console.Write("Solicitante o entidad remitente: ");
            string solicitante = (Console.ReadLine() ?? "").Trim();
            Console.Write("Tipo de trámite: ");
            string tipoTramite = (Console.ReadLine() ?? "").Trim();
            Console.Write("Grado, año o periodo: ");
            string periodo = (Console.ReadLine() ?? "").Trim();
            Console.Write("Ubicación física del original: ");
            string ubicacion = (Console.ReadLine() ?? "").Trim();

            string[] textos = { solicitante, tipoTramite, periodo, ubicacion };
            for (int i = 0; i < textos.Length; i++)
            {
                if (!Validaciones.ValidarTextoObligatorio(textos[i]))
                {
                    Console.WriteLine("Hay datos vacíos o con el carácter |");
                    return;
                }
            }

            Console.Write("Celular (9 dígitos): ");
            string celular = (Console.ReadLine() ?? "").Trim();
            if (!Validaciones.ValidarCelular(celular))
            {
                Console.WriteLine("Celular inválido");
                return;
            }

            solicitante = solicitante.ToUpper();

            codigos[contador] = codigo;
            fechas[contador] = fecha;
            documentos[contador] = documento;
            solicitantes[contador] = solicitante;
            tiposTramite[contador] = tipoTramite;
            periodos[contador] = periodo;
            ubicaciones[contador] = ubicacion;
            celulares[contador] = celular;
            contador++;

            Console.WriteLine("Expediente registrado");
        }

        // Búsqueda secuencial: devuelve la posición o -1 si no existe
        public static int BuscarIndice(string codigoBuscado)
        {
            codigoBuscado = codigoBuscado.Trim().ToUpper();
            for (int i = 0; i < contador; i++)
            {
                if (codigos[i] == codigoBuscado) return i;
            }
            return -1;
        }

        public static void BuscarExpediente()
        {
            Console.Write("Código a buscar: ");
            string codigo = Console.ReadLine() ?? "";
            int indice = BuscarIndice(codigo);
            if (indice == -1)
            {
                Console.WriteLine("No se encontró el expediente");
            }
            else
            {
                MostrarExpediente(indice);
            }
        }

        public static void MostrarExpediente(int indice)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Código: " + codigos[indice]);
            Console.WriteLine("Fecha: " + fechas[indice]);
            Console.WriteLine("Documento: " + documentos[indice]);
            Console.WriteLine("Solicitante: " + solicitantes[indice]);
            Console.WriteLine("Trámite: " + tiposTramite[indice]);
            Console.WriteLine("Periodo: " + periodos[indice]);
            Console.WriteLine("Ubicación: " + ubicaciones[indice]);
            Console.WriteLine("Celular: " + celulares[indice]);
        }

        // Ordenamiento burbuja por código; termina antes si una pasada no hace cambios
        public static void OrdenarExpedientes()
        {
            int n = contador;
            bool huboCambio = true;
            while (huboCambio)
            {
                huboCambio = false;
                for (int j = 0; j <= n - 2; j++)
                {
                    if (string.CompareOrdinal(codigos[j], codigos[j + 1]) > 0)
                    {
                        IntercambiarPosiciones(j, j + 1);
                        huboCambio = true;
                    }
                }
                n--;
            }
        }

        // Intercambia las posiciones a y b en los ocho arreglos a la vez
        public static void IntercambiarPosiciones(int a, int b)
        {
            string tmp;
            tmp = codigos[a]; codigos[a] = codigos[b]; codigos[b] = tmp;
            tmp = fechas[a]; fechas[a] = fechas[b]; fechas[b] = tmp;
            tmp = documentos[a]; documentos[a] = documentos[b]; documentos[b] = tmp;
            tmp = solicitantes[a]; solicitantes[a] = solicitantes[b]; solicitantes[b] = tmp;
            tmp = tiposTramite[a]; tiposTramite[a] = tiposTramite[b]; tiposTramite[b] = tmp;
            tmp = periodos[a]; periodos[a] = periodos[b]; periodos[b] = tmp;
            tmp = ubicaciones[a]; ubicaciones[a] = ubicaciones[b]; ubicaciones[b] = tmp;
            tmp = celulares[a]; celulares[a] = celulares[b]; celulares[b] = tmp;
        }

        public static void ListarExpedientes()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay expedientes registrados");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                MostrarExpediente(i);
            }
        }
    }
}
