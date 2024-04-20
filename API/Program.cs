using Microsoft.AspNetCore.Localization;
using SharpApi.Repository;
using SharpApi.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("USERS")));

// Dans la méthode ConfigureServices
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("fr-FR");
});

// Add services to the container.
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

//AUTO MAPPER
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//SERVICES
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
