namespace PazuCore.AF.MyGames;

public class GameOnDevice : MonoBehaviour
{
	[SerializeField]
	private MyGamesBanner _gameBanner; //Field offset: 0x20
	[CompilerGenerated]
	private int <GameId>k__BackingField; //Field offset: 0x28

	public private int GameId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public GameOnDevice() { }

	[CompilerGenerated]
	private void <SetGameID>b__5_0() { }

	[CompilerGenerated]
	public int get_GameId() { }

	[CompilerGenerated]
	private void set_GameId(int value) { }

	public void SetGameID(int id) { }

}

