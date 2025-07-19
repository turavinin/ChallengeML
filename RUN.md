
# 🏃‍♂️ Cómo correr el proyecto ChallengeML

Este documento explica todas las formas de ejecutar la API ChallengeML, tanto en modo local como con Docker.

---

## ✅ Opción 1: Ejecutar localmente con .NET 9

### Requisitos:
- Tener instalado el SDK de [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).

### Pasos:

1. Cloná el repositorio:
```bash
git clone https://github.com/turavinin/ChallengeML.git
cd ChallengeML
```

2. Restaurar dependencias:
```bash
dotnet restore
```

3. Ir al proyecto principal:
```bash
cd ChallengeML
```

4. Ejecutar la API:
```bash
dotnet run
```

5. Acceder a Swagger en tu navegador:
```
https://localhost:5001
```
o
```
http://localhost:5000
```

---

## ✅ Opción 2: Ejecutar con Docker

### Requisitos:
- Tener instalado [Docker Desktop](https://www.docker.com/products/docker-desktop/).
- (proceso automatizado con run-docker.bat)

### Pasos:

1. Pararse en la raíz del repositorio (donde está la solución `.sln`):
```bash
cd C:/ruta/a/tu/repositorio/ChallengeML
```

2. Construir la imagen Docker:
```bash
docker build -f ChallengeML/Dockerfile -t challengeml-api .
```

3. Correr el contenedor:
```bash
docker run -d -p 5000:8080 --name challengeml-api challengeml-api
```

4. Acceder a la API y Swagger en:
```
http://localhost:5000
```

5. Ver logs del contenedor:
```bash
docker logs challengeml-api
```

6. Detener el contenedor:
```bash
docker stop challengeml-api
```

7. Eliminar el contenedor:
```bash
docker rm challengeml-api
```

---

## ✅ Contacto

Para cualquier inconveniente, podés escribirme a **aturavinin@gmail.com**
