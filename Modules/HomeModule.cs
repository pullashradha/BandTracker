using Nancy;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => View ["index.cshtml"];
      Get ["/bands"] = _ => View ["bands.cshtml", Band.GetAll()];
      Get ["/venues"] = _ => View ["venues.cshtml", Venue.GetAll()];
      // Post ["/bands/{id}/{name}"] = parameters => {
      //   Band selectedBand = Band.Find(parameters.id);
      //   selectedBand.Save();
      //   return View ["band.cshtml", selectedBand];
      // };
      // Post ["/venues/{id}/{name}"] = parameters => {
      //   Venue selectedVenue = Venue.Find(parameters.id);
      //   selectedVenue.Save();
      //   return View ["venue.cshtml", selectedVenue];
      // };
    }
  }
}
