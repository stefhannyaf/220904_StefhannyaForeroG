using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _220904_StefhannyaForeroG.Models;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace _220904_StefhannyaForeroG.Controllers
{
    public class InstituteController : Controller
    {
        static string cadena = "Data Source=LAPTOP-CGO01H7N\\SQLEXPRESS; Initial Catalog=DB_PHOTOEXPRESS; Integrated Security=true";
        // GET: Institute
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Institute institute)
        {
            string message;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_RegisterInstitute", cn);
                cmd.Parameters.AddWithValue("Institute_name", institute.Institute_name);
                cmd.Parameters.AddWithValue("Institute_address", institute.Institute_address);
                cmd.Parameters.AddWithValue("Students_Number", institute.Students_Number);
                cmd.Parameters.AddWithValue("Time_service", institute.Time_service);
                cmd.Parameters.AddWithValue("Price", institute.Price);
                cmd.Parameters.Add("Message", System.Data.SqlDbType.VarChar, 100).Direction = System.Data.ParameterDirection.Output;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                message = cmd.Parameters["Message"].Value.ToString();

            }

            if (message == "Registered institute")
            {
                ViewData["Message"] = message;
            }
            else
            {
                ViewData["Message"] = "there is a problem with the registration";
            }
            return View();
        }

        public ActionResult List()
        {
            List<Institute> model = new List<Institute>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListEvents", cn))
                {
                    cn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                var m = new Institute();
                                m.Institute_name = rdr.GetString(rdr.GetOrdinal("Institute_name"));
                                m.Institute_address = rdr.GetString(rdr.GetOrdinal("Institute_address"));
                                m.Students_Number = rdr.GetInt32(rdr.GetOrdinal("Students_Number"));
                                m.Time_service = rdr.GetInt32(rdr.GetOrdinal("Time_service"));
                                m.Price = rdr.GetInt32(rdr.GetOrdinal("Price"));
                                model.Add(m);
                            }
                        }
                    }
                }
            }
            return View(model);
        }

        
        public async Task<ActionResult> Api()
        {
            Api data = new Api();
            data.IMEI = "354330030646882";
            data.CompanyID = 10;
            List<Api> model = new List<Api>();
            using (var client = new System.Net.Http.HttpClient())
            {
                //client.BaseAddress = new Uri("https://api.iotsol.net/api/GetIMEIDataServicesByIMEIAndCompany");
                var response = client.PostAsJsonAsync<Api>("https://api.iotsol.net/api/GetIMEIDataServicesByIMEIAndCompany",data);
                response.Wait();

                var result = response.Result;
                if(result.IsSuccessStatusCode)
                {
                    var a = new Api();
                    var cuerpo = result.Content.ReadAsStringAsync().Result;
                    var res =JObject.Parse(cuerpo);

                    a.IMEI = (string)res["IMEI"];
                    a.CompanyID = (int)res["CompanyID"];
                    a.VehicleID = (string)res["VehicleID"];

                    model.Add(a);
                    return View(model);
                }
            }
            return View();
        }
    }
}