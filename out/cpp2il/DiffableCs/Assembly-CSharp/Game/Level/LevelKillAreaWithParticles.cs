namespace Game.Level;

public class LevelKillAreaWithParticles : LevelKillArea
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x148

	public LevelKillAreaWithParticles() { }

	protected virtual void OnPointerClickBeforeRestoringItem() { }

	protected virtual void OnPostKillItem(LevelItem levelItem) { }

}

