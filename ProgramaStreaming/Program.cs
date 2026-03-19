void Menu()
{
    Console.WriteLine("Menú: \n1. Evaluar nuevo contenido\n2. Mostrar reglas del sistema\n3. Mostrar estadisticas de inicio de sesion\n4. Reiniciar estadisticas \n5. Salir");
    
}


int opcion;
bool esNumero;
do
{
    Menu();
    esNumero = int.TryParse(Console.ReadLine(), out opcion);
    if (esNumero)
    {
        switch (opcion)
        {
            case 1:
                Console.WriteLine("opcion 1");
                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:
                Console.WriteLine("Saliendo del programa...");
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, elige una opción del menú.");
                break;
        }

    }
    else
    {
        Console.WriteLine("Entrada no válida. Por favor, ingresa un número.");

    }
}while(opcion != 5 || !esNumero);