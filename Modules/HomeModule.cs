using Nancy;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => {
        return View ["index.cshtml", Venue.GetAll()];
      };
    }
  }
}
