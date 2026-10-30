namespace Game.Level.BakingMachine;

public class LevelBakingMachine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public LevelBakingMachine <>4__this; //Field offset: 0x10
		public Item item; //Field offset: 0x18

		public <>c__DisplayClass30_0() { }

		internal void <ProcessCreateOutcome>g__OnComplete|0(TrackEntry track) { }

	}

	internal enum ProgressType
	{
		None = 0,
		Idle = 1,
		ChooseTop = 2,
		ChooseBase = 3,
		Completed = 4,
		Creating = 5,
	}

	private const string BUTTON_SELECTED_SUFFIX = "_Selected"; //Field offset: 0x0
	protected const string BUTTON_OFF_SUFFIX = "_Off"; //Field offset: 0x0
	private const string BUTTON_ON_SUFFIX = "_On"; //Field offset: 0x0
	[SerializeField]
	private LevelBakingMachineData _data; //Field offset: 0x20
	[SerializeField]
	private LevelBakingMachineFoodEntryArea _foodEntryArea; //Field offset: 0x28
	[SerializeField]
	protected LevelDropArea _outcomeDropArea; //Field offset: 0x30
	[SerializeField]
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0x38
	[SerializeField]
	private string _outcomeSoundName; //Field offset: 0x40
	[SerializeField]
	private string _dropSoundName; //Field offset: 0x48
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x50
	[SerializeField]
	protected LevelBakingMachineBaseTypeButton[] _baseTypeButtons; //Field offset: 0x58
	[SerializeField]
	protected LevelBakingMachineTopTypeButton[] _topTypeButtons; //Field offset: 0x60
	private TopType _topType; //Field offset: 0x68
	private BaseType _baseType; //Field offset: 0x6C
	private ProgressType _progressType; //Field offset: 0x70
	protected Color _color; //Field offset: 0x74
	protected readonly Dictionary<ValueTuple`2<BaseType, TopType>, Item> _hashedData; //Field offset: 0x88
	private Skin _skin; //Field offset: 0x90

	public LevelBakingMachine() { }

	protected void AddSkin(string skinName) { }

	private void Awake() { }

	public void ChooseBaseType(BaseType baseType) { }

	public void ChooseTopType(TopType topType) { }

	protected void DisableButtons() { }

	protected override void FinishInstantiate(Item item) { }

	private void OnDestroy() { }

	protected override void OnLevelPostInit() { }

	protected override void ProcessChooseBase() { }

	private void ProcessChooseTop() { }

	protected override void ProcessCompleted() { }

	protected override void ProcessCreateOutcome() { }

	protected override void ProcessIdle() { }

	public override void ProcessItem(LevelItem levelItem) { }

	public void ProcessProgress() { }

	protected void RefreshSkeletonAnimation() { }

	protected override void ReturnToProperIdleAnimation() { }

}

