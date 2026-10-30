namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelHangHandler : MonoBehaviour, IMultiplayer_PrepareForDrag
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public LevelHangHandler <>4__this; //Field offset: 0x10
		public LevelHangArea hangableArea; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <HangOnArea>b__0() { }

	}

	[SerializeField]
	private Transform _hangPoint; //Field offset: 0x20
	public LevelHangArea currentArea; //Field offset: 0x28
	protected LevelItem _levelItem; //Field offset: 0x30
	public Action<LevelHangArea> OnHangAction; //Field offset: 0x38

	public Transform HangPoint
	{
		 get { } //Length: 8
	}

	public LevelHangHandler() { }

	protected override void Awake() { }

	protected void EnsureLevelItem() { }

	public Transform get_HangPoint() { }

	public LevelItem GetLevelItem() { }

	public void HangOnArea(LevelHangArea hangableArea, bool snap) { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	protected override void OnDestroy() { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrag.Multiplayer_PrepareForDrag() { }

	public override bool TryHangOnConsumer(ILevelConsumer consumer) { }

}

