namespace Game.Level;

public class LevelCampfireFireSpine : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public bool isOn; //Field offset: 0x10
		public LevelCampfireFireSpine <>4__this; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <Animate>b__0() { }

	}

	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x20
	[SerializeField]
	private LightSource _lightSource; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	[SerializeField]
	private GameObject _fireArea; //Field offset: 0x38
	[SerializeField]
	private LevelCampfireFryArea _campfireFryArea; //Field offset: 0x40
	private int _lastNumberOfFirewood; //Field offset: 0x48
	private FireCampFireSizeType _currentFireSizeType; //Field offset: 0x4C
	private int _tweenID; //Field offset: 0x50

	public LevelCampfireFireSpine() { }

	public void Animate(int numberOfFirewood) { }

	private LeanTweenType GetEaseType(int numberOfFirewood) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private Vector3 GetScale() { }

	public bool IsFireOn() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private bool UpdateFireSizeTypeIfNeeded(int numberOfFirewood) { }

}

