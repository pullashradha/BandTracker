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
      Venue firstVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", new DateTime(2020, 3, 25));
      Venue secondVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", new DateTime(2020, 3, 25));
      Assert.Equal(firstVenue, secondVenue);
    }
    [Fact]
    public void Test_Save_SavesVenueToDatabase()
    {
      Venue newVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", new DateTime(2020, 3, 25));
      newVenue.Save();
      List<Venue> testList = new List<Venue> {newVenue};
      List<Venue> resultList = Venue.GetAll();
      Assert.Equal(testList, resultList);
    }
    [Fact]
    public void Test_Find_ReturnsVenueById()
    {
      Venue newVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", new DateTime(2020, 3, 25));
      newVenue.Save();
      Venue foundVenue = Venue.Find(newVenue.GetId());
      Assert.Equal(newVenue, foundVenue);
    }
    [Fact]
    public void Test_Update_UpdatesVenueInformation()
    {
      Venue newVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", new DateTime(2020, 3, 25));
      newVenue.Save();
      newVenue.SetEventDate(new DateTime (2020, 4, 25));
      newVenue.Update();
      Venue updatedVenue = Venue.Find(newVenue.GetId());
      Assert.Equal(newVenue.GetEventDate(), updatedVenue.GetEventDate());
    }
    [Fact]
    public void Test_DeleteOne_DeletesOneVenue()
    {
      Venue firstVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", new DateTime(2020, 3, 25));
      Venue secondVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", new DateTime(2020, 3, 25));
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
    }
  }
}
