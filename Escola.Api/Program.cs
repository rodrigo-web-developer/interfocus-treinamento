using InterfocusConsole.Services;
using NHibernate;
using NHibernate.Cfg;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ISessionFactory>((s) =>
{
    var config = new Configuration();
    config.Configure();
    return config.BuildSessionFactory();
});

builder.Services.AddMvcCore().AddJsonOptions(
    x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    }    
);

if (true)
{
    // configura SQL SERVER
}
else
{
    // configura postgres
}
builder.Services.AddTransient<AlunoService>();
builder.Services.AddTransient<CursoService>();

builder.Services.AddCors(
    b => b.AddDefaultPolicy(c => 
        c.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseDeveloperExceptionPage();
app.MapControllers();

app.Run();
