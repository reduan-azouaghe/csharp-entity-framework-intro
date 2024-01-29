# C# Entity Framework Intro

1. Fork this repository
2. Clone your fork to your machine
3. Open the ef.intro.sln in Visual Studio


## Core and Extension are combined into the following requirements

The overall objective is to complete the BookAPI CRUD operations, using DTO objects to return nicely formatted json without any cyclical serialization errors.

As guidelines we suggest:

- implement the GET book and GET all books. When you return the books objects, use an appropriate DTO to return the book + author (but no nested books inside author). Make sure to include the authors when you load the data in the repository.
- implement the UPDATE boook where you can change the author via id (you may skip updating other properties like title, etc); make sure to return the Book + Author once the update is done
- implement the DELETE book
- implement the CREATE book - it should return NotFound when author id is not valid and BadRequest when book object not valid

- implement the author API (interested in just the GET, GET all) -> the author should return the list of books, use its own author response DTO


Extensions (each one is one extension, implement at least one):

- Add a publisher model and add that as an additional relation to the book, where a book has one publisher; make sure to update the seeder and to create a publisher API Endpoints with the GET and GET all endpoints. Getting a Publisher should return all books that have that publisher + the author for each book. Update the author endpoint to return the Book + Publisher; Updaate the book endpoint to return the Book + Author + Publisher.
- Update the model to have many to many relation between Book and Author, where a Book can have 1 or more authors. Update all the endpoints to return the Book + Authors list.


