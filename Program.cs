using Professor_TI_Onboarding.Services;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ADICIONE ESTA LINHA - Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:3000", "http://localhost:5174", "http://localhost:3001")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// registra o agente como Singleton
builder.Services.AddSingleton<OpenAIAgentService>();

var app = builder.Build();

// ADICIONE ESTA LINHA - Usar o CORS (ANTES de MapControllers)
app.UseCors("AllowReactApp");

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();