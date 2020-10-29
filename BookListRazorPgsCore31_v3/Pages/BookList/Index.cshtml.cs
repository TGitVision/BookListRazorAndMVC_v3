using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorPgsCore31_v3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazorPgsCore31_v3.Pages.BookList
{
    public class IndexModel : PageModel
    {
		private readonly ApplicationDbContext _db;

		// constructor with Dependency Inj based on RR pipeline
		// note: without DI need to declare a New and Dispose after
		//	 with DI no need to do a NEW and Dispose! Yeah!
		public IndexModel(ApplicationDbContext db)
		{
			_db = db;
		}

		//private NewIndexModel()
		//{
		//	//_db = db;
		//	_db = new ApplicationDbContext();
		//}

		////private ApplicationDbContext _db = new ApplicationDbContext();

		public IEnumerable<Book> Books { get; set; }


		// *note async Task HANDLERS for Razor pgs VS ACTION Methods in MVC
		public async Task OnGet() // changed "void" to "async Task"
		{
			// await Async pattern Lets you run multiple methods at a time and await.
			Books = await _db.Books.ToListAsync();
			// Lets you run multiple methods at a time and await.
		}
		public Book Book { get; set; }


		// *note async Task HANDLERS for Razor pgs VS ACTION Methods in MVC
		// DELETE CUSTOM HANDLER
		// Custom Handler is a Extension of OnPost. TagHelper references this WITHOUT OnPost prefix.
		public async Task<IActionResult> OnPostDelete(int id) // changed "void" to "async Task"
		{
			var book = await _db.Books.FindAsync(id);
			if (book == null)
			{
				return NotFound();
			}
			_db.Books.Remove(book);
			await _db.SaveChangesAsync();

			return RedirectToPage("Index");
		}

	}
}