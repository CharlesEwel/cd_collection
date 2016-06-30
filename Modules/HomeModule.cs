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
        Cd newCd = new Cd(Request.Form["new-album"], Request.Form["new-artist"]);
        return View["artist_details.cshtml", newCd];
      };
      Get["/view_all_cds"] = _ => {
        List<Cd> allCds = Cd.GetAllCds();
        return View["view_all_cds.cshtml", allCds];
      };
    }
  }
}
