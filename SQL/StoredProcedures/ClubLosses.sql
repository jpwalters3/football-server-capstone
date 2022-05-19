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
        INNER JOIN Season s ON m.SeasonId = s.SeasonId
        WHERE m.HomeClubId = @ClubId AND m.HomeScore < m.AwayScore and s.IsActive = 1
    )+
    (
        SELECT
        COUNT(m.MatchId) AS 'visitingLosses'
        FROM [Match] m
        INNER JOIN Club vc ON m.VisitingClubId = vc.ClubId
        INNER JOIN Season s ON m.SeasonId = s.SeasonId
        WHERE m.VisitingClubId = @ClubId AND m.AwayScore < m.HomeScore and s.IsActive = 1
    )
) AS 'Losses'


END
GO