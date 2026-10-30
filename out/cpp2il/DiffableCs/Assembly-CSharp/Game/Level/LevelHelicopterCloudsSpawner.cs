namespace Game.Level;

public class LevelHelicopterCloudsSpawner : MonoBehaviour, IWorldCloudSpawner
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		private sealed class <<LoadCloudSprites>g__DefaultIndices|0>d : IEnumerable<Int32>, IEnumerable, IEnumerator<Int32>, IEnumerator, IDisposable
		{
			private int <>1__state; //Field offset: 0x10
			private int <>2__current; //Field offset: 0x14
			private int <>l__initialThreadId; //Field offset: 0x18
			public <>c__DisplayClass31_0 <>4__this; //Field offset: 0x20
			private int <i>5__2; //Field offset: 0x28

			private override int System.Collections.Generic.IEnumerator<System.Int32>.Current
			{
				[DebuggerHidden]
				private get { } //Length: 8
			}

			private override object System.Collections.IEnumerator.Current
			{
				[DebuggerHidden]
				private get { } //Length: 92
			}

			[DebuggerHidden]
			public <<LoadCloudSprites>g__DefaultIndices|0>d(int <>1__state) { }

			private override bool MoveNext() { }

			[DebuggerHidden]
			private override IEnumerator<Int32> System.Collections.Generic.IEnumerable<System.Int32>.GetEnumerator() { }

			[DebuggerHidden]
			private override int System.Collections.Generic.IEnumerator<System.Int32>.get_Current() { }

			[DebuggerHidden]
			private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

			[DebuggerHidden]
			private override object System.Collections.IEnumerator.get_Current() { }

			[DebuggerHidden]
			private override void System.Collections.IEnumerator.Reset() { }

			[DebuggerHidden]
			private override void System.IDisposable.Dispose() { }

		}

		public int cloudSetCount; //Field offset: 0x10

		public <>c__DisplayClass31_0() { }

		[IteratorStateMachine(typeof(<<LoadCloudSprites>g__DefaultIndices|0>d))]
		internal IEnumerable<Int32> <LoadCloudSprites>g__DefaultIndices|0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public WorldCloud cloud; //Field offset: 0x10

		public <>c__DisplayClass37_0() { }

		internal bool <OnCloudDestroy>b__0(ValueTuple<WorldCloud, Sprite, Single> entry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public WorldCloud cloud; //Field offset: 0x10
		public float targetY; //Field offset: 0x18
		public LevelHelicopterCloudsSpawner <>4__this; //Field offset: 0x20

		public <>c__DisplayClass39_0() { }

		internal void <OnBackgroundMoveY>b__0() { }

	}

	private enum CloudSet
	{
		L160 = 0,
		L63 = 1,
	}

	private const string L160_CLOUD_RESOURCES_PATH = "Level/SceneItems/Level_FarmingFields_L160/Cloud_{0:00}_L160"; //Field offset: 0x0
	private const int L160_CLOUD_COUNT = 19; //Field offset: 0x0
	private const string L63_CLOUD_RESOURCES_PATH = "Level/SceneItems/Level_Beach_L63/Cloud_{0:00}_L63"; //Field offset: 0x0
	private const int L63_CLOUD_COUNT = 4; //Field offset: 0x0
	[SerializeField]
	private Transform _cloudsParent; //Field offset: 0x20
	[SerializeField]
	private Transform _endPoint; //Field offset: 0x28
	[SerializeField]
	private int _cloudCount; //Field offset: 0x30
	[SerializeField]
	private CloudSet _cloudSet; //Field offset: 0x34
	[SerializeField]
	private List<Int32> _cloudIndices; //Field offset: 0x38
	[SerializeField]
	private LevelHelicopter _helicopter; //Field offset: 0x40
	[SerializeField]
	private LevelHelicopterBackgroundSwitcher _backgroundSwitcher; //Field offset: 0x48
	[SerializeField]
	private bool _keepCloudsFixedWorldX; //Field offset: 0x50
	[FormerlySerializedAs("_cutoffOffsetFromHelicopter")]
	[SerializeField]
	private float _minCutoffOffsetFromHelicopter; //Field offset: 0x54
	[SerializeField]
	private float _maxCutoffOffsetFromHelicopter; //Field offset: 0x58
	[SerializeField]
	private float _hiddenBottomRatio; //Field offset: 0x5C
	[SerializeField]
	private int _sortingOrder; //Field offset: 0x60
	[Range(0, 1)]
	[SerializeField]
	private float _secondSortingOrderChance; //Field offset: 0x64
	[SerializeField]
	private int _secondSortingOrder; //Field offset: 0x68
	[SerializeField]
	private float _minSpeed; //Field offset: 0x6C
	[SerializeField]
	private float _maxSpeed; //Field offset: 0x70
	[SerializeField]
	private float _flyMoveDuration; //Field offset: 0x74
	[SerializeField]
	private float _flyMoveDelay; //Field offset: 0x78
	[SerializeField]
	private float _flyMoveDistance; //Field offset: 0x7C
	private GameObject _cloudPrefab; //Field offset: 0x80
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"clear", "rain"})]
	private readonly List<ValueTuple`2<Sprite, Sprite>> _cloudSprites; //Field offset: 0x88
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"cloud", "clearSprite", "cutoffOffset"})]
	private readonly List<ValueTuple`3<WorldCloud, Sprite, Single>> _activeClouds; //Field offset: 0x90
	private float _targetParentWorldY; //Field offset: 0x98

	public LevelHelicopterCloudsSpawner() { }

	private void Awake() { }

	private void DrawCutoffLine(float cutoffOffset) { }

	private string GetCloudResourcesPathFormat() { }

	private int GetCloudSetCount() { }

	private float GetLocalCutoffY(float cutoffOffset) { }

	private float GetLocalY(Sprite clearSprite, float cutoffOffset) { }

	private float GetRandomCutoffOffset() { }

	private void LoadCloudSprites() { }

	public void OnBackgroundHidden() { }

	private void OnBackgroundMoveY(float deltaY, float duration) { }

	public override void OnCloudDestroy(WorldCloud cloud) { }

	private void OnDestroy() { }

	private void OnDrawGizmos() { }

	private void OnLevelPostInit() { }

	private void SpawnCloud() { }

	private void SpawnCloud(float localX) { }

	private static bool TryGetCloudSprites(GameObject cloudPrefab, out Sprite clearSprite, out Sprite rainSprite) { }

}

