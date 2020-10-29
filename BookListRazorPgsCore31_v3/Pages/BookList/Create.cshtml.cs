using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorPgsCore31_v3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazorPgsCore31_v3.Pages.BookList
{
    public class CreateModel : PageModel
    {
		
		private readonly ApplicationDbContext _db;

		// constructor with Dependency Inj based on RR pipeline
		// note: without DI need to declare a New and Dispose after
		//	 with DI no need to do a NEW and Dispose! Yeah!
		public CreateModel(ApplicationDbContext db)
		{
			_db = db;
		}

		//private NewIndexModel()
		//{
		//	//_db = db;
		//	_db = new ApplicationDbContext();
		//}

		/////private ApplicationDbContext _db = new ApplicationDbContext();

		[BindProperty] // attribute ties Book property to Post
		public Book Book { get; set; }


		// *note async Task HANDLERS for Razor pgs VS ACTION Methods in MVC
		public async Task OnGet() // changed "void" to "async Task"
		{

		}

		// OnPost will automatically receive Book as for Post due to Book's [BindProperty] attribute
		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				await _db.Books.AddAsync(Book); // cue the change
				await _db.SaveChangesAsync();   // execute the change
				return RedirectToPage("Index");
			}
			else
			{
				return Page();
			}
		}
	}
}