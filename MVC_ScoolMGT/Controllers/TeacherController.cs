using MVC_ScoolMGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ScoolMGT.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/

        public ActionResult Teacher()
        {
            var Teacher = new Teacher();
            ViewBag.Command = "ADD";
            if (TempData["Teacher"] != null)
            {
                ViewBag.Command = "UPDATE";
                Teacher = (Teacher)TempData["Teacher"];
            }
            return View(Teacher);
        }

        [HttpPost]
        public ActionResult Teacher(HttpPostedFileBase photoName, Teacher teacher, string command)
        {
            var teacherEntity = new SchoolUser();
            var db = new StudentEntities();
            if (command == "ADD")
            {
                teacherEntity.RoleId = 2;
                teacherEntity.CreatedOn = DateTime.Now;
                teacherEntity.IsActive = true;
            }
            else if (command == "UPDATE")
            {
                teacherEntity = db.SchoolUsers.FirstOrDefault(s => s.Id == teacher.Id);
            }
            teacherEntity.FirstName = teacher.FirstName;
            teacherEntity.LastName = teacher.LastName;
            teacherEntity.MName = teacher.MName;
            teacherEntity.FName = teacher.FName;
            teacherEntity.Gender = teacher.Gender;
            teacherEntity.DOB = teacher.DOB;
            teacherEntity.MobileNo = teacher.MobileNo;
            teacherEntity.Village = teacher.Village;
            teacherEntity.Mandal = teacher.Mandal;
            teacherEntity.District = teacher.District;
            teacherEntity.Municipality = teacher.Municipality;
            teacherEntity.Habitation = teacher.Habitation;
            teacherEntity.BloodGroup = teacher.BloodGroup;
            teacherEntity.Caste = teacher.Caste;
            teacherEntity.Religion = teacher.Religion;
            teacherEntity.MotherTongue = teacher.MotherTongue;
            teacherEntity.AdharNo = teacher.AdharNo;
            teacherEntity.PInstituteName = teacher.PInstituteName;
            teacherEntity.PIdentificationNo = teacher.PIdentificationNo;
            teacherEntity.PhotoName = teacher.PhotoName;
            teacherEntity.DOJ = teacher.DOJ;
            teacherEntity.ClassNmae = teacher.ClassNmae;
            teacherEntity.Section = teacher.Section;
            teacherEntity.RollNo = teacher.RollNo;
            teacherEntity.AdmissionNo = teacher.AdmissionNo;
            teacherEntity.AFee = teacher.AFee;
            teacherEntity.HFee = teacher.HFee;
            teacherEntity.TFee = teacher.TFee;
            teacherEntity.TotalFee = teacher.TotalFee;
            teacherEntity.Email = teacher.Email;
            teacherEntity.Qualification = teacher.Qualification;
            teacherEntity.Experience = teacher.Experience;
            teacherEntity.Designed = teacher.Designed;
            teacherEntity.Subject = teacher.Subject;
            teacherEntity.WorkType = teacher.WorkType;
            teacherEntity.WorkHourPerDay = teacher.WorkHourPerDay;
            teacherEntity.WorkHourPerMonth = teacher.WorkHourPerMonth;

            //TODO TeacherEntity.CreatedBy="";
            if (command == "ADD")
            {
                db.SchoolUsers.Add(teacherEntity);
                TempData["Message"] = "Teacher added successfully.";
            }
            else if (command == "UPDATE")
            {
                teacherEntity.UpdatedOn = DateTime.Now;
                //TODO TeacherEntity.UpdatedBy = "";
                TempData["Message"] = "Teacher updated successfully.";
            }
            db.SaveChanges();
            if (command == "UPDATE")
            {
                return RedirectToAction("ManageTeachers");
            }
            return RedirectToAction("Teacher");
        }

        public ActionResult ManageTeachers()
        {
            var db = new StudentEntities();
            List<Teacher> teachers = null;
            teachers = (from teacher in db.SchoolUsers
                        where teacher.IsActive == true && teacher.RoleId==2
                        select new Teacher
                        {
                            Id = teacher.Id,
                            FirstName = teacher.FirstName,
                            LastName = teacher.LastName,
                            MName = teacher.MName,
                            FName = teacher.FName,
                            Gender = teacher.Gender,
                            DOB = teacher.DOB,
                            MobileNo = teacher.MobileNo,
                            Village = teacher.Village,
                            Mandal = teacher.Mandal,
                            District = teacher.District,
                            Municipality = teacher.Municipality,
                            Habitation = teacher.Habitation,
                            BloodGroup = teacher.BloodGroup,
                            Caste = teacher.Caste,
                            Religion = teacher.Religion,
                            MotherTongue = teacher.MotherTongue,
                            AdharNo = teacher.AdharNo,
                            PInstituteName = teacher.PInstituteName,
                            PIdentificationNo = teacher.PIdentificationNo,
                            PhotoName = teacher.PhotoName,
                            DOJ = teacher.DOJ,
                            ClassNmae = teacher.ClassNmae,
                            Section = teacher.Section,
                            RollNo = teacher.RollNo,
                            AdmissionNo = teacher.AdmissionNo,
                            AFee = teacher.AFee,
                            HFee = teacher.HFee,
                            TFee = teacher.TFee,
                            TotalFee = teacher.TotalFee,
                            Email = teacher.Email,
                            IsActive = teacher.IsActive,
                            RoleId = teacher.RoleId,
                            Qualification = teacher.Qualification,
                            Experience = teacher.Experience,
                            Designed = teacher.Designed,
                            Subject = teacher.Subject,
                            WorkType = teacher.WorkType,
                            WorkHourPerDay = teacher.WorkHourPerDay,
                            WorkHourPerMonth = teacher.WorkHourPerMonth
                        }).ToList();
            var teacherModel = new TeacherModel();
            teacherModel.TeacherList = teachers;
            return View(teacherModel);

        }

        public ActionResult EditTeacher(int id)
        {
            var db = new StudentEntities();
            var teacherModel = (from teacher in db.SchoolUsers
                                where teacher.Id == id
                                select new Teacher
                                {
                                    Id = teacher.Id,
                                    FirstName = teacher.FirstName,
                                    LastName = teacher.LastName,
                                    MName = teacher.MName,
                                    FName = teacher.FName,
                                    Gender = teacher.Gender,
                                    DOB = teacher.DOB,
                                    MobileNo = teacher.MobileNo,
                                    Village = teacher.Village,
                                    Mandal = teacher.Mandal,
                                    District = teacher.District,
                                    Municipality = teacher.Municipality,
                                    Habitation = teacher.Habitation,
                                    BloodGroup = teacher.BloodGroup,
                                    Caste = teacher.Caste,
                                    Religion = teacher.Religion,
                                    MotherTongue = teacher.MotherTongue,
                                    AdharNo = teacher.AdharNo,
                                    PInstituteName = teacher.PInstituteName,
                                    PIdentificationNo = teacher.PIdentificationNo,
                                    PhotoName = teacher.PhotoName,
                                    DOJ = teacher.DOJ,
                                    ClassNmae = teacher.ClassNmae,
                                    Section = teacher.Section,
                                    RollNo = teacher.RollNo,
                                    AdmissionNo = teacher.AdmissionNo,
                                    AFee = teacher.AFee,
                                    HFee = teacher.HFee,
                                    TFee = teacher.TFee,
                                    TotalFee = teacher.TotalFee,
                                    Email = teacher.Email,
                                    IsActive = teacher.IsActive,
                                    RoleId = teacher.RoleId,
                                    Qualification = teacher.Qualification,
                                    Experience = teacher.Experience,
                                    Designed = teacher.Designed,
                                    Subject = teacher.Subject,
                                    WorkType = teacher.WorkType,
                                    WorkHourPerDay = teacher.WorkHourPerDay,
                                    WorkHourPerMonth = teacher.WorkHourPerMonth
                                }).FirstOrDefault();
            TempData["Teacher"] = teacherModel;
            return RedirectToAction("Teacher");
        }


        public ActionResult DeleteTeacher(int id)
        {
            var db = new StudentEntities();
            var teacher = db.SchoolUsers.FirstOrDefault(s => s.Id == id);
            if (teacher != null)
            {
                teacher.IsActive = false;
                teacher.UpdatedOn = DateTime.Now;
                db.SaveChanges();
                // TODOTeacher.UpdatedBy = "";
                TempData["Message"] = "Teacher deleted successfully.";
            }
            return RedirectToAction("ManageTeachers");
        }
    }
}
