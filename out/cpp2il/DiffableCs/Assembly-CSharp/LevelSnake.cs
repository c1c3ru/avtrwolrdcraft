//Type is in global namespace

public class LevelSnake : LevelAnimal
{
	internal enum SnakeType
	{
		Snake_A = 0,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelSnake() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

}

