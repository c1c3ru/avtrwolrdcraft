namespace Game.Level;

public class LevelLuggageTagItemHandler : MonoBehaviour
{
	[SerializeField]
	private Transform _hangArea; //Field offset: 0x20
	[SerializeField]
	private Transform _openPoint; //Field offset: 0x28
	[SerializeField]
	private Transform _closedPoint; //Field offset: 0x30

	public LevelLuggageTagItemHandler() { }

	public void SwitchTagPosition(bool toOpenState) { }

}

