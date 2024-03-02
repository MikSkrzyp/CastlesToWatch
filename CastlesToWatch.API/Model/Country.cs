﻿namespace CastlesToWatch.API.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<Castle> Castles { get; set; }

    }
}
