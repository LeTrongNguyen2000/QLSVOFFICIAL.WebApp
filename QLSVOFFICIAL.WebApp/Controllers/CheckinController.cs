using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using QLSVOFFICIAL.Data.Models;
using QLSVOFFICIAL.WebApp.Views.Shared;
using QLSVOFFICIAL.Data.EF;

namespace QLSVOFFICIAL.BackendApi1.Controllers
{
    public class CheckinController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        List<Checkin> checkins = new List<Checkin>();
        QLSVContext connect = new QLSVContext();

        private readonly ILogger<CheckinController> _logger;

        public CheckinController(ILogger<CheckinController> logger)
        {
            _logger = logger;
            conn.ConnectionString = Resources.ConnectionString;
        }

        //Method show database lên bảng
        public void FechData()
        {
            //Đảm bảo rằng dữ liệu cũ của bảng đã được xóa để tránh việc douple dữ liệu
            if (checkins.Count > 0)
            {
                checkins.Clear();
            }
            try
            {
                conn.Open();
                com.Connection = conn;
                com.CommandText = "SELECT TOP 1000 [IdCheckin],[IdClassSubject],[IdUser],[CheckinDate],[CheckRoom] FROM [QLSV].[dbo].[CHECKIN]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    checkins.Add(new Checkin()
                    {
                        IdCheckin = int.Parse(dr["IdCheckin"].ToString()),
                        IdClassSubject = int.Parse(dr["IdClassSubject"].ToString()),
                        IdUser = int.Parse(dr["IdUser"].ToString()),
                        CheckinDate = Convert.ToDateTime(dr["CheckinDate"]),
                        CheckRoom = dr["CheckRoom"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //View điểm danh
        public IActionResult Checkin()
        {
            FechData();
            return View(checkins);
        }
        //View báo cáo điểm danh
        public IActionResult ReportCheckin()
        {
            return View();
        }
        //[HttpPost]
        ////Funtion add checkin
        //public void AddCheckin()
        //{
        //    //try
        //    //{
        //    if (dr["IdClassSubject"] != "" || dr["IdUser"] != "" || dr["CheckinDate"] != "" || dr["CheckRoom"] != "")
        //    {
        //        Checkin CheckinExist = connect.Checkins.Find((Predicate<Checkin>)dr["IdCheckin"]);
        //        if (CheckinExist != null)
        //        {
        //            MessageBoxManager.Ignore = "Mã checkin đã tồn tại, vui lòng nhập lại...";
        //        }
        //        else
        //        {
        //            CheckinExist = new Checkin();

        //            CheckinExist.IdClassSubject = (int)dr["IdClassSubject"];
        //            CheckinExist.IdUser = (int)dr["IdUser"];
        //            CheckinExist.CheckinDate = (DateTime)dr["CheckinDate"];
        //            CheckinExist.CheckRoom = dr["CheckRoom"].ToString();

        //            connect.Checkins.Add(CheckinExist);
        //            connect.SaveChanges();
        //            MessageBoxManager.Ignore = "Thêm hàng hóa thành công!";
        //        }
        //    }
        //    else
        //    {
        //        MessageBoxManager.Ignore = "Định dạng nhập vào không hợp lệ!";
        //    }
        //    //}
        //    //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        //    //{
        //    //    Exception raise = dbEx;
        //    //    foreach (var validationErrors in dbEx.EntityValidationErrors)
        //    //    {
        //    //        foreach (var validationError in validationErrors.ValidationErrors)
        //    //        {
        //    //            string message = string.Format("{0}:{1}",
        //    //                validationErrors.Entry.Entity.ToString(),
        //    //                validationError.ErrorMessage);
        //    //            // raise a new exception nesting  
        //    //            // the current instance as InnerException  
        //    //            raise = new InvalidOperationException(message, raise);
        //    //        }
        //    //    }
        //    //    throw raise;
        //    //}
        //}
    }
}
