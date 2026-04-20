using Microsoft.EntityFrameworkCore;
using SistemaDeVenda.Data;
using SistemaDeVenda.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseInMemoryDatabase("BancoVendas"));

builder.Services.AddScoped<VendaService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("1 - Vendas", new() { Title = "Vendas", Version = "v1" });
    c.SwaggerDoc("2 - Contratos", new() { Title = "Contratos", Version = "v1" });
    c.SwaggerDoc("3 - Faturas", new() { Title = "Faturas", Version = "v1" });
    c.SwaggerDoc("4 - Relatorio", new() { Title = "Relatório", Version = "v1" });

    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        return apiDesc.GroupName == docName;
    });
});

var app = builder.Build();

// Swagger 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/1 - Vendas/swagger.json", "Vendas");
        c.SwaggerEndpoint("/swagger/2 - Contratos/swagger.json", "Contratos");
        c.SwaggerEndpoint("/swagger/3 - Faturas/swagger.json", "Faturas");
        c.SwaggerEndpoint("/swagger/4 - Relatorio/swagger.json", "Relatório");
    });
}

//  CORS 
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();