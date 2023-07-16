using System;
namespace GivenAPIs.Models
{
	public class Book
	{
		public Book()
		{
		}
		public int BookId { get; set; }
		public string Title { get; set; }
		public int AuthorId { get; set; }
	}
}

