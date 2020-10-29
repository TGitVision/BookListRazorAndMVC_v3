using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorPgsCore31_v3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazorPgsCore31_v3.Pages.BookList
{
    public class EditModel : PageModel
    {

		private readonly ApplicationDbContext _db;

		// constructor with Dependency Inj based on RR pipeline
		// note: without DI need to declare a New and Dispose after
		//	 with DI no need to do a NEW and Dispose! Yeah!
		public EditModel(ApplicationDbContext db)
		{
			_db = db;
		}

		//private NewIndexModel()
		//{
		//	//_db = db;
		//	_db = new ApplicationDbContext();
		//}

		////private ApplicationDbContext _db = new ApplicationDbContext();

		[BindProperty]
		public Book Book { get; set; }


		// *note async Task HANDLERS for Razor pgs VS ACTION Methods in MVC
		public async Task OnGet(int id) // changed "void" to "async Task"
		{
			Book = await _db.Books.FindAsync(id);
		}

		public async Task<IActionResult> OnPost() // changed "void" to "async Task"
		{
			if (ModelState.IsValid)
			{
				var BookFromDb = await _db.Books.FindAsync(Book.Book_ID);
				BookFromDb.Name = Book.Name;
				BookFromDb.Author = Book.Author;
				BookFromDb.ISBN = Book.ISBN;

				await _db.SaveChangesAsync();

				return RedirectToPage();

			}

			return RedirectToPage();

		}

	}
}