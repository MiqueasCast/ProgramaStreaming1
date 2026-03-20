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
                Console.Clear();
                int tipoContenido;
                bool entradaValida = false;

                while (!entradaValida)
                {
                    Console.Write("Tipo de contenido: \n1. Pelicula\n2. Serie\n3. Documental\n4. Evento en vivo\n> ");
                    entradaValida = int.TryParse(Console.ReadLine(), out tipoContenido) && tipoContenido >= 1 && tipoContenido <= 4;

                    if (!entradaValida)
                    {
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Elige entre 1 y 4.\n");
                    }
                }
                double duracionMinutos;
                bool entradaValida2 = false;

                while (!entradaValida2)
                {
                    Console.Write("Duracion en minutos: \n> ");
                    entradaValida2 = double.TryParse(Console.ReadLine(), out duracionMinutos) && duracionMinutos > 0 && duracionMinutos < 500;

                    if (!entradaValida2)
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese una cifra en minutos valida\n");
                    }
                }
                int clasificacion;
                bool entradaValida3 = false;

                while (!entradaValida3)
                {
                    Console.Write("Clasificacion: \n1. Todo publico\n2. +13\n3. +18\n> ");
                    entradaValida3 = int.TryParse(Console.ReadLine(), out clasificacion) && clasificacion >= 1 && clasificacion <= 3;

                    if (!entradaValida3)
                    {
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Elige entre 1 y 3.\n");
                    }

                }
                int horaProgramada;
                bool entradaValida4 = false;
          
                while (!entradaValida4)
                {
                    Console.Write("Hora programda: (0-23)\n> ");
                    entradaValida4 = int.TryParse(Console.ReadLine(), out horaProgramada) && horaProgramada >0 && horaProgramada <= 23;

                    if (!entradaValida4)
                    {
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Elija un horario valido.\n");
                    }
                }
                int nivelProduccion;
                bool entradaValida5 = false;

                while (!entradaValida5)
                {
                    Console.Write("Nivel de producción:\n1. Bajo\n2. Medio\n3. Alto\n> ");
                    entradaValida5 = int.TryParse(Console.ReadLine(), out nivelProduccion) && nivelProduccion >= 1 && nivelProduccion <= 3;

                    if (!entradaValida5)
                    {
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Elija una opción valida\n");
                    }
                }
                Console.Clear();

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:
                Console.Clear();
                Console.WriteLine("Saliendo del programa...");
                Console.ReadKey();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Opción no válida. Por favor, elige una opción del menú.");
                break;
        }

    }
    else
    {
        Console.Clear();
        Console.WriteLine("Entrada no válida. Por favor, ingresa un número.");

    }
}while(opcion != 5 || !esNumero);