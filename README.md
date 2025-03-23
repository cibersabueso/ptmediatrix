Prueba Tecnica

Descripción
Este proyecto implementa una API RESTful, siguiendo los requisitos de la prueba técnica proporcionada. La solución incluye un backend desarrollado en C# con .NET 8 utilizando arquitectura Onion y un frontend en React que se integra con la API para proporcionar una interfaz de usuario completa.
Tecnologías Utilizadas
Backend

Lenguaje: C# (.NET 8)
Arquitectura: Onion Architecture (Infraestructura, Aplicación, Servicios, Dominio)
Base de datos: Archivo de texto plano (JSON)
Documentación: Swagger
Autenticación: JWT (JSON Web Token)
Logging: Serilog
Manejo de excepciones: Implementación básica

Frontend

Framework: React.js
Routing: React Router
HTTP Client: Axios
Estilos: CSS personalizado con las especificaciones requeridas

Estructura del Proyecto
La solución sigue la arquitectura Onion con las siguientes capas:
pruebatecnica/
├── src/
│   ├── SB.GovEntitiesAPI.Domain/         # Entidades y lógica de negocio
│   ├── SB.GovEntitiesAPI.Application/    # Casos de uso e interfaces
│   ├── SB.GovEntitiesAPI.Infrastructure/ # Implementaciones y acceso a datos
│   ├── SB.GovEntitiesAPI.Services/       # Implementación de servicios
│   └── SB.GovEntitiesAPI.API/            # Controladores y punto de entrada
└── frontend/                             # Aplicación React
Funcionalidades
API

CRUD completo para entidades gubernamentales
Autenticación mediante JWT
Documentación con Swagger
Persistencia en archivo de texto plano
Manejo de logs con Serilog

Frontend

Pantalla de login
Listado de entidades gubernamentales
Formulario para crear/editar entidades
Capacidad para eliminar entidades
Interfaz responsiva con los colores especificados

Instalación y Ejecución
Requisitos Previos

.NET 8 SDK
Node.js y npm
Git

Pasos para Ejecutar el Backend

Clonar el repositorio: git clone https://github.com/cibersabueso/ptmediatrix.git y cd ptmediatrix
Compilar la solución: dotnet build
Ejecutar la API: cd src/SB.GovEntitiesAPI.API y dotnet run
La API estará disponible en https://localhost:5001 o http://localhost:5000
Acceder a la documentación Swagger:

Abrir en el navegador: https://localhost:5001/swagger o http://localhost:5000/swagger



Pasos para Ejecutar el Frontend

Navegar a la carpeta del frontend: cd frontend
Instalar dependencias: npm install
Iniciar la aplicación: npm start
La aplicación estará disponible en http://localhost:3000

Credenciales de Prueba

Usuario: admin
Contraseña: admin123