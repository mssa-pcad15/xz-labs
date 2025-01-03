using MortgageCalculator;
using RazorPagesMovie;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Use this "Services" collections: Dependency injections. S.A. if I consume sth. I don't need to know how this thing is made, I only need to inject it and consume it.
builder.Services.AddRazorPages(); //AddRazerPages() is an extension method
builder.Services.AddSingleton(typeof(Counter), new Counter()); //when someone needs a Counter, given them ONE instance of it.

//MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);
//builder.Services.AddSingleton(typeof(MortgageCalc), mortgageCalc); //Singleton means there might be 100 people asking for it, but there is always one instance returned
//Singleton is used for Global, Stateful service
WebApplication? app = builder.Build(); //this "builder" builds web application, whenever it calls "Build()", it returns an instance of app

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); 
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run(); //Run() will block program exiting, it hangs
