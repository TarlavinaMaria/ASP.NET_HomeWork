using System.Collections.Generic;
using System;

namespace CinemaSchedule
{
    public class Film
    {
        public string Title { get; set; }//Название
        public string Director { get; set; }//Режисер
        public string Genre { get; set; }//Жанр
        public string Description { get; set; } // Описание
        public List<Showtime> Showtimes { get; set; }//Время
    }
}
