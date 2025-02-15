using Asp.Versioning;
using Asp.Versioning.Conventions;
using BenTechAPI.Data;
using BenTechAPI.Security;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var signingKey = builder.Configuration["JwtSettings:SigningKey"];
builder.Services
   .AddAuthenticationJwtBearer(s => s.SigningKey = signingKey)
   .AddAuthorization(options =>
   {
       options.AddPolicy("AdminOnly", policy => policy.RequireClaim("userIsadmin", "True"));
   })
.AddFastEndpoints()
.AddVersioning(o =>
{
    o.DefaultApiVersion = new(1.0);
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ApiVersionReader = new HeaderApiVersionReader("Api version 1");
});

builder.Services.AddSingleton<IPasswordHasher, PasswordHasherService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
}
    );


VersionSets.CreateApi(">>Login<<", v => v
.HasApiVersion(1.0)
);
VersionSets.CreateApi(">>User<<", v => v
.HasApiVersion(1.0)
);
VersionSets.CreateApi(">>Dates<<", v => v
.HasApiVersion(1.0)
); VersionSets.CreateApi(">>Prices<<", v => v
.HasApiVersion(1.0)
);

builder.Services
   .SwaggerDocument(o =>
   {
       o.DocumentSettings = x =>
       {
           x.DocumentName = "version one";
           x.ApiVersion(new(1.0));
       };
       o.AutoTagPathSegmentIndex = 0; //need to disable path segment based auto tagging
   });

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoConnection"));
});

var app = builder.Build();
app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.Run();
