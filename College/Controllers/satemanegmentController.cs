using College.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace College.Controllers
{
    public class satemanegmentController : Controller
    {

        collegecontext context = new collegecontext();

        // temodata
        public IActionResult SET()
        {
            //SET DATA TEMPDATA
            TempData["Client1"] = "ali";
            return Content("data saved");
        }
        public IActionResult get1()
        {
            //get DATA TemptatA
            string NAME = "EMPITY";
            if(TempData.ContainsKey("Client1"))
            {
                NAME = TempData["Client1"].ToString();
                TempData.Keep("Client1");
            }
            
            return Content($"get1 call and tempdata = {NAME}");
        }
        public IActionResult get2()
        {
            //get DATA TemptatA
            string NAME = "EMPITY";
            if (TempData.ContainsKey("Client1"))
            {
                NAME = TempData.Peek("Client1").ToString();
            }

            return Content($"get2 call and tempdata = {NAME}");
        }




        //Session 
        public IActionResult SETstate()
        {
            string name = "iti";
            int age = 23;
            HttpContext.Session.SetString("stdname", name);
            HttpContext.Session.SetInt32("stdage", age);
            return Content(" saved data session");
        }
        public IActionResult getstate()
        {
            string name =HttpContext.Session.GetString("stdname");
            int age = (int) HttpContext.Session.GetInt32("stdage");//.Value;
            return Content($" name {name} age {age}");
        }



        // cookies
        public IActionResult SetCookie()
        {
            // Expires When the browsing session ends
            Response.Cookies.Append("username", "shafik attia shafik"); 
            return Content("SetCookie saved");
        }
        public IActionResult SetCookieusername()
        { //persisste cookie
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(2);
            Response.Cookies.Append("password", "shafik-attia-shafik", cookieOptions);
            return Content(" SetCookieusername saved");
        }
        // get cookies
        public IActionResult getCookieusername()
        { 
         
          String cookie =  Request.Cookies["password"].ToString();

            return Content($" password is : {cookie}");
        }

    }
}
