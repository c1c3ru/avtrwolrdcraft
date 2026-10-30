namespace Game.Level;

public class LevelCopyAnimationsFromOtherDropArea : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public LevelCAConfig config; //Field offset: 0x10
		public Func<LevelCAHandlerBase, Boolean> <>9__0; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal bool <OnAnimationBeginHandler>b__0(LevelCAHandlerBase caHandler) { }

	}

	[Header("Settings")]
	[SerializeField]
	private bool _copyAllAnimations; //Field offset: 0x20
	[SerializeField]
	private String[] _animationsToCopy; //Field offset: 0x28
	[Header("Scene References")]
	[SerializeField]
	private List<LevelDropArea> _areasToCopyFrom; //Field offset: 0x30
	[SerializeField]
	private List<LevelDropArea> _areasToCopyTo; //Field offset: 0x38
	private bool _isAnimating; //Field offset: 0x40

	public LevelCopyAnimationsFromOtherDropArea() { }

	private void Awake() { }

	private void OnAnimationBeginHandler(LevelCAHandlerBase levelCAHandler, ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEndHandler(LevelCAHandlerBase _, ICATarget __, LevelCAConfig ___) { }

	private void OnDestroy() { }

}

