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
        public Film NewFilm { get; set; } // ��� ���������� ����� �������
        [BindProperty]
        public string Showtimes { get; set; } // ��� �������
        public List<Film> Film { get; set; } // ��� ������������� ������ �������
        public void OnGet()
        {
            Film = _filmRepository.GetMovies();
        }
        //IActionResult � ��� ���������, ������� ������������ ��������� ���������� �������� (������) � ����������� ��� � ����������� Razor Pages.
        //�� ������������ ��� �������� ��������� ����� �����������, ����� ��� �������������, ���������������, ��������� �� ������� � �.�.
        public IActionResult OnPost() //OnPost ������������ ������, ������������ �� �����
        {
            if (!ModelState.IsValid)
            {
                Film = _filmRepository.GetMovies();
                return Page();
            }

            // �������������� ����� ������� � TimeSpan
            //Split(',', StringSplitOptions.RemoveEmptyEntries): ���� ����� ��������� ������ �� ���������, ��������� ������� � �������� �����������.
            //�������� StringSplitOptions.RemoveEmptyEntries ���������, ��� ������ ��������� ������ ���� ��������� �� ����������.
            NewFilm.Showtimes = Showtimes.Split(',', StringSplitOptions.RemoveEmptyEntries)
                //st => new Showtime { StartTime = TimeSpan.Parse(st.Trim()) }: ��� ������-���������, ������� ��������� ������ st � ������� ����� ������ Showtime
                //TimeSpan.Parse(st.Trim()): ����������� ������ st � ������ TimeSpan
                //ToList: ���� ����� ����������� ������������������ �������� Showtime � ������
                .Select(st => new Showtime { StartTime = TimeSpan.Parse(st.Trim()) }).ToList();
            //��������� �����
            _filmRepository.AddFilm(NewFilm);
            // �������������� ������������ �� �������� � ����������� �����������
            return RedirectToPage("/CinemaSchedule"); //RedirectToPage("/CinemaSchedule"): �������������� �� ��������� ��������.
        }
        public IActionResult OnPostDelete(string id)
        {
            // ���� ����� ��������� �������� id, ������� ������������� film.Title �� �����.
            //_filmRepository.GetMovies().FirstOrDefault(f => f.Title == id): ������� ����� � �������� Title
            var filmToRemove = _filmRepository.GetMovies().FirstOrDefault(f => f.Title == id);
            if (filmToRemove != null) //�������� �� �������
            {
                _filmRepository.RemoveFilm(filmToRemove);
            }
            // �������������� ������������ �� �������� � ����������� �����������
            return RedirectToPage("/CinemaSchedule");
        }
    }
}

