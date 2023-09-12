using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemoMVC.EntitiesFrameWork.Entites
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
    }

}