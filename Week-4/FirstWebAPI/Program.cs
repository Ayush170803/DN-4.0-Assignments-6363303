using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>
{
    options.AddPolicy("AllowAll",policy=> policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var securityKey="mysuperdupersecret"; 
var symmetricKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey.PadRight(32, 'x')));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters=new TokenValidationParameters
    {
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,

        ValidIssuer="mySystem",
        ValidAudience="myUsers",
        IssuerSigningKey=symmetricKey
    };
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title="Swagger Demo",
        Version="v1",
        Description="Demo Web API",
        Contact=new OpenApiContact
        {
            Name="John Doe",
            Email="john@example.com",
            Url=new Uri("https://example.com")
        }
    });

    c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
    {
        In=ParameterLocation.Header,
        Description="Enter 'Bearer' [space] and then your token",
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app=builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json","Swagger Demo");
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
