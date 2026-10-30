namespace BWYW;

public class BWYWGiftBase
{
	[SerializeField]
	private string _title; //Field offset: 0x10
	[SerializeField]
	private Sprite _sprite; //Field offset: 0x18
	[SerializeField]
	private Sprite _hiddenSprite; //Field offset: 0x20

	public Sprite HiddenSprite
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Sprite Sprite
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string Title
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public BWYWGiftBase() { }

	public Sprite get_HiddenSprite() { }

	public Sprite get_Sprite() { }

	public string get_Title() { }

	public void set_HiddenSprite(Sprite value) { }

	public void set_Sprite(Sprite value) { }

	public void set_Title(string value) { }

}

