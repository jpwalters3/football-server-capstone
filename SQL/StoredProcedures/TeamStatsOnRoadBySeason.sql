CREATE PROCEDURE [TeamStatsOnRoadBySeason](@seasonId as int, @visitingClubId as int)
AS
BEGIN
SELECT m.VisitingClubId, m.SeasonId, c.Name,
sum(ShotsOnTarget) TotalShotsOnTarget, sum(Fouls) TotalFouls,
sum(Goals) TotalGoals, sum(Assists) TotalAssists, sum(Shots) TotalShots,
sum(Saves) TotalSaves, sum(Passes) TotalPasses, sum(PassesCompleted) TotalPassesCompleted,
sum(Dribbles) TotalDribbles, sum(DribblesSucceeded) TotalDribblesSucceeded,
sum(Tackles) TotalTackles, sum(TacklesSucceeded) TotalTackledSucceeded,
sum(cast(CleanSheet as int)) TotalCleanSheet from Club c
JOIN Player pl on c.ClubId = pl.ClubId
JOIN [Match] m on c.ClubId = m.VisitingClubId
JOIN Performance p on pl.PlayerId = p.PlayerId
GROUP by m.SeasonId, m.VisitingClubId, c.Name
having SeasonId = @seasonId and m.VisitingClubId = @visitingClubId
END