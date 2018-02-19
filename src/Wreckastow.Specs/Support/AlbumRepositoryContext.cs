using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Wreckastow.Models;
using Wreckastow.Services;

namespace WreckaStow.Specs.Support
{
    [Binding]
    public sealed class AlbumRepositoryContext
    {
        private readonly IAlbumRepository _repository;
        private Album _album;

        public AlbumRepositoryContext(IAlbumRepository repository)
        {
            _repository = repository;
        }

        [Given(@"these albums are available:")]
        public void GivenTheseAlbumsAreAvailable(IEnumerable<Album> albums)
        {
            foreach (var album in albums)
            {
                _repository.Save(album);
            }
        }

        [Given(@"this album is available:")]
        public void GivenThisAlbumIsAvailable(Album album)
        {
            _album = album;
            _repository.Save(album);
        }

        [Given(@"it has this description")]
        public void GivenItHasThisDescription(string description)
        {
            _album.Description = description;
        }

        [StepArgumentTransformation]
        public IEnumerable<Album> ToAlbums(Table table)
        {
            return table.Rows.Select(ToAlbum);
        }

        [StepArgumentTransformation]
        public Album ToAlbum(Table table)
        {
            return ToAlbum(table.Rows[0]);
        }

        private static Album ToAlbum(TableRow row)
        {
            DateTime dateAvailable;
            DateTime.TryParse(row.ContainsKey("Date Available") ? row["Date Available"] : string.Empty, out dateAvailable);

            DateTime releaseDate;
            DateTime.TryParse(row.ContainsKey("Release Date") ? row["Release Date"] : string.Empty, out releaseDate);

            return new Album
            {
                Title = row["Title"],
                Artist = row["Artist"],
                DateAvailable = dateAvailable,
                ReleaseDate = releaseDate
            };
        }
    }
}
