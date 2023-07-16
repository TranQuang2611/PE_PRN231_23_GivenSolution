using System;
namespace GivenAPIs.Models
{
	public class DataGeneration
	{
		public static List<Author> Authors = new List<Author>
		{
			new Author{AuthorId=1, Name="Author 1"},
			new Author{AuthorId=2, Name="Author 2"},
			new Author{AuthorId=3, Name="Author 3"},
		};
        public static List<Book> Books = new List<Book>
        {
            new Book{BookId=1, Title="Book 1", AuthorId=1},
            new Book{BookId=2, Title="Book 2", AuthorId=1},
            new Book{BookId=3, Title="Book 3", AuthorId=2},
            new Book{BookId=1, Title="Book 4", AuthorId=2},
            new Book{BookId=2, Title="Book 5", AuthorId=1},
            new Book{BookId=3, Title="Book 6", AuthorId=3}
        };

        public static List<Studio> Studios = new List<Studio>
        {
            new Studio{StudioId=1, StudioName="Studio 1"},
            new Studio{StudioId=2, StudioName="Studio 2"},
            new Studio{StudioId=3, StudioName="Studio 3"},
        };
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie{MovieId=1, Title="Movie 1", StudioId=1},
            new Movie{MovieId=2, Title="Movie 2", StudioId=1},
            new Movie{MovieId=3, Title="Movie 3", StudioId=2},
            new Movie{MovieId=1, Title="Movie 4", StudioId=2},
            new Movie{MovieId=2, Title="Movie 5", StudioId=1},
            new Movie{MovieId=3, Title="Movie 6", StudioId=3}
        };
    }
}

