using WebAppSample.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Install-Package Swashbuckle.AspNetCore
builder.Services.AddSwaggerGen();

var app = builder.Build();

// فعال کردن Swagger
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();