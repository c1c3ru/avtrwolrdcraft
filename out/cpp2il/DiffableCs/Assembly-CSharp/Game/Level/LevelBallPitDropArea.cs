namespace Game.Level;

public class LevelBallPitDropArea : LevelDropArea
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xD8
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xE0
	[SerializeField]
	private string _soundName; //Field offset: 0xE8
	[SerializeField]
	private bool _showParticlesForAvatarOnly; //Field offset: 0xF0

	public LevelBallPitDropArea() { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	public void TryPlayBallSplashAnimation(LevelItem levelItem) { }

}

