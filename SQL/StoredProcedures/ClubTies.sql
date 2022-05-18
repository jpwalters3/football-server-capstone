CREATE PROCEDURE [dbo].[ClubTies]
(
    @ClubId AS INT
)
AS
BEGIN

SELECT
(
    (
        SELECT
        COUNT(m.MatchId) AS 'homeTies'
        FROM [Match] m
        INNER JOIN Club hc ON m.HomeClubId = hc.ClubId
        INNER JOIN Season s ON m.SeasonId = s.SeasonId
        WHERE m.HomeClubId = @ClubId AND m.HomeScore = m.AwayScore and s.IsActive = 1
        GROUP BY m.HomeClubId
    )+
    (
        SELECT
        COUNT(m.MatchId) AS 'visitingTies'
        FROM [Match] m
        INNER JOIN Club vc ON m.VisitingClubId = vc.ClubId
        INNER JOIN Season s ON m.SeasonId = s.SeasonId
        WHERE m.VisitingClubId = @ClubId AND m.AwayScore = m.HomeScore and s.IsActive = 1
        GROUP BY m.VisitingClubId
    )
) AS 'Ties'


END
GO