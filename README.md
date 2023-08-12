#### By _**Elle Hailu**_

#### _A web application to keep track of treats and flavors offered at a bakery_

## Technologies Used

- _C#_
- _.NET_
- _Bootstrap_
- Html
- CSS
- Asp.Net

## Description

- An MVC application with user authentication and a many-to-many relationship.
- A user is able to log in and log out. Only logged in users have create, update, and delete functionality. All users have read functionality.
- There is a many-to-many relationship between Treats and Flavors.
- A user is able to navigate to a splash page that lists all treats and flavors. And users are able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

## Setup/Installation Requirements

- _Clone this repository to your desktop_
- _Open your terminal and navigate to the top level of the directory_
- _Navigate to the production (PierresTreats) directory in your terminal._
- _Create a new file in your production folder and name it "appsettings.json"_
- _Update the contents of your appsettings.json file with:_

```
{
  "ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;database=elle_hailu_factory;uid=[YOUR-USER-NAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
  }
```

- _Replace the place holder user name and password in the appsettings.json file with your actual username and password._

- _To launch application remain in your production folder and run the command "dotnet run" in your terminal._

## Known Bugs

## License

MIT [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Copyright (c) _2023_ _Elle Hailu_

_Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:_

_The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software._

_THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._
