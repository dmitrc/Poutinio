using System.Collections.Generic;

namespace Yapp.Models
{
    public class PathItem
    {
        public string Name { get; set; }
        public long? Id { get; set; }
        public IList<File> CachedFiles { get; set; }
    }
}
