using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppConfigFactory
    {
        public IFileSearchService Create()
        {
            return new FileSearchService(2, null, null);
        }
    }
}
