namespace Data.Models
{
    public class ModelDepartmentsOverview
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? SuperiorDepartmentId { get; set; }
        public int? ManagerEmployeeId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
    }
}
