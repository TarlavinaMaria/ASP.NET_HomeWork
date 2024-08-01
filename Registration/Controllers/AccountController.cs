using Microsoft.AspNetCore.Mvc;
using Registration.Models;

namespace Registration.Controllers
{
    public class AccountController : Controller
    {
        // Действие для отображения формы регистрации
        [HttpGet]
        public ActionResult Register()
        {
            RegisterModel model = new RegisterModel();
            return View(model);
        }

        // Действие для обработки данных регистрации
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверка данных пользователя и регистрация
                // ...

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Данные пользователя некорректны, отображаем форму снова
                return View(model);
            }
        }
    }
}
