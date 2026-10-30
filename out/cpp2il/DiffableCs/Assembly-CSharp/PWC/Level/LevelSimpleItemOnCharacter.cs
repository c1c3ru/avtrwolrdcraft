namespace PWC.Level;

public class LevelSimpleItemOnCharacter : LevelItemOnCharacterBase
{
	[SerializeField]
	private string _animationName; //Field offset: 0x358
	[SerializeField]
	private string _boneName; //Field offset: 0x360
	[SerializeField]
	private bool _useItemOnSpine; //Field offset: 0x368

	public LevelSimpleItemOnCharacter() { }

	protected virtual string GetCharacterAnimationName() { }

	protected virtual string GetCharacterBoneName() { }

	protected virtual bool UseItemInSpine() { }

}

