namespace Game.Level;

public class LevelWashingMachine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PlaySound>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelWashingMachine <>4__this; //Field offset: 0x20

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
		public <PlaySound>d__10(int <>1__state) { }

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

	internal class ItemState
	{
		public Vector2 position; //Field offset: 0x10
		public Dictionary<CShape, Boolean> cShapes; //Field offset: 0x18
		public SpriteRenderer[] spriteRenderers; //Field offset: 0x20

		public ItemState() { }

	}

	[SerializeField]
	private LevelSimpleTransparentContainer _container; //Field offset: 0x20
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	private readonly Dictionary<LevelItem, ItemState> _itemsStartPositions; //Field offset: 0x38

	public LevelWashingMachine() { }

	private void Awake() { }

	private void OnDestroy() { }

	public void OnDoorStateChange(List<LevelItem> items, bool isOpen) { }

	private void OnLevelPostInit() { }

	[IteratorStateMachine(typeof(<PlaySound>d__10))]
	private IEnumerator PlaySound() { }

	private void StartWashing(List<LevelItem> items) { }

	private void StopSound() { }

	private void StopWashing(List<LevelItem> items) { }

}

