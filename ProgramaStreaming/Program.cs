// variables globales
int totalEvaluaciones = 0;
int publicados = 0;
int rechazados = 0;
int enRevision = 0;

double porcentajeAprobacion = 0;
int impactoAlto = 0;
int impactoMedio = 0;
int impactoBajo = 0;

// funciones
void Resumen(int TipoContenido, double DuracionMinutos, int Clasificacion,
             int HoraProgramada, int NivelProduccion,
             string decision, string razon)
{
    Console.WriteLine("\n═══════════ RESUMEN DE EVALUACIÓN ═══════════");

    if (TipoContenido == 1)
    {
        Console.WriteLine("Tipo de contenido:   Película");
    }
    else if (TipoContenido == 2)
    {
        Console.WriteLine("Tipo de contenido:   Serie");
    }
    else if (TipoContenido == 3)
    {
        Console.WriteLine("Tipo de contenido:   Documental");
    }
    else if (TipoContenido == 4)
    {
        Console.WriteLine("Tipo de contenido:   Evento en vivo");
    }

    Console.WriteLine($"Duración:            {DuracionMinutos} minutos");

    if (Clasificacion == 1)
    {
        Console.WriteLine("Clasificación:       Todo público");
    }
    else if (Clasificacion == 2)
    {
        Console.WriteLine("Clasificación:       +13");
    }
    else if (Clasificacion == 3)
    {
        Console.WriteLine("Clasificación:       +18");
    }

    Console.WriteLine($"Hora programada:     {HoraProgramada}:00");

    if (NivelProduccion == 1)
    {
        Console.WriteLine("Nivel de producción: Bajo");
    }
    else if (NivelProduccion == 2)
    {
        Console.WriteLine("Nivel de producción: Medio");
    }
    else if (NivelProduccion == 3)
    {
        Console.WriteLine("Nivel de producción: Alto");
    }

    Console.WriteLine("═════════════════════════════════════════════");
    Console.WriteLine($"Decisión:            {decision}");
    Console.WriteLine($"Razón:               {razon}");
    Console.WriteLine("═════════════════════════════════════════════\n");
}
void Menu()
{
    Console.Write("Menú: \n1. Evaluar nuevo contenido\n2. Mostrar reglas del sistema\n3. Mostrar estadisticas de inicio de sesion\n4. Reiniciar estadisticas \n5. Salir\n>");
    
}
void Reglas()
{
    Console.Clear();

    Console.WriteLine("══════════════════ REGLAS DE CLASIFICACION ══════════════════\n");

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

    Console.WriteLine("═════════════════════════════════════════════════════════════");
}
string ClasificacionImpacto(int impactoAlto, int impactoMedio, int impactoBajo)
{
    if (impactoAlto == 0 && impactoMedio == 0 && impactoBajo == 0)
    {
        return "Sin datos";
    }
    else if (impactoAlto >= impactoMedio && impactoAlto >= impactoBajo)
    {
        return "Impacto Alto";
    }
    else if (impactoMedio >= impactoAlto && impactoMedio >= impactoBajo)
    {
        return "Impacto Medio";
    }
    else
    {
        return "Impacto Bajo";
    }
}
double PorcentajeAprobacion(int total, int aprobados)
{
    if (total == 0)
    {
        return porcentajeAprobacion = 0;
    }
    return porcentajeAprobacion = (double)aprobados / total * 100;
}

void ReglasDuracion(int duracionm)
{
    switch (duracionm)
    {
        case 1:
            Console.WriteLine("═══════════  Película ═══════════" +
                "\nRecuerda que para que el contenido sea aceptado debe estar en el rango de 60–180 minutos.\n");
            break;
        case 2:
            Console.WriteLine("═══════════  Serie  ═══════════" +
                "\nRecuerda que para que el contenido sea aceptado debe estar en el rango de 20–90 minutos.\n");
            break;
        case 3:
            Console.WriteLine("═══════════  Documental  ═══════════\nRecuerda que para que el contenido sea aceptado debe estar en el rango de 30–120 minutos.\n");
            break;
        case 4:
            Console.WriteLine("═══════════  Evento en vivo  ═══════════\nRecuerda que para que el contenido sea aceptado debe estar en el rango de 30–240 minutos.\n");
            break;
    }
}
void clasificacionHora(int clasificacíon)
{
    switch (clasificacíon)
    {
        case 1:
            Console.WriteLine("Ingrese hora programada en el rango de 0-23 horas\n");
            break;
        case 2:
            Console.WriteLine("Recuerda que para que el contenido sea aceptado debe programarse entre las 6 y las 22 horas.\n");
            break;
        case 3:
            Console.WriteLine("Recuerda que para que el contenido sea aceptado debe programarse entre las 22 y las 5 horas.\n");
            break;
    }
}
void ReglasProduccion(int clasificacion)
{
    if (clasificacion == 3)
    {
        Console.WriteLine("Recuerda que para clasificación +18 no se permite producción baja\n");
    }
}


// función para validación de reglas
bool ValidacionTecnica(int TipoContenido, double DuracionMinutos, int Clasificacion, int HoraProgramada, int NivelProduccion, out string razon)
{
    bool ClasificacionHorario(int Clasificacion, int HoraProgramada)
    {
        if (Clasificacion == 1)
        {
            return true;
        }
        else if (Clasificacion == 2 && (HoraProgramada >= 6 && HoraProgramada <= 22))
        {
            return true;

        }
        else if (Clasificacion == 3 && (HoraProgramada >= 22 || HoraProgramada <= 5))
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


    if (!ClasificacionHorario(Clasificacion, HoraProgramada))
    {
        razon = "Horario no permitido para esa clasificación";
        return false;
    }
    if (!DuracionValida(TipoContenido, DuracionMinutos))
    {
        razon = "Duración fuera del rango permitido";
        return false;
    }
    if (!ProduccionValida(NivelProduccion, Clasificacion))
    {
        razon = "Nivel de producción no válido para esa clasificación";
        return false;
    }
    razon = "Cumple todas las reglas técnicas";
    return true;

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
                Console.Clear();
                double duracionMinutos = 0;
                bool entradaValida2 = false;

                while (!entradaValida2)
                {
                    Console.Clear();
                    ReglasDuracion(tipoContenido);
                    Console.Write("Ingrese la duración: > ");
                    entradaValida2 = double.TryParse(Console.ReadLine(), out duracionMinutos) && duracionMinutos > 0 && duracionMinutos <= 240;

                    if (!entradaValida2)
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese una cifra en minutos valida\n");
                    }
                }
                Console.Clear();
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
                Console.Clear();
                int horaProgramada = 0;
                bool entradaValida4 = false;
          
                while (!entradaValida4)
                {
                    clasificacionHora(clasificacion);
                    Console.Write("Ingrese horario:  ");
                    entradaValida4 = int.TryParse(Console.ReadLine(), out horaProgramada) && horaProgramada >= 0 && horaProgramada <= 23;

                    if (!entradaValida4)
                    {
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Elija un horario valido.\n");
                    }
                }
                Console.Clear();
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

                bool respuesta = ValidacionTecnica(tipoContenido, duracionMinutos, clasificacion, horaProgramada, nivelProduccion, out string razon);

                if (respuesta == true)
                {
                    int nivelImpacto = 0;

                    if (nivelProduccion == 3 || duracionMinutos > 120 || (horaProgramada >= 20 && horaProgramada <= 23))
                    {
                        nivelImpacto = 3;
                    }
                    else if (nivelProduccion == 2 || (duracionMinutos >= 60 && duracionMinutos <= 120))
                    {
                        nivelImpacto = 2;
                    }
                    else
                    {
                        nivelImpacto = 1;
                    }

                    if (nivelImpacto == 3)
                    {
                        Resumen(tipoContenido, duracionMinutos, clasificacion, horaProgramada, nivelProduccion, "Enviar a revisión", "Impacto Alto");
                        enRevision++;
                        impactoAlto++;
                    }
                    else if (nivelImpacto == 2 && (horaProgramada >= 18 || duracionMinutos >= 100))
                    {
                        Resumen(tipoContenido, duracionMinutos, clasificacion, horaProgramada, nivelProduccion, "Publicar con ajustes", "Impacto Medio — se recomienda ajustar horario o duración");
                        publicados++;
                        impactoMedio++;
                    }
                    else if (nivelImpacto == 2)
                    {
                        Resumen(tipoContenido, duracionMinutos, clasificacion, horaProgramada, nivelProduccion,  "Publicar", "Impacto Medio, cumple todas las reglas");
                        publicados++;
                        impactoMedio++;
                    }
                    else
                    {
                        Resumen(tipoContenido, duracionMinutos, clasificacion, horaProgramada, nivelProduccion,  "Publicar", "Impacto Bajo, cumple todas las reglas");
                        publicados++;
                        impactoBajo++;
                    }
                }
                else
                {
                    Resumen(tipoContenido, duracionMinutos, clasificacion, horaProgramada, nivelProduccion, "Rechazar", razon);
                    rechazados++;
                }
                totalEvaluaciones++;
                break;
            case 2:
                Console.Clear();
                Reglas();
                break;
            case 3:
                Console.Clear();
                if (totalEvaluaciones == 0)
                {
                    Console.WriteLine("═══════════ No se han ingresado datos aun ═══════════\n");
                }
                else
                {
                    Console.WriteLine($"═════════════  Estadisticas  ═════════════");
                    Console.WriteLine(
                                     $"Total evaluados          : {totalEvaluaciones}\n" +
                                     $"Publicados               : {publicados}\n" +
                                     $"Rechazados               : {rechazados}\n" +
                                     $"En revisión              : {enRevision}\n" +
                                     $"Impacto predominante     : {ClasificacionImpacto(impactoAlto, impactoMedio, impactoBajo)}\n" +
                                     $"Porcentaje de aprobación : {PorcentajeAprobacion(totalEvaluaciones, publicados):F2}%\n" +
                                     $"═════════════════════════════════════════\n");
                }
               
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("Estadisticas reiniciadas");
                totalEvaluaciones = 0;
                publicados = 0;
                rechazados = 0;
                enRevision = 0;
                porcentajeAprobacion = 0;
                impactoAlto = 0;
                impactoMedio = 0;
                impactoBajo = 0;

                break;
            case 5:
                Console.Clear();
                Console.WriteLine("Saliendo del programa...");
                Console.WriteLine($"═══════════ Resumen de hoy ═══════════");
                Console.WriteLine(
                                 $"Total evaluados          : {totalEvaluaciones}\n" +
                                 $"Publicados               : {publicados}\n" +
                                 $"Rechazados               : {rechazados}\n" +
                                 $"En revisión              : {enRevision}\n" +
                                 $"Impacto predominante     : {ClasificacionImpacto(impactoAlto, impactoMedio, impactoBajo)}\n" +
                                 $"Porcentaje de aprobación : {PorcentajeAprobacion(totalEvaluaciones, publicados):F2}%");
                string separador = "";
                for (int i = 0; i < 38; i++)
                {
                    separador += "═";
                }
                Console.WriteLine(separador);
                Console.WriteLine($"Presione cualquier tecla para salir.");
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