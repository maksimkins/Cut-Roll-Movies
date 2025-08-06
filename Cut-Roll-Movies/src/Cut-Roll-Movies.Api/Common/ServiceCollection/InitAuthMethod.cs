namespace Cut_Roll_Movies.Api.Common.ServiceCollection;

using System.Security.Claims;
using Cut_Roll_Movies.Core.Common.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static class InitAuthMethod
{
    public static void InitAuth(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection("Jwt") ?? throw new ArgumentNullException("Jwt section not found");
        serviceCollection.Configure<JwtOptions>(jwtSection);

        var jwtOptions = jwtSection.Get<JwtOptions>() ?? throw new Exception("Cannot bind Jwt section");

        serviceCollection
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtOptions.KeyInBytes)
                };
            });

        serviceCollection.AddAuthorization(options =>
        {
            options.AddPolicy("Essentials", policy => {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("EmailConfirmed", "True");
                policy.RequireClaim(ClaimTypes.Email);
                policy.RequireClaim(ClaimTypes.NameIdentifier);
            });
            
            options.AddPolicy("NotMuted", policy => {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("IsMuted", "False");
            });
        });
    }
}