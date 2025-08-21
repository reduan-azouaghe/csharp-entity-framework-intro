﻿using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.webapi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        
        public int PublisherId { get; set; }  // <-- add FK
        public Publisher Publisher { get; set; }
    }
}
