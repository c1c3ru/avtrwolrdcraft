namespace Game.Level;

[AddComponentMenu(null)]
public class LevelFriesMachine : LevelSimpleSpawner
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public LevelFriesMachine <>4__this; //Field offset: 0x10
		public PointerEventData eventData; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal void <OnPointerClick>b__0() { }

	}

	[SerializeField]
	private GameObject _onState; //Field offset: 0x98
	private bool _isOn; //Field offset: 0xA0

	public LevelFriesMachine() { }

	[CompilerGenerated]
	[DebuggerHidden]
	private void <>n__0(PointerEventData eventData) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

}

