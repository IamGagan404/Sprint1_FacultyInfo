using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacLib;
using DataLayer;

namespace BusinessLayer
{
    public class businessLayer
    {
        FacultyInfo fac;

        public businessLayer()
        {
            fac = new FacultyInfo();
        }

        public int AddNewUser(User us)
        {
            return this.fac.addNewUser(us);
        }

        public bool addCourse(course cu)
        {
            return  this.fac.AddCourse(cu);
        }

        public bool UpdateCourse(course cu)
        {
            return this.fac.UpdateCourse( cu);
        }

        public void DeleteCourse(int courseId)
        {
            this.fac.DeleteCourse(courseId);
        }

        public void AddSubject(Subject su)
        {
            this.fac.AddSubject(su);
        }

        public void UpdateSubject(Subject su)
        {
            this.fac.UpdateSubject(su);
        }

        public void DeleteSubject(int subjectId)
        {
            this.fac.DeleteSubject(subjectId);
        }

        public void AddDesignation(Designation des)
        {
            this.fac.AddDesignation(des);
        }

        public void AddDepartment(Department dept)
        {
            this.fac.AddDepartment(dept);
        }


        public string CheckCredentials(int userId, string pass)
        {
            return this.fac.CheckCredntials(userId, pass);
        }
    }
}
