using Play.Catalog.Service.Entities;
using Play.Common.MassTransit;
using Play.Common.MongoDB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongo()
        .AddMongoRepository<Items>("items")
        .AddMassTransitWithRabbitMq();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

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
