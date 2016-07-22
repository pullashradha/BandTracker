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
      Post ["/bands/new"] = _ => {
        Band newBand = new Band
        (
          Request.Form ["band-name"],
          Request.Form ["band-music-genre"],
          Request.Form ["band-description"],
          Request.Form ["band-website"]
        );
        newBand.Save();
        return View ["bands.cshtml", Band.GetAll()];
      };
      Post ["/bands/{id}/{name}"] = parameters => {
        Band selectedBand = Band.Find(parameters.id);
        return View ["band.cshtml", selectedBand];
      };
      Post ["/venues/new"] = _ => {
        Venue newVenue = new Venue
        (
          Request.Form ["venue-id"],
          Request.Form ["venue-name"],
          Request.Form ["venue-street-address"],
          Request.Form ["venue-city"],
          Request.Form ["venue-state"],
          Request.Form ["venue-zipcode"],
          Request.Form ["venue-phone-number"],
          Request.Form ["venue-website"],
          Request.Form ["venue-event-date"]
        );
        newVenue.Save();
        return View ["venues.cshtml", Venue.GetAll()];
      };
      Post ["/venues/{id}/{name}"] = parameters => {
        Venue selectedVenue = Venue.Find(parameters.id);
        return View ["venue.cshtml", selectedVenue];
      };
    }
  }
}
