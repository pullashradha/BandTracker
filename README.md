# Band Tracker Webpage

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
  * All tests should be passing, if not run dnx test again
* View the web page:
  * Type following command into PowerShell > dnx kestrel
  * Open Chrome and type in the following address: localhost:5004

## Known Bugs

No known bugs.

## Specifications

The program should ... | Example Input | Example Output
----- | ----- | -----
Create and add a new band to the database | Band: "One Ok Rock", "Pop/Rock", "Band from Japan, currently touring the US.", "www.oneokrock.com", add to database | Bands in Database: 1
Update a band's information | Update One Ok Rock's description to: "The band is currently touring the US." | One Ok Rock: "The band is currently touring the US."
View a band | View One Ok Rock | One Ok Rock: Genre-Pop/Rock, Description-Band from Japan, currently touring the US., Website-www.oneokrock.com
View all bands | Bands: 1 | Bands: One Ok Rock
View all venues a band has played at | One Ok Rock Venues: 1 | Crossroads MegaStadium, Seattle, Washington
Delete one band | Bands: 1 | Bands: 0
Delete all bands | Bands: 3 | Bands: 0
Create and add a new venue to the database | Venue: "Crossroads MegaStadium", "101 SW Washington St.", "Seattle", "Washington", "97206", "555-555-5555", "www.crossroadsstadium.com", "3/25/2020" | Venues in Database: 1
Update a venue's information | Update Crossroads MegaStadium event date to: 4/25/2020 | CrossRoads MegaStadium: 4/25/2020
View a venue | View Crossroads MegaStadium | CrossRoads MegaStadium: Address-101 SW Washington St., Seattle, Washington 97206, Phone Number- 555-555-5555, Website- www.crossroadstadium.com, Event Date- 3/25/2020
View all venues | Venues: 1 | Venues: Crossroads MegaStadium
View all bands that have played at a venue | Crossroad MegaStadium Bands: 1 | One Ok Rock, Pop/Rock
Delete one venue | Venues: 1 | Venues: 0
Delete all venues | Venues: 3 | Venues: 0

## Future Features

HTML | CSS | C#
----- | ----- | -----
--- | --- | ---

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
