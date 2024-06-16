Bonjour afin de pouvoir tester l'application il y a plusieurs étapes à suivre.
Dans un premier temps si elle ne sont pas présente il y faut installer des dépendances, l'application étant en c# il faut installer.

- Swashbuckle.AspNetCore
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

Dans un second temps si vous n'avez SQL Server LocalDB il faut l'installer
Puis dans le terminal exécuter

- sqllocaldb create "MSSQLLocalDB"
- sqllocaldb start "MSSQLLocalDB"

Dans le terminal de gestionnaire NuGet

- Add-Migration InitialCreate
- Update-Database

Ensuite vous pouvez build puis tester avec 'URL de l'application hébergée
