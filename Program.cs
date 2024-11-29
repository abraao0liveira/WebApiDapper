using WebApiDapper.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Adiciona o serviço de Controllers

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUser, UserService>(); //Conecta a interface IUser com a classe UserService

builder.Services.AddAutoMapper(typeof(Program)); //Adiciona o AutoMapper

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); //Adiciona o serviço de autorização

app.MapControllers(); //Adiciona o serviço de Controllers

app.Run();

// link: http://localhost:5050/swagger/index.html
