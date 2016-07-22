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
      Post ["/bands/{id}/{name}/updated"] = parameters => {
        Band selectedBand = Band.Find(parameters.id);
        Band updatedBand = selectedBand
        (
          Request.Form ["update-band-name"],
          Request.Form ["update-band-music-genre"],
          Request.Form ["update-band-description"],
          Request.Form ["update-band-website"]
        );
        updatedBand.Update();
        return View ["band.cshtml", updatedBand];
      };
      Post ["/bands/deleted"] = _ => {
        Band.DeleteAll();
        return View ["bands.cshtml", Band.GetAll()];
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
      Post ["/venues/{id}/{name}/updated"] = parameters => {
        Venue selectedVenue = Venue.Find(parameters.id);
        Venue updatedVenue = selectedVenue
        (
          Request.Form ["update-venue-id"],
          Request.Form ["update-venue-name"],
          Request.Form ["update-venue-street-address"],
          Request.Form ["update-venue-city"],
          Request.Form ["update-venue-state"],
          Request.Form ["update-venue-zipcode"],
          Request.Form ["update-venue-phone-number"],
          Request.Form ["update-venue-website"],
          Request.Form ["update-venue-event-date"]
        );
        updatedVenue.Update();
        return View ["venue.cshtml", updatedVenue];
      };
      Post ["/venues/deleted"] = _ => {
        Venue.DeleteAll();
        return View ["venues.cshtml", Venue.GetAll()];
      };
    }
  }
}
