namespace PWC.World.Buildings;

public class WorldBuildingRemoteConfigView : StationaryInteractableItem, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <Start>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WorldBuildingRemoteConfigView <>4__this; //Field offset: 0x20

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
		public <Start>d__8(int <>1__state) { }

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
	private GameObject _underConstruction; //Field offset: 0x40
	[SerializeField]
	private GameObject _playable; //Field offset: 0x48
	[SerializeField]
	private GameObject _earlyAccess; //Field offset: 0x50
	[SerializeField]
	private GameObject _updateAvailable; //Field offset: 0x58
	[SerializeField]
	private WorldBuildingType _worldBuildingType; //Field offset: 0x60
	private ZoneBuildingItem _dataItem; //Field offset: 0x68

	public WorldBuildingRemoteConfigView() { }

	[CompilerGenerated]
	internal static void <SetRemoteData>g__SetActiveIfExists|13_0(GameObject obj, bool isActive) { }

	protected virtual void Awake() { }

	private int GetRemoteConfigID() { }

	private void Init() { }

	protected virtual void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnTextureDownloaded(ZoneBuildingItem dataItem, string url) { }

	private void SetRemoteData(ZoneBuildingItem dataItem) { }

	[IteratorStateMachine(typeof(<Start>d__8))]
	private IEnumerator Start() { }

}

