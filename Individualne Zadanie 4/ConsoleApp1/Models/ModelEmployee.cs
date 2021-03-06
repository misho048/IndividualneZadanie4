﻿namespace Data.Models
{
    public class ModelEmployee
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }
        public int? DepartmentId { get; set; }


        public override string ToString()
        {

            return $"{Title} {Name} {Surname}";
        }


    }

    
}
