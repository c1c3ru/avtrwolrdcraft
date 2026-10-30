namespace Game.Level;

public class LevelCampfireFireArea : LevelFireArea
{
	[SerializeField]
	private LevelCampfireFireSpine _campfireFireSpine; //Field offset: 0x58

	public LevelCampfireFireArea() { }

	public virtual void Extinguish() { }

}

