using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtAuth;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<TokenManagement>(builder.Configuration.GetSection("tokenConfig"));
        var token = builder.Configuration.GetSection("tokenConfig").Get<TokenManagement>();
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            //Token Validation Parameters
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                //获取或设置要使用的Microsoft.IdentityModel.Tokens.SecurityKey用于签名验证。
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.
                GetBytes(token.Secret)),
                //获取或设置一个System.String，它表示将使用的有效发行者检查代币的发行者。
                ValidIssuer = token.Issuer,
                //获取或设置一个字符串，该字符串表示将用于检查的有效受众反对令牌的观众。
                ValidAudience = token.Audience,
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
        builder.Services.AddScoped<IAuthenticateService, TokenAuthenticationService>();
        builder.Services.AddScoped<IUserService, UserService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}