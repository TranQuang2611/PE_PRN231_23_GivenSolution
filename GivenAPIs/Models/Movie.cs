using System;
namespace GivenAPIs.Models
{
	public class Movie
	{
		public Movie()
		{
		}

		public int MovieId { get; set; }
		public string Title { get; set; }
		public DateTime PublishDate { get; set; }
		public int StudioId { get; set; }
	}
}

