using StudentRegistration.Services; // Update namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Services (since repository is merged)
builder.Services.AddScoped<IStudentService, StudentService>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
    return new StudentService(connectionString);
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Update this with your Angular app's URL
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAngularApp");

// Map controllers
app.MapControllers();

// Run the application
app.Run();
