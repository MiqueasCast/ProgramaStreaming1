# ProgramaStreaming1

Simulador de decisiones para una plataforma de streaming, desarrollado en C# como proyecto del curso de Pensamiento Computacional — Facultad de Ingeniería, Universidad Rafael Landívar.
---
## Descripción del sistema

El programa simula la consola interna de un equipo de streaming que evalúa solicitudes de contenido antes de publicarlas. Cada contenido ingresado pasa por una validación técnica basada en reglas de clasificación, duración, horario y nivel de producción. 
Según los resultados, el sistema emite una de estas decisiones:

- **Publicar** — cumple todas las reglas y tiene impacto Bajo o Medio
- **Enviar a revisión** — cumple las reglas pero tiene impacto Alto
- **Rechazar** — incumple alguna regla obligatoria

El sistema no almacena listas de contenidos. Cada solicitud se evalúa en el momento y el programa mantiene estadísticas generales de la sesión.

---

## Cómo ejecutar el programa

1. Clona el repositorio:
```bash
git clone https://github.com/MiqueasCast/ProgramaStreaming1.git
```

2. Entra a la carpeta del proyecto:
```bash
cd ProgramaStreaming1
```

3. Ejecuta el programa:
```bash
dotnet run
```

## Opciones del menú

| Opción | Descripción |
|--------|-------------|
| 1 | Evaluar nuevo contenido — ingresa los datos y recibe una decisión |
| 2 | Mostrar reglas del sistema — consulta las reglas que usa el programa |
| 3 | Mostrar estadísticas de la sesión — ve el resumen de evaluaciones realizadas |
| 4 | Reiniciar estadísticas — borra los contadores de la sesión actual |
| 5 | Salir — muestra el resumen final y cierra el programa |

---

## Estructuras utilizadas

- `switch` — manejo del menú principal
- `do-while` — ciclo principal que mantiene el sistema activo
- `while` — validación de entradas del usuario
- `for` — generación del separador en el resumen final
- `if/else` encadenado y anidado — lógica de validación técnica y clasificación de impacto
- Funciones — el código está organizado en funciones separadas por responsabilidad

---

## Autor

Desarrollado como proyecto del curso Pensamiento Computacional  
Facultad de Ingeniería — Universidad Rafael Landívar
