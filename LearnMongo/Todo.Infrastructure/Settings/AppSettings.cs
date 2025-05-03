using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Infrastructure.Settings
{
    public class AppSettings
    {
        public string DefaultConnection { get; set; } = string.Empty;
        public string PersistenceMode { get; set; } = string.Empty;
        public string MongoDb { get; set; } = string.Empty;
    }
}
