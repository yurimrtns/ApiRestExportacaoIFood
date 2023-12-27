using CamadaDeDados.Interface;
using CamadaDeNeg�cios.Profiles;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<Singleton>();
builder.Services.AddSingleton<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddSingleton<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddSingleton<ISegmentoRepository, SegmentoRepository>();

builder.Services.AddAutoMapper(typeof(CategoriaProfile),typeof(EmpresaProfile),typeof(SegmentoProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiExpIFood", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
