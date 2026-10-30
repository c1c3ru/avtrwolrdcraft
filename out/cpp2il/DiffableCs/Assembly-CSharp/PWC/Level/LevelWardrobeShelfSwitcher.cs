namespace PWC.Level;

public class LevelWardrobeShelfSwitcher : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public LevelWardrobeShelfSwitcher <>4__this; //Field offset: 0x10
		public int stateIndex; //Field offset: 0x18

		public <>c__DisplayClass31_0() { }

		internal void <GoToState>b__0() { }

	}

	private class StateEvent
	{
		public int stateIndex; //Field offset: 0x10
		public UnityEvent stateEvent; //Field offset: 0x18

		public StateEvent() { }

	}

	internal class WardrobeState
	{
		public Vector2 shelfLocalPosition; //Field offset: 0x10
		public Vector2 optionsLocalPosition; //Field offset: 0x18
		public Transform optionParent; //Field offset: 0x20

		public WardrobeState() { }

	}

	private class WardrobeStatePD
	{
		public int stateIndex; //Field offset: 0x10

		public WardrobeStatePD() { }

	}

	[SerializeField]
	private Transform _shelfParent; //Field offset: 0x20
	[SerializeField]
	private CShape _blockerShape; //Field offset: 0x28
	[SerializeField]
	private WardrobeState[] _states; //Field offset: 0x30
	[SerializeField]
	private float _tweenDuration; //Field offset: 0x38
	[SerializeField]
	private LeanTweenType _tweenEase; //Field offset: 0x3C
	[SerializeField]
	private List<StateEvent> _onStateStartEvents; //Field offset: 0x40
	[SerializeField]
	private List<StateEvent> _onStateEndEvents; //Field offset: 0x48
	[SerializeField]
	private List<StateEvent> _onForceStateEvents; //Field offset: 0x50
	private int _currentStateIndex; //Field offset: 0x58
	private bool _isTransitioning; //Field offset: 0x5C
	private readonly List<LevelDropArea> _blockedDropAreas; //Field offset: 0x60
	private readonly List<LevelItem> _blockedItems; //Field offset: 0x68
	[CompilerGenerated]
	private Action<Int32> OnTransitionStartAction; //Field offset: 0x70
	[CompilerGenerated]
	private Action<Int32> OnTransitionEndAction; //Field offset: 0x78

	public event Action<Int32> OnTransitionEndAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Int32> OnTransitionStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelWardrobeShelfSwitcher() { }

	[CompilerGenerated]
	public void add_OnTransitionEndAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnTransitionStartAction(Action<Int32> value) { }

	private void Awake() { }

	private void BlockAreas() { }

	private bool BlockBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void BlockConsume(LevelItem levelItem, ref bool canConsume) { }

	private List<LevelDropArea> CollectDropAreas() { }

	private void EndTransition(int stateIndex) { }

	public void ForceState(int stateIndex) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void GoToState(int stateIndex) { }

	public void NextState() { }

	private void OnDestroy() { }

	public void PreviousState() { }

	private void RefreshDropAreaShapes() { }

	[CompilerGenerated]
	public void remove_OnTransitionEndAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnTransitionStartAction(Action<Int32> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void ShowAllOptionParents() { }

	private void ShowOnlyStateOptionParent(int stateIndex) { }

	private void TransitionEndEvent(int index) { }

	private void TransitionEventByIndex(int index, List<StateEvent> stateEventsList) { }

	private void TransitionStartEvent(int index) { }

	private void UnblockAreas() { }

}

