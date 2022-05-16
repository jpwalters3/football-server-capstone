Create PROCEDURE [PlayerStatsBySeason](@seasonId as int, @playerId as int)
AS
BEGIN
SELECT m.SeasonId, pl.FirstName + ' ' + pl.LastName [Name],
sum(ShotsOnTarget) TotalShotsOnTarget, sum(Fouls) TotalFouls,
sum(Goals) TotalGoals, sum(Assists) TotalAssists, sum(Shots) TotalShots,
sum(Saves) TotalSaves, sum(Passes) TotalPasses, sum(PassesCompleted) TotalPassesCompleted,
sum(Dribbles) TotalDribbles, sum(DribblesSucceeded) TotalDribblesSucceeded,
sum(Tackles) TotalTackles, sum(TacklesSucceeded) TotalTackledSucceeded,
sum(cast(CleanSheet as int)) TotalCleanSheet from Performance p
JOIN Player pl on p.PlayerId = pl.PlayerId
JOIN [Match] m on p.MatchId = m.MatchId
GROUP by m.SeasonId, pl.FirstName, pl.LastName, pl.PlayerId
having SeasonId = @seasonId
AND pl.PlayerId = @playerId
END