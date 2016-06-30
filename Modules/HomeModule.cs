using System.Collections.Generic;
using CdList.Objects;
using Nancy;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
          return View["index.cshtml"];
      };Get["/add_cd"] = _ => {
          return View["add_cd.cshtml"];
      };
      Post["/add_new_cd"] = _ =>{
        List<Artist> allArtists = Artist.GetAllArtists();
        int artistIndex=-1;
        if (allArtists.Count > 0)
        {
          artistIndex = Artist.Find(Request.Form["new-artist"]);
        }
        if (artistIndex == -1){
          Artist newArtist = new Artist(Request.Form["new-artist"]);
          newArtist.AddAlbum(Request.Form["new-album"]);
          return View["artist_details.cshtml", newArtist];
        } else {
          Artist newArtist = allArtists[artistIndex];
          newArtist.AddAlbum(Request.Form["new-album"]);
          return View["artist_details.cshtml", newArtist];
        }
        // return View["artist_details.cshtml", newArtist];
      };
      // Get["/artist_details"] = _ =>{
      //   Artist newArtist = new Artist(Request.Form["new-artist"]);
      //   newArtist.AddAlbum(Request.Form["new-album"]);
      //   return View["artist_details.cshtml", newArtist];
      // };
      Get["/{detailsArtist}"] = parameters => {
        List<Artist> allArtists = Artist.GetAllArtists();
        Artist currentArtist = allArtists [Artist.Find(parameters.detailsArtist)];
        return View ["artist_details.cshtml", currentArtist];
      };
      Get["/view_all_artists"] = _ => {
        List<Artist> allArtists = Artist.GetAllArtists();
        return View["view_all_artists.cshtml", allArtists];
      };
      Post["/search_list"] = _ => {
        List<Artist> searchedList = Artist.SearchArtists(Request.Form["search-artist"]);
        return View["view_all_artists.cshtml", searchedList];
      };
      Get["/search_form"] = _ =>{
        return View["search_form.cshtml"];
      };
    }
  }
}
