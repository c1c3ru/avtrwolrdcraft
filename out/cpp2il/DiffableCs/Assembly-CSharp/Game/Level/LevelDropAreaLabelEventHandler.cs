namespace Game.Level;

public class LevelDropAreaLabelEventHandler : MonoBehaviour
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private string _label; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onLabelMatchEvent; //Field offset: 0x30

	public LevelDropAreaLabelEventHandler() { }

	public void InvokeIfLabelMatches() { }

}

