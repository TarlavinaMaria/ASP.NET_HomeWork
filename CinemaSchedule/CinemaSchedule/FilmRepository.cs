using System;
using System.Collections.Generic;

namespace CinemaSchedule
{
    public class FilmRepository
    {
        public List<Film> _films; //список фильмов
        public FilmRepository()
        {
            _films = new List<Film>
            {
                new Film
                 {
                     Title = "Головоломка 2",
                     Director = "Келси Манн",
                     Genre = "Комедия",
                     Description = "Продолжение головоломка, в которой доявляются новые эмоции Райли.",
                     Showtimes = new List<Showtime>
                     {
                        new Showtime { StartTime = new TimeSpan(10, 0, 0) },
                        new Showtime { StartTime = new TimeSpan(14, 0, 0) },
                        new Showtime { StartTime = new TimeSpan(20, 0, 0) }
                     }
                 },
                 new Film
                 {
                     Title = "Веном 3: последний танец",
                     Director = "Келли Марсель",
                     Genre = "Криминал",
                     Description = "Финальный эпизод трилогии об антигерое Веноме от режиссёра Келли Марсел, продукт киновселенной Marvel.",
                     Showtimes = new List<Showtime>
                     {
                        new Showtime { StartTime = new TimeSpan(12, 0, 0) },
                        new Showtime { StartTime = new TimeSpan(17, 0, 0) },
                        new Showtime { StartTime = new TimeSpan(21, 0, 0) }
                     }
                 }

            };
        }
        public List<Film> GetMovies() // получение списка фильмов
        {
            return _films;
        }
        public void AddFilm(Film film) // добавление фильма в список фильмов
        {
            _films.Add(film);
        }
        public void RemoveFilm(Film film) // удаление фильма из списока фильмов
        {
            _films.Remove(film);
        }
    }
}
