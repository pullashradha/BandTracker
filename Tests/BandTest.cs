using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_Empty_EmptyDatabase()
    {
      int resultValue = Band.GetAll().Count;
      Assert.Equal(0, resultValue);
    }
    [Fact]
    public void Test_Equals_EntriesMatch()
    {
      Band firstBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      Band secondBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      Assert.Equal(firstBand, secondBand);
    }
    [Fact]
    public void Test_Save_SavesBandToDatabase()
    {
      Band newBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      newBand.Save();
      List<Band> testList = new List<Band> {newBand};
      List<Band> resultList = Band.GetAll();
      Assert.Equal(testList, resultList);
    }
    [Fact]
    public void Test_AddVenue_SavesVenueToBand()
    {
      Band newBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      newBand.Save();
      Venue newVenue = new Venue ("Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com");
      newVenue.Save();
      newBand.AddVenue(newVenue, new DateTime(2020, 7, 25));
      List<Venue> testVenueList = new List<Venue> {newVenue};
      List<Venue> resultVenueList = newBand.GetVenues();
      Assert.Equal(testVenueList, resultVenueList);
    }
    [Fact]
    public void Test_Find_ReturnsBandById()
    {
      Band newBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      newBand.Save();
      Band foundBand = Band.Find(newBand.GetId());
      Assert.Equal(newBand, foundBand);
    }
    [Fact]
    public void Test_Update_UpdatesBandInformation()
    {
      Band newBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      newBand.Save();
      newBand.SetDescription("The band is currently touring the US.");
      newBand.Update();
      Band updatedBand = Band.Find(newBand.GetId());
      Assert.Equal(newBand.GetDescription(), updatedBand.GetDescription());
    }
    [Fact]
    public void Test_DeleteOne_DeletesOneBand()
    {
      Band firstBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      Band secondBand = new Band ("One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com");
      firstBand.Save();
      secondBand.Save();
      List<Band> testList = new List<Band> {secondBand};
      firstBand.DeleteOne();
      List<Band> resultList = Band.GetAll();
      Assert.Equal(testList, resultList);
    }
    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
