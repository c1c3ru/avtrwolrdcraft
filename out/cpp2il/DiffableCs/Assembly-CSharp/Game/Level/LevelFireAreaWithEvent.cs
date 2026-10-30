namespace Game.Level;

public class LevelFireAreaWithEvent : LevelFireArea
{
	public UnityEvent onExtinguish; //Field offset: 0x58

	public LevelFireAreaWithEvent() { }

	public virtual void Extinguish() { }

}

