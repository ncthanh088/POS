﻿using Microsoft.Extensions.DependencyInjection;

namespace POS.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
