
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using TestWebAPI.DB;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {

        Employee_DB db = new Employee_DB();
        Response_Employee Json = new Response_Employee();
        JObject jobj = null;


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Data/Employee")]
        public HttpResponseMessage MyEmployeeDetails([FromBody]Request_Employee employee)
        {
          
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    result = db.RegisterNewEmployee(employee);
                    if (result == 1)
                    {
                        Json.responseDateTime = DateTime.Now.ToString("dd-MM-yyyyHH:mm:ss:ff");
                        Json.RespCode = "000";
                        Json.responseMessage = "Data Successfully Inserted !!";
                        jobj = (JObject)JToken.FromObject(Json);
                        return Request.CreateResponse(System.Net.HttpStatusCode.Created, jobj);
                       

                    }
                    else
                    {
                        Json.responseDateTime = DateTime.Now.ToString("dd-MM-yyyyHH:mm:ss:ff");
                        Json.RespCode = "001";
                        Json.responseMessage = "Data could not Inserted !!";
                        jobj = (JObject)JToken.FromObject(Json);
                        return Request.CreateResponse(System.Net.HttpStatusCode.NotImplemented, jobj);
                       
                    }
                }
                else
                {
                    Json.responseDateTime = DateTime.Now.ToString("dd-MM-yyyyHH:mm:ss:ff");
                    Json.RespCode = "003";
                    Json.responseMessage = "Bad Request !!";
                    jobj = (JObject)JToken.FromObject(Json);
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, jobj);
                   
                }



            }
            catch (Exception ex)
            {
                Json.responseDateTime = DateTime.Now.ToString("dd-MM-yyyyHH:mm:ss:ff");
                Json.RespCode = "002";
                Json.responseMessage = "Internal Server Occured !!";
                jobj = (JObject)JToken.FromObject(Json);
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, jobj);
              

            }

        }



        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Data/Employee")]
        public HttpResponseMessage MyEmployee()
        {
            int res = 0;
            try
            {
                res = db.isEmployeesPresent();
                if (res != 0)
                {
                    Json.responseDateTime = DateTime.Now.ToString("dd-MM-yyyyHH:mm:ss:ff");
                    Json.RespCode = "000";
                    Json.responseMessage = res + "are the number of employee!!";
                    jobj = (JObject)JToken.FromObject(Json);
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, jobj);
                }
                else
                {
                    Json.responseDateTime = DateTime.Now.ToString("dd-MM-yyyyHH:mm:ss:ff");
                    Json.RespCode = "004";
                    Json.responseMessage = "No employee is there!!";
                    jobj = (JObject)JToken.FromObject(Json);
                    return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, jobj);
                }
            }
            catch (Exception ex)
            {

                Json.responseDateTime = DateTime.Now.ToString("dd-MM-yyyyHH:mm:ss:ff");
                Json.RespCode = "002";
                Json.responseMessage = "Internal Server Occured !!";
                jobj = (JObject)JToken.FromObject(Json);
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, jobj);
            }
        }
    }
}