namespace Game.Level;

public class LevelGraffitiStencilsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public LevelItem droppedItem; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <OnItemEndDrop>b__0(LevelItem item) { }

	}

	[SerializeField]
	private LevelFreePositionDropArea _freePositionDropArea; //Field offset: 0x20
	[SerializeField]
	private LevelChalkGround _graffitiWall; //Field offset: 0x28
	private Vector3 _offset; //Field offset: 0x30

	public LevelGraffitiStencilsManager() { }

	private void Awake() { }

	private void OnDestroy() { }

	protected void OnItemEndDrop(LevelItem levelItem) { }

	protected void OnItemPickUp(LevelItem levelItem) { }

}

