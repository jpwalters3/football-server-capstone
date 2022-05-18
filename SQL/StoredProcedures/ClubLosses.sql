CREATE PROCEDURE [dbo].[ClubLosses]
(
    @ClubId AS INT
)
AS
BEGIN

SELECT
(
    (
        SELECT
        COUNT(m.MatchId) AS 'homeLosses'
        FROM [Match] m
        INNER JOIN Club hc ON m.HomeClubId = hc.ClubId
        WHERE m.HomeClubId = @ClubId AND m.HomeScore < m.AwayScore
        GROUP BY m.HomeClubId
    )+
    (
        SELECT
        COUNT(m.MatchId) AS 'visitingLosses'
        FROM [Match] m
        INNER JOIN Club vc ON m.VisitingClubId = vc.ClubId
        WHERE m.VisitingClubId = @ClubId AND m.AwayScore < m.HomeScore
        GROUP BY m.VisitingClubId
    )
) AS 'Losses'


END
GO