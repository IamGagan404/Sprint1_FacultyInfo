using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacLib;
using BusinessLayer;


namespace PresentaionLayer
{
    internal class presentaionLayer
    {
        static void Main(string[] args)
        {
            businessLayer busL = new businessLayer();

            User getUserData()
            {
                User newUser = new User();
                Console.WriteLine("RoleId:");
                newUser.roleId = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Username:");
                newUser.UserName = Console.ReadLine();
                Console.WriteLine("Firstname");
                newUser.FirstName = Console.ReadLine();
                Console.WriteLine("Lastname");
                newUser.LastName = Console.ReadLine();
                Console.WriteLine("User Email");
                newUser.UserEmail = Console.ReadLine();
                Console.WriteLine("Address :");
                newUser.Address = Console.ReadLine();
                Console.WriteLine("City :");
                newUser.City = Console.ReadLine();
                Console.WriteLine("State :");
                newUser.State = Console.ReadLine();
                Console.WriteLine("Pincode");
                newUser.Pincode = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Mobile Number");
                newUser.MobileNo = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Password");
                newUser.Password = Console.ReadLine();
                return newUser;

            }

            void HandleCourses()
            {
                Console.WriteLine("Choose Operation");
                int op = Int32.Parse(Console.ReadLine());
                course newCourse = new course();
                switch (op)
                {
                    case 1:
                        Console.WriteLine("CourseId");
                        newCourse.CourseID = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Course name:");
                        newCourse.CourseName = Console.ReadLine();
                        Console.WriteLine("Course Credits");
                        newCourse.CourseCredits = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Dept Id");
                        newCourse.DeptID = Int32.Parse(Console.ReadLine());
                        if(busL.addCourse(newCourse)) Console.WriteLine("New Course Added");
                        else Console.WriteLine("An Error Occurred");
                        break;
                    case 2:

                }
            }



            Console.WriteLine("Welcome");
            Console.WriteLine("Select your role : \n 1.Admin \n 2.Faculty \n 3.Student");
            int role = Int32.Parse(Console.ReadLine());
            int access = 0;
            switch (role)
            {
                case 1:
                    Console.WriteLine("Admin Login. Enter Your Credentials");
                    access = userLogin();
                    if(access == 1)
                    {
                        AdminLogin();
                    }
                    break;
                case 2:
                    Console.WriteLine("Faculty Login. Enter Your Credentials");
                    access = userLogin();
                    if(access == 2)
                    {
                        FacultyLogin();
                    }
                    break;
                case 3:
                    Console.WriteLine("Student Login. Enter Your Credentials");
                    access = userLogin();
                    if(access == 3)
                    {
                        StudentLogin();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input.");
                    break ;
            }
            int userLogin()
            {
                Console.WriteLine("UserID: ");
                int userId = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Password: ");
                string pass = Console.ReadLine();
                string auth = busL.CheckCredentials(userId, pass);
                Console.WriteLine(auth);
                if (auth != "No user found.")
                {
                    return 1;
                } else return 0;
                //return auth;
            }


            void AdminLogin()
            {
                Console.WriteLine("Choose Option \n " +
                    "1. Create New User \n" +
                    "2. Add New Department \n" +
                    "3. Add New Designation \n" +
                    "4. View Faculty Information \n" +
                    "5. View Faculty Publication Reports \n" +
                    "6. Courses \n" +
                    "7. Subjects ");
                int input =  Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter User details");
                        User us = getUserData();
                        int retUserid = busL.AddNewUser(us);
                        Console.WriteLine($"New User created with ID {retUserid}");
                        break;
                    case 2:
                        Console.WriteLine("Enter Department Details");
                        Department dept = new Department();
                        Console.WriteLine("Enter Department ID");
                        dept.DeptID = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Department Name");
                        dept.DeptName = Console.ReadLine();
                        busL.AddDepartment(dept);
                        Console.WriteLine("New Department Added");
                        break;
                    case 3:
                        Console.WriteLine("Enter Designation Details");
                        Designation des = new Designation();
                        Console.WriteLine("Enter Designation ID");
                        des.DesiID = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Designation Name");
                        des.DesiName = Console.ReadLine();
                        busL.AddDesignation(des);
                        Console.WriteLine("New Designation Added");
                        break;
                    case 6:
                        HandleCourses();
                        break;
                
                }
                

            }



            //Console.WriteLine("Press 1 to add New user : ");
            //int w = Int32.Parse(Console.ReadLine());
            //User us = new User() { roleId = 102, UserName = "firstUser5", FirstName = "first",
            //    LastName = "last", UserEmail = "dd@gmail.com", Address = "addressq",
            //    City = "city1", State = "maha", Pincode = 1100, MobileNo = 7895,
            //    Password = "password12" };
            //course cu = new course() { CourseName = "phy", CourseCredits = 23, DeptID = 101 };
            //if (w == 1)
            //{
            //    //int y = busL.AddNewUser(us);
            //    busL.addCourse(cu);
            //}


            Console.ReadKey();
        }
    }
}
