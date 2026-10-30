namespace Game.Level;

[RequireComponent(typeof(LevelScreenCaptureHandler))]
public class LevelPhotoBooth : MonoBehaviour, ILevelMakerUIMenuItem
{
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x20
	[SerializeField]
	private LevelSpawn _prefab; //Field offset: 0x28
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x30
	[SerializeField]
	private Vector3 _spawnPhotoPosition; //Field offset: 0x38
	private LevelScreenCaptureHandler _screenCaptureHandler; //Field offset: 0x48
	private bool _didZoomPhotoFirstTime; //Field offset: 0x50

	public LevelPhotoBooth() { }

	private void Awake() { }

	private string GetImagesDirectory() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	public void TakePhoto() { }

}

