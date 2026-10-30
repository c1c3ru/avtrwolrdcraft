namespace PWC.Level;

public class LevelSplashingPuddle : LevelAreaBase
{
	[SerializeField]
	private Renderer _renderer; //Field offset: 0x38
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x40
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0x48
	[SerializeField]
	private string _soundName; //Field offset: 0x50
	private int _tweenId; //Field offset: 0x58

	public LevelSplashingPuddle() { }

	[CompilerGenerated]
	private void <OnItemEndLand>b__7_0() { }

	protected virtual void Awake() { }

	protected virtual void OnDestroy() { }

	private void OnItemEndLand(LevelItem levelItem, LevelDropArea dropArea) { }

}

