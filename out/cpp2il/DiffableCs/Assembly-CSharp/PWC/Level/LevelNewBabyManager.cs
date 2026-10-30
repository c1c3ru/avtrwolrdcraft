namespace PWC.Level;

public class LevelNewBabyManager : LevelNewAvatarManager
{
	[SerializeField]
	private PDPrefabReference _prefabReference; //Field offset: 0x40
	[SerializeField]
	private Transform _babyHolderParent; //Field offset: 0x48

	public LevelNewBabyManager() { }

	protected virtual void OnAvatarSpawnPostInit() { }

	protected virtual void PerformNewAvatarFromBackButtonAction() { }

}

