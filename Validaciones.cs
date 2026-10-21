namespace MesaPartesDigital
{
    static class Validaciones
    {
        // Función auxiliar: texto no vacío formado solo por dígitos 0-9
        public static bool SoloDigitos(string texto)
        {
            if (texto.Length == 0) return false;
            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] < '0' || texto[i] > '9') return false;
            }
            return true;
        }

        // Formato EXP-AAAA-NNN (12 caracteres)
        public static bool ValidarCodigo(string codigo)
        {
            if (codigo.Length != 12) return false;
            if (codigo.Substring(0, 3) != "EXP") return false;
            if (codigo[3] != '-' || codigo[8] != '-') return false;
            if (!SoloDigitos(codigo.Substring(4, 4))) return false;
            if (!SoloDigitos(codigo.Substring(9, 3))) return false;
            return true;
        }

        // Formato dd/mm/aaaa y fecha real (considera años bisiestos)
        public static bool ValidarFecha(string fecha)
        {
            if (fecha.Length != 10) return false;
            if (fecha[2] != '/' || fecha[5] != '/') return false;

            string dd = fecha.Substring(0, 2);
            string mm = fecha.Substring(3, 2);
            string aaaa = fecha.Substring(6, 4);
            if (!SoloDigitos(dd) || !SoloDigitos(mm) || !SoloDigitos(aaaa)) return false;

            int dia = int.Parse(dd);
            int mes = int.Parse(mm);
            int anio = int.Parse(aaaa);

            if (mes < 1 || mes > 12) return false;

            int diasMes = 31;
            if (mes == 4 || mes == 6 || mes == 9 || mes == 11) diasMes = 30;
            if (mes == 2)
            {
                if ((anio % 4 == 0 && anio % 100 != 0) || (anio % 400 == 0))
                    diasMes = 29;
                else
                    diasMes = 28;
            }
            return dia >= 1 && dia <= diasMes;
        }

        // DNI (8 dígitos) o RUC (11 dígitos)
        public static bool ValidarDocumento(string documento)
        {
            if (!SoloDigitos(documento)) return false;
            return documento.Length == 8 || documento.Length == 11;
        }

        // Celular de 9 dígitos
        public static bool ValidarCelular(string celular)
        {
            if (!SoloDigitos(celular)) return false;
            return celular.Length == 9;
        }

        // No vacío y sin el carácter | (protege el formato del archivo)
        public static bool ValidarTextoObligatorio(string texto)
        {
            if (texto.Trim().Length == 0) return false;
            if (texto.Contains("|")) return false;
            return true;
        }
    }
}
