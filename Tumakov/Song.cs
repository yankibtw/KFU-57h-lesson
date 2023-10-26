using System;


namespace Tumakov
{
    class Song
    {
        private string name;
        private string author;
        Song prev;

        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetPreviousSong(Song prev)
        {
            this.prev = prev;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }
        public override bool Equals(object d)
        {
            if (!(d is Song) && (d == null))
                return false; 
            Song song = (Song)d;
            return name == song.name && author == song.author;
        }
    }
}
