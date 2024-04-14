# derivco
Technical Test

Task 1:

Presumed to have the Microsoft Northwind database set up.
Open sql file in the "Task 01" folder of the repository and run the script to create the stored procedure.
Can then run tests as you please.

Task 2:

Api was written in .NET8 and using EntityFramework to handle the SQLite database.
Make sure to restore any nuget packages.
Database is already generated but if api.db is missing, run:
dotnet ef migrations add "initial_migration"
and then
dotnet ef database update

The database connection string should work as long as api.db is in the root of the project (Same location as .csproj)

Project include Swagger for ease of testing the api endpoints.

How to:
1. Run the application
2. Swagger page should open with all the api endpoints.
3. Create a game (/api/roulettegame/create-game).
4. Bet on the game. (/api/roulettegame/bet) (There is only one rule and it is for betting on single numbers)
5. Do a spin. (/api/roulettegame/spin)
6. Payout winning bets. (/api/roulettegame/payout) (There's only a flat x2.5 payout for a winning number as there is only one rule)
7. Get the history for all spins done ever. (/api/roulettegame/spin-history)


Extra Notes:

1. Was originally developing a full roulette system with players and betting/payout rules.
2. Restarted as the scope would have been too large and this is the result of the time I had remaining before delivery.
3. I am unfamilliar with using unit tests and global exception handling as this was not something done at any of my previous employers. I am however interrested and have looked into it.
4. As I am unfamilliar with global exception handling I forgoed doing normal inline exceptions and rather sticked to null/zero checks to return statuscodes. This however does not deal with things like database connection issues etc. and is not recommended.
   
