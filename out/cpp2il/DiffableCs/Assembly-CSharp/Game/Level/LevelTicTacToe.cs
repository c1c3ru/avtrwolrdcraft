namespace Game.Level;

[RequireComponent(typeof(SkeletonAnimation))]
public class LevelTicTacToe : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public MPDataGeneratorHandle mpDataGenerator; //Field offset: 0x10
		public LevelTicTacToe <>4__this; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <OnPointerClick>b__2(TrackEntry track) { }

		internal void <OnPointerClick>b__3(TrackEntry track) { }

		internal void <OnPointerClick>b__4(TrackEntry track) { }

		internal void <OnPointerClick>g__OnPostStateChagedCall|1() { }

		internal void <OnPointerClick>g__OnPreStateChagedCall|0() { }

	}

	internal enum State
	{
		None = 0,
		O = 1,
		X = 2,
	}

	[SerializeField]
	private TicTacToeLine[] _possibleWinLines; //Field offset: 0x20
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[CompilerGenerated]
	private State <CurrentState>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private Action<TicTacToeLine[], State> StateChanged; //Field offset: 0x38

	public event Action<TicTacToeLine[], State> StateChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public private State CurrentState
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public LevelTicTacToe() { }

	[CompilerGenerated]
	public void add_StateChanged(Action<TicTacToeLine[], State> value) { }

	private void Awake() { }

	[CompilerGenerated]
	public State get_CurrentState() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public void remove_StateChanged(Action<TicTacToeLine[], State> value) { }

	[CompilerGenerated]
	private void set_CurrentState(State value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

