using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Miniaction.API.Extensions;
using Miniaction.API.JWT;
using Miniaction.API.JWT.TokenStorage;
using Miniaction.Application;
using Miniaction.Application.Tracking;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Implementation.Tracking;
using Miniaction.Implementation.UseCases.Commands;
using Miniaction.Implementation.UseCases.Queries;
using Miniaction.Implementation.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Miniaction.API
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
            var appSettings = new AppSettingsDTO();
            Configuration.Bind(appSettings);
            services.AddHttpContextAccessor();
            /*
                Transient - Svaki put kada se zatrazi objekat, kreira se novi
                Scoped - Ponovna upotreba na nivou 1 http zahteva
                Singleton - jedan objekat od starta do stop-a aplikacije
                
            */
            services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
            services.AddTransient<JWTManager>(x =>
            {
                var context = x.GetService<MiniactionContext>();
                var tokenStorage = x.GetService<ITokenStorage>();
                return new JWTManager(context, appSettings.JWT.Issuer, appSettings.JWT.SecretKey, appSettings.JWT.DurationSeconds, tokenStorage);
            });
            services.AddTransient<MiniactionContext>(x =>
            {
                DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
                builder.UseSqlServer("Data Source=localhost; Initial Catalog = Miniaction; Integrated Security = true");
                return new MiniactionContext(builder.Options);
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Miniaction.API", Version = "v1" });
            });
            services.AddScoped<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var data = header.ToString().Split("Bearer ");

                if (data.Length < 2)
                {
                    return new UnvalidatedActor();
                }

                var handler = new JwtSecurityTokenHandler();

                var tokenObj = handler.ReadJwtToken(data[1].ToString());

                var claims = tokenObj.Claims;

                var email = claims.First(x => x.Type == "EmailAddress").Value;
                var id = claims.First(x => x.Type == "ID").Value;
                var username = claims.First(x => x.Type == "Username").Value;
                var roleID = claims.First(x => x.Type == "RoleID").Value;
                var useCaseIDs = claims.First(x => x.Type == "UseCaseIDs").Value;
                return new JWTActor
                {
                    EmailAddress = email,
                    ID = int.Parse(id),
                    Username = username,
                    RoleID = int.Parse(roleID),
                    UseCaseIDs = JsonConvert.DeserializeObject<List<int>>(useCaseIDs)
                };
            });
            services.AddTransient<ICreateGenreCommand, EFCreateGenreCommand>();
            services.AddTransient<ICreateFormatCommand, EFCreateFormatCommand>();
            services.AddTransient<ICreateNetworkCommand, EFCreateNetworkCommand>();
            services.AddTransient<ICreatePGCommand, EFCreatePGCommand>();
            services.AddTransient<ICreateSerialCommand, EFCreateSerialCommand>();
            services.AddTransient<ICreateTrailerCommand, EFCreateTrailerCommand>();
            services.AddTransient<ICreateOptionCommand, EFCreateOptionCommand>();
            services.AddTransient<ICreateRoleCommand, EFCreateRoleCommand>();
            services.AddTransient<ICreateUserCommand, EFCreateUserCommand>();
            services.AddTransient<ICreateAvatarCommand, EFCreateAvatarCommand>();
            services.AddTransient<ICreateOrderCommand, EFCreateOrderCommand>();
            services.AddTransient<ICreateStarCommand, EFCreateStarCommand>();
            services.AddTransient<ICreateReviewCommand, EFCreateReviewCommand>();
            services.AddTransient<ICreateGrantCommand, EFCreateGrantCommand>();
            services.AddTransient<ISearchGenresQuery, EFSearchGenresQuery>();
            services.AddTransient<ISearchFormatsQuery, EFSearchFormatsQuery>();
            services.AddTransient<ISearchNetworksQuery, EFSearchNetworksQuery>();
            services.AddTransient<ISearchPGsQuery, EFSearchPGsQuery>();
            services.AddTransient<ISearchSerialsQuery, EFSearchSerialsQuery>();
            services.AddTransient<ISearchTrailersQuery, EFSearchTrailersQuery>();
            services.AddTransient<ISearchOptionsQuery, EFSearchOptionsQuery>();
            services.AddTransient<ISearchRolesQuery, EFSearchRolesQuery>();
            services.AddTransient<ISearchUsersQuery, EFSearchUsersQuery>();
            services.AddTransient<ISearchAvatarsQuery, EFSearchAvatarsQuery>();
            services.AddTransient<ISearchOrdersQuery, EFSearchOrdersQuery>();
            services.AddTransient<ISearchStarsQuery, EFSearchStarsQuery>();
            services.AddTransient<ISearchReviewsQuery, EFSearchReviewsQuery>();
            services.AddTransient<ISearchGrantsQuery, EFSearchGrantsQuery>();
            services.AddTransient<ISearchTrackingsQuery, EFSearchTrackingsQuery>();
            services.AddTransient<IFindGenreQuery, EFFindGenreQuery>();
            services.AddTransient<IFindFormatQuery, EFFindFormatQuery>();
            services.AddTransient<IFindNetworkQuery, EFFindNetworkQuery>();
            services.AddTransient<IFindPGQuery, EFFindPGQuery>();
            services.AddTransient<IFindSerialQuery, EFFindSerialQuery>();
            services.AddTransient<IFindTrailerQuery, EFFindTrailerQuery>();
            services.AddTransient<IFindOptionQuery, EFFindOptionQuery>();
            services.AddTransient<IFindRoleQuery, EFFindRoleQuery>();
            services.AddTransient<IFindUserQuery, EFFindUserQuery>();
            services.AddTransient<IFindAvatarQuery, EFFindAvatarQuery>();
            services.AddTransient<IFindOrderQuery, EFFindOrderQuery>();
            services.AddTransient<IFindStarQuery, EFFindStarQuery>();
            services.AddTransient<IFindReviewQuery, EFFindReviewQuery>();
            services.AddTransient<IFindGrantQuery, EFFindGrantQuery>();
            services.AddTransient<IFindTrackingQuery, EFFindTrackingQuery>();
            services.AddTransient<CreateNetworkValidator>();
            services.AddTransient<CreateGenreValidator>();
            services.AddTransient<CreatePGValidator>();
            services.AddTransient<CreateStarValidator>();
            services.AddTransient<CreateFormatValidator>();
            services.AddTransient<CreateTrailerValidator>();
            services.AddTransient<CreateAvatarValidator>();
            services.AddTransient<CreateSerialValidator>();
            services.AddTransient<CreateOptionValidator>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<CreateGrantValidator>();
            services.AddTransient<CreateReviewValidator>();
            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<PatchNetworkValidator>();
            services.AddTransient<PatchGenreValidator>();
            services.AddTransient<PatchPGValidator>();
            services.AddTransient<PatchStarValidator>();
            services.AddTransient<PatchFormatValidator>();
            services.AddTransient<PatchFileValidator>();
            services.AddTransient<PatchSerialValidator>();
            services.AddTransient<PatchOptionValidator>();
            services.AddTransient<PatchOrderValidator>();
            services.AddTransient<PatchReviewValidator>();
            services.AddTransient<PatchRoleValidator>();
            services.AddTransient<PatchUserValidator>();
            services.AddJWT(appSettings);
            services.AddTransient<IUseCaseTracker, EFUseCaseTracker>();
            services.AddTransient<IQueryHandler>(x =>
            {
                var actor = x.GetService<IApplicationActor>();
                var tracker = x.GetService<IUseCaseTracker>();
                var queryHandler = new QueryHandler(actor,tracker);
                //var timeTrackingHandler = new TimeTrackingQueryHandler(queryHandler);
                //var trackingHandler = new TrackingQueryHandler(timeTrackingHandler,actor,tracker);
                //var decoration = new VerificationQueryHandler(actor, trackingHandler);
                return queryHandler;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Miniaction.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
