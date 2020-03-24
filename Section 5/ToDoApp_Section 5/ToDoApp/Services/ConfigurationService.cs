using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Services
{
    public class ConfigurationService
    {
        private IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int TaskTimeout 
        {
            get
            {
                return _configuration.GetValue<Int32>("TaskTimeout");
            }
        }
    }
}
