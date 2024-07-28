using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaSchedule.Pages
{
    public class CinemaScheduleModel : PageModel
    {
        private readonly FilmRepository _filmRepository;
        public CinemaScheduleModel(FilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }
        [BindProperty]
        public Film NewFilm { get; set; } // дл€ добавлени€ новых фильмов
        [BindProperty]
        public string Showtimes { get; set; } // дл€ времени
        public List<Film> Film { get; set; } // дл€ существующего списка фильмов
        public void OnGet()
        {
            Film = _filmRepository.GetMovies();
        }
        //IActionResult Ч это интерфейс, который представл€ет результат выполнени€ действи€ (метода) в контроллере или в обработчике Razor Pages.
        //ќн используетс€ дл€ возврата различных типов результатов, таких как представлени€, перенаправлени€, сообщени€ об ошибках и т.д.
        public IActionResult OnPost() //OnPost обрабатывает данные, отправленные из формы
        {
            if (!ModelState.IsValid)
            {
                Film = _filmRepository.GetMovies();
                return Page();
            }

            // ѕреобразование строк времени в TimeSpan
            //Split(',', StringSplitOptions.RemoveEmptyEntries): Ётот метод разбивает строку на подстроки, использу€ зап€тую в качестве разделител€.
            //ѕараметр StringSplitOptions.RemoveEmptyEntries указывает, что пустые подстроки должны быть исключены из результата.
            NewFilm.Showtimes = Showtimes.Split(',', StringSplitOptions.RemoveEmptyEntries)
                //st => new Showtime { StartTime = TimeSpan.Parse(st.Trim()) }: Ёто л€мбда-выражение, которое принимает строку st и создает новый объект Showtime
                //TimeSpan.Parse(st.Trim()): ѕреобразует строку st в объект TimeSpan
                //ToList: Ётот метод преобразует последовательность объектов Showtime в список
                .Select(st => new Showtime { StartTime = TimeSpan.Parse(st.Trim()) }).ToList();
            //добавл€ем фильм
            _filmRepository.AddFilm(NewFilm);
            // ѕеренаправл€ет пользовател€ на страницу с обновленным расписанием
            return RedirectToPage("/CinemaSchedule"); //RedirectToPage("/CinemaSchedule"): ѕеренаправл€ет на указанную страницу.
        }
        public IActionResult OnPostDelete(string id)
        {
            // Ётот метод принимает параметр id, который соответствует film.Title из формы.
            //_filmRepository.GetMovies().FirstOrDefault(f => f.Title == id): Ќаходит фильм с заданным Title
            var filmToRemove = _filmRepository.GetMovies().FirstOrDefault(f => f.Title == id);
            if (filmToRemove != null) //проверка на пустоту
            {
                _filmRepository.RemoveFilm(filmToRemove);
            }
            // ѕеренаправл€ет пользовател€ на страницу с обновленным расписанием
            return RedirectToPage("/CinemaSchedule");
        }
    }
}

