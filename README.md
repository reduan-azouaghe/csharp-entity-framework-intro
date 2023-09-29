# C# Entity Framework Intro

1. Fork this repository
2. Clone your fork to your machine
3. Open the ef.intro.sln in Visual Studio
5. Note:  There are no controllers in this project!!  A current way of writing endpoints is in the EndPoint directory.
		  See How the AuthorApi.cs & BookApi.cs both are extension methods of the WebApplication class which 
		  is returned in the Program.cs from a builder.Build() call.  This way we can call this to initialize from the 
		  extension method.  See also how the data is populated via the Seed() method call.  Note how we are 
		  randomly generating names of both authors & books!

## Core and Extension are combined into the following requirements

-Complete the LibraryRepository.cs.  Finish all methods, replacing "throw new NotImplementedException();" with relevant C# Entity Framework code by using the LibraryContext.   
-Add a Publisher Model with properties Id(int) and Name(string)    
-Add a controller for the Publisher.  Create in a similar way to AuthorApi.cs/BookApi.cs using the minimal api approach.  
-update ILibraryRepository,  LibraryRepository and LibraryContext and any other place you feel relevant to wire in the Publisher into the project.  Don't forget to link the Publisher by Id as a foreign key on the Book object (decorate accordingly!).  
-In the Seed class populate the db by using the context class (hopefully you added a new Publisher DbSet in the Context).  You can call the 
GeneratePublisherName() to generate a name or make up your own version of this.  As each publisher is added to the book object you should populate BEFORE the book 
population code, then randomly create a publisher for a book (tip.. use a similar approach to the book.AuthorId = authors[authorRandom.Next(authors.Count)].Id);)




