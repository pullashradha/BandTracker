using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_Empty_EmptyDatabase()
    {
      int resultValue = Venue.GetAll().Count;
      Assert.Equal(0, resultValue);
    }
    [Fact]
    public void Test_Equals_EntriesMatch()
    {
      Venue firstVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      Venue secondVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      Assert.Equal(firstVenue, secondVenue);
    }
    [Fact]
    public void Test_Save_SavesVenueToDatabase()
    {
      Venue newVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      newVenue.Save();
      List<Venue> testList = new List<Venue> {newVenue};
      List<Venue> resultList = Venue.GetAll();
      Assert.Equal(testList, resultList);
    }
    [Fact]
    public void Test_AddBand_SavesBandToVenue()
    {
      Venue newVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      newVenue.Save();
      Band newBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      newBand.Save();
      newVenue.AddBand(newBand, new DateTime(2020, 7, 25));
      Dictionary<Band, DateTime> testBandDictionary = new Dictionary<Band, DateTime> {{newBand, new DateTime(2020, 7, 25)}};
      Dictionary<Band, DateTime> resultBandDictionary = newVenue.GetBands();
      Assert.Equal(testBandDictionary, resultBandDictionary);
    }
    [Fact]
    public void Test_Find_ReturnsVenueById()
    {
      Venue newVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      newVenue.Save();
      Venue foundVenue = Venue.Find(newVenue.GetId());
      Assert.Equal(newVenue, foundVenue);
    }
    [Fact]
    public void Test_Update_UpdatesVenueInformation()
    {
      Venue newVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      newVenue.Save();
      newVenue.SetPhoneNumber("360-555-5555");
      newVenue.Update();
      Venue updatedVenue = Venue.Find(newVenue.GetId());
      Assert.Equal(newVenue.GetPhoneNumber(), updatedVenue.GetPhoneNumber());
    }
    [Fact]
    public void Test_DeleteOne_DeletesOneVenue()
    {
      Venue firstVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      Venue secondVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      firstVenue.Save();
      secondVenue.Save();
      List<Venue> testList = new List<Venue> {secondVenue};
      firstVenue.DeleteOne();
      List<Venue> resultList = Venue.GetAll();
      Assert.Equal(testList, resultList);
    }
    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
  }
}
