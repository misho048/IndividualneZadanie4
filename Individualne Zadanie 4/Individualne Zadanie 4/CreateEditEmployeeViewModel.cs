namespace Individualne_Zadanie_4
{
    class CreateEditEmployeeViewModel
    {
        private Logic.Logic _logic = new Logic.Logic();


        public bool CreateEmployee(string title, string name, string surname, string phoneNumber,
            string email, int? departmentId)
        {
            return _logic.CreateEmployee(title, name, surname, phoneNumber, email, departmentId);

        }


        public bool UpdateEmployee(string title, string name, string surname, string phoneNumber,
            string email, int? departmentId, int id)
        {
            return _logic.UpdateEmployee(title, name, surname, phoneNumber, email, departmentId, id);

        }



    }
}
