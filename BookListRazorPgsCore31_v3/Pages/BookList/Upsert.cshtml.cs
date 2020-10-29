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
    public class UpsertModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Book Book { get; set; }

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

		// *note async Task HANDLERS for Razor pgs VS ACTION Methods in MVC
		public async Task<IActionResult> OnGet(int? id) // changed "void" to "async Task"
		{

			Book = new Book();
			if (id == null)
			{
				// create
				return Page();
			}

			// update
			Book = await _db.Books.FirstOrDefaultAsync(u => u.Book_ID == id);
			if (Book == null) 
			{

				return NotFound();

			}

			return Page();

		}
	
		////////else 
		////////{ 

		////////}			
	

		public async Task<IActionResult> OnPost() // changed "void" to "async Task"
		{

			if (ModelState.IsValid)
			{

				if (Book.Book_ID == 0)
				{
					// create
					_db.Books.Add(Book);

				}
				else

				{

					// update : note this EF Update method updates every prop of the book.
					_db.Books.Update(Book);

				}

				await _db.SaveChangesAsync();

				return RedirectToPage("Index");

			}

			return RedirectToPage("Index");

			////////	if (Book.Book_ID > 0) 
			////////	{
			////////		Book BookFromDb = await _db.Books.FindAsync(Book.Book_ID);
			////////		BookFromDb.Name = Book.Name;
			////////		BookFromDb.Author = Book.Author;
			////////		BookFromDb.ISBN = Book.ISBN;

			////////		await _db.SaveChangesAsync();

			////////		return RedirectToPage();

			////////	}
			////////	else 
			////////	{
			////////		await _db.Books.AddAsync(Book); // cue the change
			////////		await _db.SaveChangesAsync();   // execute the change

			////////		return RedirectToPage("Index");
			////////	}
			////////}

			//////// return RedirectToPage("Index");			
			

		}

	}
}
