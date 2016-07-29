using Nancy;
using System.Collections.Generic;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => View ["index.cshtml"];
      Get ["/bands"] = _ => View ["bands.cshtml", Band.GetAll()];
      Get ["/venues"] = _ => View ["venues.cshtml", Venue.GetAll()];
//Bands Start
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
      Get ["/bands/{id}/{name}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object> {};
        Band selectedBand = Band.Find(parameters.id);
        List<Venue> allVenues = Venue.GetAll();
        model.Add("selectedBand", selectedBand);
        model.Add("allVenues", allVenues);
        return View ["band.cshtml", model];
      };
      Post ["/bands/{id}/{name}/updated"] = parameters => {
        Band selectedBand = Band.Find(parameters.id);
        selectedBand.SetName(Request.Form ["update-band-name"]);
        selectedBand.SetMusicGenre(Request.Form ["update-band-music-genre"]);
        selectedBand.SetDescription(Request.Form ["update-band-description"]);
        selectedBand.SetWebsite(Request.Form ["update-band-website"]);
        selectedBand.Update();
        return View ["band.cshtml", selectedBand];
      };
      Post ["/bands/new_venue"] = _ => {
        Band selectedBand = Band.Find(Request.Form ["band-id"]);
        Venue newVenue = Venue.Find(Request.Form ["venue-id"]);
        selectedBand.AddVenue(newVenue, Request.Form ["event-date"]);
        return View ["confirmation.cshtml"];
      };
      Post ["/bands/{id}/{name}/deleted"] = parameters => {
        Band selectedBand = Band.Find(parameters.id);
        selectedBand.DeleteOne();
        return View ["deleted.cshtml", selectedBand];
      };
      Post ["/bands/deleted"] = _ => {
        Band.DeleteAll();
        return View ["bands.cshtml", Band.GetAll()];
      };
//Venues Start
      Post ["/venues/new"] = _ => {
        Venue newVenue = new Venue
        (
          Request.Form ["venue-name"],
          Request.Form ["venue-street-address"],
          Request.Form ["venue-city"],
          Request.Form ["venue-state"],
          Request.Form ["venue-zipcode"],
          Request.Form ["venue-phone-number"],
          Request.Form ["venue-website"]
        );
        newVenue.Save();
        return View ["venues.cshtml", Venue.GetAll()];
      };
      Get ["/venues/{id}/{name}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object> {};
        Venue selectedVenue = Venue.Find(parameters.id);
        List<Band> allBands = Band.GetAll();
        model.Add("selectedVenue", selectedVenue);
        model.Add("allBands", allBands);
        return View ["venue.cshtml", model];
      };
      Post ["/venues/{id}/{name}/updated"] = parameters => {
        Venue selectedVenue = Venue.Find(parameters.id);
        selectedVenue.SetName(Request.Form ["update-venue-name"]);
        selectedVenue.SetStreetAddress(Request.Form ["update-venue-street-address"]);
        selectedVenue.SetCity(Request.Form ["update-venue-city"]);
        selectedVenue.SetState(Request.Form ["update-venue-state"]);
        selectedVenue.SetZipcode(Request.Form ["update-venue-zipcode"]);
        selectedVenue.SetPhoneNumber(Request.Form ["update-venue-phone-number"]);
        selectedVenue.SetWebsite(Request.Form ["update-venue-website"]);
        selectedVenue.Update();
        return View ["venue.cshtml", selectedVenue];
      };
      Post ["/venues/new_band"] = _ => {
        Venue selectedVenue = Venue.Find(Request.Form ["venue-id"]);
        Band newBand = Band.Find(Request.Form ["band-id"]);
        selectedVenue.AddBand(newBand, Request.Form ["event-date"]);
        return View ["confirmation.cshtml"];
      };
      Post ["/venues/{id}/{name}/deleted"] = parameters => {
        Venue selectedVenue = Venue.Find(parameters.id);
        selectedVenue.DeleteOne();
        return View ["deleted.cshtml", selectedVenue];
      };
      Post ["/venues/deleted"] = _ => {
        Venue.DeleteAll();
        return View ["venues.cshtml", Venue.GetAll()];
      };
    }
  }
}
