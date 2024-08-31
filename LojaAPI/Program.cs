var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        corsBuilder => corsBuilder.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
});

// Add authorization service
builder.Services.AddAuthorization();

// Add controllers service
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

app.UseHttpsRedirection();

// Add CORS middleware here
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
