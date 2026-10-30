namespace Game.Level;

[AddComponentMenu(null)]
public class LevelGachaponMachineCoinSlot : LevelKillArea
{
	[SerializeField]
	private LevelGachaponMachine _gachaponMachine; //Field offset: 0x148

	public LevelGachaponMachineCoinSlot() { }

	protected virtual Vector2 GetTweenDestinationOffset() { }

	protected virtual void OnPostKillItem(LevelItem levelItem) { }

}

