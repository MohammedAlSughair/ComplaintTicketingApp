using ComplaintTicketingApp.Entities;
using ComplaintTicketingApp.Repository;
using ComplaintTicketingApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CTADBContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("CTAConnectionString"));
});
builder.Services.AddSession();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<ITicketsrv, Ticketsrv>();
builder.Services.AddTransient<ICategorysrv, Categorysrv>();
builder.Services.AddTransient<IUsersrv, Usersrv>();
builder.Services.AddTransient<IDocumentsrv, Documentsrv>();
builder.Services.AddTransient<ITicketTransactionsrv, TicketTransactionsrv>();
builder.Services.AddTransient<IActionsrv, Actionsrv>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddMvc(o => o.EnableEndpointRouting = false)
  .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
