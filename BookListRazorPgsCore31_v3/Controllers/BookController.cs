using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorPgsCore31_v3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazorPgsCore31_v3.Controllers
{

	[Route("api/Book")]
	[ApiController]
    public class BookController : Controller
    {

		private readonly ApplicationDbContext _db;

		// constructor with Dependency Inj based on RR pipeline
		// note: without DI need to declare a New and Dispose after
		//	 with DI no need to do a NEW and Dispose! Yeah!
		public BookController(ApplicationDbContext db)
		{
			_db = db;			
		}

		//private BookController()
		//{
		//	//_db = db;
		//	_db = new ApplicationDbContext();
		//}

		//private ApplicationDbContext _db = new ApplicationDbContext();

		[HttpGet]
		public async Task<IActionResult> GetAll()
        {
			return Json(new { data = await _db.Books.ToListAsync() });   
        }

		[HttpDelete]
		public async Task<IActionResult> Delete(int id) 
		{
			Book bookFromDb = await _db.Books.FirstOrDefaultAsync(u => u.Book_ID == id);
			if (bookFromDb == null)
			{
				return Json(new { success = false, message = "Error while Deleting" });
			}
			_db.Books.Remove(bookFromDb);
			await _db.SaveChangesAsync();
			return Json(new { success = true, message = "Delete successful" });
		}

    }
}