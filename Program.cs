using Crm_CSharp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<AlertRateService>(client => { client.BaseAddress = new Uri("http://localhost:8080"); });

builder.Services.AddHttpClient<ExpenseService>(client => { client.BaseAddress = new Uri("http://localhost:8080"); });

builder.Services.AddHttpClient<LeadService>(client => { client.BaseAddress = new Uri("http://localhost:8080"); });

builder.Services.AddHttpClient<TicketService>(client => { client.BaseAddress = new Uri("http://localhost:8080"); });

builder.Services.AddHttpClient<CustomerStatisticsDTOService>(client =>{client.BaseAddress = new Uri("http://localhost:8080");});

builder.Services.AddHttpClient<BudgetService>(client => { client.BaseAddress = new Uri("http://localhost:8080"); });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();