namespace PWC.Level;

public class LevelSimpleToggleableSpine : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IHasPersistentData, IRequirePDSceneObject
{
	internal sealed class SpineAnimationEvent : MulticastDelegate
	{

		public SpineAnimationEvent(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(TrackEntry trackEntry, Event spineEvent, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(TrackEntry trackEntry, Event spineEvent) { }

	}

	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	protected String[] _soundNames; //Field offset: 0x28
	[SerializeField]
	protected float _volume; //Field offset: 0x30
	[SerializeField]
	private bool _isRandom; //Field offset: 0x34
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x38
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _idleAnimationsNames; //Field offset: 0x40
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _transitionAnimationsNames; //Field offset: 0x48
	[SerializeField]
	private GameObject[] _gameObjects; //Field offset: 0x50
	[SerializeField]
	private UnityEvent _onAnimationBeginAction; //Field offset: 0x58
	[SerializeField]
	private UnityEvent _onAnimationEndAction; //Field offset: 0x60
	[SerializeField]
	private bool _dontAllowClick; //Field offset: 0x68
	[SerializeField]
	private bool _dontPlayEndEventOnIdle; //Field offset: 0x69
	[SerializeField]
	private bool _returnToIdle; //Field offset: 0x6A
	public SpineAnimationEvent _onAnimationEventAction; //Field offset: 0x70
	protected int _currentIndex; //Field offset: 0x78

	public LevelSimpleToggleableSpine() { }

	private void Awake() { }

	public void ForceClick() { }

	public void ForceIdle() { }

	public void ForceSpecificIdle(int index) { }

	public void ForceSpecificTransition(int index) { }

	public void ForceSpecificTransition(int index, bool isLoop = false) { }

	public void ForceSpecificTransitionAndLoop(int index) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnAnimationEnd(TrackEntry trackEntry) { }

	private void OnClick() { }

	private void OnEvent(TrackEntry trackEntry, Event spineEvent) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	protected override void PlaySound() { }

	private void SetAnimation(int animationIndex, bool snap, bool isLoop = false) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

