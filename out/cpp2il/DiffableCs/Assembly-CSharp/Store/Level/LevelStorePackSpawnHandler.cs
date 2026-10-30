namespace Store.Level;

public class LevelStorePackSpawnHandler : MonoBehaviour
{
	[SerializeField]
	private StorePackType _storePackType; //Field offset: 0x20
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x24
	[SerializeField]
	private bool _skipLoadingLevelOnClaim; //Field offset: 0x28

	public bool SkipLoadingLevelOnClaim
	{
		 get { } //Length: 8
	}

	public LevelStorePackSpawnHandler() { }

	public bool get_SkipLoadingLevelOnClaim() { }

	public LevelType GetLevelType() { }

	public override StorePackType GetStorePackType() { }

}

