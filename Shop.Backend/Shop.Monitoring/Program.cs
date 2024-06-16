var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHealthChecksUI().AddInMemoryStorage();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();
app.MapHealthChecksUI();

app.Run();
