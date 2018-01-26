﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ScoolMGT.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MName { get; set; }
        public string FName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string MobileNo { get; set; }
        public string Village { get; set; }
        public string Mandal { get; set; }
        public string District { get; set; }
        public string Municipality { get; set; }
        public string Habitation { get; set; }
        public string BloodGroup { get; set; }
        public string Caste { get; set; }
        public string Religion { get; set; }
        public string MotherTongue { get; set; }
        public string AdharNo { get; set; }
        public string PInstituteName { get; set; }
        public string PIdentificationNo { get; set; }
        public string PhotoName { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public string ClassNmae { get; set; }
        public string Section { get; set; }
        public string RollNo { get; set; }
        public string AdmissionNo { get; set; }
        public string AFee { get; set; }
        public string HFee { get; set; }
        public string TFee { get; set; }
        public string TotalFee { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> RoleId { get; set; }
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MName { get; set; }
        public string FName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string MobileNo { get; set; }
        public string Village { get; set; }
        public string Mandal { get; set; }
        public string District { get; set; }
        public string Municipality { get; set; }
        public string Habitation { get; set; }
        public string BloodGroup { get; set; }
        public string Caste { get; set; }
        public string Religion { get; set; }
        public string MotherTongue { get; set; }
        public string AdharNo { get; set; }
        public string PInstituteName { get; set; }
        public string PIdentificationNo { get; set; }
        public string PhotoName { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public string ClassNmae { get; set; }
        public string Section { get; set; }
        public string RollNo { get; set; }
        public string AdmissionNo { get; set; }
        public string AFee { get; set; }
        public string HFee { get; set; }
        public string TFee { get; set; }
        public string TotalFee { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public string Designed { get; set; }
        public string Email { get; set; }
        public string WorkType { get; set; }
        public string Subject { get; set; }
        public string WorkHourPerDay { get; set; }
        public string WorkHourPerMonth { get; set; }
        public string Salary { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> RoleId { get; set; }
    }


    public class StudentModel
    {
        public List<Student> StudentList { get; set; }
    }

    public class TeacherModel
    {
        public List<Teacher> TeacherList { get; set; }
    }


}