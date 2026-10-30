namespace PWC.Level;

public class LevelLabelHandler : MonoBehaviour, ILevelLabelHandler
{
	[SerializeField]
	private string _label; //Field offset: 0x20

	public string Label
	{
		 get { } //Length: 8
	}

	public LevelLabelHandler() { }

	public string get_Label() { }

	private override bool PWC.Level.ILevelLabelHandler.PerformLabelTest(string label) { }

	public void SetLabel(string lebal) { }

}

