using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using FacLib;


namespace DataLayer
{
    public class FacultyInfo
    {
        SqlConnection con;
        string conStr;

        //Constructor to establic the connection
        public FacultyInfo()
        {
            conStr = "server = WHITEFANG\\SQLExpress; database = Sprint1; integrated security = true";
            con = new SqlConnection(conStr);
            con.Open();
            Console.WriteLine("Connection establied");
            //Connection establied
        }

        public int addNewUser(User us)
        {
            SqlCommand cmd1 = new SqlCommand("proc_addNewUser", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            //input params
            cmd1.Parameters.AddWithValue("@roleid", us.roleId);
            cmd1.Parameters.AddWithValue("@userName", us.UserName);
            cmd1.Parameters.AddWithValue("@firstName", us.FirstName);
            cmd1.Parameters.AddWithValue("@lastName", us.LastName);
            cmd1.Parameters.AddWithValue("@useremail", us.UserEmail);
            cmd1.Parameters.AddWithValue("@password", us.Password);

            // Out param
            SqlParameter outP = new SqlParameter("@userid", System.Data.SqlDbType.Int);
            outP.Direction = System.Data.ParameterDirection.Output;
            cmd1.Parameters.Add(outP);

            cmd1.ExecuteNonQuery();
            return ((int)outP.Value);
            //Console.WriteLine(outP.Value);
        }

        public bool AddCourse(course cr)
        {
            SqlCommand cmd1 = new SqlCommand("proc_addCourse", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@courseName", cr.CourseName);
            cmd1.Parameters.AddWithValue("@CourseCredit", cr.CourseCredits);
            cmd1.Parameters.AddWithValue("@deptId", cr.DeptID);
            if (cmd1.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else return false;
        }

        public bool UpdateCourse( course cr)
        {
            SqlCommand cmd1 = new SqlCommand("proc_updateCourse", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@CourseId", cr.CourseID);
            cmd1.Parameters.AddWithValue("@courseName", cr.CourseName);
            cmd1.Parameters.AddWithValue("@CourseCredits", cr.CourseCredits);
            cmd1.Parameters.AddWithValue("@deptId", cr.DeptID);
            if (cmd1.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else return false;
        }

        public void DeleteCourse(int courseId)
        {
            SqlCommand cmd1 = new SqlCommand("proc_deleteCourse", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@CourseId", courseId);
            cmd1.ExecuteNonQuery();
        }

        public void AddSubject(Subject su)
        {
            SqlCommand cmd1 = new SqlCommand("proc_addSubject", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Subjectname", su.SubjectName);
            cmd1.ExecuteNonQuery();
        }
        public void UpdateSubject(Subject su)
        {
            SqlCommand cmd1 = new SqlCommand("proc_updateSubject", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@SubjectId", su.SubjectId);
            cmd1.Parameters.AddWithValue("@Subjectname", su.SubjectName);
            cmd1.ExecuteNonQuery();
        }

        public void DeleteSubject(int subjectid)
        {
            SqlCommand cmd1 = new SqlCommand("proc_deleteSubject", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@CourseId", subjectid);
            cmd1.ExecuteNonQuery();
        }

        public void AddDesignation(Designation des)
        {
            SqlCommand cmd1 = new SqlCommand("proc_addNewDesignation", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@desiname", des.DesiName);
            cmd1.ExecuteNonQuery();
        }
        public void AddDepartment(Department dep)
        {
            SqlCommand cmd1 = new SqlCommand("proc_addNewDepartment", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@desiname", dep.DeptName);
            cmd1.ExecuteNonQuery();
        }

        public string CheckCredntials(int userid, string pass)
        {
            SqlCommand cmd1 = new SqlCommand("proc_checkCredentials", con);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@userid", userid);
            cmd1.Parameters.AddWithValue("@password", pass);
            SqlDataReader dr = cmd1.ExecuteReader();
            //int auth = cmd1.ExecuteNonQuery();
            //return auth;
            if (dr.HasRows)
            {
                dr.Read();
                string welcome = $"Welcome {dr.GetString(3)} {dr.GetString(4)}";
                return welcome;
            }
            else return "No user found.";
        }
    }

}

