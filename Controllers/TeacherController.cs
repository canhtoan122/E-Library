using E_Library_03.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace E_Library_03.Controllers
{
    [Authorize]
    public class TeacherController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select * from
                    dbo.teacher
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["E_Library_Entities"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(teacher teacher)
        {
            try
            {
                string query = @"
                    insert into dbo.teacher (teacher_name, subjectID, lessionID, resourceID, exam_and_test_ID, notificationID, helpID, userID) values
                    (
                    '" + teacher.teacher_name + @"'
                    , '" + teacher.subjectID + @"'
                    , '" + teacher.lessionID + @"'
                    , '" + teacher.resourceID + @"'
                    , '" + teacher.exam_and_test_ID + @"'
                    , '" + teacher.notificationID + @"'
                    , '" + teacher.helpID + @"'
                    , '" + teacher.userID + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["E_Library_Entities"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }


        public string Put(teacher teacher)
        {
            try
            {
                string query = @"
                    update dbo.teacher set 
                    teacher_name='" + teacher.teacher_name + @"'
                    ,subjectID='" + teacher.subjectID + @"'
                    ,lessionID='" + teacher.lessionID + @"'
                    ,resourceID='" + teacher.resourceID + @"'
                    ,exam_and_test_ID='" + teacher.exam_and_test_ID + @"'
                    ,notificationID='" + teacher.notificationID + @"'
                    ,helpID='" + teacher.helpID + @"'
                    ,userID='" + teacher.userID + @"'
                    where teacherID=" + teacher.teacherID + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["E_Library_Entities"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }


        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.teacher 
                    where teacherID=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["E_Library_Entities"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }



    }
}
