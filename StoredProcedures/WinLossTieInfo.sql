CREATE PROCEDURE [WinLossTieInfo](@clubName as nvarchar(50))
AS
BEGIN
SELECT Wins, Losses, Ties from
(SELECT Count(*) as Wins from
(SELECT HomeClubName, HomeScore, VisitingClubName, AwayScore, HST.SeasonId, HST.MatchId
from (SELECT m.MatchId, c.[Name] HomeClubName, m.HomeScore, m.SeasonId from [Match] m
join Club c on m.HomeClubId = c.ClubId) HST
join (SELECT m.MatchId, c.[Name] VisitingClubName, m.AwayScore, m.SeasonId from [Match] m
join Club c on m.VisitingClubId = c.ClubId) VST on HST.MatchId = VST.MatchId
where (HomeClubName = @clubName and HomeScore > AwayScore) 
or (VisitingClubName = @clubName and AwayScore > HomeScore)) WT) WT, (Select Count(*) Losses from
(SELECT HomeClubName, HomeScore, VisitingClubName, AwayScore, HST.SeasonId, HST.MatchId
from (SELECT m.MatchId, c.[Name] HomeClubName, m.HomeScore, m.SeasonId from [Match] m
join Club c on m.HomeClubId = c.ClubId) HST
join (SELECT m.MatchId, c.[Name] VisitingClubName, m.AwayScore, m.SeasonId from [Match] m
join Club c on m.VisitingClubId = c.ClubId) VST on HST.MatchId = VST.MatchId
where (HomeClubName = @clubName and HomeScore < AwayScore) 
or (VisitingClubName = @clubName and AwayScore < HomeScore)) LT) LT, (Select count(*) Ties from
(SELECT HomeClubName, HomeScore, VisitingClubName, AwayScore, HST.SeasonId, HST.MatchId
from (SELECT m.MatchId, c.[Name] HomeClubName, m.HomeScore, m.SeasonId from [Match] m
join Club c on m.HomeClubId = c.ClubId) HST
join (SELECT m.MatchId, c.[Name] VisitingClubName, m.AwayScore, m.SeasonId from [Match] m
join Club c on m.VisitingClubId = c.ClubId) VST on HST.MatchId = VST.MatchId
where (HomeClubName = @clubName and HomeScore = AwayScore) 
or (VisitingClubName = @clubName and AwayScore = HomeScore)) as TT) TT
END