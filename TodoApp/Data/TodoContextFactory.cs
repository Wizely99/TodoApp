// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;

// namespace TodoApp.Data
// {
//     public class TodoContextFactory : IDesignTimeDbContextFactory<TodoAppContext>
//     {
//         public TodoAppContext CreateDbContext(string[] args)
//         {
//             // Get the configuration from appsettings.json
//             IConfigurationRoot configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("appsettings.json")
//                 .Build();

//             // Get the connection string
//             var connectionString = configuration.GetConnectionString("TodoContext");

//             // Create the options for the context
//             var optionsBuilder = new DbContextOptionsBuilder<TodoAppContext>();
//             optionsBuilder.UseSqlite(connectionString); // Adjust to your database provider

//             return new TodoAppContext(optionsBuilder.Options);
//         }
//     }
// }
