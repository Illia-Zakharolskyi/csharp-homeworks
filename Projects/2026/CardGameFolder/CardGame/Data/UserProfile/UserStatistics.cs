// .net 9.0
using System;

namespace CardGame.Data.UserProfile;

public class UserStatistics
{
    public int GamesPlayed { get; set; } = 0;
    public int UserMovesMade { get; set; } = 0;
    public int OpponentMovesMade { get; set; } = 0;
    public int GamesWon { get; set; } = 0;
    public int GamesLost { get; set; } = 0;
    public int TotalPlayerDamageDealt { get; set; } = 0;
    public int TotalOpponentDamageDealt { get; set; } = 0;
}
