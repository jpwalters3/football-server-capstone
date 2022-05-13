CREATE PROCEDURE [TopScorerForSeason](@seasonId as int)
AS
BEGIN
SELECT top(1) m.SeasonId, pl.FirstName + ' ' + pl.LastName [Name], sum(Goals) TotalGoals from Performance p
JOIN Player pl on p.PlayerId = pl.PlayerId
JOIN [Match] m on p.MatchId = m.MatchId
GROUP by m.SeasonId, pl.LastName, pl.FirstName
having SeasonId = @seasonId
order by SeasonId desc, sum(Goals) DESC
END