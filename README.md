# Band Tracker

#### Advanced Databases Independent Project for Epicodus, 07/22/2016

#### By Shradha Pulla

## Description

This program is a web app that will track bands and where they have played. It will store all of the information for each band and venue, and allow basic data manipulation such as: updating a band or venue, deleting one or all bands/venues.

## Setup/Installation Requirements

This program can only be accessed on a PC with Windows 10, and with Git, Atom, and Sql Server Management Studio (SSMS) installed.

* Clone this repository
* Import the database and test database:
  * Open SSMS
  * Select the following buttons from the top nav bar to open the database scripts file: File>Open>File>"Desktop\BandTracker\Sql Databases\band_tracker.sql"
  * Save the band_tracker.sql file
  * To create the database: click the "!Execute" button on the top nav bar
  * To create the database another way, type the following into the top of the sql file:
    * CREATE DATABASE band_tracker;
    * GO
  * Refresh SSMS
  * Repeat the above steps to import the test database
* Test the program:
  * Type following command into PowerShell > dnx test
  * All tests should be passing, if not run dnx test again. Otherwise fix the errors before launching the program on the browser
* View the web page:
  * Type following command into PowerShell > dnx kestrel
  * Open Chrome and type in the following address: localhost:5004

## Database Creation Instructions

To build the databases from scratch, type the commands below in the Windows PowerShell:
  * Desktop> SQLCMD -S "[Server-Name]";
    * 1> CREATE DATABASE band_tracker;
    * 2> GO
    * 3> USE band_tracker;
    * 4> GO
    * 5> CREATE TABLE bands
    * 6>  (
    * 7>  id INT IDENTITY(1,1),
    * 8>  name VARCHAR(255),
    * 9>  music_genre VARCHAR(255),
    * 10> description VARCHAR(500),
    * 11> website VARCHAR(255)
    * 12> );
    * 13> GO
    * 14> CREATE TABLE venues
    * 15> (
    * 16> id INT IDENTITY(1,1),
    * 17> name VARCHAR(255),
    * 18> street_address VARCHAR(255),
    * 19> city_address VARCHAR(255),
    * 20> state_address VARCHAR(255),
    * 21> zipcode VARCHAR(255),
    * 22> phone_number VARCHAR(255),
    * 23> website VARCHAR(255),
    * 24> event_date DATETIME
    * 25> );
    * 26> GO
    * 27> CREATE TABLE bands_venues
    * 28> (
    * 29> id INT IDENTITY(1,1),
    * 30> band_id INT,
    * 31> venue_id INT
    * 32> );
    * 33> GO
  * Exit out of SQLCMD by typing> QUIT
  * Open SSMS, click open Databases folder and check that the band_tracker database has been created
  * Click "New Query" button on top nav bar (above "!Execute")
  * Type following command into query text space to backup database: BACKUP DATABASE band_tracker TO DISK = 'C:\Users\[Account-Name]\band_tracker.bak'
  * Click "!Execute"
  * Right click band_tracker in the Databases folder: Tasks>Restore>Database
  * Confirm that there is a database to restore in the "Backup sets to restore" option field
  * Under the "Destination" input form, change the database name to: "band_tracker_test"
  * Click "OK", refresh SSMS, and view the new test database in the Database folder

If SQL is not connected in the PowerShell, open SSMS and click the "New Query" button (in nav bar above "!Execute"). Type commands shown above into the text space, starting from "CREATE DATABASE...".

## Known Bugs

* Can create duplicate entries of a band or venue that already exists.

## Specifications

The program should... | Example Input | Example Output
----- | ----- | -----
Create and add a new band to the database | Band: "One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com", add to database | Bands in Database: 1
Update a band's information | Update One Ok Rock's description to: "The band is currently touring the US." | One Ok Rock: "The band is currently touring the US."
View a band | View One Ok Rock | One Ok Rock: Genre-"Pop/Rock", Description-"Band from Japan, currently touring the US.", Website-"www.oneokrock.com"
View all bands | Bands: 1 | Bands: One Ok Rock
View all venues a band has played at | One Ok Rock Venues: 1 | "Crossroads MegaStadium, Seattle, Washington"
Delete one band | Bands: 1 | Bands: 0
Delete all bands | Bands: 3 | Bands: 0
Create and add a new venue to the database | Venue: "Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", "3/25/2020" | Venues in Database: 1
Update a venue's information | Update Crossroads MegaStadium event date to: 4/25/2020 | CrossRoads MegaStadium: 4/25/2020
View a venue | View Crossroads MegaStadium | CrossRoads MegaStadium: Address-"101 SW Washington St., Seattle, Washington 97206", Phone Number- 555-555-5555, Website-" www.crossroadstadium.com", Event Date- 3/25/2020
View all venues | Venues: 1 | Venues: Crossroads MegaStadium
View all bands that have played at a venue | Crossroad MegaStadium Bands: 1 | One Ok Rock, Pop/Rock
Delete one venue | Venues: 1 | Venues: 0
Delete all venues | Venues: 3 | Venues: 0
Add a band to a venue | Crossroads MegaStadium, Bands: 0, add One Ok Rock | Bands: 1
Add a venue to a band | One OK Rock, Venues: 0, add Crossroads MegaStadium | Venues: 1

## Future Features

HTML | CSS | C#
----- | ----- | -----
Add a better input form to set event date & time | --- | Update bands_venues database to include date & time columns(separate)
Add drop down bar for existing venues & bands | --- | Allow user to add band to already existing venue & vice versa
Have more confirmation pages | --- | Allow user to delete band from database but keep information of band in the venue page though it can't be altered, just to view past performers

## Support and Contact Details

Contact Epicodus for support in running this program.

## Technologies Used

* HTML
* CSS
* Bootstrap
* C#

## Links

Git Hub Repository: https://github.com/pullashradha/BandTracker

## License

*This software is licensed under the Microsoft ASP.NET license.*

Copyright (c) 2016 Shradha Pulla
