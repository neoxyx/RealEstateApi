# 🏠 RealEstate API

API RESTful desarrollada con **ASP.NET Core 9** que permite gestionar propiedades inmobiliarias. Los datos se almacenan en **MongoDB**.

## 🚀 Requisitos

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [MongoDB](https://www.mongodb.com/try/download/community)
- Visual Studio o VS Code
- Docker (opcional, para MongoDB local)

## ⚙️ Configuración del entorno

### 1. Clona el repositorio

```bash
git clone https://github.com/neoxyx/RealEstateApi.git
cd RealEstateApi

### 2. Configura appsettings.json

{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "local",
    "PropertiesCollectionName": "properties"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

### 3. Ejecutar la API
dotnet build
dotnet run
La API estará disponible en:
📍 http://localhost:5076/api/property

Endpoint Principal
GET /api/property
Soporta filtros por name, address, minPrice, maxPrice.
