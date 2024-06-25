var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ApiClient.LightClient client = new ApiClient.LightClient("http://localhost:5000");
Console.WriteLine(await client.GetSettings());
Console.WriteLine(await client.GetJobs());
Console.WriteLine(await client.StartJob("LightJobs.SingleRunJobs.SetColour, LightJobs", new[] {"#ff595"} ));
Console.WriteLine(await client.GetCurrentJob());
Console.WriteLine(await client.StopCurrentJob());
Console.WriteLine(await client.GetCurrentJob());



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
