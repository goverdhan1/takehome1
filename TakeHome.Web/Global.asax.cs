using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using TakeHome.Services;
using TakeHome.Core.Services;
using System.Reflection;
using TakeHome.Data;
using TakeHome.Core.Data.Repositories;
using Autofac.Integration.WebApi;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using TakeHome.Core.Entities;
using AutoMapper;
using System.Globalization;
using AutoMapper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TakeHome.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            _autoRegistrations();

            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            RepositoryRegistration(builder);
            ServiceRegistration(builder);

            ContextRegistration(builder);
            builder.RegisterApiControllers(Assembly.Load("TakeHome.Web"));
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var resolver = new AutofacWebApiDependencyResolver(container);
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = resolver;
            ConfigureFormatting(config);
        }

        private void ConfigureFormatting(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void ServiceRegistration(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("TakeHome.Services")).
                Where(_ => _.Name.EndsWith("Service")).
                AsImplementedInterfaces().
                InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IService<>)).InstancePerDependency();
        }

        private void RepositoryRegistration(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("TakeHome.Data")).
                Where(_ => _.Name.EndsWith("Repository")).
                AsImplementedInterfaces().
                InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();
        }

        private void ContextRegistration(ContainerBuilder builder)
        {
            builder.Register<IDbContext>(b =>
            {
                var context = new TakeHomeDBContext();
                return context;
            }).InstancePerLifetimeScope();
        }
        private void _autoRegistrations()
        {
            var cfg = new MapperConfigurationExpression();
            Mapper.Initialize(cfg);


            var dataEntities =
                Assembly.Load("TakeHome.Core").
                    GetTypes().Where(x => typeof(IEntity).IsAssignableFrom(x)).ToList();

            var dtos =
                Assembly.Load("TakeHome.ViewModels").
                GetTypes().Where(x => x.Name.EndsWith("ViewModel", true, CultureInfo.InvariantCulture)).ToList();

            foreach (var entity in dataEntities)
            {
                if (Mapper.Configuration.GetAllTypeMaps().FirstOrDefault(m => m.DestinationType == entity || m.SourceType == entity) == null)
                {
                    var matchingDto =
                        dtos.FirstOrDefault(x => x.Name.Replace("ViewModel", string.Empty).Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));

                    if (matchingDto != null)
                    {
                        cfg.CreateMap(entity, matchingDto);
                        cfg.CreateMap(matchingDto, entity);
                    }
                }
            }
        }
    }
}