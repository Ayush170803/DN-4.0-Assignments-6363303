using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer",options =>
    {
        var config=builder.Configuration;
        options.TokenValidationParameters=new TokenValidationParameters
        {
            ValidateIssuer=true,
            ValidateAudience=true,
            ValidateLifetime=true,
            ValidateIssuerSigningKey=true,
            ValidIssuer=config["Jwt:Issuer"],
            ValidAudience=config["Jwt:Audience"],
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed=context =>
            {
                if (context.Exception.GetType()==typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired","true");
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

var app=builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
