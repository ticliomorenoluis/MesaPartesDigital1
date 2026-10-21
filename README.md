# Mesa de partes digital — I.E. N.° 80914 "Tomás Gamarra León"

Prototipo en C# (aplicación de consola) para registrar, buscar y ordenar los expedientes de la mesa de partes de la institución. Proyecto del curso Fundamentos de Programación (UPN), Grupo 8.

## Funciones
1. Registrar expediente, con validación de código, fecha, DNI/RUC, celular y textos obligatorios.
2. Buscar expediente por código.
3. Ordenar por código (método burbuja) y listar.
4. Guardar los expedientes en `expedientes.txt`.
5. Salir (guarda antes de cerrar). Al iniciar, el programa carga `expedientes.txt` si existe.

## Archivos
- `Program.cs`: menú y ciclo principal.
- `Expedientes.cs`: arreglos paralelos, registro, búsqueda y ordenamiento.
- `Validaciones.cs`: reglas de validación.
- `Archivos.cs`: guardado y carga del archivo de texto.

## Cómo ejecutarlo
Requiere el SDK de .NET. Desde la carpeta del proyecto:

```
dotnet run
```

## Formato de `expedientes.txt`
Una línea por expediente, con ocho campos separados por `|`:

```
código|fecha|documento|solicitante|trámite|periodo|ubicación|celular
```
