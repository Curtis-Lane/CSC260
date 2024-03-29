﻿using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		private static int count = 0;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult ParamTest(int? id, string s) {
			return Content($"id = {id?.ToString() ?? "NULL"} {s}"); // Content returns JUST what you put in
			// id? = Nullable variable
			// ?? = Null coalescing operator, if variable is not null, do left stuff
			// If null, do right stuff
		}

		[Route("Pizza/{id?}")] // Attribute routing
		public IActionResult RouteTest(int? id) {
			return Content($"id = {id?.ToString() ?? "NULL"}");
		}

		[Route("Home/Colors/{*colors}")]
		public IActionResult Colors(string colors) {
			var colorList = colors.Split('/');
			return Content(string.Join(',', colorList));
		}

		public IActionResult Index() {
			return View();
		}

		//[Route("Home/Index")] // One page can have multiple routes
		//[Route("stuff")] // Permanently takes over routing for Privacy
		public IActionResult Privacy(int id) {
			return View();
		}
		
		public IActionResult Counter() {
			count += 1;
			ViewBag.Count = count;
			ViewData["Count"] = count;

			return View();
		}

		[HttpGet]
		public IActionResult Input() {
			ViewData["Title"] = "Input Form";
			return View();
		}

		[HttpPost]
		public IActionResult Output(string FirstName, string LastName) {
			ViewBag.FN = FirstName;
			ViewBag.LN = LastName;
			return View();
		}

		public IActionResult Send3Ways() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
