insert into Club ([Name], FoundingDate, City) values ('Manchester City FC', 1880, 'Manchester');
insert into Club ([Name], FoundingDate, City) values ('Chelsea FC', 1905, 'London');
insert into Club ([Name], FoundingDate, City) values ('Southampton FC', 1885, 'Southampton');
insert into Club ([Name], FoundingDate, City) values ('Crystal Palace FC', 1905, 'London');

insert into Position (PositionName) values ('Forward');
insert into Position (PositionName) values ('Midfielder');
insert into Position (PositionName) values ('Defender');
insert into Position (PositionName) values ('GoalKeeper');

insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Ederson', 'Santana de Moraes', '1993-08-17', 1, 4, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Ruben', 'Dias', '1997-05-14', 1, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Joao', 'Cancelo', '1994-05-27', 1, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Rodrigo', 'Cascante', '1996-06-22', 1, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Kevin', 'De Bruyne', '1991-06-28', 1, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Phil', 'Foden', '2000-05-28', 1, 1, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Edouard', 'Mendy', '1992-03-01', 2, 4, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Reece', 'James', '1999-12-08', 2, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Thiago', 'Silva', '1984-09-22', 2, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Benjamin', 'Chilwell', '1996-12-21', 2, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Mason', 'Mount', '1999-01-10', 2, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Kai', 'Havertz', '1999-06-11', 2, 1, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Fraser', 'Forster', '1988-03-17', 3, 4, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Mohammed', 'Salisu', '1999-04-17', 3, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Valentino', 'Livramento', '2002-11-12', 3, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('James', 'Ward-Prowse', '1994-11-01', 3, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Oriol', 'Romeu', '1991-09-24', 3, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Armando', 'Broja', '2001-09-10', 3, 1, 1, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Vicente', 'Guaita', '1987-01-10', 4, 4, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Marc', 'Guehi', '2000-07-13', 4, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Joachim', 'Andersen', '1996-05-31', 4, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Conor', 'Gallagher', '2000-02-06', 4, 2, 1, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Wilfried', 'Zaha', '1992-11-10', 4, 1, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Odsonne', 'Edouard', '1998-01-16', 4, 1, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Vincent', 'Kompany', '1986-04-10', 1, 3, 0, 0);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Sergio', 'Aguero', '1988-06-02', 1, 1, 0, 0);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Frank', 'Lampard', '1978-06-20', 2, 2, 0, 0);

insert into Season (NumberOfGames, [Year]) values ('2020-2021');

insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (1, 2, 1, 45,293, 2, 1);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (3, 4, 1, 24,756, 2, 2);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (1, 3, 1, 36,730, 4, 0);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (4, 2, 1, 19,945, 0, 2);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (4, 1, 1, 20,169, 1, 0);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (2, 3, 1, 35,945, 3, 0);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (1, 4, 1, 45,945, 2, 1);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (3, 2, 1, 28,945, 2, 2);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (2, 1, 1, 39,945, 1, 3);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (4, 3, 1, 20,945, 2, 1);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (3, 1, 1, 30,293, 0, 1);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore) values (2, 4, 1, 36,945, 1, 0);

insert into Loan (ParentClubId, LoanClubId, PlayerId, LoanDuration, LoanStart) values (2, 3, 18, 10, '2021-08-01');
insert into Loan (ParentClubId, LoanClubId, PlayerId, LoanDuration, LoanStart) values (2, 4, 22, 10, '2021-08-01');

insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Shots, Fouls, Goals, Assists, Saves, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (1, 1, 4, 0, 0, 0, 0, 0, 3, 22, 17, 0, 0, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Shots, Fouls, Goals, Assists, Saves, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (2, 1, 3, 1, 1, 2, 0, 0, 0, 32, 28, 3, 2, 5, 3, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Shots, Fouls, Goals, Assists, Saves, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (3, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);