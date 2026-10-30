namespace PazuCore.Analytics.Internal.ChangeTracking;

public class GameInfo
{
	public int buildNumber; //Field offset: 0x10
	public int pazucoreVersion; //Field offset: 0x14

	public GameInfo() { }

	public static GameInfo CreateSynced() { }

	public bool IsSynced() { }

}

