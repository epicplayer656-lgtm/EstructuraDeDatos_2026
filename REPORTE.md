# REPORTE DE AUDITORÍA - SIMULACRO BIMESTRAL

## Información General
* **Alumno:** Emiliano Aguilar Gutiérrez
* **Institución:** UNITEC

---

## Registro de Fallos Detectados

### 1. Encapsulamiento Roto en Geolocalización
* **Clase Afectada:** `PuntoDeRed`
* **Principio Violado:** Encapsulamiento (Clase 5) y Mal manejo de Tipos de Referencia (Clase 2)
* **Severidad:** Alta
* **Descripción:** Se definió como una clase (`Reference Type`) permitiendo que múltiples servidores apunten a la misma dirección de memoria en el Heap. Modificar la ubicación de uno corrompe silenciosamente a los demás. Además, expone campos públicos sin validación de rangos.

### 2. Violación del Principio de Responsabilidad Única (SRP)
* **Clase Afectada:** `ServidorConexion`
* **Principio Violado:** SRP (SOLID - Clase 10)
* **Severidad:** Media
* **Descripción:** La clase mezcla la lógica de administración de conexión con algoritmos complejos de diagnóstico de latencia y lógica de notificaciones.

### 3. Rendimiento Algorítmico Deficiente y Riesgo de Desbordamiento
* **Clase Afectada:** `ServidorConexion` (Método `DiagnosticarLatencia`)
* **Principio Violado:** Fail Fast y Optimización (Clase 9 y 11)
* **Severidad:** Alta
* **Descripción:** El método utiliza recursión pura sin control de caché (Memoization), lo que eleva el estrés de CPU de manera exponencial $O(2^n)$ y no previene un `StackOverflowException` si las entradas son inválidas.