# InsuranceQuoteCalculator

This project is an ASP.NET MVC web application that calculates insurance quotes based on user input. The application uses Entity Framework for data access and stores user information and calculated quotes in a database.

## Features

- Calculate insurance quotes based on user information.
- Display a list of all insurance quotes for site administrators.
- Simple form for users to input their information and receive a quote.
- Admin view showing all issued quotes with user details.

## Calculation Guidelines

The quote calculation follows these guidelines:

- Start with a base of $50 per month.
- If the user is 18 or under, add $100 to the monthly total.
- If the user is from 19 to 25, add $50 to the monthly total.
- If the user is 26 or older, add $25 to the monthly total.
- If the car's year is before 2000, add $25 to the monthly total.
- If the car's year is after 2015, add $25 to the monthly total.
- If the car's Make is a Porsche, add $25 to the price.
  - If the car's Make is a Porsche and its model is a 911 Carrera, add an additional $25 to the price (total of $50).
- Add $10 to the monthly total for every speeding ticket the user has.
- If the user has ever had a DUI, add 25% to the total.
- If it's full coverage, add 50% to the total.

## How to Run the Project

1. Clone the repository from GitHub.
2. Open the solution file (`InsuranceApp.sln`) in Visual Studio.
3. Restore the NuGet packages.
4. Update the database by running the migrations (if any) using the Package Manager Console:
   ```shell
   Update-Database
