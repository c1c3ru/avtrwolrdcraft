namespace PWC.Level;

public class LevelToggleableGameObject : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, ILevelMakerDisabledWhileInEditMode, ICanListenForSecrets, ICanSolveSecrets
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public int index; //Field offset: 0x10

		public <>c__DisplayClass36_0() { }

		internal bool <PlaySound>b__0(SoundsAndIndexes x) { }

	}

	internal class SoundsAndIndexes
	{
		public int index; //Field offset: 0x10
		public string soundName; //Field offset: 0x18

		public SoundsAndIndexes() { }

	}

	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[FormerlySerializedAs("_soundName")]
	[SerializeField]
	protected string _onClickSoundName; //Field offset: 0x28
	[SerializeField]
	private bool _isRandom; //Field offset: 0x30
	[SerializeField]
	private bool _isReverse; //Field offset: 0x31
	[SerializeField]
	protected GameObject[] _gameObjects; //Field offset: 0x38
	[SerializeField]
	private int _secretSolvingIndex; //Field offset: 0x40
	[SerializeField]
	private bool _disallowToggleOnClick; //Field offset: 0x44
	[SerializeField]
	private List<SoundsAndIndexes> _soundsAndIndexes; //Field offset: 0x48
	protected int _currentIndex; //Field offset: 0x50
	[CompilerGenerated]
	private Action <OnSolvedSecretAction>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private Action <OnUnsolvedSecretAction>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private Action<Int32> OnClickAction; //Field offset: 0x68
	[CompilerGenerated]
	private Action<Int32> OnLoadPersistentDataAction; //Field offset: 0x70

	public event Action<Int32> OnClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Int32> OnLoadPersistentDataAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public int CurrentIndex
	{
		 get { } //Length: 8
	}

	public override Action OnSolvedSecretAction
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override Action OnUnsolvedSecretAction
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelToggleableGameObject() { }

	[CompilerGenerated]
	public void add_OnClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnLoadPersistentDataAction(Action<Int32> value) { }

	public void ForceClick() { }

	public void ForceDecreaseIndexClick() { }

	public void ForceIncreaseIndexClick() { }

	public int get_CurrentIndex() { }

	[CompilerGenerated]
	public override Action get_OnSolvedSecretAction() { }

	[CompilerGenerated]
	public override Action get_OnUnsolvedSecretAction() { }

	public int GetCurrentIndex() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnSecretSolvedHandler() { }

	public override void OnSecretUnsolvedHandler() { }

	private void PerformClick() { }

	private void PlayDefaultSound() { }

	protected override void PlaySound(int index) { }

	private void PlaySoundInternal(string soundName) { }

	[CompilerGenerated]
	public void remove_OnClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnLoadPersistentDataAction(Action<Int32> value) { }

	[CompilerGenerated]
	public override void set_OnSolvedSecretAction(Action value) { }

	[CompilerGenerated]
	public override void set_OnUnsolvedSecretAction(Action value) { }

	public override void SetGameObjectActive(int index) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSpecificIndex(int index) { }

}

