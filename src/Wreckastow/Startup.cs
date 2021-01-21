using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WreckaStow.Models;
using WreckaStow.Services;

namespace WreckaStow
{
    public sealed class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddSingleton<IAlbumRepository>(new AlbumRepositoryStub(
                new Album
                {
                    Title = "Purple Rain",
                    Artist = "Prince & The Revolution",
                    ReleaseDate = DateTime.Parse("1984-06-25"),
                    DateAvailable = DateTime.Parse("2017-12-24"),
                    Description = @"Purple Rain (the motion picture soundtrack to the movie Purple Rain) is the sixth full-length 
    studio album by Prince, and the first to be credited to Prince and the Revolution. 
    It was released worldwide in June 1984, a month before the movie, Purple Rain opened in theaters."
                },
                new Album
                {
                    Title = "Lovesexy",
                    Artist = "Prince",
                    DateAvailable = DateTime.Parse("2018-02-12")
                },
                new Album
                {
                    Title = "Plectrumelectrum",
                    Artist = "3rdeyegirl",
                    DateAvailable = DateTime.Parse("2018-01-02")
                }
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRequestLocalization("en-AU");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
