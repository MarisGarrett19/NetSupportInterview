using Application;
using Application.Groups;
using Application.Users;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DemoData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IAppDbContext>(services => services.GetRequiredService<AppDbContext>());

// Register our app services
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDemoDataService, DemoDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
