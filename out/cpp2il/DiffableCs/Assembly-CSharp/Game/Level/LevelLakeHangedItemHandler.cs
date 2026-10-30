namespace Game.Level;

public class LevelLakeHangedItemHandler : MonoBehaviour
{
	[SerializeField]
	private LakeHangedItemType _campsiteHangedItemType; //Field offset: 0x20

	public LakeHangedItemType CampsiteHangedItemType
	{
		 get { } //Length: 8
	}

	public LevelLakeHangedItemHandler() { }

	public LakeHangedItemType get_CampsiteHangedItemType() { }

}

