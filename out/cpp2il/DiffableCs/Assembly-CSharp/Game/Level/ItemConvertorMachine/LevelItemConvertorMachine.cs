namespace Game.Level.ItemConvertorMachine;

public class LevelItemConvertorMachine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public PDPrefabReference pdPrefabReference; //Field offset: 0x10
		public LevelItemConvertorMachine <>4__this; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <OnInputDropItemEndDrop>b__0(TrackEntry _) { }

	}

	[SerializeField]
	private LevelItemConvertorMachineData _data; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _inputDropArea; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _outputDropArea; //Field offset: 0x30
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x38
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x40
	[SerializeField]
	private string _soundName; //Field offset: 0x48
	private Dictionary<String, PDPrefabReference> _hashedData; //Field offset: 0x50

	public LevelItemConvertorMachine() { }

	private void Awake() { }

	private void CanInputDropAreaConsumeItem(LevelItem levelItem, ref bool canConsume) { }

	private void OnDestroy() { }

	private void OnInputDropItemEndDrop(LevelItem levelItem) { }

	private void PopulateHashedData() { }

}

