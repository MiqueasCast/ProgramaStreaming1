// funciones
void Menu()
{
    Console.WriteLine("Menú: \n1. Evaluar nuevo contenido\n2. Mostrar reglas del sistema\n3. Mostrar estadisticas de inicio de sesion\n4. Reiniciar estadisticas \n5. Salir");
    
}
void ReglasDuracion(int duracionm)
{
    switch (duracionm)
    {
        case 1:
            Console.WriteLine("Película.\nRecuerda que para que el contenido sea aceptado debe estar en el rango de 60–180 minutos.");
            break;
        case 2:
            Console.WriteLine("Serie.\nRecuerda que para que el contenido sea aceptado debe estar en el rango de 20–90 minutos.");
            break;
        case 3:
            Console.WriteLine("Documental.\nRecuerda que para que el contenido sea aceptado debe estar en el rango de 30–120 minutos.");
            break;
        case 4:
            Console.WriteLine("Evento en vivo.\nRecuerda que para que el contenido sea aceptado debe estar en el rango de 30–240 minutos.");
            break;
    }
}
void clasificacionHora(int clasificacíon)
{
    switch (clasificacíon)
    {
        case 1:
            Console.WriteLine("Ingrese hora programada en el rango de 0-23 horas");
            break;
        case 2:
            Console.WriteLine("Recuerda que para que el contenido sea aceptado debe programarse entre las 6 y las 22 horas.");
            break;
        case 3:
            Console.WriteLine("Recuerda que para que el contenido sea aceptado debe programarse entre las 22 y las 5 horas.");
            break;
    }
}
void ReglasProduccion(int nivelProduccion)
{
    if (nivelProduccion == 1 || nivelProduccion == 2)
    {
        Console.WriteLine("Recuerde que la clasificación elegida solo acepta producción baja");
    }
}
void Reglas()
{
    Console.Clear();

    Console.WriteLine("==========================================");
    Console.WriteLine("        REGLAS DE CLASIFICACION");
    Console.WriteLine("==========================================\n");

    Console.WriteLine("Horarios permitidos:");
    Console.WriteLine("- Todo publico  : cualquier hora");
    Console.WriteLine("- +13           : entre 6 y 22 horas");
    Console.WriteLine("- +18           : entre 22 y 5 horas\n");

    Console.WriteLine("Duracion por tipo de contenido:");
    Console.WriteLine("- Pelicula        : 60-180 minutos");
    Console.WriteLine("- Serie           : 20-90 minutos");
    Console.WriteLine("- Documental      : 30-120 minutos");
    Console.WriteLine("- Evento en vivo  : 30-240 minutos\n");

    Console.WriteLine("Reglas de produccion:");
    Console.WriteLine("- Produccion baja   : solo valida para Todo publico o +13");
    Console.WriteLine("- Produccion media  : valida para cualquier clasificacion");
    Console.WriteLine("- Produccion alta   : valida para cualquier clasificacion\n");

    Console.WriteLine("==========================================");
}
bool ValidacionTecnica(int TipoContenido, double DuracionMinutos, int Clasificacion, int HoraProgramada, int NivelProduccion)
{
    bool ClasificacionHorario(int Clasificacion, int HoraProgramada)
    {
        if (Clasificacion == 1)
        {
            return true;
        }
        else if (Clasificacion == 2 && HoraProgramada >= 6 && HoraProgramada <= 22)
        {
            return true;

        }
        else if (Clasificacion == 3 && (HoraProgramada >= 5 && HoraProgramada <= 22))
        {
            return true;
        }
        return false;
    }
    bool DuracionValida(int TipoContenido, double DuracionMinutos)
    {
        if (TipoContenido == 1 && DuracionMinutos >= 60 && DuracionMinutos <= 180)
        {
            return true;
        }
        else if (TipoContenido == 2 && DuracionMinutos >= 20 && DuracionMinutos <= 90)
        {
            return true;
        }
        else if (TipoContenido == 3 && DuracionMinutos >= 30 && DuracionMinutos <= 120)
        {
            return true;
        }
        else if (TipoContenido == 4 && DuracionMinutos >= 30 && DuracionMinutos <= 240)
        {
            return true;
        }
        return false;
    }
    bool ProduccionValida(int NivelProduccion, int Clasificacion)
    {
        if (NivelProduccion == 1 && (Clasificacion == 1 || Clasificacion == 2))
        {
            return true;
        }
        else if (NivelProduccion == 2 || NivelProduccion == 3 && (Clasificacion == 1 || Clasificacion == 2 || Clasificacion == 3))
        {
            return true;
        }
        return false;
    }


    if (ClasificacionHorario(Clasificacion, HoraProgramada) &&
        DuracionValida(TipoContenido, DuracionMinutos) &&
        ProduccionValida(NivelProduccion, Clasificacion))
    {
        return true; 
    }
    else
    {
        return false; 
    }

}


// variables globales
int totalEvaluaciones = 0;
int publicados = 0;
int rechazados = 0;
int enRevision = 0;
int impactoProdeminante = 0;
double porcentajeAprobacion = 0;


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
                int tipoContenido = 0;
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
                double duracionMinutos = 0;
                bool entradaValida2 = false;

                while (!entradaValida2)
                {
                    Console.Clear();
                    ReglasDuracion(tipoContenido);
                    Console.Write("> ");
                    entradaValida2 = double.TryParse(Console.ReadLine(), out duracionMinutos) && duracionMinutos > 0 && duracionMinutos <= 240;

                    if (!entradaValida2)
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese una cifra en minutos valida\n");
                    }
                }
                int clasificacion = 0;
                bool entradaValida3 = false;

                while (!entradaValida3)
                {
                    Console.Clear();
                    Console.Write("Clasificacion: \n1. Todo publico\n2. +13\n3. +18\n> ");
                    entradaValida3 = int.TryParse(Console.ReadLine(), out clasificacion) && clasificacion >= 1 && clasificacion <= 3;

                    if (!entradaValida3)
                    {
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Elige entre 1 y 3.\n");
                    }

                }
                int horaProgramada = 0;
                bool entradaValida4 = false;
          
                while (!entradaValida4)
                {
                    clasificacionHora(clasificacion);
                    Console.Write("> ");
                    entradaValida4 = int.TryParse(Console.ReadLine(), out horaProgramada) && horaProgramada >= 0 && horaProgramada <= 23;

                    if (!entradaValida4)
                    {
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Elija un horario valido.\n");
                    }
                }
                int nivelProduccion = 0;
                bool entradaValida5 = false;

                while (!entradaValida5)
                {
                    ReglasProduccion(clasificacion);
                    Console.Write("Nivel de producción:\n1. Bajo\n2. Medio\n3. Alto\n> ");
                    entradaValida5 = int.TryParse(Console.ReadLine(), out nivelProduccion) && nivelProduccion >= 1 && nivelProduccion <= 3;

                    if (!entradaValida5)
                    {
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Elija una opción valida\n");
                    }
                }
                Console.Clear();

                bool respuesta = ValidacionTecnica(tipoContenido, duracionMinutos, clasificacion, horaProgramada, nivelProduccion);

                if (respuesta == true)
                {

                    Console.WriteLine("Felicidades su contenido aprobo la validación tecnica, presione enter para continuar: \n>");
                    if (nivelProduccion == 3 || duracionMinutos > 120 || horaProgramada >= 20 & horaProgramada <= 23)
                    {
                        Console.WriteLine("El contenido cumple con los requisitos técnicos pero requiere revisión adicional.");
                        enRevision++;

                    }
                    else if (nivelProduccion == 2 || duracionMinutos > 60 && duracionMinutos <= 120)
                    {
                        Console.WriteLine("El contenido ha sido aprobado y publicado en la plataforma.");
                        publicados++;
                    }
                    else if (nivelProduccion == 1 && duracionMinutos <= 60)
                    {
                        Console.WriteLine("El contenido ha sido aprobado y publicado en la plataforma.");
                        publicados++;
                    }
                }
                else
                {
                    Console.WriteLine("El contenido no cumple con los requisitos técnicos y ha sido rechazado.");
                    rechazados++;
                }

                break;
            case 2:
                Reglas();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine($"Total evaluados: {totalEvaluaciones}\nPublicados: {publicados}\nRechazados: {rechazados}\nEn revisión: {enRevision}\nImpacto predominante: {impactoProdeminante}\nPorcentaje de aprobación: {porcentajeAprobacion}");
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("Estadisticas reiniciadas");
                totalEvaluaciones = 0;
                publicados = 0;
                rechazados = 0;
                enRevision = 0;
                impactoProdeminante = 0;
                porcentajeAprobacion = 0;

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