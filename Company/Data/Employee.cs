namespace Company.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public DateTime dob { get; set; }

        [Required]
        [StringLength(50)]
        public string address { get; set; }

        public byte gender { get; set; }

        public DateTime startdate { get; set; }

        public int department_id { get; set; }

        public int salary_id { get; set; }

        public virtual Department Department { get; set; }

        public virtual Salary Salary { get; set; }
    }
}
