# Запуск приложения через Docker Compose

1. **Склонируйте репозиторий:**

   ```bash
   git clone https://github.com/VladimirBudilov/PasswordManager.git
   cd PasswordManager
   ```
   
2. **Запустите контейнеры:**
   ```bash
    docker-compose up -d --build 
    ```
    *Эта команда соберет и запустит контейнеры в фоновом режиме.*

3. **Проверьте запуск приложения:**

    *Фронтенд (Angular):* http://localhost:4200 
    *Бэкенд (ASP.NET):* http://localhost:8080 


4. **Остановите и удалите контейнеры:**
    ```bash
      docker-compose down -v
    ```
