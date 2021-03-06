﻿using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElektronskiDnevnik.Controllers
{
    public class RegisterController : Controller
    {
        // GET: RegisterStudent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(CassandraDataLayer.QueryEntities.Student s)
        {
            s.studentID = Guid.NewGuid().ToString("N");
            User u = CassandraDataLayer.Store.GetInstance().GetUser();
            s.teacherID = u.userID;
            CassandraDataLayer.DataProvider.AddStudent(s);
            CassandraDataLayer.DataProvider.ChangeNumStud(s.sectionID,u.userID, u.schoolID, 1);
            //CassandraDataLayer.DataProvider.GetStudents();
            return View();

        }

        public ActionResult RegisterTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterTeacher(CassandraDataLayer.QueryEntities.Teacher t)
        {
            t.teacherID = Guid.NewGuid().ToString("N");
            CassandraDataLayer.DataProvider.AddTeacher(t);

            return View();

        }
    }
}