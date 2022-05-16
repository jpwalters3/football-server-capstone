USE master;
GO
Alter database TestFootballLeague Set Single_User with rollback immediate;
drop database TestFootballLeague;
go
CREATE DATABASE TestFootballLeague;
GO

USE TestFootballLeague;
GO

CREATE TABLE Club (
    ClubId int primary key identity(1,1),
    [Name] nvarchar(50) not null,
    FoundingDate DATETIME2 not null,
    City nvarchar(50) not null    
)
GO

CREATE TABLE Position(
    PositionId int primary key identity(1,1),
    PositionName varchar(50) not null
)
GO

CREATE TABLE Player(
    PlayerId int primary key identity(1,1),
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    DateOfBirth datetime2 not null,
    ClubId int not null,
    PositionId int not null,
    IsActive bit not null,
    IsOnLoan bit not null,
    constraint fk_Player_ClubId
        foreign key (ClubId)
        references Club(ClubId),
    constraint fk_Player_PositionId
        foreign key (PositionId)
        references Position(PositionId)
)
GO

CREATE TABLE Season (
    SeasonId int primary key identity(1,1),
    [Year] NVARCHAR(50) not null,
    IsActive bit not null
)
GO

CREATE TABLE Match (
    MatchId int primary key identity(1,1),
    HomeClubId int not null,
    VisitingClubId int not null,
    SeasonId int not null,
    NumberOfAttendees int null,
    HomeScore int null,    
    AwayScore int null,
    MatchDate DateTime2 not null,
    constraint fk_Match_HomeClubId
        foreign key (HomeClubId)
        references Club(ClubId),
    constraint fk_Match_VisitingClubId
        foreign key (VisitingClubId)
        references Club(ClubId),
    constraint fk_Match_SeasonId
        foreign key (SeasonId)
        references Season(SeasonId)
)
GO



CREATE TABLE Loan (
    LoanId int primary key identity(1,1),
    ParentClubId int not null,
    LoanClubId int not null,
    PlayerId int not null,
    LoanDuration int not null,
    LoanStart DATETIME2 not null,
    constraint fk_Loan_ParentClubId
        foreign key (ParentClubId)
        references Club(ClubId),
    constraint fk_Loan_LoanClubId
        foreign key (LoanClubId)
        references Club(ClubId),
    constraint fk_Loan_PlayerId
        foreign key (PlayerId)
        references Player(PlayerId)
)
GO

CREATE TABLE Performance (
    PlayerId int not null,
    MatchId int not null,
    PositionId int not null,
    ShotsOnTarget int not null DEFAULT(0),
    Fouls int not null DEFAULT(0),
    Goals int not null DEFAULT(0),
    Assists int not null DEFAULT(0),
    Saves int not null DEFAULT(0),
    Shots int not null DEFAULT(0),
    Passes int not null DEFAULT(0),
    PassesCompleted int not null DEFAULT(0),
    Dribbles int not null DEFAULT(0),
    DribblesSucceeded int not null DEFAULT(0),
    Tackles int not null DEFAULT(0),
    TacklesSucceeded int not null DEFAULT(0),
    CleanSheet bit not null DEFAULT(0),
    constraint fk_Performance_PlayerId
        foreign key (PlayerId)
        references Player(PlayerId),
    constraint fk_Performance_MatchId
        foreign key (MatchId)
        references Match(MatchId),
    constraint fk_Performance_PositionId
        foreign key (PositionId)
        references Position(PositionId),
    CONSTRAINT PK_Performance PRIMARY KEY (MatchId, PlayerId)
)
GO

CREATE TABLE History (
    HistoryId int PRIMARY KEY IDENTITY(1,1),
    PlayerId int not null,
    HistoryEntry text not null,
    constraint fk_History_PlayerId
        foreign key (PlayerId)
        references Player(PlayerId)
)
GO