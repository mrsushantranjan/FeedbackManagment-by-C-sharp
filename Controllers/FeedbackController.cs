using Microsoft.AspNetCore.Mvc;
using FeedbackManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        private static readonly List<Feedback> FeedbackList = new();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(FeedbackList.OrderByDescending(f => f.Id).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Feedback());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }

            feedback.Id = nextId++;
            FeedbackList.Add(feedback);

            TempData["Success"] = "Feedback submitted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}