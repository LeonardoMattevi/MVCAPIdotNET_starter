1) Connection string example in web.config. NB: check name of DB, User Id and password.
<add name="AppDbContext" providerName="System.Data.SqlClient" connectionString="Server=.\SQLEXPRESS; Database=CodeFirstExample; Integrated Security=False;User ID=localadmin;Password=admin" />

2) DbContext with entity example
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
}

3) If don't exist Migration directory in to application root... Enamle migration with console command: Enable-Migrations

4) console command: Add-Migration "write a comment" (folder migration has been created)

5) Update database console command: Update-Database
 
