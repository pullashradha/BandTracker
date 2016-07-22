using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Band
  {
    private int _id;
    private string _name;
    private string _musicGenre;
    private string _description;
    private string _website;
    public Band (string Name, string MusicGenre, string Description, string Website, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _musicGenre = MusicGenre;
      _description = Description;
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
    public string GetMusicGenre()
    {
      return _musicGenre;
    }
    public void SetMusicGenre (string newMusicGenre)
    {
      _musicGenre = newMusicGenre;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription (string newDescription)
    {
      _description = newDescription;
    }
    public string GetWebsite()
    {
      return _website;
    }
    public void SetWebsite (string newWebsite)
    {
      _website = newWebsite;
    }
    public override bool Equals (System.Object otherBand)
    {
      if (otherBand is Band)
      {
        Band newBand = (Band) otherBand;
        bool idEquality = (this.GetId() == newBand.GetId());
        bool nameEquality = (this.GetName() == newBand.GetName());
        bool musicGenreEquality = (this.GetMusicGenre() == newBand.GetMusicGenre());
        bool descriptionEquality = (this.GetDescription() == newBand.GetDescription());
        bool websiteEquality = (this.GetWebsite() == newBand.GetWebsite());

        return (idEquality && nameEquality && musicGenreEquality && descriptionEquality && websiteEquality);
      }
      else
      {
        return false;
      }
    }
    public static List<Band> GetAll()
    {
      List<Band> allBands = new List<Band> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM bands;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        string bandMusicGenre = rdr.GetString(2);
        string bandDescription = rdr.GetString(3);
        string bandWebsite = rdr.GetString(4);
        Band newBand = new Band (bandName, bandMusicGenre, bandDescription, bandWebsite, bandId);
        allBands.Add(newBand);
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
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("INSERT INTO bands (name, street_address, city_address, state_address, zipcode, phone_number, website, event_date) OUTPUT INSERTED.id VALUES (@BandName, @BandStreetAddress, @BandCity, @BandState, @BandZipcode, @BandPhoneNumber, @BandWebsite, @BandEventDate);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@BandName";
      nameParameter.Value = this.GetName();
      SqlParameter streetAddressParameter = new SqlParameter();
      streetAddressParameter.ParameterName = "@BandStreetAddress";
      streetAddressParameter.Value = this.GetStreetAddress();
      SqlParameter cityParameter = new SqlParameter();
      cityParameter.ParameterName = "@BandCity";
      cityParameter.Value = this.GetCity();
      SqlParameter stateParameter = new SqlParameter();
      stateParameter.ParameterName = "@BandState";
      stateParameter.Value = this.GetState();
      SqlParameter zipcodeParameter = new SqlParameter();
      zipcodeParameter.ParameterName = "@BandZipcode";
      zipcodeParameter.Value = this.GetZipcode();
      SqlParameter phoneNumberParameter = new SqlParameter();
      phoneNumberParameter.ParameterName = "@BandPhoneNumber";
      phoneNumberParameter.Value = this.GetPhoneNumber();
      SqlParameter websiteParameter = new SqlParameter();
      websiteParameter.ParameterName = "@BandWebsite";
      websiteParameter.Value = this.GetWebsite();
      SqlParameter eventDateParameter = new SqlParameter();
      eventDateParameter.ParameterName = "@BandEventDate";
      eventDateParameter.Value = this.GetEventDate();
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(streetAddressParameter);
      cmd.Parameters.Add(cityParameter);
      cmd.Parameters.Add(stateParameter);
      cmd.Parameters.Add(zipcodeParameter);
      cmd.Parameters.Add(phoneNumberParameter);
      cmd.Parameters.Add(websiteParameter);
      cmd.Parameters.Add(eventDateParameter);
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
    public static Band Find (int queryId)
    {
      List<Band> allBands = new List<Band> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM bands WHERE id = @QueryId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@QueryId";
      idParameter.Value = queryId;
      cmd.Parameters.Add(idParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        string bandStreetAddress = rdr.GetString(2);
        string bandCity = rdr.GetString(3);
        string bandState = rdr.GetString(4);
        string bandZipcode = rdr.GetString(5);
        string bandPhoneNumber = rdr.GetString(6);
        string bandWebsite = rdr.GetString(7);
        DateTime bandEventDate = rdr.GetDateTime(8);
        Band newBand = new Band (bandName, bandStreetAddress, bandCity, bandState, bandZipcode, bandPhoneNumber, bandWebsite, bandEventDate, bandId);
        allBands.Add(newBand);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allBands[0];
    }
    public void Update()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("UPDATE bands SET name = @NewBandName, street_address = @NewBandStreetAddress, city_address = @NewBandCity, state_address = @NewBandState, zipcode = @NewBandZipcode, phone_number = @NewBandPhoneNumber, website = @NewBandWebsite, event_date = @NewBandEventDate WHERE id = @BandId;", conn);
      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewBandName";
      newNameParameter.Value = this.GetName();
      SqlParameter newStreetAddressParameter = new SqlParameter();
      newStreetAddressParameter.ParameterName = "@NewBandStreetAddress";
      newStreetAddressParameter.Value = this.GetStreetAddress();
      SqlParameter newCityParameter = new SqlParameter();
      newCityParameter.ParameterName = "@NewBandCity";
      newCityParameter.Value = this.GetCity();
      SqlParameter newStateParameter = new SqlParameter();
      newStateParameter.ParameterName = "@NewBandState";
      newStateParameter.Value = this.GetState();
      SqlParameter newZipcodeParameter = new SqlParameter();
      newZipcodeParameter.ParameterName = "@NewBandZipcode";
      newZipcodeParameter.Value = this.GetZipcode();
      SqlParameter newPhoneNumberParameter = new SqlParameter();
      newPhoneNumberParameter.ParameterName = "@NewBandPhoneNumber";
      newPhoneNumberParameter.Value = this.GetPhoneNumber();
      SqlParameter newWebsiteParameter = new SqlParameter();
      newWebsiteParameter.ParameterName = "@NewBandWebsite";
      newWebsiteParameter.Value = this.GetWebsite();
      SqlParameter newEventDateParameter = new SqlParameter();
      newEventDateParameter.ParameterName = "@NewBandEventDate";
      newEventDateParameter.Value = this.GetEventDate();
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@BandId";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(newNameParameter);
      cmd.Parameters.Add(newStreetAddressParameter);
      cmd.Parameters.Add(newCityParameter);
      cmd.Parameters.Add(newStateParameter);
      cmd.Parameters.Add(newZipcodeParameter);
      cmd.Parameters.Add(newPhoneNumberParameter);
      cmd.Parameters.Add(newWebsiteParameter);
      cmd.Parameters.Add(newEventDateParameter);
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
      SqlCommand cmd = new SqlCommand ("DELETE FROM bands WHERE id = @BandId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@BandId";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(idParameter);
      cmd.ExecuteNonQuery();
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM bands;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
