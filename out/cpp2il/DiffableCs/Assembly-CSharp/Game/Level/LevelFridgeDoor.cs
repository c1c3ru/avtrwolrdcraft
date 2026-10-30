namespace Game.Level;

public class LevelFridgeDoor : LevelSpineDoor
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xD0

	public LevelFridgeDoor() { }

	protected virtual void OnBeginAnimation() { }

}

