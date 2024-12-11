using OurProject.Components;
using OurProject.Components.Pages;
using OurProject.Data;

namespace OurProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSingleton<MongoDBContext>(sp =>
                new MongoDBContext(builder.Configuration));
            builder.Services.AddControllers();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7160") });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapControllers();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.UseCors();
            app.MapBlazorHub();
            

            app.Run();
        }
    }
}
