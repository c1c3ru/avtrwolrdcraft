namespace PWC.Level;

public class LevelPump : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public LevelPump <>4__this; //Field offset: 0x10
		public LevelPumpableItemHandler pumpableItemToPump; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass2_0() { }

		internal void <OnPointerClickInternal>b__0() { }

		internal void <OnPointerClickInternal>b__1() { }

	}

	[SerializeField]
	private GameObject _top; //Field offset: 0x348
	[SerializeField]
	private Transform _actionPoint; //Field offset: 0x350

	public LevelPump() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

}

