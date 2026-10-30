namespace Game.Level;

public class LevelAutomaticSlidingDoorToOtherLevel : LevelLevelSwitcher
{
	[SerializeField]
	private GameObject _leftDoor; //Field offset: 0x48
	[SerializeField]
	private GameObject _rightDoor; //Field offset: 0x50
	[SerializeField]
	private float _leftDoorClosedXValue; //Field offset: 0x58
	[SerializeField]
	private float _leftDoorOpenXValue; //Field offset: 0x5C
	[SerializeField]
	private float _rightDoorClosedXValue; //Field offset: 0x60
	[SerializeField]
	private float _rightDoorOpenXValue; //Field offset: 0x64
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x68
	private bool _didBecomeVisible; //Field offset: 0x70
	private int _rightDoorTweenId; //Field offset: 0x74
	private int _leftDoorTweenId; //Field offset: 0x78
	private int _soundTweenId; //Field offset: 0x7C

	public LevelAutomaticSlidingDoorToOtherLevel() { }

	[CompilerGenerated]
	private void <OnBecameInvisible>b__12_0() { }

	[CompilerGenerated]
	private void <OnBecameVisible>b__11_0() { }

	private void OnBecameInvisible() { }

	private void OnBecameVisible() { }

}

