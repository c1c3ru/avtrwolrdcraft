namespace Game.Level;

[AddComponentMenu(null)]
public class LevelSnackMachineItem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public LevelSnackMachineItem <>4__this; //Field offset: 0x10
		public LevelSpawn levelSpawn; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass5_0() { }

		internal void <OnPointerClick>b__0() { }

		internal void <OnPointerClick>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_1
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass5_1() { }

		internal void <OnPointerClick>b__2() { }

	}

	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _prefab; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private Transform _yDropPosition; //Field offset: 0x38
	private bool _isPressed; //Field offset: 0x40

	public LevelSnackMachineItem() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

