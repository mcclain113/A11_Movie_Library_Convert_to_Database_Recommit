﻿/*using System.Collections.Immutable;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieLibraryEntities.Context;

namespace MovieLibrary;

public class Startup
{
    public IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddFile("app.log");

        });
        services.AddTransient<IMainService, MainService>();
        services.AddTransient<DbContext, MovieContext>();
        return services.BuildServiceProvider();

    }


}*/