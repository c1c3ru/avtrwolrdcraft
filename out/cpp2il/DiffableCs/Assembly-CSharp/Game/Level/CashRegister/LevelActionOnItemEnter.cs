namespace Game.Level.CashRegister;

public class LevelActionOnItemEnter : MonoBehaviour
{
	[SerializeField]
	protected LevelDragActionArea _dragActionArea; //Field offset: 0x20
	[SerializeField]
	protected List<GameObject> _onEnterGameObjects; //Field offset: 0x28
	[SerializeField]
	protected List<GameObject> _onExitGameObjects; //Field offset: 0x30
	[SerializeField]
	protected string _soundName; //Field offset: 0x38
	protected int _bleepTweenID; //Field offset: 0x40

	public LevelActionOnItemEnter() { }

	[CompilerGenerated]
	private void <OnItemEnter>b__7_0() { }

	protected override void Awake() { }

	protected override void OnDestroy() { }

	protected override void OnItemEnter(LevelItem levelItem) { }

	protected override void OnItemExit(LevelItem levelItem, ExitReasonType exitReasonType) { }

}

