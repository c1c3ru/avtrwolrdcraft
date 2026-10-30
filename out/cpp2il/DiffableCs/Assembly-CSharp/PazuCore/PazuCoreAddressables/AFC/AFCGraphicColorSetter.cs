namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCGraphicColorSetter : MonoBehaviour
{
	[SerializeField]
	private Color[] _colors; //Field offset: 0x20
	private Graphic _graphic; //Field offset: 0x28

	public AFCGraphicColorSetter() { }

	public void SetColor(int index) { }

}

