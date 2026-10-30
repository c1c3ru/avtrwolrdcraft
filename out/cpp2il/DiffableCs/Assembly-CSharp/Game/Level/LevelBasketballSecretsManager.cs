namespace Game.Level;

public class LevelBasketballSecretsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public PDPrefab prefabReference; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal bool <OnScore>b__0(PDprefabEventEntry x) { }

	}

	[SerializeField]
	private int _leftTargetScore; //Field offset: 0x20
	[SerializeField]
	private int _rightTargetScore; //Field offset: 0x24
	[SerializeField]
	private UnityEvent _onScoreBoardComplete; //Field offset: 0x28
	[SerializeField]
	private List<PDprefabEventEntry> _uniqueBallEvents; //Field offset: 0x30
	[SerializeField]
	private string _bouncingChairLabel; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onScoreWithBouncingChair; //Field offset: 0x40

	public LevelBasketballSecretsManager() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnScore(LevelBSBasketballItemHandler itemHandler, LevelBSHoop hoop) { }

	private void OnScoreUpdate(LevelBasketballScoreBoard scoreBoard) { }

}

