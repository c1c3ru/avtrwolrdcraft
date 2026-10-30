namespace Game.Level;

public class LevelPerscriptionMachineHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public LevelPerscriptionMachineHandler <>4__this; //Field offset: 0x18
		public LevelSpawn levelSpawn; //Field offset: 0x20

		public <>c__DisplayClass10_0() { }

		internal void <EnterPrescription>b__0() { }

	}

	[SerializeField]
	private LevelDropArea _prescriptionDropArea; //Field offset: 0x20
	[SerializeField]
	private Transform _pillDropArea; //Field offset: 0x28
	[SerializeField]
	private Transform _endPosition; //Field offset: 0x30
	[SerializeField]
	private LevelSpawner _levelSpawner; //Field offset: 0x38
	[SerializeField]
	private PDPrefabReference[] _pills; //Field offset: 0x40
	[SerializeField]
	private string _soundName; //Field offset: 0x48
	private bool _isInteractable; //Field offset: 0x50
	private int _tweenID; //Field offset: 0x54

	public LevelPerscriptionMachineHandler() { }

	private void Awake() { }

	private void EnterPrescription(LevelItem levelItem) { }

	private void OnDestroy() { }

}

