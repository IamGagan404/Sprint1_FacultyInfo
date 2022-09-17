using System;

namespace FacLib
{
    public class Subject
    {
        public int SubjectId { get; set; } 
        public string SubjectName { get; set; }
    }
    public class WorkHistory
    {
        public int WorkHistoryID { set; get; }
        public int FacultyID { set; get; }
        public string Organization { set; get; }
        public string JobTitle { set; get; }
        public string JobBeginDate { set; get; }
        public string JobEndDate { set; get; }
        public string JobResponsibilities { set; get; }
        public string JobType { set; get; }
    }

    public class course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseCredits { get; set; }
        public int DeptID { get; set; }

    }

    public class Faculty
    {
        public int FacultyId { get; set; }
        public int HireDate { get; set; }
        public int DateofBirth { get; set; }
        public string DepartmentId { get; set; }
        public string DesignationId { get; set; }
    }


    public class User
    {
        public int UserId { get; set; }
        public int roleId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public int MobileNo { get; set; }
        public string Password { get; set; }
    }
    public class Department
    {

        public int DeptID { set; get; }
        public string DeptName { set; get; }
    }
    public class Designation
    {

        public int DesiID { set; get; }
        public string DesiName { set; get; }
    }
    public class Publications
    {

        public int PublicationID { set; get; }
        public int FacultyID { set; get; }
        public string PublicationTitle { set; get; }
        public string ArticleName { set; get; }
        public string PublisherName { set; get; }
        public string PublicationLocation { set; get; }
        public DateTime CitationDate { set; get; }
    }


}
