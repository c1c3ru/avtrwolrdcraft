namespace PWC.Level;

public class LevelCrossLevelSlide : MonoBehaviour
{
	private const float SLIDE_TIME = 1; //Field offset: 0x0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private LevelCrossLevelDropArea _crossDropArea; //Field offset: 0x28
	[SerializeField]
	private EdgeCollider2D _slidePath; //Field offset: 0x30
	[SerializeField]
	private string _slideSoundName; //Field offset: 0x38
	[SerializeField]
	private bool _isMasked; //Field offset: 0x40
	[SerializeField]
	private SlideType _slideType; //Field offset: 0x44
	private Vector2[] _pathPoints; //Field offset: 0x48
	private LTSpline _spline; //Field offset: 0x50
	private ILevelAvatar _levelAvatar; //Field offset: 0x58

	public LevelCrossLevelSlide() { }

	private void Awake() { }

	private Vector3[] ConvertArray(Vector2[] v2) { }

	private void FinishSlide() { }

	private void MoveToScene() { }

	private void OnDestroy() { }

	protected override void OnItemEndDropAction(LevelItem item) { }

	protected void OnLevelPostInit() { }

	private bool OverrideCharacterEndDropAnimationAction(ILevelAvatar avatar) { }

	private void PlayMovingSound() { }

	private void Slide(Action onCompleteAction = null) { }

}

