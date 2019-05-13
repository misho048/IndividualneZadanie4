using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Individualne_Zadanie_4
{
    class CreateEmployeeViewModel
    {
        public bool CreateEmployee(string title,string name, string surname,string phoneNumber, string email, int? departmentId )
        {
            return Logic.Logic.CreateEmployee(title, name, surname, phoneNumber, email, departmentId);

        }
    }
}
