using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _name;
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _zipcode;
    private string _phoneNumber;
    private string _website;
    public Venue (string Name, string StreetAddress, string City, string State, string Zipcode, string PhoneNumber, string Website, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _streetAddress = StreetAddress;
      _city = City;
      _state = State;
      _zipcode = Zipcode;
      _phoneNumber = PhoneNumber;
      _website = Website;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName (string newName)
    {
      _name = newName;
    }
    public string GetStreetAddress()
    {
      return _streetAddress;
    }
    public void SetStreetAddress (string newStreetAddress)
    {
      _streetAddress = newStreetAddress;
    }
    public string GetCity()
    {
      return _city;
    }
    public void SetCity (string newCity)
    {
      _city = newCity;
    }
    public string GetState()
    {
      return _state;
    }
    public void SetState (string newState)
    {
      _state = newState;
    }
    public string GetZipcode()
    {
      return _zipcode;
    }
    public void SetZipcode (string newZipcode)
    {
      _zipcode = newZipcode;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber (string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    public string GetWebsite()
    {
      return _website;
    }
    public void SetWebsite (string newWebsite)
    {
      _website = newWebsite;
    }
    public override bool Equals (System.Object otherVenue)
    {
      if (otherVenue is Venue)
      {
        Venue newVenue = (Venue) otherVenue;
        bool idEquality = (this.GetId() == newVenue.GetId());
        bool nameEquality = (this.GetName() == newVenue.GetName());
        bool streetAddressEquality = (this.GetStreetAddress() == newVenue.GetStreetAddress());
        bool cityEquality = (this.GetCity() == newVenue.GetCity());
        bool stateEquality = (this.GetState() == newVenue.GetState());
        bool zipcodeEquality = (this.GetZipcode() == newVenue.GetZipcode());
        bool phoneNumberEquality = (this.GetPhoneNumber() == newVenue.GetPhoneNumber());
        bool websiteEquality = (this.GetWebsite() == newVenue.GetWebsite());

        return (idEquality && nameEquality && streetAddressEquality && cityEquality && stateEquality && zipcodeEquality && phoneNumberEquality && websiteEquality);
      }
      else
      {
        return false;
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("INSERT INTO venues (name, street_address, city_address, state_address, zipcode, phone_number, website) OUTPUT INSERTED.id VALUES (@VenueName, @VenueStreetAddress, @VenueCity, @VenueState, @VenueZipcode, @VenuePhoneNumber, @VenueWebsite);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@VenueName";
      nameParameter.Value = this.GetName();
      SqlParameter streetAddressParameter = new SqlParameter();
      streetAddressParameter.ParameterName = "@VenueStreetAddress";
      streetAddressParameter.Value = this.GetStreetAddress();
      SqlParameter cityParameter = new SqlParameter();
      cityParameter.ParameterName = "@VenueCity";
      cityParameter.Value = this.GetCity();
      SqlParameter stateParameter = new SqlParameter();
      stateParameter.ParameterName = "@VenueState";
      stateParameter.Value = this.GetState();
      SqlParameter zipcodeParameter = new SqlParameter();
      zipcodeParameter.ParameterName = "@VenueZipcode";
      zipcodeParameter.Value = this.GetZipcode();
      SqlParameter phoneNumberParameter = new SqlParameter();
      phoneNumberParameter.ParameterName = "@VenuePhoneNumber";
      phoneNumberParameter.Value = this.GetPhoneNumber();
      SqlParameter websiteParameter = new SqlParameter();
      websiteParameter.ParameterName = "@VenueWebsite";
      websiteParameter.Value = this.GetWebsite();
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(streetAddressParameter);
      cmd.Parameters.Add(cityParameter);
      cmd.Parameters.Add(stateParameter);
      cmd.Parameters.Add(zipcodeParameter);
      cmd.Parameters.Add(phoneNumberParameter);
      cmd.Parameters.Add(websiteParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static List<Venue> GetAll()
    {
      List<Venue> allVenues = new List<Venue> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM venues;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        string venueStreetAddress = rdr.GetString(2);
        string venueCity = rdr.GetString(3);
        string venueState = rdr.GetString(4);
        string venueZipcode = rdr.GetString(5);
        string venuePhoneNumber = rdr.GetString(6);
        string venueWebsite = rdr.GetString(7);
        Venue newVenue = new Venue (venueName, venueStreetAddress, venueCity, venueState, venueZipcode, venuePhoneNumber, venueWebsite, venueId);
        allVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allVenues;
    }
    public void AddBand (Band newBand, DateTime newEventDate)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("INSERT INTO bands_venues (band_id, venue_id, event_date) VALUES (@BandId, @VenueId, @EventDate);", conn);
      SqlParameter bandIdParameter = new SqlParameter();
      bandIdParameter.ParameterName = "@BandId";
      bandIdParameter.Value = newBand.GetId();
      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = this.GetId();
      SqlParameter eventDateParameter = new SqlParameter();
      eventDateParameter.ParameterName = "@EventDate";
      eventDateParameter.Value = newEventDate;
      cmd.Parameters.Add(bandIdParameter);
      cmd.Parameters.Add(venueIdParameter);
      cmd.Parameters.Add(eventDateParameter);
      cmd.ExecuteNonQuery();
      if (conn != null )
      {
        conn.Close();
      }
    }
    public Dictionary<Band, DateTime> GetBands()
    {
      Dictionary<Band, DateTime> allBands = new Dictionary<Band, DateTime> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT bands.* FROM venues JOIN bands_venues ON (venues.id = bands_venues.venue_id) JOIN bands ON (bands.id = bands_venues.band_id) WHERE venues.id = @VenueId;", conn);
      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = this.GetId();
      cmd.Parameters.Add(venueIdParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        string bandMusicGenre = rdr.GetString(2);
        string bandDescription = rdr.GetString(3);
        string bandWebsite = rdr.GetString(4);
        DateTime bandEventDate = default(DateTime);
        Band newBand = new Band (bandName, bandMusicGenre, bandDescription, bandWebsite, bandId);
        allBands.Add(newBand, bandEventDate);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allBands;
    }
    public static Venue Find (int queryId)
    {
      List<Venue> allVenues = new List<Venue> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM venues WHERE id = @QueryId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@QueryId";
      idParameter.Value = queryId;
      cmd.Parameters.Add(idParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        string venueStreetAddress = rdr.GetString(2);
        string venueCity = rdr.GetString(3);
        string venueState = rdr.GetString(4);
        string venueZipcode = rdr.GetString(5);
        string venuePhoneNumber = rdr.GetString(6);
        string venueWebsite = rdr.GetString(7);
        Venue newVenue = new Venue (venueName, venueStreetAddress, venueCity, venueState, venueZipcode, venuePhoneNumber, venueWebsite, venueId);
        allVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allVenues[0];
    }
    public void Update()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("UPDATE venues SET name = @NewVenueName, street_address = @NewVenueStreetAddress, city_address = @NewVenueCity, state_address = @NewVenueState, zipcode = @NewVenueZipcode, phone_number = @NewVenuePhoneNumber, website = @NewVenueWebsite WHERE id = @VenueId;", conn);
      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewVenueName";
      newNameParameter.Value = this.GetName();
      SqlParameter newStreetAddressParameter = new SqlParameter();
      newStreetAddressParameter.ParameterName = "@NewVenueStreetAddress";
      newStreetAddressParameter.Value = this.GetStreetAddress();
      SqlParameter newCityParameter = new SqlParameter();
      newCityParameter.ParameterName = "@NewVenueCity";
      newCityParameter.Value = this.GetCity();
      SqlParameter newStateParameter = new SqlParameter();
      newStateParameter.ParameterName = "@NewVenueState";
      newStateParameter.Value = this.GetState();
      SqlParameter newZipcodeParameter = new SqlParameter();
      newZipcodeParameter.ParameterName = "@NewVenueZipcode";
      newZipcodeParameter.Value = this.GetZipcode();
      SqlParameter newPhoneNumberParameter = new SqlParameter();
      newPhoneNumberParameter.ParameterName = "@NewVenuePhoneNumber";
      newPhoneNumberParameter.Value = this.GetPhoneNumber();
      SqlParameter newWebsiteParameter = new SqlParameter();
      newWebsiteParameter.ParameterName = "@NewVenueWebsite";
      newWebsiteParameter.Value = this.GetWebsite();

      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@VenueId";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(newNameParameter);
      cmd.Parameters.Add(newStreetAddressParameter);
      cmd.Parameters.Add(newCityParameter);
      cmd.Parameters.Add(newStateParameter);
      cmd.Parameters.Add(newZipcodeParameter);
      cmd.Parameters.Add(newPhoneNumberParameter);
      cmd.Parameters.Add(newWebsiteParameter);
      cmd.Parameters.Add(idParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public void DeleteOne()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM venues WHERE id = @VenueId; DELETE FROM bands_venues WHERE venue_id = @VenueId", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@VenueId";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(idParameter);
      cmd.ExecuteNonQuery();
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM venues; DELETE FROM bands_venues;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
