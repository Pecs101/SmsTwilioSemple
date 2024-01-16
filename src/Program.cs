using SMSAPIs.Entities;
using SmsTwilioSemple.Helper.Servicies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<SmsConfig>(builder.Configuration.GetSection("TwilioSetting")); // Map Config params to object
builder.Services.AddTransient<ISmsExecService, SmsExecService>(); // Dependency declaration

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
