# **DOCUMENTACION OFICIAL**
# Aspectos tecnicos

## Librerias y paquetes utilizados:
  - .NET
  - Microsoft.EntityFrameworkCore.Tools - Versión 5.0.7
  - Microsoft.EntityFrameworkCore.SqlServer - Versión 5.0.7
  - Microsoft.EntityFrameworkCore - Versión 5.0.7
  - Microsoft.EntityFrameworkCore.Design - Versión 5.0.7
  - ItextSharp

## Modelos de Diseños:
### Instaladores:
  - Se necesita la instalación de SQL Developer o Express.
  - Para poder correr el programa, es necesario que ejecutemos el txt o script "**data_bank_final.sql**" para poder gestionar nuestro sistema de datos.

### Repository:
  - El repositorio nos ayudara a llevar los registros de cambios o modificaciones en los archivos a lo largo del proyecto, facilitando la creación de diferentes programas que seran de ayuda para nuestro proyecto.

### Issues
  - Los Issues son una sección de Github que nos permite asignar las tareas que los integrantes del equipo van a realizar, facilitandonos el trabajo.

## Desarrollado utilizando:
  - Windows 10
  - SQL SERVER
  - SQL SERVER Management Studio
  - JetBrains Rider 2021

#
#
#

# **INSTALADORES**

  - Para poder utilizar nuestro programa del Seguimiento de vacunación contra el COVID-19, debera seguir los siguientes pasos de instalación:

## **Documentación Previa**
  - **Base de datos y gestor de base de datos**: La base de datos que ocuparemos es "**ProjectFinalV2**". Este archivo lo encontraremos en la carpeta de **Base de datos**, dentro de ella encontraremos el documento de "**data_bank_final.sql**".
  -  **Installer.msi:** Este archivo se encuentra en la carpeta **Installer** Una vez descargado estos dos instaladores,procederemos con la instalación de nuestro programa.

#
#

## **Proceso de Instalación**
  - Una vez descargado los dos instaladores anteriormente, procedemos a abrir el instalador "**Installer**".
  - Cuando le demos doble click nos mostrara una ventana donde nos aparecera dos opciones las cuales son "**Siguiente**" o "**Cancelar**". En este caso procedemos a darle en **Siguiente**.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/insta1.jpeg)

  - Después de darle siguiente, nos aparecera un apartado el cual se llama "**Seleccionar carpeta de instalación**".

## **Seleccionar carpeta de instalación**
  - En este apartado tenemos la opción de examinar en que carpeta de nuestra computadora queremos guardar el instalador. En nuestro caso lo dejaremos por default.
  - Además tenemos que seleccionar la opción que dice "**Sólo para este usuario**" y podemos darle click en **Siguiente**.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/insta2.jpeg)

## **Confirmar Instalación**
  - Si no estamos seguros con los pasos anteriores tenemos una opcion que se llama "**Atrás**".
  - Una vez confirmamos que todos los pasos anteriores esten correctamente, podemos proceder con la instalación dando click en **Siguiente**.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/insta3.jpeg)

## **Instalando Installer**
  - En este apartado esperaremos unos segundos hasta que se haya instalado todo correctamente.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/insta4.jpeg)

## **Instalación Completa**
  - Una vez finalizado la instalación, nos aparecera un mensaje diciendo "**Installer se ha instalado correctamente. Haga click en Cerrar para salir.**"

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/insta5.jpeg)

  - El acceso directo lo encontraremos en nuestro escritorio con el siguiente icono.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/insta6.jpeg)

Asi finalizamos el proceso de instalación.
#
#
#

# **MANUAL DE USUARIO**

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/covid.png)

#

## **INICIO DE SESIÓN**
- Al momento de ejecutar el programa, al usuario se le presentara una ventada donde habra un apartado para que digite su usuario y contraseña.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo1.jpeg)

- Una vez ingresado el usuario y la contraseña correctamente, aparecera un nuevo apartado que se llama "**Creando usuario**".
- **Nota** : Solo aquel empleado que cuente con el permiso de **Gestor** puede acceder al sistema 
- **Gestor Genérico para probar el programa :** 
  - Nombre: **Henrie Thompson**
  - Usuario: **hnisuis7**
  - Contraseña: **48mBNo1LP**
- *Para encontrar la lista de empleados revisar archivo **"data_bank_final"** disponible en la carpeta "Base de datos" en este repositorio*



## **Creando Usuario**
- Su DUI: El DUI es el Documento Único de Identidad.
- Nombre del usuario: Estrictamente nombre completo para llevar un mejor control.
- Número de telefono: Unicamente telefono celular.
- Su correo electrónico: Puede ser correo personal o correo de trabajo. 
- La dirección: Ubicacion o lugar donde el usuario este viviendo actualmente.
- Institución a la que pertenece: Aquí colocaremos al área en la que pertenece o tiene la opción de poner otra institución
- Pertenece a alguno de estos grupos: en este apartado el usuario tiene que seleccionar si está entre el rango de edad ya estipulado.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo2.jpeg)

- Cuando el usuario haya completado los campos correctamente, nos llevara a otro apartado que son el **Detalle cita** 

## **Detalle Cita**
- En el **Detalle cita** encontraremos nuestro DUI, la fecha de nuestra cita ya generada, la hora a la que tenemos que estar y el lugar donde nos tocara asistir para la vacunación contra el COVID-19.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo4.jpeg)

- Una vez confirmemos que todo los datos que el sistema nos genero este bien, tenemos dos opciones las cuales son "**Aceptar**" y "**Generar PDF**"
- Si damos en **Generar PDF** el programa automaticamente nos dira que se creo el PDF de la primera cita correctamente.
  
![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo5.jpeg)

- Si damos en **Aceptar** el programa nos llevara a otro apartado que seria nuestro "**Menu Principal**".
## **Menu Principal**
- Al momento de entrar al **Menu Principal** nos dara la bienvenida al sistemas de vacunación COVID-19 , después encontraremos dos opciones las cuales son "**Seguimiento de cita**" y "**Nuevo Usuario**"

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo3.jpeg)
  
  - Si optamos por darle en **Nuevo Usuario**, volveremos a repetir los procesos anteriores.
  - Si elegimos la opción "**Seguimiento de cita**" el programa nos enviara a otra ventana. 

## **Seguimiento de cita**
  - En **Seguimiento de cita** podremos llevar un mejor control para la segunda dosis de la vacunación contra el COVID-19. Para llevar acabo este proceso el gestor debe introducir el **DUI** de la persona que se desea buscar.
  
![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo6.jpeg)

  - Una vez ingresado los datos correctamente, el gestor tiene que dar click en continuar proceso, para poder llevar a cabo la segunda dosis de la vacunación. Inmediatamente le aparecera un mensaje diciendo "**Desea continuar proceso de vacunación**" el gestor tiene que darle en "**Si**" si quiere seguir con el proceso o "**No**" si el gestor ya no quiere seguir con el proceso.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo7.jpeg)

Cuando el gestor haya dado click en **Si** desea continuar con el proceso de vacunación, el sistema nos mostrara una ventana que se llama "**Datos Preliminares**"

## **Datos Preliminares**
  - Una vez la persona obtenga su segunda dosis de la vacunación, le aparecera una ventana que seria los **Datos Preliminares**.
  - En esta ventana encontraremos una nota que nos dira "**El paciente debe permanecer 30 minutos en las instalaciones**". Este mensaje quiere decir, que una vez nos coloquen la segunda dosis, aguardemos en las instalaciones por si llegaran haber efectos secundarios. Ademas de la nota encontraremos:
  - **Fecha registrada.**
  - **Hora registrada.**
  - **Hora de inicio del proceso.:** El gestor tiene que digitar la hora de inicio del proceso de vacunación.
  - **Hora de la vacunación.:** El gestor debe digitar la hora en que vacunaron a la persona.
  - **Minutos con efectos secundarios:** En este apartado hay que destacar que si la persona no presento efectos secundarios dentro de los 30 minutos, en el apartado tiene que poner 0 (cero) minutos para que no haya ningun inconveniente al momento de poder seguir con el proceso.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo8.jpeg)

  - Cuando se haya completado los campos que se han solicitado de la ventana, el gestor tiene que dar click en **Aceptar** y automaticamente nos aparecera un mensaje diciendo "**Proceso terminado exitosamente**" 

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo9.jpeg)

El gestor tiene la posibilidad de generar un PDF si el lo desea, el PDF lo puede descargar y contiene la información de los detalles de las 2 citas que tuvo durante el proceso de vacunación, es decir, la primera dosis y la segunda dosis.

![alt text](https://github.com/UCASV/proyecto-final-grupo-6/blob/main/Manual/Imagenes/campo10.jpeg)

Y con esto termina todo el proceso de nuestro sistema, recuerden seguir paso a paso para que no tengan ningun inconveniente. Y recuerden siempre tener en cuenta las medidas de bioseguridad.
