namespace PazuCore.EndSession.Serializable;

public class CrossPromotionData : CardsDataSimpleBase
{
	internal class Game
	{
		internal class Assets
		{
			public string snapshotCardRegularPhoto; //Field offset: 0x10
			public string snapshotCardCoverPhoto; //Field offset: 0x18

			public Assets() { }

		}

		public int localId; //Field offset: 0x10
		public int gameId; //Field offset: 0x14
		public Assets assets; //Field offset: 0x18

		public Game() { }

	}

	private class State
	{
		public Int32[] lastGamesIndexes; //Field offset: 0x10
		public long lastGameSetTime; //Field offset: 0x18

		public State() { }

	}

	public Game[] games; //Field offset: 0x28
	public long rotationInterval; //Field offset: 0x30
	public int numOfCards; //Field offset: 0x38
	private string _playerPrefsKey; //Field offset: 0x40
	private Game[] _gamesToShow; //Field offset: 0x48

	public CrossPromotionData() { }

	public Game[] GetGamesToShow() { }

	private string GetPlayerPrefsKey() { }

}

