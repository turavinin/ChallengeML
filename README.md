
# Challenge Mercado Libre - .NET 9 API

API REST desarrollada como solución para el challenge técnico de Mercado Libre.

## 🚀 Tecnologías utilizadas

- [.NET 9](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)
- C#
- Swagger / OpenAPI
- AutoMapper
- Dependency Injection
- Manejo de excepciones custom con Middleware

## 🐳 Docker + bat
Correr run-docker.bat que automatiza levantar el contenedor. 
Abrir en el navegador http://localhost:5000 para swagger o pegarle desde postman. 


## 🐳 Docker Manual

### Build de la imagen:
```bash
docker build -t challengeml-api .
```

### Correr el contenedor:
```bash
docker run -d -p 5000:8080 --name challengeml-api challengeml-api
```

### Acceso a la API:
```
http://localhost:5000
```

### Probar con Swagger
Abrí en tu navegador:
```
http://localhost:5000



## 📦 Setup del proyecto 

### ✅ Requisitos
- Tener instalado el SDK de [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).
- Un navegador web moderno (Chrome, Edge, Firefox).
- Git (opcional para clonar el repo).

### ✅ Clonar el repositorio
```bash
git clone https://github.com/turavinin/ChallengeML.git
cd ChallengeML
```

### ✅ Restaurar dependencias
```bash
dotnet restore
```

### ✅ Ejecutar la aplicación
```bash
dotnet run
```

### ✅ Acceder a la documentación Swagger
Una vez que la aplicación esté corriendo, abrí tu navegador en:

```
https://localhost:5001
```
o
```
http://localhost:5000
```

Ahí vas a encontrar la documentación interactiva en **Swagger UI**, donde podés explorar y probar todos los endpoints.

---

## 📌 Endpoints disponibles

### `GET /products`
Obtiene la lista de productos con soporte de filtros, ordenamiento y paginación.

#### Query Parameters:
| Parámetro  | Tipo    | Descripción |
|------------|---------|-------------|
| name       | string  | Filtra por nombre parcial |
| category   | string  | Filtra por categoría exacta |
| minPrice   | decimal | Precio mínimo |
| maxPrice   | decimal | Precio máximo |
| limit      | int     | Cantidad máxima de resultados |
| offset     | int     | Cantidad de resultados a saltar |
| orderBy    | string  | Campo por el cual ordenar (`Name`, `Price`, `Category`) |
| descending | bool    | Orden descendente si es `true` |

#### Ejemplos:
- Obtener productos filtrados por nombre:
```
GET /products?name=shampoo
```
- Obtener productos ordenados por precio descendente:
```
GET /products?orderBy=price&descending=true
```
- Paginación:
```
GET /products?limit=5&offset=10
```

### `GET /products/{id}`
Obtiene el detalle de un producto específico por su ID.

---

## 🧪 Probar con curl o Postman

### Obtener todos los productos:
```bash
curl https://localhost:5001/products --insecure
```

### Obtener un producto por ID:
```bash
curl https://localhost:5001/products/1 --insecure
```

> ⚠️ El flag `--insecure` en curl evita errores de certificado en localhost.

---

## 🧰 Estructura del proyecto

- `/Controllers`: Endpoints de la API.
- `/Repositories`: Lógica de acceso a datos y filtros.
- `/Dtos`: Objetos de transferencia de datos (DTOs).
- `/Middlewares`: Middleware para manejo global de excepciones.
- `/Mapper`: Configuración de AutoMapper.

---

## ✅ Decisiones técnicas

- **AutoMapper** para mapear entidades a DTOs de salida.
- **Middleware custom** para centralizar el manejo de errores.
- **Swagger UI** accesible en entorno de desarrollo.
- Soporte completo para:
  - Filtros dinámicos.
  - Ordenamiento flexible.
  - Paginación.

---

## 🗒️ Contacto

Desarrollado por **Antón Turavínin**  
📧 [aturavinin@gmail.com](mailto:aturavinin@gmail.com)
