using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using TCCCards.Web.ViewModels;

namespace TCCCards.Web.Controllers
{
    public class HomeController : Controller
    {

        //The URL of the WEB API Service
        string url = "https://localhost:44342/User";
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //GET: Register
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                //var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                //if (check == null)
                //{
                //    _user.Password = GetMD5(_user.Password);
                //    _db.Configuration.ValidateOnSaveEnabled = false;
                //    _db.Users.Add(_user);
                //    _db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                //else
                //{
                //    ViewBag.error = "Email already exists";
                //    return View();
                //}


            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user, HttpClient client)
        {
            return View("CardImages");

            //string stringData = JsonConvert.SerializeObject(user);
            //var contentData = new StringContent (stringData, System.Text.Encoding.UTF8,"application/json");            
            //HttpResponseMessage response = client.PostAsync("https://localhost:44342/User/CheckUser", contentData).Result;
            //ViewBag.Message = response.Content.
            //ReadAsStringAsync().Result;
            //return View();     
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(User user, HttpClient client)
        //{
        //    user.FirstName = "";
        //    user.LastName = "";
        //    user.ConfirmPassword = "";
        //    //if (ModelState.IsValid)
        //    //{
        //    //var data = new JsonConvert.SerializeObject(user, Encoding.UTF8, "application/json");
        //    //HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, user);
        //    //    if (responseMessage.IsSuccessStatusCode)
        //    //    {
        //    //        return RedirectToAction("Index");
        //    //    }

        //    var postRequest = new HttpRequestMessage(HttpMethod.Post, url)
        //    {
        //        Content = JsonContent.Create(user)
        //    };

        //    var postResponse = await client.SendAsync(postRequest);

        //    postResponse.EnsureSuccessStatusCode();
        //    return RedirectToAction("Error");
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.error = "Login failed";
        //    //    return RedirectToAction("Login");
        //    //}

        //    //return View();
        //}

        //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");


        //    if (ModelState.IsValid)
        //    {
        //        var f_password = GetMD5(password);
        //        var data = 1;
        //            //_db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
        //        //if (data.Count> 0)
        //            if (data > 0)
        //            {
        //            //add session
        //            //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
        //            //Session["Email"] = data.FirstOrDefault().Email;
        //            //Session["idUser"] = data.FirstOrDefault().idUser;
        //            Session["FullName"] ="Admin";
        //            Session["Email"] = email;
        //            Session["idUser"] = "1";
        //            using (var client = new HttpClient())
        //            {
        //                //https://localhost:44342/user
        //                client.BaseAddress = new Uri("https://localhost:44342/");

        //            //HTTP GET
        //            var responseTask = client.GetAsync("user");
        //            responseTask.Wait();

        //            var result = responseTask.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var readTask = result.Content.ReadAsStringAsync().Result;
        //                //readTask.Wait();

        //                //students = readTask.Result;
        //            }
        //            }
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Login failed";
        //            return RedirectToAction("Login");
        //        }
        //    }
        //    return View();
        //}

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}