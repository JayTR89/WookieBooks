﻿namespace WookieBooks.Api.Dtos
{
    public class SaveBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public double Price { get; set; }
    }
}
