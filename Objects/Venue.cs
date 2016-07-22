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
  }
}
