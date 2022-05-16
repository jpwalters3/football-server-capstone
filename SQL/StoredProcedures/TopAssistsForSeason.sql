Create PROCEDURE [TopAssistsForSeason](@seasonId as int)
AS
BEGIN
SELECT top(10) with ties m.SeasonId, c.Name ClubName, pl.FirstName + ' ' + pl.LastName PlayerName, sum(Assists) TotalAssists from Performance p
JOIN Player pl on p.PlayerId = pl.PlayerId
JOIN [Match] m on p.MatchId = m.MatchId
JOIN Club c on pl.ClubId = c.ClubId
GROUP by m.SeasonId, c.Name, pl.LastName, pl.FirstName
having SeasonId = @seasonId
order by SeasonId desc, sum(Assists) DESC
END