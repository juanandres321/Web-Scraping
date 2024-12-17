# Proyecto Due Diligence

Este proyecto es una API desarrollada en **.NET 8** que utiliza SQL Server como base de datos y está diseñada con el enfoque Code-First. Adicionalmente, se utiliza Playwright para automatizar tareas relacionadas con la navegación web.

## Requisitos previos

Antes de comenzar, asegúrate de tener instalados los siguientes componentes en tu sistema:

- **.NET 8 SDK**  
  Descárgalo desde [la página oficial de .NET](https://dotnet.microsoft.com/download/dotnet/8.0).

- **SQL Server**  
  Debes tener un servidor SQL Server configurado.

- **Microsoft Edge**  
  Asegúrate de tener instalado Microsoft Edge para la automatización con Playwright. Puedes descargarlo desde [Microsoft Edge](https://www.microsoft.com/edge).

- **Node.js (opcional)**  
  Si necesitas interactuar directamente con Playwright desde su CLI. Descárgalo desde [Node.js](https://nodejs.org).

## Configuración del proyecto

### 1. Clonar el repositorio
Clona este repositorio en tu máquina local utilizando Git:

```bash
git clone https://github.com/usuario/proyecto-due-diligence.git
```
### 2. Configurar la cadena de conexión
Modifica el archivo appsettings.json en el directorio raíz del proyecto para incluir la cadena de conexión de tu base de datos SQL Server. Un ejemplo de configuración sería:
     ``` {
        "ConnectionStrings": {
          "DefaultConnection": "Server=<tu-servidor>;Database=<tu-base-de-datos>;User Id=<tu-usuario>;Password=<tu-contraseña>;"
        }
      }
    ```
### 3.  Realizar las migraciones
Dado que este proyecto utiliza Entity Framework Core con el enfoque Code First, es necesario aplicar las migraciones a la base de datos antes de ejecutarlo.
Ejecuta los siguientes comandos desde la terminal en el directorio del proyecto:
    ```
    dotnet ef migrations add InitialMigration
    dotnet ef database update
    ```

### 4.  Rellenar la base de datos con datos iniciales
El proyecto incluye una funcionalidad de seeding para agregar datos iniciales en la base de datos. Esto se realiza automáticamente durante la ejecución del proyecto en el entorno de desarrollo.

### 5. Configurar Playwright
Este proyecto utiliza Microsoft Edge como navegador para las funciones automatizadas de Playwright.
Si Microsoft Edge no está instalado en la ruta predeterminada (C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe), asegúrate de modificar la configuración dentro del código en Playwright para apuntar al ejecutable correcto:

  ``` var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
        ExecutablePath = @"<ruta-completa-al-navegador>",
        Headless = true
    });
  ```

### 6. Ejecutar el proyecto
Finalmente, inicia el servidor ejecutando:
    ```
    dotnet run
    ```

