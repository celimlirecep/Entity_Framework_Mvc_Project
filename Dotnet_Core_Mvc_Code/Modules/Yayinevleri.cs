using System;
using System.Collections.Generic;

#nullable disable

namespace Dotnet_Core_Mvc_Code.Modules
{
    public partial class Yayinevleri
    {
        public Yayinevleri()
        {
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string Tel { get; set; }

        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
