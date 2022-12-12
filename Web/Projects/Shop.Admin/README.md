# Shop Website

## Connect DB and Models Project
1. First, Install the following Packages from nuget
	* Microsoft.EntityFrameworkCore
	* Microsoft.EntityFrameworkCore.Tools
	* Microsoft.EntityFrameworkCore.SqlServer
2. Run the following Code
	Scaffold-DbContext "Server=<SERVER_NAME>;Database=<DB_NAME>;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force