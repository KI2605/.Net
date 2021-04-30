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
            Message = "������� �����";
        }
        public void OnPost(int? sum)
        {
            if (sum == null || sum < currentRate)
            {
                Message= "�������� ������������ �����. ��������� ����";
            }
            else
            {
                decimal result = sum.Value / currentRate;
                // ToString("F2") - �������������� �����: F2 - ������� ����� � 2 ������� ����� �������
                Message = $"��� ������ {sum} ������ �� �������� {result.ToString("F2")}$.";
            }
        }
    }
}
