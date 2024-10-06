using Inventory.Data;
using Inventory.Service.Sevices.AlertService;
using Inventory.Service.Sevices.CategoryService;
using Inventory.Service.Sevices.ProductService;
using Inventory.Service.Sevices.Reports;
using Inventory.Service.Sevices.SupplierService;
using Inventory.Service.Sevices.TransactionService;
using Inventory.Service.Sevices.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task.Repositories;

namespace Inventory
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITransactionService,TransactionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IAlertService, AlertService>();
            builder.Services.AddDbContext<ApplicationDBcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<User,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBcontext>()
                .AddDefaultUI()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders();
           
           //adding identity
            
           

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();    
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "admin", "user" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            //using (var scope = app.Services.CreateScope())
            //{
            //    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            //    //string userNam = "Admin";
            //    //string email = "admin@admin.com";
            //    //string password = "Admin123??";
            //    if (await userManager.FindByEmailAsync(email) == null)
            //    {
            //        var user = new User();
            //        user.UserName = userName;
            //        user.NormalizedEmail = email;

            //        await userManager.CreateAsync(user, password);

            //        userManager.AddToRoleAsync(user, "admin");
            //    }

            //}

            app.Run();
        }
    }
}