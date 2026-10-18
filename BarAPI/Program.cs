var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadir la carpeta de controllers
builder.Services.AddControllers();

// Configurar CORS para permitir solicitudes desde Blazor
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirBlazor", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
//Activar CORS para permitir solicitudes desde Blazor
app.UseCors("PermitirBlazor");

app.Run();
