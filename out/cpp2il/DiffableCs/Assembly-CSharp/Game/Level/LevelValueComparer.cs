namespace Game.Level;

public class LevelValueComparer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LevelValueProvider, Boolean> <>9__3_0; //Field offset: 0x8
		public static Func<LevelValueProvider, Boolean> <>9__3_1; //Field offset: 0x10
		public static Func<LevelValueProvider, Boolean> <>9__3_2; //Field offset: 0x18
		public static Func<LevelValueProvider, Object> <>9__3_3; //Field offset: 0x20
		public static Predicate<LevelValueProvider> <>9__4_0; //Field offset: 0x28

		private static <>c() { }

		public <>c() { }

		internal bool <Editor_PerformDiagnosticsTest>b__4_0(LevelValueProvider p) { }

		internal bool <GetAllMatchValue>b__3_0(LevelValueProvider p) { }

		internal bool <GetAllMatchValue>b__3_1(LevelValueProvider p) { }

		internal bool <GetAllMatchValue>b__3_2(LevelValueProvider p) { }

		internal object <GetAllMatchValue>b__3_3(LevelValueProvider p) { }

	}

	[SerializeField]
	private List<LevelValueProvider> providers; //Field offset: 0x20
	[SerializeField]
	private UnityEvent onMatchingValueEvent; //Field offset: 0x28
	[SerializeField]
	private UnityEvent onMismatchedValueEvent; //Field offset: 0x30

	public LevelValueComparer() { }

	public void Editor_PerformDiagnosticsTest(bool isInScene) { }

	[ContextMenu("Get All Match Value")]
	public void GetAllMatchValue() { }

}

