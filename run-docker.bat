
@echo off
echo Building Docker image...
docker build -t challengeml-api .

echo Running Docker container on port 5000...
docker run -d -p 5000:8080 --name challengeml-api challengeml-api

echo Done! Access the API at http://localhost:5000
pause
