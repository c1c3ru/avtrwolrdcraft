namespace Game.Level;

public class LevelCampfireFryArea : LevelFryArea
{
	[SerializeField]
	private LevelCampfireFireSpine _campfireFire; //Field offset: 0xF8

	public virtual bool IsOn
	{
		 get { } //Length: 36
	}

	public LevelCampfireFryArea() { }

	public virtual bool get_IsOn() { }

	protected virtual void SyncSound() { }

}

