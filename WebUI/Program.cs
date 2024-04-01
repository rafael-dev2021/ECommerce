using Infra_Ioc;
using Infra_Ioc.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDomainInfrastructureModule(builder.Configuration);

builder.Services.AddEnUSCultureInfoDI();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


await SeedData.SeedUsersRoles(app);

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "adminOrderProducts",
    pattern: "{area:exists}/{controller=AdminOrder}/{action=Index}/{id}/{*catchall}",
    defaults: new { action = "Index" },
    constraints: new { id = @"(.*)" } 
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();




