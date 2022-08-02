*Entity Framework Database First Approch*
---
1. Create Project with Visual Studio.
2. Install Following NuGet Packages :
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
    - System.Data.SqlClient
    - System.Configuration.ConfigurationManager
3. Connect with database.
4. Open Package Manager Console And Run Following Command
    `Scaffold-DbContext "Data Source=PC0345\MSSQL2019;Initial Catalog=Blogging;Integrated Security=True;Trust Server Certificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models`
5. Add Application Configuration File to store ConnectionString.
6. Add Following in App.Config File
    `<connectionStrings>
		<add name="BloggingDB" connectionString="Data Source=PC0345\MSSQL2019;Initial Catalog=Blogging;Integrated Security=True;Trust Server Certificate=True;"/>
	</connectionStrings>`
7. Change ConnectionString from contect File
    `ConfigurationManager.ConnectionStrings["BloggingDB"].ConnectionString`
8. Create new Classs file and Create connection in constructor to do database related operation.