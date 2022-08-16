using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using TokenAuthentication.Model;
using TokenAuthentication.Service;
using Microsoft.IdentityModel;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using DigitalBooksApp.DatabaseEntity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();//
builder.Services.AddSingleton<ITokenService>(new TokenService());
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Authentication:Audience"],
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
    };
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.MapPost("/validate", [AllowAnonymous](UserValidationRequestModel request, HttpContext http, ITokenService tokenService) =>
//{
//    if (request is UserValidationRequestModel {UserName },)
//    {
//        var token = tokenService.BuildToken(builder.Configuration["Authentication:Key"],
//                                            builder.Configuration["Authentication:Issuer"],
//                                            new[]
//                                            {
//                                                builder.Configuration["Authentication:Aud1"],
//                                                builder.Configuration["Authentication:Aud2"]
//                                            },
//                                            request.UserName);
//        return new
//        {
//            Token = token,
//            IsAuthenticated = true,
//        };
//    }
//    return new
//    {
//        Token = string.Empty,
//        IsAuthenticated = false,
//    };
//})
//    .WithName("validate");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
