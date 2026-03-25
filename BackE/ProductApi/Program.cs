var builder = WebApplication.CreateBuilder(args);

// ============================================
// PART 1: ADD SERVICES (Before builder.Build)
// ============================================

// Add CORS Policy right here at the top
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// LOCK IN THE SERVICES
var app = builder.Build();

// ============================================
// PART 2: USE PIPELINES (After builder.Build)
// ============================================

if (app.Environment.IsDevelopment())
{
   
}

// ** Use CORS exactly here! **
app.UseCors("AllowAngular");

app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "The .NET Web API is successfully running!");
app.Run();
