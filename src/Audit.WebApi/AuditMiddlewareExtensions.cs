﻿#if NETCOREAPP3_1 || NETCOREAPP3_0 || NETSTANDARD2_1 || NETSTANDARD2_0 || NETSTANDARD1_6 || NET451
using Microsoft.AspNetCore.Builder;
using System;

namespace Audit.WebApi
{
    public static class AuditMiddlewareExtensions
    {
        /// <summary>
        /// Add the Audit middleware to the pipeline. 
        /// This can be used together with AuditApi action filter.
        /// </summary>
        /// <param name="builder">The application builder</param>
        /// <param name="config">The audit middleware configuration</param>
        public static IApplicationBuilder UseAuditMiddleware(this IApplicationBuilder builder, Action<ConfigurationApi.IAuditMiddlewareConfigurator> config)
        {
            var mwConfig = new ConfigurationApi.AuditMiddlewareConfigurator();
            config.Invoke(mwConfig);
            return builder.UseMiddleware<AuditMiddleware>(mwConfig);
        }

    }
}
#endif