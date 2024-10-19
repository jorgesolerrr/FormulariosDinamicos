INFORME
# Formularios Dinámicos

Este proyecto tiene como objetivo crear formularios dinámicos que se adapten a las necesidades del usuario.

## Inicialización del Proyecto

Para inicializar el proyecto, sigue estos pasos:

1. Clona el repositorio:
    ```bash
    git clone https://github.com/jorgesolerrr/FormulariosDinamicos.git
    ```

2. Navega al directorio del frontend:
    ```bash
    cd FormulariosDinamicosClient/FormulariosDinamicos
    ```

3. Instala las dependencias necesarias:
    ```bash
    npm install
    ```

4. Inicia el servidor de desarrollo:
    ```bash
    npm start
    ```

5. Inicializa la base de datos y el backend con Docker Compose:
    ```bash
    docker-compose up
    ```

## Inicialización de la Base de Datos

Para inicializar la base de datos con el archivo SQL proporcionado, sigue estos pasos:

1. Asegúrate de tener MySQL instalado y en funcionamiento. Puedes usar Docker para esto:
    ```bash
    docker run --name mysql-dynamicforms -e MYSQL_ROOT_PASSWORD=1234 -d mysql:latest
    ```

2. Copia el archivo SQL a tu contenedor Docker:
    ```bash
    docker cp /path/to/your/DynamicForms.sql mysql-dynamicforms:/DynamicForms.sql
    ```

3. Ingresa al contenedor Docker:
    ```bash
    docker exec -it mysql-dynamicforms bash
    ```

4. Importa el archivo SQL a tu base de datos:
    ```bash
    mysql -u root -p yourpassword < /DynamicForms.sql
    ```

5. Sal del contenedor Docker:
    ```bash
    exit
    ```

Con estos pasos, la base de datos debería estar inicializada y lista para usarse con el proyecto.


