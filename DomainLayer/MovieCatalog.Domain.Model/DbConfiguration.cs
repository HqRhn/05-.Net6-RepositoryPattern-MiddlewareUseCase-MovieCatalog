using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalog.Domain.Model
{
    public class DbConfiguration
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
