namespace BWYW;

public class AnimationGroupGift : BWYWGiftBase
{
	[SerializeField]
	private string _cAClassName; //Field offset: 0x28
	[SerializeField]
	private int _level; //Field offset: 0x30

	public string CAClassName
	{
		 get { } //Length: 8
	}

	public int Level
	{
		 get { } //Length: 8
	}

	public AnimationGroupGift() { }

	public string get_CAClassName() { }

	public int get_Level() { }

}

