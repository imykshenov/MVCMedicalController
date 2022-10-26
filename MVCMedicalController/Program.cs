using Microsoft.EntityFrameworkCore;
using MVCMedicalController.Data;
using MVCMedicalController.Modules;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MedicalContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCMedicalControllerContext") ?? throw new InvalidOperationException("Connection string 'MVCMedicalControllerContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    DbIni.Initialize(services);
//}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseSwagger();
   //app.UseSwaggerUI();
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