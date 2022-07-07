using EFCoreMovies_Demo_2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// the IgnoreCycles fixes --> System.Text.Json.JsonException: A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32
builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(Program));

// ApplicationDbContext builder services with NetTopologySuite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql("name=DefaultConnection", npgsql => npgsql.UseNetTopologySuite());
    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //options.UseLazyLoadingProxies();
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
