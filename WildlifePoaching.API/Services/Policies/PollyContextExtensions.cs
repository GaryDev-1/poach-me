﻿using Polly;

namespace WildlifePoaching.API.Services.Policies
{
    public static class PollyContextExtensions
    {
        private const string LoggerKey = "Logger";

        public static Context WithLogger(this Context context, ILogger logger)
        {
            context[LoggerKey] = logger;
            return context;
        }

        public static ILogger GetLogger(this Context context)
        {
            if (context.TryGetValue(LoggerKey, out object logger))
            {
                return logger as ILogger;
            }
            return null;
        }
    }
}
