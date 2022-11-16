
# party-game

## Setup

1. Crear una cuenta de github.
2. [Crear un token de desarrollador](https://docs.github.com/en/enterprise-server@3.4/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token) sin fecha límite (guardarlo en un lugar seguro)
    - Este token se usa en vez de tu contraseña de usuario cuando tengas que loggearte fuera de github.com (al tratar de subir cambios se los va a pedir)
    - En el paso 7 solo marcar la primer casilla "repo"
3. Aceptar invitación de colaboración
4. [Descargar GIT](https://git-scm.com/downloads)
5. [Descargar GIT LFS](https://git-lfs.github.com/)
6. Clonar el repositorio
    - Abrir una terminal/cmd/shell (win + r y escribir cmd o abrirla desde aplicaciones de windows)
    - Ir a la carpeta en la que quieres que esté el proyecto (desde la terminal/cmd/shell). [Ejemplo](https://www.alphr.com/change-directory-in-cmd/#:~:text=To%20change%20directories%20in%20CMD%2C%20simply%20type%20in%20%E2%80%9Ccd%2C,to%20change%2C%20and%20that%27s%20it.)
    - Escribir el siguiente comando en la terminal: `git clone https://github.com/Dario19999/party-game.git`
    - Esperar a que se descargue el proyecto

## Desarrollo
1. Cuando queramos empezar a desarrollar, antes hay que correr este comando en la terminal `git pull` (la terminal tiene que estar en la carpeta del proyecto)
2. Cuando queramos subir cambios al repositorio:
    - Rezar porque todo salga bien.
    - (Opcional) Ver qué archivos modificamos con nuestro trabajo: `git status`
    - Correr el comando `git add -A` (agrega los cambios en rojo del comando anterior y los pone verde o "listos para subirse")
    - Correr el comando `git commit -m "mensaje"` (cambiar "mensaje" por una breve descripción de lo que se está subiendo)
    - Correr el comando `git push`
    
**ADVERTENCIA:** **Siempre** correr el comando `git pull` antes de `git push`
