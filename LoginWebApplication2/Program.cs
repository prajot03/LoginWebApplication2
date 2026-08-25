
using ApplicationLayer;
using InfrastratureLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Text;



namespace LoginWebApplication2
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    // 1. Define Bearer authentication
                    var securityScheme = new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Description = "Enter your JWT token to authenticate requests."
                    };

                    // 2. Register the Bearer scheme
                    document.Components ??= new OpenApiComponents();
                    document.Components.SecuritySchemes ??=
            new Dictionary<string, IOpenApiSecurityScheme>();

                    document.Components.SecuritySchemes.Add(
                        "BearerAuth",
                        securityScheme);
                    

                    return Task.CompletedTask;
                });
            });



            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration
            .GetConnectionString("DefaultConnection")));
            // Add services to the container.
            builder.Services.AddScoped<IRolesService, RoleService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IAuthenticateUserService,AuthenticateUserService>();
            // JWT token service
            builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
           // builder.Services.AddOpenApi();

            // Configure Authentication / JWT
            var jwtKey = builder.Configuration["JwtSettings:Key"];
            var issuer = builder.Configuration["JwtSettings:Issuer"];
            var audience = builder.Configuration["JwtSettings:Audience"];

            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.AddPreferredSecuritySchemes("BearerAuth");
                });
            }

            app.UseHttpsRedirection();

           
            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
