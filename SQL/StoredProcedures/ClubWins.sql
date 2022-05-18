CREATE PROCEDURE [dbo].[ClubWins]
(
    @ClubId AS INT
)
AS
BEGIN

SELECT
(
    (
        SELECT
        COUNT(m.MatchId) AS 'homwWins'
        FROM [Match] m
        INNER JOIN Club hc ON m.HomeClubId = hc.ClubId
        WHERE m.HomeClubId = @ClubId AND m.HomeScore > m.AwayScore
        GROUP BY m.HomeClubId
    )+
    (
        SELECT
        COUNT(m.MatchId) AS 'visitingWins'
        FROM [Match] m
        INNER JOIN Club vc ON m.VisitingClubId = vc.ClubId
        WHERE m.VisitingClubId = @ClubId AND m.AwayScore > m.HomeScore
        GROUP BY m.VisitingClubId
    ) 
) AS 'Wins'


END
GO