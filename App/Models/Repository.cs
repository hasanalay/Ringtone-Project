using System.Collections.Generic;
using System.Linq;

namespace App.Models
{
    public static class Repository
    {
        private static List<Ringtone> _ringtones = null;

        static Repository()
        {
            _ringtones = new List<Ringtone>()
            {
                new Ringtone() { Id=1, Name="Shazam", Artist= "Berke Bıçak" Genre="Shazam", ImageUrl="2.jpeg"},
                new Ringtone() { Id=2, Name="Amazing Grace", Artist= "Berke Bıçak" Genre="Amazing Grace", ImageUrl="2.jpeg"},
                new Ringtone() { Id=3, Name="High Life", Artist= "Berke Bıçak" Genre="High Life", ImageUrl="2.jpeg"},
                new Ringtone() { Id=4, Name="Billboard", Artist= "Berke Bıçak" Genre="Billboard", ImageUrl="2.jpeg"},
                new Ringtone() { Id=5, Name="Storm Boy", Artist= "Berke Bıçak" Genre="Storm Boy", ImageUrl="2.jpeg"},
        }

        public static List<Ringtone> Movies
        {
            get
            {
                return _ringtones;
            }
        }

        public static void AddMovie(Ringtone entity)
        {
            _ringtones.Add(entity);
        }

        public static Ringtone GetById(int id)
        {
            return _ringtones.FirstOrDefault(i => i.Id == id);
        }


    }
}