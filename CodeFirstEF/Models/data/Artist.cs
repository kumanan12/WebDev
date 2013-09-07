using System;

namespace CodeFirstEF.Models.data
{
    public partial class Artist
    {
        public virtual int ArtistId { get; set; }
        public virtual string Name { get; set; }


        public string GetName()
        {
            return Name;
        }
    }

}