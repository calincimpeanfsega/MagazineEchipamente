using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MagazineEchipamente.Models
{
    public class ListaMagazine
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Magazin))]
        public int MagazinID { get; set; }
        public int EchipamentID { get; set; }
    }
}
