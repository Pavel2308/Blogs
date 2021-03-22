using Blogs.Markdown.Intefaces;
using Blogs.Markdown.Parsers.ElementParsers;
using Blogs.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blogs.Markdown.Parsers;

namespace Blogs.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BlogsContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("BlogsContext"), b => b.MigrationsAssembly("Blogs.Infrastructure")));
            services.AddSingleton<IParser, MarkdownParser>();
            services.AddSingleton<IElementParser, BackslashEscapeParser>();
            services.AddSingleton<IElementParser, HorizontalLineParser>();
            services.AddSingleton<IElementParser, ImageParser>();
            services.AddSingleton<IElementParser, LinkParser>();
            services.AddSingleton<IElementParser, UnorderedListParser>();
            services.AddSingleton<IElementParser, OrderedListParser>();
            services.AddSingleton<IElementParser, CodeBlockParser>();
            services.AddSingleton<IElementParser, BlockquotParser>();
            services.AddSingleton<IElementParser, HeaderParser>();
            services.AddSingleton<IElementParser, CodeParser>();
            services.AddSingleton<IElementParser, EmphasisParser>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Posts}/{action=Index}/{id?}");
            });
        }
    }
}
