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
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("INSERT INTO bands (name, music_genre, description, website) OUTPUT INSERTED.id VALUES (@BandName, @BandMusicGenre, @BandDescription, @BandWebsite);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@BandName";
      nameParameter.Value = this.GetName();
      SqlParameter musicGenreParameter = new SqlParameter();
      musicGenreParameter.ParameterName = "@BandMusicGenre";
      musicGenreParameter.Value = this.GetMusicGenre();
      SqlParameter descriptionParameter = new SqlParameter();
      descriptionParameter.ParameterName = "@BandDescription";
      descriptionParameter.Value = this.GetDescription();
      SqlParameter websiteParameter = new SqlParameter();
      websiteParameter.ParameterName = "@BandWebsite";
      websiteParameter.Value = this.GetWebsite();
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(musicGenreParameter);
      cmd.Parameters.Add(descriptionParameter);
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
      return allBands[0];
    }
    public void Update()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("UPDATE bands SET name = @NewBandName, music_genre = @NewBandMusicGenre, description = @NewDescription, website = @NewBandWebsite WHERE id = @BandId;", conn);
      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewBandName";
      newNameParameter.Value = this.GetName();
      SqlParameter newMusicGenreParameter = new SqlParameter();
      newMusicGenreParameter.ParameterName = "@NewBandMusicGenre";
      newMusicGenreParameter.Value = this.GetMusicGenre();
      SqlParameter newDescriptionParameter = new SqlParameter();
      newDescriptionParameter.ParameterName = "@NewDescription";
      newDescriptionParameter.Value = this.GetDescription();
      SqlParameter newWebsiteParameter = new SqlParameter();
      newWebsiteParameter.ParameterName = "@NewBandWebsite";
      newWebsiteParameter.Value = this.GetWebsite();
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@BandId";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(newNameParameter);
      cmd.Parameters.Add(newMusicGenreParameter);
      cmd.Parameters.Add(newDescriptionParameter);
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
