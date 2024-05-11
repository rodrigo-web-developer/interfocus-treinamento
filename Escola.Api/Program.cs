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

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDeveloperExceptionPage();

app.MapControllers();

app.Run();
