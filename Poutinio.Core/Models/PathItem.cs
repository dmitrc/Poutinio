using System.Collections.Generic;

namespace Poutinio.Core.Models
{
    public class PathItem
    {
        public string Name { get; set; }
        public long? Id { get; set; }
        public IList<File> CachedFiles { get; set; }
    }
}
