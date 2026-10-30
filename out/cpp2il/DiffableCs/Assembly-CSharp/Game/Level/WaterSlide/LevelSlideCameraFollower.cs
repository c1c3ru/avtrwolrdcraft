namespace Game.Level.WaterSlide;

public class LevelSlideCameraFollower : MonoBehaviour
{
	[SerializeField]
	private LevelSlideItemsSpawner _slideItemsSpawner; //Field offset: 0x20
	[SerializeField]
	private float maxHeight; //Field offset: 0x28
	[SerializeField]
	private float minHeight; //Field offset: 0x2C
	private LevelItem _slideItem; //Field offset: 0x30
	private float maxWidth; //Field offset: 0x38
	private float minWidth; //Field offset: 0x3C
	private Camera _camera; //Field offset: 0x40

	public LevelSlideCameraFollower() { }

	private void Awake() { }

	private void FixCameraPosition() { }

	private void OnDestroy() { }

	private void OnFirstItemSpawnAction(LevelItem item) { }

	private void OnLevelPostInit() { }

	private void Update() { }

}

