using BusinessObject;
using eStoreLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eStoreClient.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public IActionResult Index()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(Member member)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await eStoreClientUtils.ApiRequest(
                        eStoreHttpMethod.POST,
                        eStoreClientConfiguration.DefaultBaseApiUrl + "/Members/register",
                        member);

                    if (response.IsSuccessStatusCode)
                    {
                        // Registration successful, redirect to login or home
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        // Get error message from response content and display it
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, errorMessage);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                }
            }

            // If we reach here, registration failed
            return View("Index", member);
        }
    }
}
