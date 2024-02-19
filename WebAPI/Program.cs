using AutoMapper;
using DomainLayer.Models;
using DomainLayer.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Impl.Repository;
using RepositoryLayer.Repository;
using RepositoryLayer.Repository.Imp;
using ServiceLayer.Service;
using ServiceLayer.Service.Imp;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Database Context Dependency Injection */
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
dbHost = "localhost,8003";
dbName = "dbName";
dbPassword = "password@12345#";
var connectionString = $"Server={dbHost};Database={dbName};User ID=SA;Password={dbPassword}";
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

/**************************************************************/

var services = builder.Services;
services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();
/*services.AddAuthentication().AddGoogle(options =>
{
    IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuthNSection["client_id"];
    options.ClientSecret = googleAuthNSection["client_secret"];
    // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
    options.CallbackPath = "/google-login";
});*/
services.AddSingleton(new MapperConfiguration(mc =>
{
    mc.AddProfile(new CategoryProfile());
    mc.AddProfile(new PostProfile());
    mc.AddProfile(new PostCategoryProfile());

}).CreateMapper());
//services.AddTransient<IEmailSender, SendMailService>();
services.AddScoped(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));
services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
services.AddScoped(typeof(IPostRepository), typeof(PostRepository));
services.AddScoped(typeof(IPostService), typeof(PostService));
services.AddScoped(typeof(IPostCategoryRepository), typeof(PostCategoryRepository));
//services.AddScoped(typeof(IPostCategoryService), typeof(PostCategoryService));





//services.Configure<MailSetting>(Configuration.GetSection("MailSettings"));
services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
