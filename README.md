# blog-net

<b>Prerequisitos</b>
- .NET Framework Core 3.1
- MSSQL Server 2019

<b>Pasos para ejeuctar la applicación</b>
- Clone el repositorio
- Restaure el backup de la BD que está en la ruta /Web/BlogNet.Web/AppData/BlogNetDB.bak.zip
- Actualice la cadena de conexión a la BD en el archivo Api/appsettings.json. Tanga en cuenta la configuración de su servidor MSSQL Server
- Abra la solución de la carpeta raíz (blog-net.sln)
- Compile y ejecute la solución. Esta carga primero el proyecto BlogNet.API y luego BlogNet.Web

<b>Tiempo aproximado de desarrollo </b>
14 hrs

- Pendiente: Autenticación/Autorización
