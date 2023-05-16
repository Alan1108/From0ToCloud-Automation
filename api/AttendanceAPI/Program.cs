using MongoDB.Driver;
using Microsoft.Extensions.Options;
using AttendanceAPI.Model;
using AttendanceAPI.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AttendanceDBSettings>(
                    builder.Configuration.GetSection(nameof(AttendanceDBSettings)));
builder.Services.AddSingleton<IAttendanceDBSettings>(sp =>
    sp.GetRequiredService<IOptions<AttendanceDBSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("AttendanceDBSettings:ConectionString")));
builder.Services.AddScoped<IMembersService,MembersService>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
