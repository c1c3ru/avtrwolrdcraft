namespace Game.Level;

public class LevelFishingRodTargetItemHandler : MonoBehaviour
{
	[SerializeField]
	protected Transform _baitPoint; //Field offset: 0x20
	private LevelItem _levelItem; //Field offset: 0x28

	public LevelItem MyLevelItem
	{
		 get { } //Length: 8
	}

	public LevelFishingRodTargetItemHandler() { }

	private void Awake() { }

	public LevelItem get_MyLevelItem() { }

	public void GoToFishingRodBait(LevelFishingRodBait bait, bool snap, bool disableLevelItem) { }

}

