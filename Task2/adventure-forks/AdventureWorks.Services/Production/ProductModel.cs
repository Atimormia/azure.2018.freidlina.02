using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AdventureWorks.Services.Production
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public XmlSchema CatalogDescription { get; set; }
        public XmlSchema Instructions { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
