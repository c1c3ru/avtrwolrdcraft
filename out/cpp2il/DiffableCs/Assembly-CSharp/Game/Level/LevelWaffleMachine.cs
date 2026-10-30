namespace Game.Level;

public class LevelWaffleMachine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public LevelWaffleMachine <>4__this; //Field offset: 0x10
		public int index; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal void <CreateWaffle>b__0(MPDataGeneratorHandle _) { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private PDPrefabReference[] _waffles; //Field offset: 0x38
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x40
	[SerializeField]
	private string _workingSoundName; //Field offset: 0x48
	[SerializeField]
	private string _buttonsSoundName; //Field offset: 0x50
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x58
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _idleAnimationsNames; //Field offset: 0x60
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _workingAnimationName; //Field offset: 0x68
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _dynamicAnimationsNames; //Field offset: 0x70
	private Animation _workingAnimation; //Field offset: 0x78
	private Animation _idleCloseAnimation; //Field offset: 0x80
	private Animation _idleOpenAnimation; //Field offset: 0x88
	private Animation _closeAnimation; //Field offset: 0x90
	private Animation _openAnimation; //Field offset: 0x98
	private bool _isWorking; //Field offset: 0xA0
	private Skin _skin; //Field offset: 0xA8
	private Skin[] _pressedButtonsSkins; //Field offset: 0xB0

	public LevelWaffleMachine() { }

	private void Awake() { }

	public void CreateWaffle(int index) { }

	private void FindAllSkins() { }

	private LevelSpawn GetPrefabToSpawn(int index) { }

	private bool OnCanOpenDoorOverrideBehaviour() { }

	private void OnDestroy() { }

	private void OnDoorChangeState(bool state) { }

	private void OnLevelPostInit() { }

	private void RefreshSkeletonAnimation() { }

	private void RemoveSkin(Skin skin) { }

}

