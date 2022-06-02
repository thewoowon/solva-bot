// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.15.2

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SolvaBot
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
            services.AddHttpClient().AddControllers().AddNewtonsoftJson();

            // 봇 어댑터와 함께 사용되어야하는 봇 프레임워크 인증을 생성한다.
            services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();

            // 봇 어댑터를 에러 핸들링과 함께 생성한다.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            // 사용자 객체와 대화 상태를 사용하기 위한 저장소를 생성한다.
            services.AddSingleton<IStorage, MemoryStorage>();

            // 사용자 상태 객체를 생성한다.
            services.AddSingleton<UserState>();

            // 대화 상태 객체를 생성한다.
            services.AddSingleton<ConversationState>();

            // 봇이 사용할 예정인 다이얼로그(문답) -> 메인 스테이지 
            services.AddSingleton<MainDialog>();

            // 일시적인 봇을 생성합니다.  ASP 컨트롤러가 Bot 인터페이스를 형성할 때
            // Transient -> 과도현상 -> 본론으로 넘어가기 전에 나타나는 현상을 말합니다.
            services.AddTransient<IBot, RichCardsBot>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                //.UseWebSockets() // 다이렉트라인 필요 없음
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            // app.UseHttpsRedirection();
        }
    }
}
