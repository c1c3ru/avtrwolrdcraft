namespace Game.Level;

public class LevelDeflatedBalloonItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _blownPrefabRef; //Field offset: 0x28
	[SerializeField]
	private GameObject _unblownGameObject; //Field offset: 0x30
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x38
	[SerializeField]
	private LevelRuntimeColoredSpineHandler _levelRuntimeColoredSpineHandler; //Field offset: 0x40
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _deflatedIdleAnimation; //Field offset: 0x48
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _inflatedIdleAnimation; //Field offset: 0x50
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _inflatingAnimation; //Field offset: 0x58
	[SerializeField]
	private Color _color; //Field offset: 0x60
	[SerializeField]
	private bool _isColored; //Field offset: 0x70
	private int _colorIndex; //Field offset: 0x74

	public LevelDeflatedBalloonItemHandler() { }

	[CompilerGenerated]
	private void <Inflate>b__13_0(float t) { }

	private void FinishInflation(TrackEntry trackEntry) { }

	public void Inflate() { }

	public void SetColor(Color newColor) { }

	public void SetParticlesColor(int colorIndex) { }

}

