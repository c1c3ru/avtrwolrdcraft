namespace Game.Level;

public class LevelTweenSeesaw : MonoBehaviour
{
	[SerializeField]
	private List<LevelSitArea> _leftSitAreas; //Field offset: 0x20
	[SerializeField]
	private List<LevelSitArea> _rightSitAreas; //Field offset: 0x28
	[SerializeField]
	private GameObject _rotateableObject; //Field offset: 0x30
	[SerializeField]
	private float _smallChangeMaxLocation; //Field offset: 0x38
	[SerializeField]
	private float _bigChangeMaxLocation; //Field offset: 0x3C
	[SerializeField]
	private float _timeForBigChange; //Field offset: 0x40
	[SerializeField]
	private float _timeForSmallChange; //Field offset: 0x44
	[SerializeField]
	private string _soundName; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _gameSoundPlayer; //Field offset: 0x50
	private int _amountOfPeopleOnLeft; //Field offset: 0x58
	private int _amountOfPeopleOnRight; //Field offset: 0x5C
	private int _currentActiveTween; //Field offset: 0x60

	public LevelTweenSeesaw() { }

	[CompilerGenerated]
	private void <SmallLeftRight>b__23_0() { }

	[CompilerGenerated]
	private void <SmallLeftRight>b__23_1() { }

	private void Awake() { }

	private float GetTimeFromDistance(float distance) { }

	private void GoBackToStationary() { }

	private void MoveHardLeft() { }

	private void MoveHardToRight(bool isReverse = false) { }

	private void OnAvatarBeginDropOnLeft(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	private void OnAvatarBeginDropOnRight(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	private void OnAvatarPickUpLeft(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	private void OnAvatarPickUpRight(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	private void OnCounterChange() { }

	private void OnDestroy() { }

	private void SmallLeftRight() { }

}

