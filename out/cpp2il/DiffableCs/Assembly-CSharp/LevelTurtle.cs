//Type is in global namespace

public class LevelTurtle : LevelAnimal
{
	internal enum TurtleType
	{
		Turtle_A = 0,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelTurtle() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

}

