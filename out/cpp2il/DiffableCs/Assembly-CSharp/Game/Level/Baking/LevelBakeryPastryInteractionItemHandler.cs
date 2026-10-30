namespace Game.Level.Baking;

[DisallowMultipleComponent]
public class LevelBakeryPastryInteractionItemHandler : LevelSimpleItemHandlerConsumerBase
{
	[SerializeField]
	private bool _isBigPastry; //Field offset: 0x28
	[SerializeField]
	private MoldShape _shape; //Field offset: 0x2C

	public LevelBakeryPastryInteractionItemHandler() { }

	public MoldShape GetShape() { }

	public bool IsBigPastry() { }

}

