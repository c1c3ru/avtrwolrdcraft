namespace Game.Level;

public class LevelDigHoleEventsArea : LevelDigArea
{
	[SerializeField]
	public UnityEvent OnShovelDigEvent; //Field offset: 0x58

	public LevelDigHoleEventsArea() { }

	public virtual void OnShovelDig() { }

}

