namespace Game.Level.BakingMachine;

public class LevelBakingMachineBaseTypeButton : LevelBakingMachineButtonBase
{
	[SerializeField]
	private BaseType _baseType; //Field offset: 0x3C

	public LevelBakingMachineBaseTypeButton() { }

	protected virtual void OnClickInternal(PointerEventData eventData) { }

}

