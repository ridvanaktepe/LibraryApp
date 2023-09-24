using LibraryApp.Data.Abstract;
using LibraryApp.Data.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add the Library Context and specify the connection string
var connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<LibraryContext>(options=> options.UseSqlite(connectionString));

// Add services to the container by using the DI pattern
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

// Add other services as needed
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
