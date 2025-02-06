using AWBlazor.Components;
using AWBlazor.EFClass;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Queues;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* !!!!!!!!!!!
 Very Important, because we need injection to be able to use these classes in razor components
 !!!!!!!!!!!!
*/
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//options: I choose to use SqlServer, I can also choose to use SqlLite, hence this "options"
builder.Services.AddDbContextFactory<AdventureWorksLt2019Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_DB")) //within DB context, we need to supply connection string
    );

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton(typeof(QueueServiceClient), new QueueServiceClient(builder.Configuration["ConnString"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

/* middlewares */
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
