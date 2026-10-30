namespace Game.Level.BakingMachine;

public class LevelBakingMachineTopTypeButton : LevelBakingMachineButtonBase
{
	[SerializeField]
	private TopType _topType; //Field offset: 0x3C

	public LevelBakingMachineTopTypeButton() { }

	protected virtual void OnClickInternal(PointerEventData eventData) { }

}

