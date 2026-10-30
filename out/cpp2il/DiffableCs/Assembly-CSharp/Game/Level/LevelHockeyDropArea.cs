namespace Game.Level;

public class LevelHockeyDropArea : LevelDropArea
{
	public int _numberOfPucks; //Field offset: 0xD8

	public int NumberOfPucks
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelHockeyDropArea() { }

	protected virtual void Awake() { }

	public int get_NumberOfPucks() { }

	private void LevelHockeyDropAreaPostInit() { }

	protected virtual void OnDestroy() { }

	private void OnPuckDrop(LevelItem levelItem) { }

	private void OnPuckPickUp(LevelItem levelItem) { }

	public void set_NumberOfPucks(int value) { }

}

