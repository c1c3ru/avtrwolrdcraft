namespace PWC.Level;

public class LevelDropAreaLinker : LevelConsumerAreaBase
{
	[SerializeField]
	protected LevelDropArea _dropArea; //Field offset: 0x58
	[SerializeField]
	protected bool _DontLinkIfTargetDisabled; //Field offset: 0x60

	public LevelDropAreaLinker() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	public override LevelDropArea GetDropArea() { }

}

