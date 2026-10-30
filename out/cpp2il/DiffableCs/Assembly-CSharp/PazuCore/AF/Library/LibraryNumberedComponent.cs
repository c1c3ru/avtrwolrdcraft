namespace PazuCore.AF.Library;

public class LibraryNumberedComponent : MonoBehaviour
{
	[SerializeField]
	private Image _number; //Field offset: 0x20
	[SerializeField]
	private Sprite[] _numbersSprites; //Field offset: 0x28

	public LibraryNumberedComponent() { }

	public void SetProperNumber() { }

}

