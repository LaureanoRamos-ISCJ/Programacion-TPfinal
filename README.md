# TP Integrador - Sistema de Login de usuarios

## Introducción

### ¿Qué hace el programa?

En este proyecto desarrollamos una aplicación en **C#** utilizando **Windows Forms**. Nuestro objetivo fue armar un sistema que permita registrar usuarios, iniciar sesión y controlar a qué funciones puede acceder cada uno según su **rol o nivel de jerarquía**. Además, para que las cuentas creadas no se borren al cerrar la aplicación, implementamos un sistema de guardado en un archivo de texto txt.

### ¿Cómo funciona?

Para organizar el funcionamiento del programa, dividimos la aplicación en tres pantallas principales por las que va pasando el usuario:

1. **Inicio de Sesión (`Form1`):**
   * Apenas se abre el programa, llamamos a nuestra función de carga para leer todos los usuarios guardados en el archivo `usuarios.txt`.
   * Para entrar, el usuario tiene que ingresar su **ID numérico** y su **Contraseña**.
   * Antes de buscarlo, validamos que no haya dejado casillas en blanco y usamos `int.TryParse` para asegurarnos de que el ID ingresado sea realmente un número y el programa no falle. Si los datos coinciden con algún usuario de nuestra lista, abrimos la pantalla principal pasándole toda la información de esa cuenta.

2. **Registro de Nuevos Usuarios (`SignUp`):**
   * Si alguien no tiene cuenta, desde el inicio puede ir a esta ventana para registrarse completando su **Nombre**, **Contraseña** (escribiéndola dos veces para confirmar que no se equivocó) y eligiendo su **Nivel** en un menú desplegable (`ComboBox`).
   * **Generación automática de ID:** En lugar de que el usuario elija su ID, decidimos generarlo de forma aleatoria con la clase `Random` entre `0` y `499` (estableciendo un límite máximo de **500 usuarios**). Para evitar que a dos personas les toque el mismo número, armamos un ciclo `do-while` que revisa toda la lista y vuelve a sortear el número si detecta que ya está en uso.
   * Al finalizar, guardamos el nuevo usuario en el archivo de texto y mostramos un cartel informándole cuál es su ID para que pueda iniciar sesión.

3. **Panel de Sesión y Control de Roles (`SesionIniciada`):**
   * Al entrar, mostramos un saludo personalizado con el nombre del usuario y su rol.
   * Primero ocultamos todos los botones de acción y luego, usando una estructura `switch` que evalúa el **Nivel** del usuario activo, habilitamos únicamente lo que le corresponde ver:
     * **Nivel `"Usuario"`:** Solo le activamos el botón para ver un cartel con sus propios datos (`Nombre`, `Contraseña`, `ID` y `Nivel`).
     * **Nivel `"Operador"`:** Además de poder ver sus propios datos, le habilitamos un botón especial que recorre toda la base de datos y le muestra por pantalla la lista completa de los usuarios registrados.
     * **Nivel `"Administrador"`:** Tiene acceso a todo lo anterior y le sumamos una función para editar la base de datos directamente. Al tocar su botón, el programa abre el archivo `usuarios.txt` en el **Bloc de Notas de Windows (`notepad.exe`)**. Usamos `WaitForExit()` para que espere a que el administrador guarde y cierre el Bloc de Notas, y recargamos la lista para aplicar los cambios al instante.

---

## Uso y Creación de Estructuras y Clases

### 1. Clase `Usuarios` (`Usuarios.cs`)

Esta clase es la que contiene las características de los usuarios.

* **Propiedades:** Definimos cuatro propiedades públicas (`Nombre`, `Contraseña`, `Nivel` e `Id`) con sus `get` y `set` para poder leer y asignar sus valores fácilmente desde cualquier formulario del proyecto.
* **Constructor:** Armamos un constructor que recibe esos cuatro datos por parámetro al momento de hacer `new Usuarios(...)`, lo que nos permite crear e inicializar al usuario en una sola línea de código.

### 2. Clase Estática `BaseDeDatos` (`BaseDeDatos.cs`)

La declaramos como `public static class BaseDeDatos` porque necesitábamos acceder a la lista de usuarios desde cualquiera de las tres ventanas sin tener que crear una instancia nueva de la base de datos en cada formulario, evitando así que se pierda la información al cambiar de pantalla.

* **Estructura de almacenamiento en memoria (`List<Usuarios>`):**
  * Dentro de esta clase creamos la lista `public static List<Usuarios> usuariosDB`.
  * Elegimos usar una estructura `List` porque nos permite agregar elementos dinámicamente (`.Add()`), contar cuántos usuarios hay (`.Count`), vaciarla cuando necesitamos actualizarla (`.Clear()`) y recorrerla de punta a punta con ciclos `foreach`.

### 3. Clases de los Formularios (`Form1`, `SignUp`, `SesionIniciada`)

Cada pantalla es una clase que hereda de `Form`. Un detalle importante que implementamos fue modificar el constructor de la ventana `SesionIniciada(Usuarios activo)`: al pedir un objeto de tipo `Usuarios` como parámetro, logramos pasar todos los datos de la persona que acaba de iniciar sesión en `Form1` hacia la nueva ventana, guardándolo en la variable privada `usuarioActivo`.

---

## Guardado y Lectura en el archivo `usuarios.txt`

Para que los datos persistan en la computadora, programamos los métodos `Guardar()` y `Cargar()` dentro de `BaseDeDatos.cs` utilizando las herramientas de la librería `System.IO`.

### Formato en el que guardamos los datos

Decidimos guardar un usuario por cada renglón del archivo, separando cada uno de sus datos con un punto y coma (`;`):

```text
Nombre;Contraseña;Nivel;Id
```

### ¿Cómo funciona nuestro método `Guardar()`?

1. Utilizamos un bloque `using (StreamWriter escritor = new StreamWriter(ruta, false))`. Le pasamos `false` como segundo parámetro para que, cada vez que se actualice la lista, sobrescriba el archivo `usuarios.txt` limpio con todos los usuarios actuales. Además, el bloque `using` se encarga de cerrar el archivo automáticamente al terminar.
2. Con un ciclo `foreach`, recorremos cada objeto de `usuariosDB` y escribimos una línea de texto concatenando sus propiedades separadas por `;` mediante `escritor.WriteLine(...)`.

### ¿Cómo funciona nuestro método `Cargar()`?

1. Envolvemos todo el código en un bloque `try-catch`. De esta forma, si alguien borra el archivo por error o escribe datos inválidos a mano, el programa no se cierra de golpe, sino que muestra un `MessageBox` avisando del problema.
2. Primero hacemos `usuariosDB.Clear()` para limpiar la lista en memoria y no duplicar los usuarios que ya estaban cargados.
3. Abrimos el archivo con `using (StreamReader lector = new StreamReader(ruta))` y usamos un ciclo `while` que lee renglón por renglón mientras no llegue al final del archivo (`!= null`).
4. Si hay un renglón vacío lo salteamos, y a las líneas con información les aplicamos `.Split(';')`. Esto corta el texto en cada punto y coma y nos devuelve un vector de *strings* (`string[] datos`) con los 4 valores por separado:
   * `datos[0]` $\rightarrow$ Nombre
   * `datos[1]` $\rightarrow$ Contraseña
   * `datos[2]` $\rightarrow$ Nivel
   * `int.Parse(datos[3])` $\rightarrow$ Convertimos el texto del ID nuevamente a un número entero (`int`).
5. Por último, con esos 4 datos reconstruimos el objeto `Usuarios` y lo volvemos a meter en nuestra lista `usuariosDB`.

---

## Conclusión

Realizar este Trabajo Práctico Integrador nos permitió unir varios conceptos fundamentales de programación en un proyecto completo y funcional. Pudimos ver en la práctica la utilidad de separar el código en clases como `Usuarios` y `BaseDeDatos`, lo cual nos ahorró repetir código y nos facilitó mucho la comunicación entre los distintos formularios de Windows Forms.

Además, trabajar con el archivo `usuarios.txt` nos ayudó a comprender cómo transformar objetos que están en la memoria RAM a texto plano y cómo reconstruirlos al volver a abrir el programa, sumando validaciones para evitar errores de ingreso y manejando distintos niveles de permisos según el rol de cada cuenta.
