using System;

namespace ElCavernas.Govrnz.Extensions.Configuration
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message)
            : base(message)
        {

        }

        public ConfigurationException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
