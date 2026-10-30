namespace PWC.Level;

public class LevelMultiLabelHandler : MonoBehaviour, ILevelLabelHandler
{
	[SerializeField]
	private String[] _labels; //Field offset: 0x20
	private HashSet<String> _labelsHashSet; //Field offset: 0x28

	public LevelMultiLabelHandler() { }

	private override bool PWC.Level.ILevelLabelHandler.PerformLabelTest(string label) { }

}

