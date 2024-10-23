
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;
using PruebaApi.Repositories;
using PruebaApiNet.Database;
using PruebaApiNet.Repositories;
using PruebaApiNet.SakilaDatabase;
using System.Text;
using System.Text.Json.Serialization;

namespace PruebaApiNet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container INYECTOR.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; //Cuando el JSON detecte que hay un ciclo lo corta
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<MyDbContext>(); //Base de datos
            builder.Services.AddScoped<SakilaMasterContext>(); //Base de datos Sakila
            //builder.Services.AddScoped<AddressRepository>();
            //builder.Services.AddScoped<FilmRepository>();
            //builder.Services.AddScoped<LenguajeRepository>();
            builder.Services.AddScoped<UnitOfWork>();

            builder.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    string key = "PatatasPacoPatatasPacoPatatasPacoPatatasPacoPatatasPacoPatatasPacoPatatasPaco"; //Clave muy segura, mínimo 25 caracteres

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Si no nos importa que se valide el emisor del token, lo desactivamos.
                        ValidateIssuer = false,
                        //Si no nos importa que se valida para quien o para que proposito esta destinado el token, lo desactivamos
                        ValidateAudience = false,
                        //Indicamos la clave
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))

                    };
                });

            var app = builder.Build(); 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();  //Autenticamos primero
            app.UseAuthorization();   //Autorizamos despues


            app.MapControllers();

            using (IServiceScope scope = app.Services.CreateScope()) //Con using finaliza el metodo
            {
                MyDbContext context = scope.ServiceProvider.GetService<MyDbContext>();
                
                if (context.Database.EnsureCreated())
                {
                    Author author = new Author() { Name = "Miguel" }; //Creamos un nuevo Autor
                    Book book = new Book() { Name = "Quijote"};

                    author.Books.Add(book);

                    context.Authors.Add(author);
                    context.SaveChanges(); //Guardamos los cambios
                }



                //AddressRepository addressRepository = scope.ServiceProvider.GetService<AddressRepository>();
                //await addressRepository.InsertAsync(new Address() { Address1 = "Casa" });
                //await addressRepository.InsertAsync(new Address() { Address1 = "Edificio" });

                //AddressRepository lenguajeRepository = scope.ServiceProvider.GetService<LenguajeRepository>();
                //await lenguajeRepository.InsertAsync(new Address() { LanguageId = 1200, Name = "Casa" });
                //await lenguajeRepository.InsertAsync(new Address() { LanguageId = 1200, Name = "Edificio" });


                //UnitOfWork unitOfWork = scope.ServiceProvider.GetService<UnitOfWork>();
                ////Probar esto con book
                //await unitOfWork.LenguajeRepository.InsertAsync(new Language() { LanguageId = 1204, Name = "Casa" });
                //Language language = await unitOfWork.LenguajeRepository.InsertAsync(new Language() { LanguageId = 1204, Name = "Casa" });
                //await unitOfWork.SaveAsync();

                //Console.WriteLine(language.LanguageId);
            }

            app.Run();
        }

    }
}
