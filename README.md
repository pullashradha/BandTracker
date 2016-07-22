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
Create and add a new band to the database | --- | ---
Update a band's information | --- | ---
View a band | --- | ---
View all bands | --- | ---
View all venues a band has played at | --- | ---
Delete one band | --- | ---
Delete all bands | --- | ---
Create and add a new venue to the database | --- | ---
Update a venue's information | --- | ---
View a venue | --- | ---
View all venues | --- | ---
View all bands that have played at a venue | --- | ---
Delete one venue | --- | ---
Delete all venues | --- | ---

Band Information: Name, Type of Music, Description, Website
Venue Information: Name, Event Date, Address, Phone Number, Website

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
