// <auto-generated/>
using EUC.Profile.Buddy.Web.Components;
using EUC.Profile.Buddy.Web.Configurations;
using EUC.Profile.Buddy.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using NSwag;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddDbContext<ProfileDataRepository>(options =>
{
	options.UseSqlite("Data Source=Profile.Data.Repository.db");
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddMudServices();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApiDocument(options =>
{
    options.PostProcess = document =>
    {
        document.Info = new OpenApiInfo
        {
            Version = "v1",
            Title = "EUC Profile Buddy API",
            Description = "API documentation for EUC Profile Buddy services.",
            TermsOfService = "https://bretty.me.uk/terms",
            Contact = new OpenApiContact
            {
                Name = "bretty.me.uk Support",
                Email = "dave@bretty.me.uk",
                Url = new Uri($"https://bretty.me.uk/").ToString(),
            },
        };
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();

    app.UseOpenApi();
    app.UseSwaggerUi();
    app.UseReDoc(options =>
    {
        options.Path = "/redoc";
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();

app.UseReDoc(options =>
{
    options.Path = "/redoc";
});

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
