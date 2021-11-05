using System;

namespace DIO.Music
{
    public class Music : BaseEntities
    {
      private Genre Genre { get; set; }
      private string Title { get; set; }
      private string Author { get; set; }
      private int Year { get; set; }
      private bool Deleted { get; set; }

      public Music(int id, Genre genre, string title, string author, int year)
      {
        this.Id = id;
        this.Genre = genre;
        this.Title = title;
        this.Author = author;
        this.Year = year;
        this.Deleted = false;
      }

      public override string ToString()
      {
        string text = "";
        text += "Genre: " + this.Genre + Environment.NewLine;
        text += "Title: " + this.Title + Environment.NewLine;
        text += "Author: " + this.Author + Environment.NewLine;
        text += "Year: " + this.Year + Environment.NewLine;
        text += "Deleted? " + this.Deleted;

        return text;
      }

      public string returnTitle()
      {
        return this.Title;
      }

      internal int returnId()
      {
        return this.Id;
      }

      public bool returnDeleted()
      {
        return this.Deleted;
      }

      public void Delete() {
        this.Deleted = true;
      }
    }
}
