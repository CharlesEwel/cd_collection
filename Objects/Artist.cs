using System.Collections.Generic;

namespace CdList.Objects
{
  public class Artist
  {
    private string _artist;
    private List<string> _albums = new List<string> {};
    private static List<Artist> _artists = new List<Artist> {};
    public Artist (string newArtist)
    {
      _artist = newArtist;
      _albums = new List<string>{};
      _artists.Add(this);
    }
    public string GetArtist()
    {
      return _artist;
    }
    public void AddAlbum(string newAlbum)
    {
      _albums.Add(newAlbum);
    }
    public List<string> GetAlbums()
    {
      return _albums;
    }
    // public List<String> GetAllArtists()
    // {
    //   return _artists;
    // }
    public static List<Artist> GetAllArtists()
    {
      return _artists;
    }
    public static int Find(string searchArtistName)
    {
      int counter=0;
      int searchIndex=-1;
      foreach(var artist in _artists)
      {
        if(artist.GetArtist()==searchArtistName)
        {
          searchIndex=counter;
        }
        counter++;
      }
      return searchIndex;
    }
    public static List<Artist> SearchArtists(string searchTerm)
    {
      List<Artist> searchedList = new List<Artist> {};
      foreach(var artist in _artists)
      {
        if (artist.GetArtist().ToLower().Contains(searchTerm.ToLower()))
        {
          searchedList.Add(artist);
        }
      }
      return searchedList;
    }
  }
}
