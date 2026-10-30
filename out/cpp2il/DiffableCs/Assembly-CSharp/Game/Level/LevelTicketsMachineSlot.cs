namespace Game.Level;

public class LevelTicketsMachineSlot : LevelConsumerAreaBase
{
	[SerializeField]
	private LevelTicketsMachine _ticketsMachine; //Field offset: 0x58

	public LevelTicketsMachineSlot() { }

	public virtual bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

