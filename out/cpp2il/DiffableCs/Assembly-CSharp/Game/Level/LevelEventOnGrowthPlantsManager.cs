namespace Game.Level;

public class LevelEventOnGrowthPlantsManager : MonoBehaviour
{
	[SerializeField]
	private List<LevelPlantBase> _plants; //Field offset: 0x20
	[SerializeField]
	private OneTimeEvent _oneTimeEvent; //Field offset: 0x28
	private bool _isSolved; //Field offset: 0x30

	public LevelEventOnGrowthPlantsManager() { }

	private void Awake() { }

	private void CheckAllPlants(int i) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

}

