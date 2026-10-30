//Type is in global namespace

public class LevelRabbit : LevelAnimal
{
	internal enum RabbitType
	{
		Rabbit_A = 0,
		Rabbit_B = 1,
	}

	private String[] _idleAnimations; //Field offset: 0x400

	public LevelRabbit() { }

	protected virtual bool CanSit() { }

	protected virtual String[] GetIdleAnimations() { }

}

