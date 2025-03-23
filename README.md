# Prueba Técnica
Este proyecto implementa una **API RESTful** y un **Frontend** siguiendo los requisitos de una prueba técnica. La solución incluye un **backend** desarrollado en C# con .NET 8 utilizando **arquitectura Onion** y un **frontend** en React que se integra con la API para proporcionar una interfaz de usuario completa.
## Tabla de Contenido
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
  - [Backend](#backend)
  - [Frontend](#frontend)
- [Arquitectura](#arquitectura)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Funcionalidades](#funcionalidades)
  - [API](#api)
  - [Frontend](#frontend-1)
- [Instalación y Ejecución](#instalación-y-ejecución)
  - [Requisitos Previos](#requisitos-previos)
  - [Pasos para Ejecutar el Backend](#pasos-para-ejecutar-el-backend)
  - [Pasos para Ejecutar el Frontend](#pasos-para-ejecutar-el-frontend)
- [Credenciales de Prueba](#credenciales-de-prueba)
- [Licencia](#licencia)
- [Autor](#autor)
## Tecnologías Utilizadas
### Backend
- Lenguaje**: C# (.NET 8)
- Arquitectura: Onion Architecture (Infraestructura, Aplicación, Servicios, Dominio)
- Base de datos: Archivo de texto plano (JSON)
- Documentación: Swagger
- Autenticación: JWT (JSON Web Token)
- Logging**: Serilog
- Manejo de excepciones**: Implementación básica
### Frontend
- Framework**: React.js
- Routing**: React Router
- HTTP Client**: Axios
- Estilos**: CSS personalizado con las especificaciones requeridas
## Arquitectura
Se utiliza la arquitectura **Onion** para estructurar el proyecto. Esto significa que la lógica de negocio (Dominio) está en el centro de la solución, seguida por capas adicionales (Aplicación, Infraestructura, Servicios) que dependen de las capas más internas, pero nunca al revés.
## Estructura del Proyecto
pruebatecnica/  
├── src/  
│   ├── SB.GovEntitiesAPI.Domain/         # Entidades y lógica de negocio  
│   ├── SB.GovEntitiesAPI.Application/    # Casos de uso e interfaces  
│   ├── SB.GovEntitiesAPI.Infrastructure/ # Implementaciones y acceso a datos  
│   ├── SB.GovEntitiesAPI.Services/       # Implementación de servicios  
│   └── SB.GovEntitiesAPI.API/            # Controladores y punto de entrada  
└── frontend/                             # Aplicación React
## Funcionalidades
### API
- CRUD completo para entidades gubernamentales
- Autenticación mediante JWT
- Documentación con Swagger
- Persistencia en archivo de texto plano
-Manejo de logs con Serilog
### Frontend
- Pantalla de Login
- Listado de Entidades Gubernamentales
- Formulario para crear/editar** entidades
- Capacidad para eliminar entidades
- Interfaz responsiva con los colores especificados
## Instalación y Ejecución
### Requisitos Previos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js y npm](https://nodejs.org/)
- [Git](https://git-scm.com/)
### Pasos para Ejecutar el Backend
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/cibersabueso/ptmediatrix.git
   cd ptmediatrix


Compilar la solución**  
1. Desde la raíz del proyecto, ejecuta: `dotnet build`
  
Ejecutar la API**  
1. Navega a la carpeta de la API: `cd src/SB.GovEntitiesAPI.API`  
2. Ejecuta el comando: `dotnet run`  
La API estará disponible en `https://localhost:5001` o `http://localhost:5000`.  

Acceder a la documentación Swagger: Abre tu navegador y visita `https://localhost:5001/swagger` o `http://localhost:5000/swagger`

Pasos para Ejecutar el Frontend 
1. Navega a la carpeta del frontend: `cd frontend`  
2. Instala las dependencias: `npm install`  
3. Inicia la aplicación: `npm start`  
El frontend estará disponible en `http://localhost:3000`.

Credenciales de Prueba
- Usuario: `admin`  
- Contraseña: `admin123`
