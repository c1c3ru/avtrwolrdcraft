namespace Game.Level;

[RequireComponent(typeof(DeliverySystemDrone))]
public class LevelDronePack : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private LevelItem _boxLevelItem; //Field offset: 0x20
	private bool _didOnReadyPostLoad; //Field offset: 0x28

	public LevelItem BoxLevelItem
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelDronePack() { }

	private void Awake() { }

	private void BringDeliveryWithDrone() { }

	private void EnsureOnReadyPostLoad() { }

	public LevelItem get_BoxLevelItem() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPreSaveProgress(Scene scene) { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	public void set_BoxLevelItem(LevelItem value) { }

}

