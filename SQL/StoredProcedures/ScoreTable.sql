CREATE PROCEDURE [ScoreTable]
AS
BEGIN
SELECT HomeClubName, HomeScore, VisitingClubName, AwayScore, HST.SeasonId
from (SELECT m.MatchId, c.[Name] HomeClubName, m.HomeScore, m.SeasonId from [Match] m
join Club c on m.HomeClubId = c.ClubId) HST
join (SELECT m.MatchId, c.[Name] VisitingClubName, m.AwayScore, m.SeasonId from [Match] m
join Club c on m.VisitingClubId = c.ClubId) VST on HST.MatchId = VST.MatchId
order by HST.SeasonId;

END