namespace PWC.SUTSystem;

public class SUTSystemTester : MonoBehaviour
{
	[CompilerGenerated]
	private struct <>c__DisplayClass6_0
	{
		public SUTSystemTester <>4__this; //Field offset: 0x0
		public Skin currentSkin; //Field offset: 0x8

	}

	[CompilerGenerated]
	private sealed class <Start>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public SUTSystemTester <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__6(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const string BASE_PATH = "Assets/Game/General/Resources/SUTSystem/Skins/"; //Field offset: 0x0
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x20
	private String[] _items; //Field offset: 0x28
	private int _currentItemIndex; //Field offset: 0x30
	private readonly List<Skin> _addedSkins; //Field offset: 0x38
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x40

	public SUTSystemTester() { }

	[CompilerGenerated]
	private void <Start>g__AddSkin|6_0(string skinName, ref <>c__DisplayClass6_0 unnamed_param_1) { }

	[CompilerGenerated]
	private void <Start>g__RefreshSkeletonAnimation|6_1(ref <>c__DisplayClass6_0 unnamed_param_0) { }

	private void LoadMaterialsOriginalTextures() { }

	private void RemoveSkin(Skin mainSkin, Skin skinToRemove) { }

	private void SetClothing(int index) { }

	private void SetMaterialsStrightAlpha() { }

	[IteratorStateMachine(typeof(<Start>d__6))]
	private IEnumerator Start() { }

	private void Update() { }

}

