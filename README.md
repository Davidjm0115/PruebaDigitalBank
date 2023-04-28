# PruebaDigitalBank
 
Esta pruba esta dividia por 3 capas.

La primera es la capa de datos (CapaDatos) Donde se encuentra la conexion a la base de datos y un pequeño modelo sobre la tabla Usuario.
La segunda capa es la capa de Negocios (CapaNegocios), donde se encuentran los metodos para el crud, mostrar, agregar, editar y eliminar.

En estas 2 primeras capas se usaron los paquetes NuGet de Dapper y System.Data.SqlClient.

La tercera capa es la capa de presentacion (CapaPresentacion) donde se encuentran las vistas y el controlador de la aplicación.

Para esta aplicacion se uso como Servidor de Base de Datos SQLServer. Para replicar la base de datos, la tabla y el Sp usado en la aplicacion en la carpeta "Base de datos" se dejo un Query el cual se ejecuta y crea todo lo mencionado anteriormente.
