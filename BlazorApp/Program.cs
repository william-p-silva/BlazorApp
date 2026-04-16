using BlazorApp.Components;
using BlazorApp.Services;
using BlazorApp.Dados; // Adicione este using

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 1. Registro do HttpClient
builder.Services.AddHttpClient();

// 2. Registro do Banco de Dados SQLite
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

// 3. Suporte para Controllers de API
builder.Services.AddControllers();

builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<OrderState>();
builder.Services.AddScoped<EnderecoService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();





var ScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = ScopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.MapControllers();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
