using System;

namespace Wreckastow.Models
{
    public sealed class Album
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}