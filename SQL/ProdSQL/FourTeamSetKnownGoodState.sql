CREATE PROCEDURE [SetKnownGoodState]
AS
BEGIN
    ALTER TABLE History DROP CONSTRAINT fk_History_PlayerId;
    ALTER TABLE Performance DROP CONSTRAINT fk_Performance_MatchId;
    ALTER TABLE Performance DROP CONSTRAINT fk_Performance_PlayerId;
    ALTER TABLE Performance DROP CONSTRAINT fk_Performance_PositionId;
    ALTER TABLE Loan DROP CONSTRAINT fk_Loan_ParentClubId;
    ALTER TABLE Loan DROP CONSTRAINT fk_Loan_LoanClubId;
    ALTER TABLE Loan DROP CONSTRAINT fk_Loan_PlayerId;
    ALTER TABLE Match DROP CONSTRAINT fk_Match_HomeClubId;
    ALTER TABLE Match DROP CONSTRAINT fk_Match_VisitingClubId; 
    ALTER TABLE Match DROP CONSTRAINT fk_Match_SeasonId;    
    ALTER TABLE Player DROP CONSTRAINT fk_Player_ClubId;   
    ALTER TABLE Player DROP CONSTRAINT fk_Player_PositionId;
    TRUNCATE TABLE History;
    TRUNCATE TABLE Performance;
    TRUNCATE TABLE Loan;
    TRUNCATE TABLE Match;
    TRUNCATE TABLE Season;
    TRUNCATE TABLE Player;
    TRUNCATE TABLE Club;
    TRUNCATE TABLE Position;
    ALTER TABLE History add CONSTRAINT fk_History_PlayerId
        FOREIGN KEY (PlayerId)
        REFERENCES Player(PlayerId);
    ALTER TABLE Performance ADD CONSTRAINT fk_Performance_MatchId
        foreign key (MatchId)
        REFERENCES Match(MatchId);
    ALTER TABLE Performance ADD CONSTRAINT fk_Performance_PlayerId
        foreign key (PlayerId)
        references Player(PlayerId);
    ALTER TABLE Performance ADD CONSTRAINT fk_Performance_PositionId
        foreign key (PositionId)
        references Position(PositionId);
    ALTER TABLE Loan add CONSTRAINT fk_Loan_ParentClubId
        FOREIGN KEY (ParentClubId)
        REFERENCES Club(ClubId);
    ALTER TABLE Loan ADD CONSTRAINT fk_Loan_LoanClubId
        foreign key (LoanClubId)
        REFERENCES Club(ClubId);
    ALTER TABLE Loan add CONSTRAINT fk_Loan_PlayerId
        FOREIGN KEY (PlayerId)
        REFERENCES Player(PlayerId);
    ALTER TABLE Match ADD CONSTRAINT fk_Match_HomeClubId
        foreign key (HomeClubId)
        REFERENCES Club(ClubId);    
    ALTER TABLE Match ADD CONSTRAINT fk_Match_VisitingClubId
        foreign key (VisitingClubId)
        REFERENCES Club(ClubId);   
    ALTER TABLE Match ADD CONSTRAINT fk_Match_SeasonId
        foreign key (SeasonId)
        REFERENCES Season(SeasonId);   
    ALTER TABLE Player ADD CONSTRAINT fk_Player_ClubId
        foreign key (ClubId)
        REFERENCES Club(ClubId);
    ALTER TABLE Player ADD CONSTRAINT fk_Player_PositionId
        foreign key (PositionId)
        REFERENCES Position(PositionId);

insert into Club ([Name], FoundingDate, City) values ('Manchester City FC', '1880-01-01', 'Manchester');
insert into Club ([Name], FoundingDate, City) values ('Chelsea FC', '1905-01-01', 'London');
insert into Club ([Name], FoundingDate, City) values ('Southampton FC', '1885-01-01', 'Southampton');
insert into Club ([Name], FoundingDate, City) values ('Crystal Palace FC', '1905-01-01', 'London');
insert into Position (PositionName) values ('GoalKeeper');
insert into Position (PositionName) values ('Defender');
insert into Position (PositionName) values ('Midfielder');
insert into Position (PositionName) values ('Forward');
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Ederson', 'Santana de Moraes', '1993-08-17', 1, 1, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Ruben', 'Dias', '1997-05-14', 1, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Joao', 'Cancelo', '1994-05-27', 1, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Rodrigo', 'Cascante', '1996-06-22', 1, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Kevin', 'De Bruyne', '1991-06-28', 1, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Phil', 'Foden', '2000-05-28', 1, 4, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Edouard', 'Mendy', '1992-03-01', 2, 1, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Reece', 'James', '1999-12-08', 2, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Thiago', 'Silva', '1984-09-22', 2, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Benjamin', 'Chilwell', '1996-12-21', 2, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Mason', 'Mount', '1999-01-10', 2, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Kai', 'Havertz', '1999-06-11', 2, 4, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Fraser', 'Forster', '1988-03-17', 3, 1, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Mohammed', 'Salisu', '1999-04-17', 3, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Valentino', 'Livramento', '2002-11-12', 3, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Oriol', 'Romeu', '1991-09-24', 3, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('James', 'Ward-Prowse', '1994-11-01', 3, 3, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Armando', 'Broja', '2001-09-10', 3, 4, 1, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Vicente', 'Guaita', '1987-01-10', 4, 1, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Marc', 'Guehi', '2000-07-13', 4, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Joachim', 'Andersen', '1996-05-31', 4, 2, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Conor', 'Gallagher', '2000-02-06', 4, 3, 1, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Wilfried', 'Zaha', '1992-11-10', 4, 4, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Odsonne', 'Edouard', '1998-01-16', 4, 4, 0, 1);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Vincent', 'Kompany', '1986-04-10', 1, 2, 0, 0);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Sergio', 'Aguero', '1988-06-02', 1, 4, 0, 0);
insert into Player (FirstName, LastName, DateOfBirth, ClubId, PositionId, IsOnLoan, IsActive) values ('Frank', 'Lampard', '1978-06-20', 2, 3, 0, 0);
insert into Season ([Year], IsActive) values ('2021-2022', 1);
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (1, 2, 1, 45293, 2, 1, '2021-11-13');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (3, 4, 1, 24756, 2, 2, '2021-11-14');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (1, 3, 1, 36730, 4, 0, '2021-11-20');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (4, 2, 1, 19945, 0, 2, '2021-11-21');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (4, 1, 1, 20169, 1, 0, '2021-11-27');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (2, 3, 1, 35945, 3, 0, '2021-11-28');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (1, 4, 1, 45945, 2, 1, '2021-12-11');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (3, 2, 1, 28945, 2, 2, '2021-12-12');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (2, 1, 1, 39945, 1, 3, '2022-01-08');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (4, 3, 1, 20945, 2, 1, '2022-01-09');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (3, 1, 1, 30293, 0, 1, '2022-01-15');
insert into Match (HomeClubId, VisitingClubId, SeasonId, NumberOfAttendees, HomeScore, AwayScore, MatchDate) values (2, 4, 1, 36945, 1, 0, '2022-01-08');
insert into Loan (ParentClubId, LoanClubId, PlayerId, LoanDuration, LoanStart) values (2, 3, 18, 10, '2021-08-01');
insert into Loan (ParentClubId, LoanClubId, PlayerId, LoanDuration, LoanStart) values (2, 4, 22, 10, '2021-08-01');
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (1, 1, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (2, 1, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (3, 1, 2, 0, 3, 0, 1, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (4, 1, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (5, 1, 3, 3, 0, 1, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (6, 1, 4, 2, 1, 1, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (7, 1, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (8, 1, 2, 0, 2, 0, 1, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (9, 1, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (10, 1, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (11, 1, 3, 3, 0, 1, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (12, 1, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (13, 2, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (14, 2, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (15, 2, 2, 0, 3, 0, 1, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (16, 2, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (17, 2, 3, 3, 0, 1, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (18, 2, 4, 2, 1, 1, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (19, 2, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (20, 2, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (21, 2, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (22, 2, 3, 0, 2, 1, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (23, 2, 3, 3, 0, 1, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (24, 2, 4, 2, 1, 0, 1, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (1, 3, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 1);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (2, 3, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (3, 3, 2, 1, 3, 1, 1, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (4, 3, 3, 0, 2, 0, 1, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (5, 3, 3, 3, 0, 1, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (6, 3, 4, 2, 1, 2, 1, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (13, 3, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (14, 3, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (15, 3, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (16, 3, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (17, 3, 3, 3, 0, 0, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (18, 3, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (19, 4, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (20, 4, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (21, 4, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (22, 4, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (23, 4, 3, 3, 0, 0, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (24, 4, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (7, 4, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 1);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (8, 4, 2, 0, 2, 1, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (9, 4, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (10, 4, 3, 0, 2, 0, 1, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (11, 4, 3, 3, 0, 0, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (12, 4, 4, 2, 1, 1, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (19, 5, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 1);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (20, 5, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (21, 5, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (22, 5, 3, 0, 2, 0, 1, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (23, 5, 3, 3, 0, 1, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (24, 5, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (1, 5, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (2, 5, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (3, 5, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (4, 5, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (5, 5, 3, 3, 0, 0, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (6, 5, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (7, 6, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 1);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (8, 6, 2, 0, 2, 0, 1, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (9, 6, 2, 1, 3, 1, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (10, 6, 3, 0, 2, 1, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (11, 6, 3, 3, 0, 0, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (12, 6, 4, 2, 1, 1, 1, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (13, 6, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (14, 6, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (15, 6, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (16, 6, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (17, 6, 3, 3, 0, 0, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (18, 6, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (1, 7, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (2, 7, 2, 0, 2, 1, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (3, 7, 2, 0, 3, 0, 1, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (4, 7, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (5, 7, 3, 3, 0, 0, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (6, 7, 4, 2, 1, 1, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (19, 7, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (20, 7, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (21, 7, 2, 0, 3, 0, 1, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (22, 7, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (23, 7, 3, 3, 0, 0, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (24, 7, 4, 2, 1, 1, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (13, 8, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (14, 8, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (15, 8, 2, 0, 3, 0, 1, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (16, 8, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (17, 8, 3, 3, 0, 1, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (18, 8, 4, 2, 1, 1, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (7, 8, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (8, 8, 2, 0, 2, 0, 1, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (9, 8, 2, 1, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (10, 8, 3, 0, 2, 0, 1, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (11, 8, 3, 3, 0, 1, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (12, 8, 4, 2, 1, 1, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (7, 9, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (8, 9, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (9, 9, 2, 1, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (10, 9, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (11, 9, 3, 3, 0, 1, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (12, 9, 4, 2, 1, 0, 1, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (1, 9, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (2, 9, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (3, 9, 2, 0, 3, 0, 1, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (4, 9, 3, 0, 2, 0, 1, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (5, 9, 3, 3, 0, 2, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (6, 9, 4, 2, 1, 1, 1, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (19, 10, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (20, 10, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (21, 10, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (22, 10, 3, 0, 2, 0, 1, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (23, 10, 3, 3, 0, 0, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (24, 10, 4, 2, 1, 2, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (13, 10, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (14, 10, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (15, 10, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (16, 10, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (17, 10, 3, 3, 0, 0, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (18, 10, 4, 2, 1, 1, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (13, 11, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (14, 11, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (15, 11, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (16, 11, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (17, 11, 3, 3, 0, 0, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (18, 11, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (1, 11, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 1);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (2, 11, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (3, 11, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (4, 11, 3, 0, 2, 0, 1, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (5, 11, 3, 3, 0, 1, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (6, 11, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (7, 12, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 1);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (8, 12, 2, 0, 2, 1, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (9, 12, 2, 1, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (10, 12, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (11, 12, 3, 3, 0, 0, 1, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (12, 12, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (19, 12, 1, 0, 0, 0, 0, 3, 0, 12, 6, 1, 1, 0, 0, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (20, 12, 2, 0, 2, 0, 0, 0, 0, 25, 20, 2, 1, 7, 5, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (21, 12, 2, 0, 3, 0, 0, 0, 2, 32, 23, 8, 5, 7, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (22, 12, 3, 0, 2, 0, 0, 0, 1, 49, 39, 3, 1, 8, 4, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (23, 12, 3, 3, 0, 0, 0, 0, 5, 38, 27, 7, 4, 3, 2, 0);
insert into Performance (PlayerId, MatchId, PositionId, ShotsOnTarget, Fouls, Goals, Assists, Saves, Shots, Passes, PassesCompleted, Dribbles, DribblesSucceeded, Tackles, TacklesSucceeded, CleanSheet) values (24, 12, 4, 2, 1, 0, 0, 0, 8, 23, 13, 11, 9, 2, 0, 0);
insert into History (PlayerId, HistoryEntry) values (1, 'Joined Manchester City from SL Benfica on Jul, 1 2017 for $44m.');
insert into History (PlayerId, HistoryEntry) values (2, 'Joined Manchester City from SL Benfica on Sep, 29 2020 for $74.80m.');
insert into History (PlayerId, HistoryEntry) values (3, 'Joined Manchester City from Juventus on Aug, 7 2019 for $71.50m.');
insert into History (PlayerId, HistoryEntry) values (4, 'Joined Manchester City from Atletico Madrid on Jul, 4 2019 for $68.97m.');
insert into History (PlayerId, HistoryEntry) values (5, 'Joined Wolfsburg from Chelsea on Jan, 18 2014 for $24.20m.');
insert into History (PlayerId, HistoryEntry) values (5, 'Joined Manchester City from Wolfsburg on Aug, 30 2015 for $83.60m.');
insert into History (PlayerId, HistoryEntry) values (7, 'Joined Chelsea from Stade Rennais on Sep, 24 2020 for $26.40m');
insert into History (PlayerId, HistoryEntry) values (8, 'Returned to Chelsea from Loan to Wigan on May, 31 2019.');
insert into History (PlayerId, HistoryEntry) values (9, 'Joined Chelsea from  on Aug, 28 2020 for free.');
insert into History (PlayerId, HistoryEntry) values (10, 'Joined Chelsea from Leicester City on Aug, 26 2020 for $55.22m.');
insert into History (PlayerId, HistoryEntry) values (11, 'Returned to Chelsea from Loan to Derby County on May, 31 2019.');
insert into History (PlayerId, HistoryEntry) values (12, 'Joined Chelsea from Bayer Leverkusen on Sep, 4 2020 for $88m.');
insert into History (PlayerId, HistoryEntry) values (13, 'Returned to Southampton from Loan to Celtic on Jun, 30 2020.');
insert into History (PlayerId, HistoryEntry) values (14, 'Joined Southampton from Real Valladolid on Aug, 12 2020 for $13.20m.');
insert into History (PlayerId, HistoryEntry) values (15, 'Joined Southampton from Chelsea on Aug, 2 2021 for $6.49m.');
insert into History (PlayerId, HistoryEntry) values (16, 'Joined Southampton from Chelsea on Aug, 12 2015 for $7.70m.');
insert into History (PlayerId, HistoryEntry) values (18, 'Joined Southampton on loan from Chelsea on Aug, 10 2021.');
insert into History (PlayerId, HistoryEntry) values (19, 'Joined Crystal Palace from Getafe on Jul, 1 2018 for free.');
insert into History (PlayerId, HistoryEntry) values (20, 'Joined Crystal Palace from Chelsea on Jul, 18 2021 for $25.67m.');
insert into History (PlayerId, HistoryEntry) values (21, 'Joined Crystal Palace from Olympique Lyon on Jul, 28 2021 for $19.25m.');
insert into History (PlayerId, HistoryEntry) values (22, 'Joined Crystal Palace on loan from Chelsea on Jul, 30 2021.');
insert into History (PlayerId, HistoryEntry) values (23, 'Joined Crystal Palace from Manchester United on Feb, 2 2015 for $4.18m.');
insert into History (PlayerId, HistoryEntry) values (24, 'Joined Crystal Palace from Celtic on Aug, 31 2021 for $17.93m.');
END