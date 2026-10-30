namespace PWC.Level;

public class LevelRemovableCoverBoxItemHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private LevelDropArea _coverDropArea; //Field offset: 0x20
	[SerializeField]
	private GameObject _containerArea; //Field offset: 0x28

	public LevelRemovableCoverBoxItemHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem _) { }

	private void OnItemPickUp(LevelItem _) { }

	private void OnLevelPostInit() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

}

