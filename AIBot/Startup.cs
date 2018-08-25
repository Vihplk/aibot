using System.Text;
using AIBot.Core.Domain.Master;
using AIBot.Core.Dto.QuestionAndAnswer.Master;
using AIBot.Core.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using AIBot.Core.Service.Interface;
using AIBot.Core.Service.Session;
using AIBot.Core.Service.User;
using AutoMapper;
using StackExchange.Redis;

namespace AIBot
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
            services.AddMvc();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = GlobalConfig.Issuer,
                        ValidAudience = GlobalConfig.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalConfig.Key))
                    };
                });

            services.AddTransient<IAIBotDbContext, AIBotDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IQuestionSessionService, QuestionSessionService>();
            services.AddTransient<IBotService, BotService>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<QuestionDto, Question>().ReverseMap();
                cfg.CreateMap<Answer, AnswerDto>()
                    .ForMember(des => des.AnswerName, p2 => p2.MapFrom(sou => sou.AnswerName.Replace(" ", "+")));
                cfg.CreateMap<AnswerDto, Answer>();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
