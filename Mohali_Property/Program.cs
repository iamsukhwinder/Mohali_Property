
using MohaliProperty.Services.WebServices.Admin.Login;
using MohaliProperty.Services.WebServices.Admin.ManageCompany;
using MohaliProperty.Services.WebServices.Admin.ManageCustomer;
using MohaliProperty.Services.WebServices.Admin.ManageKothi;
using MohaliProperty.Services.WebServices.Admin.ManageTokens;
using MohaliProperty.Services.WebServices.Admin.ManageUser;
using MohaliProperty.Services.WebServices.SignUp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepsoitory>();
builder.Services.AddScoped<IManageKothi, ManageKothi>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IManageCustomer, ManageCustomer>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISignUpRepository, SignUp>();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});




// Add Claim
builder.Services.AddAuthentication("CookieAuthentication")
                .AddCookie("CookieAuthentication", config =>
                {
                    config.Cookie.Name = "UserLoginCookie"; // Name of cookie     
                    config.LoginPath = "/Home/Login"; // Path for the redirect to user login page    
                    config.AccessDeniedPath = "/Home/Denied";
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
    
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
