namespace PWC.Level;

public class LevelTagHandler : MonoBehaviour
{
	[SerializeField]
	private LevelTagType[] _tags; //Field offset: 0x20

	public LevelTagType[] Tags
	{
		 get { } //Length: 8
	}

	public LevelTagHandler() { }

	public LevelTagType[] get_Tags() { }

}

