using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18.Pages
{
    public class ExchangeModel : PageModel
    {
        public string Message { get; set; }
        private decimal currentRate = 28.5m;
        public void OnGet()
        {
            Message = "Введите сумму";
        }
        public void OnPost(int? sum)
        {
            if (sum == null || sum < currentRate)
            {
                Message= "Передана некорректная сумма. Повторите ввод";
            }
            else
            {
                decimal result = sum.Value / currentRate;
                // ToString("F2") - форматирование числа: F2 - дробное число с 2 знаками после запятой
                Message = $"При обмене {sum} гривен вы получите {result.ToString("F2")}$.";
            }
        }
    }
}
