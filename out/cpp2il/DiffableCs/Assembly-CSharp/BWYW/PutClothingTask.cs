namespace BWYW;

public class PutClothingTask : DailyTaskBase
{
	[SerializeField]
	private List<String> _clothesNames; //Field offset: 0x40

	public List<String> ClothesNames
	{
		 get { } //Length: 8
	}

	public PutClothingTask() { }

	public List<String> get_ClothesNames() { }

}

