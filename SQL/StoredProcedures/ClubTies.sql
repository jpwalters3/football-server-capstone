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
        WHERE m.HomeClubId = 1 AND m.HomeScore = m.AwayScore
        GROUP BY m.HomeClubId
    )+
    (
        SELECT
        COUNT(m.MatchId) AS 'visitingTies'
        FROM [Match] m
        INNER JOIN Club vc ON m.VisitingClubId = vc.ClubId
        WHERE m.VisitingClubId = 1 AND m.AwayScore = m.HomeScore
        GROUP BY m.VisitingClubId
    )
) AS 'Ties'
FROM [Club] c
        WHERE c.ClubId = 1

END
GO