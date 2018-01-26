using Demo_SchoolMgt.Models;
using MVC_ScoolMGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ScoolMGT.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/

        public ActionResult Index()
        {
            //var entities = new UserEntities();
            //var list = new SiteActionData();
            //list.SiteActionList = entities.GetSiteActions(1).ToList();
            return View();
        }

        public ActionResult HTMLPage()
        {
            return View();
        }

        public ActionResult Student()
        {
            var student = new Student();
            ViewBag.Command = "ADD";
            if (TempData["Student"] != null)
            {
                ViewBag.Command = "UPDATE";
                student = (Student)TempData["Student"];
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Student(HttpPostedFileBase photoName, Student student, string command)
        {
            var studentEntity = new SchoolUser();
            var db = new StudentEntities();
            if (command == "ADD")
            {
                studentEntity.RoleId = 1;
                studentEntity.CreatedOn = DateTime.Now;
                studentEntity.IsActive = true;
            }
            else if (command == "UPDATE")
            {
                studentEntity = db.SchoolUsers.FirstOrDefault(s => s.Id == student.Id);
            }
            studentEntity.FirstName = student.FirstName;
            studentEntity.LastName = student.LastName;
            studentEntity.MName = student.MName;
            studentEntity.FName = student.FName;
            studentEntity.Gender = student.Gender;
            studentEntity.DOB = student.DOB;
            studentEntity.MobileNo = student.MobileNo;
            studentEntity.Village = student.Village;
            studentEntity.Mandal = student.Mandal;
            studentEntity.District = student.District;
            studentEntity.Municipality = student.Municipality;
            studentEntity.Habitation = student.Habitation;
            studentEntity.BloodGroup = student.BloodGroup;
            studentEntity.Caste = student.Caste;
            studentEntity.Religion = student.Religion;
            studentEntity.MotherTongue = student.MotherTongue;
            studentEntity.AdharNo = student.AdharNo;
            studentEntity.PInstituteName = student.PInstituteName;
            studentEntity.PIdentificationNo = student.PIdentificationNo;
            studentEntity.PhotoName = student.PhotoName;
            studentEntity.DOJ = student.DOJ;
            studentEntity.ClassNmae = student.ClassNmae;
            studentEntity.Section = student.Section;
            studentEntity.RollNo = student.RollNo;
            studentEntity.AdmissionNo = student.AdmissionNo;
            studentEntity.AFee = student.AFee;
            studentEntity.HFee = student.HFee;
            studentEntity.TFee = student.TFee;
            studentEntity.TotalFee = student.TotalFee;
            studentEntity.Email = student.Email;

            //TODO studentEntity.CreatedBy="";
            if (command == "ADD")
            {
                db.SchoolUsers.Add(studentEntity);
                TempData["Message"] = "Student added successfully.";
            }
            else if (command == "UPDATE")
            {
                studentEntity.UpdatedOn = DateTime.Now;
                //TODO studentEntity.UpdatedBy = "";
                TempData["Message"] = "Student updated successfully.";
            }
            db.SaveChanges();
            if (command == "UPDATE")
            {
                return RedirectToAction("ManageStudents");
            }
            return RedirectToAction("Student");
        }

        public ActionResult ManageStudents()
        {
            var db = new StudentEntities();
            List<Student> students = null;
            students = (from student in db.SchoolUsers
                        where student.IsActive == true
                        select new Student
                        {
                            Id = student.Id,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            MName = student.MName,
                            FName = student.FName,
                            Gender = student.Gender,
                            DOB = student.DOB,
                            MobileNo = student.MobileNo,
                            Village = student.Village,
                            Mandal = student.Mandal,
                            District = student.District,
                            Municipality = student.Municipality,
                            Habitation = student.Habitation,
                            BloodGroup = student.BloodGroup,
                            Caste = student.Caste,
                            Religion = student.Religion,
                            MotherTongue = student.MotherTongue,
                            AdharNo = student.AdharNo,
                            PInstituteName = student.PInstituteName,
                            PIdentificationNo = student.PIdentificationNo,
                            PhotoName = student.PhotoName,
                            DOJ = student.DOJ,
                            ClassNmae = student.ClassNmae,
                            Section = student.Section,
                            RollNo = student.RollNo,
                            AdmissionNo = student.AdmissionNo,
                            AFee = student.AFee,
                            HFee = student.HFee,
                            TFee = student.TFee,
                            TotalFee = student.TotalFee,
                            Email = student.Email,
                            IsActive = student.IsActive,
                            RoleId = student.RoleId,
                        }).ToList();
            var studentModel = new StudentModel();
            studentModel.StudentList = students;
            return View(studentModel);

        }

        public ActionResult EditStudent(int id)
        {
            var db = new StudentEntities();
            var studentModel = (from student in db.SchoolUsers
                                where student.Id == id
                                select new Student
                                {
                                    Id = student.Id,
                                    FirstName = student.FirstName,
                                    LastName = student.LastName,
                                    MName = student.MName,
                                    FName = student.FName,
                                    Gender = student.Gender,
                                    DOB = student.DOB,
                                    MobileNo = student.MobileNo,
                                    Village = student.Village,
                                    Mandal = student.Mandal,
                                    District = student.District,
                                    Municipality = student.Municipality,
                                    Habitation = student.Habitation,
                                    BloodGroup = student.BloodGroup,
                                    Caste = student.Caste,
                                    Religion = student.Religion,
                                    MotherTongue = student.MotherTongue,
                                    AdharNo = student.AdharNo,
                                    PInstituteName = student.PInstituteName,
                                    PIdentificationNo = student.PIdentificationNo,
                                    PhotoName = student.PhotoName,
                                    DOJ = student.DOJ,
                                    ClassNmae = student.ClassNmae,
                                    Section = student.Section,
                                    RollNo = student.RollNo,
                                    AdmissionNo = student.AdmissionNo,
                                    AFee = student.AFee,
                                    HFee = student.HFee,
                                    TFee = student.TFee,
                                    TotalFee = student.TotalFee,
                                    Email = student.Email,
                                    IsActive = student.IsActive,
                                    RoleId = student.RoleId,
                                }).FirstOrDefault();
            TempData["Student"] = studentModel;
            return RedirectToAction("Student");
        }


        public ActionResult DeleteStudent(int id)
        {
            var db = new StudentEntities();
            var student = db.SchoolUsers.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.IsActive = false;
                student.UpdatedOn = DateTime.Now;
                db.SaveChanges();
                // TODOstudent.UpdatedBy = "";
                TempData["Message"] = "Student deleted successfully.";
            }
            return RedirectToAction("ManageStudents");
        }
        public PartialViewResult Menu()
        {
            var entities = new StudentEntities();
            var list = new SiteActionData();
            list.SiteActionList = entities.GetSiteActions(1).ToList();
            return PartialView("_Menu", list);
        }



    }
}
