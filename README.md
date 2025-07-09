# Proyecto ASP.NET MVC - Prototipo de Login con Control de Sesión

Este proyecto es un **prototipo desarrollado en Visual Studio utilizando .NET (ASP.NET MVC Web)**. Su propósito principal es demostrar la implementación de un formulario de inicio de sesión (Login) que autentica a los usuarios mediante validación de credenciales contra una base de datos SQL Server. Una vez autenticado, el usuario accede a una vista de perfil con su información, y se implementan elementos de interfaz modernos y funcionales como un menú lateral y un encabezado con su nombre.

---

## 🎯 Objetivos del Proyecto

- Mostrar el uso de formularios de login conectados a base de datos.
- Implementar validación segura de credenciales.
- Presentar una interfaz de usuario clara y navegable.
- Aplicar control de sesión por inactividad del usuario.

---

## 🛠️ Tecnologías Utilizadas

- **Visual Studio 2022**
- **.NET Framework / .NET Core (dependiendo de la versión utilizada)**
- **ASP.NET MVC (Model-View-Controller)**
- **SQL Server (Base de datos relacional)**
- **Entity Framework (para operaciones con la base de datos)**
- **Bootstrap (para el diseño de la plantilla)**
- **JavaScript / jQuery (para el manejo del control de sesión e interactividad)**

---

## 📋 Funcionalidades Principales

### 1. **Login con Validación de Credenciales**
- Se valida el acceso del usuario comparando los datos ingresados con los registrados en una base de datos SQL Server.
- La tabla `Users` incluye campos como:
  - TipoDocumento
  - NumeroDocumento
  - PasswordHash
  - IntentosFallidos
  - BloqueadoHasta
  - Nombres, Apellidos, Email, Teléfono, entre otros.

### 2. **Formulario de Perfil**
- Al iniciar sesión correctamente, el sistema redirige a una vista de perfil personalizada.
- Se muestra toda la información relevante del usuario que ha iniciado sesión.

### 3. **Plantilla con Menú Lateral y Encabezado Superior**
- Se incorporó una plantilla HTML responsive basada en Bootstrap.
- El **menú lateral** permite la navegación hacia otras secciones.
- En la **barra superior** se muestra el nombre completo del usuario logueado.

### 4. **Control de Sesión por Inactividad**
- El sistema cuenta con un mecanismo que detecta la **inactividad del usuario**.
- Luego de un tiempo configurable sin interacción (por ejemplo, 2 minutos en pruebas), **se cierra la sesión automáticamente** y se redirige al formulario de login.
- Esto mejora la **seguridad** del sistema en entornos públicos o compartidos.

---

👨‍💻 Autor y Licencia de Uso
Este proyecto ha sido desarrollado por Roger Quispe Del Castillo.

Se autoriza el uso libre de este código fuente para fines personales, educativos o comerciales siempre y cuando se mencione claramente al autor original del proyecto.

Si deseas incluir este prototipo en tus proyectos o materiales, solo te pido que me des el debido crédito como autor.

📧 Para cualquier consulta técnica o colaboración, puedes escribirme al correo:
logaresi.com@gmail.com
