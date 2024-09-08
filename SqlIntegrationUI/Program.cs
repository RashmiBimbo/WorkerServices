
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SqlIntegrationUI;
using static SqlIntegrationUI.UIUtilities.UICommonCode;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMemoryCache();

            string erp_SQL_ConnStr = builder.Configuration.GetValue("ERP_SQL_ConnStr", Emp);

            //string erp_SQL_ConnStr = "Data Source=10.10.1.138;Initial Catalog=ERP_SQL_Integration;User ID=sa;Password='=*fj9*N*uLBRNZV';Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            if (string.IsNullOrEmpty(erp_SQL_ConnStr))
                throw new InvalidOperationException("Connection string 'ERP_SQL_ConnStr' not found or is empty.");

            builder.Services.AddDbContext<ErpSqlDbContext>(options => options.UseSqlServer(erp_SQL_ConnStr, sqlOptions =>
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Shared/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseResponseCaching();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Services}/{action=Index}/{searchString?}");

            app.Run();

        }
        catch (Exception ex)
        {
            LogInfo(ex, LogFile, NameSpacesUsed);
        }
    }
}