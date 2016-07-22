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
    private DateTime _eventDate;
    public Venue (string Name, string StreetAddress, string City, string State, string Zipcode, string PhoneNumber, string Website, DateTime EventDate = default(DateTime), int Id = 0)
    {
      _id = Id;
      _name = Name;
      _streetAddress = StreetAddress;
      _city = City;
      _state = State;
      _zipcode = Zipcode;
      _phoneNumber = PhoneNumber;
      _website = Website;
      _eventDate = EventDate;
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
    public DateTime GetEventDate()
    {
      return _eventDate;
    }
    public void SetEventDate (DateTime newEventDate)
    {
      _eventDate = newEventDate;
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
        bool eventDateEquality = (this.GetEventDate() == newVenue.GetEventDate());

        return (idEquality && nameEquality && streetAddressEquality && cityEquality && stateEquality && zipcodeEquality && phoneNumberEquality && websiteEquality && eventDateEquality);
      }
      else
      {
        return false;
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
        DateTime venueEventDate = rdr.GetDateTime(8);
        Venue newVenue = new Venue (venueName, venueStreetAddress, venueCity, venueState, venueZipcode, venuePhoneNumber, venueWebsite, venueEventDate, venueId);
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
  }
}
