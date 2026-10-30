namespace Game.Level;

public class LevelPetEggItemHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public LevelPetEggItemHandler <>4__this; //Field offset: 0x10
		public Action onComplete; //Field offset: 0x18

		public <>c__DisplayClass17_0() { }

		internal void <AnimateEggMask>b__0() { }

	}

	internal enum EggStateType
	{
		None = 0,
		Whole = 1,
		Crack1 = 2,
		Crack2 = 3,
		Open = 4,
	}

	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private string _spritePathPrefix; //Field offset: 0x28
	[SerializeField]
	private LevelTransformableWithClicksEnablerHandler _transformableItemHandler; //Field offset: 0x30
	[SerializeField]
	private GameObject _whiteEgg; //Field offset: 0x38
	[SerializeField]
	private GameObject _eggMask; //Field offset: 0x40
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x48
	private EggStateType _stateType; //Field offset: 0x50
	private float _maskStartY; //Field offset: 0x54
	private int _tweenID; //Field offset: 0x58
	[CompilerGenerated]
	private bool <CanHatch>k__BackingField; //Field offset: 0x5C

	public private bool CanHatch
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelPetEggItemHandler() { }

	public void AnimateEggMask(float time, Action onComplete) { }

	private void Awake() { }

	public void ForceHatch(float newTime, Action onComplete) { }

	[CompilerGenerated]
	public bool get_CanHatch() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void PlaySound() { }

	[CompilerGenerated]
	private void set_CanHatch(bool value) { }

	private void SetCompleted(Action onComplete) { }

	public void SetMaskY(float yPresent, bool fromDrop) { }

	private void SetNewSpriteFromResources() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UpdatedStateTypeIfNeeded() { }

}

