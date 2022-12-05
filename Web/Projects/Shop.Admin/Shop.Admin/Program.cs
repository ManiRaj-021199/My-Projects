using Shop.Admin.Services.AdminPanel;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAdminPanelService, AdminPanelService>();
builder.Services.AddHttpClient<IAdminPanelService, AdminPanelService>(client =>
                                                                      {
                                                                          client.BaseAddress = new Uri("https://localhost:7277/");
                                                                      });

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();