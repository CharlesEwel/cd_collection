using System.Collections.Generic;

namespace CdList.Objects
{
  public class Cd
  {
    private string _albumTitle;
    private string _artist;
    private static List<string> _artists = new List<string> {};
    private static List<Cd> _cds = new List<Cd> {};
    public Cd (string AlbumTitle, string Artist)
    {
      _albumTitle=AlbumTitle;
      _artist=Artist;
      _artists.Add(_artist);
      _cds.Add(this);
    }
    public string GetArtist()
    {
      return _artist;
    }
    public string GetAlbum()
    {
      return _albumTitle;
    }
    // public List<String> GetAllArtists()
    // {
    //   return _artists;
    // }
    public static List<Cd> GetAllCds()
    {
      return _cds;
    }
  }
}
