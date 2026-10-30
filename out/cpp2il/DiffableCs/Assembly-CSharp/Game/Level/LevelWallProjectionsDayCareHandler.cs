namespace Game.Level;

public class LevelWallProjectionsDayCareHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <MoveProjection>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Flat3DPlane projection; //Field offset: 0x20
		public LevelWallProjectionsDayCareHandler <>4__this; //Field offset: 0x28

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
		public <MoveProjection>d__11(int <>1__state) { }

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

	[SerializeField]
	private Flat3DPlane[] _projections; //Field offset: 0x20
	[SerializeField]
	private LevelToggleableSprite _toggleableSprite; //Field offset: 0x28
	[SerializeField]
	private Texture2D[] _textures; //Field offset: 0x30
	private bool _isActive; //Field offset: 0x38
	private bool _isUnlocked; //Field offset: 0x39

	public LevelWallProjectionsDayCareHandler() { }

	public void ActivateProjections() { }

	private void Awake() { }

	private void ChangeTexture(int index) { }

	public void DeactivateProjections() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitTexture() { }

	[IteratorStateMachine(typeof(<MoveProjection>d__11))]
	private IEnumerator MoveProjection(Flat3DPlane projection) { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetUnlocked() { }

}

