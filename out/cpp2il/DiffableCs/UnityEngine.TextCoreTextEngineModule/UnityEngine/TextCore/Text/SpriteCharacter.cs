namespace UnityEngine.TextCore.Text;

public class SpriteCharacter : TextElement
{
	[SerializeField]
	private string m_Name; //Field offset: 0x30

	public string name
	{
		 get { } //Length: 8
	}

	public SpriteCharacter() { }

	public string get_name() { }

}

