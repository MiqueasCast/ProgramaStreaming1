// funciones
void Menu()
{
    Console.WriteLine("Menú: \n1. Evaluar nuevo contenido\n2. Mostrar reglas del sistema\n3. Mostrar estadisticas de inicio de sesion\n4. Reiniciar estadisticas \n5. Salir");
    
}
void Reglas()
{
    Console.WriteLine(" Reglas de clasificación y horario\r\n• Todo público: cualquier hora\r\n• +13: entre 6 y 22 horas\r\n• +18: entre 22 y 5 horas\r\n" +
        "Reglas de duración por tipo\r\n• Película: 60–180 minutos\r\n• Serie: 20–90 minutos\r\n• Documental: 30–120 minutos\r\n• Evento en vivo: 30–240 minutos\r\n\r\n" +
        "Reglas de producción\r\n• Producción baja solo válida para Todo público o +13\r\n• Producción media o alta válida para cualquier clasificación\r\n");
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
        else if (Clasificacion == 3 && (HoraProgramada >= 22 && HoraProgramada <= 5))
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
        else if ((NivelProduccion == 2 || NivelProduccion == 3) && (Clasificacion >= 1 && Clasificacion <= 3))
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
                    Console.Write("Duracion en minutos: \n> ");
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
                    Console.Write("Hora programda: (0-23)\n> ");
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
                    //if (nivelProduccion == 3 || duracionMinutos > 120 || horaProgramada >= 20 & horaProgramada <= 23)
                    //{
                    //    Console.WriteLine("El contenido cumple con los requisitos técnicos pero requiere revisión adicional.");
                    //    enRevision++;

                    //}
                    //else if (nivelProduccion == 2 || duracionMinutos > 60 && duracionMinutos <= 120)
                    //{
                    //    Console.WriteLine("El contenido ha sido aprobado y publicado en la plataforma.");
                    //    publicados++;
                    //}
                    //else if (nivelProduccion == 1 && duracionMinutos <= 60)

                    //{
                    //    Console.WriteLine("El contenido ha sido aprobado y publicado en la plataforma.");
                    //    publicados++;
                    //}
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