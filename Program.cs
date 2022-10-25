using movie_api.Data;
using Microsoft.EntityFrameworkCore;
using movie_api.Repository;
using movie_api.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

builder.Services.AddTransient<IMovies, MovieRepo>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c=> 
            {   
                
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Movie Archive",
                    Version = "v1",
                    Description = "An API to perform Movie operations",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Deniz Çamalan",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Movie LCC",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                //c.CustomSchemaIds(type => type.FullName);
                // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                //     Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                //     Name        = "Authorization",
                //     In          = ParameterLocation.Header,
                //     Type        = SecuritySchemeType.ApiKey,
                //     Scheme      = "bearer",
                //     Reference   = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                // });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new List<string>() }
                });
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
{
    options.PreSerializeFilters.Add((swagger, httpReq) =>
    {
        var scheme = httpReq.Host.Host.StartsWith("localhost", StringComparison.OrdinalIgnoreCase) ? "http" : "https";
        swagger.Servers = new List<OpenApiServer>() {new OpenApiServer() {Url = $"{scheme}://{httpReq.Host}"}};
    });
});

    app.UseSwaggerUI(c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie_App v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
