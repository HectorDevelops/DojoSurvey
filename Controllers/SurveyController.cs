using Microsoft.AspNetCore.Mvc;
namespace SurveyController.Controllers;
public class SurveyController : Controller
{
    // Main page displaying the form 
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Survey");
    }

    // Results page display the empty results labels
    [HttpGet("/results")]
    public ViewResult Results()
    {
        return View("Results");
    }

    // POST method to submit our private data 
    [HttpPost("/process")]
    // This is like a catch action results 
    public IActionResult Process(string Name, string Location, string Language, string Comment)
    {
        // Conditional to ensure if input is filled, to re-direct to results page with ViewBag inserted data
        if (Name != null & Location != null & Language != null & Comment != null)
        {
            ViewBag.Name = Name;
            ViewBag.Location = Location;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;

            return View("Results");
        }
        return RedirectToAction("/results");
    }

    // If user navigates to a page does not exists, serves as a validation form 

}