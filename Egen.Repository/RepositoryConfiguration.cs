using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Repository
{
    public interface IRepositoryConfiguration
    {
        string ISConnectionString { get; }
        string HRConnectionString { get; }
        string OlcConnectionString { get; }
        string InventoryConnectionString { get; }
    }
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        public RepositoryConfiguration()
        {

        }
        public RepositoryConfiguration(string strIS, string strHr, string strOlc, string strInv)
        {
            ISConnectionString = strIS;
            HRConnectionString = strHr;
            OlcConnectionString = strOlc;
            InventoryConnectionString = strInv;
        }
        public string ISConnectionString { get; set; } = string.Empty;
        public string HRConnectionString { get; set; } = string.Empty;
        public string OlcConnectionString { get; set; } = string.Empty;
        public string InventoryConnectionString { get; set; } = string.Empty;

        //public string HRConnectionString { get; set; } = "Server=DESKTOP-UJBJUUD;User Id=sa;Password=123;Initial Catalog=HRDB";
        //public string InventoryConnectionString { get; set; } = "Server=DESKTOP-UJBJUUD;User Id=sa;Password=123;Initial Catalog=Inventory";

    }
}
