namespace PWC.Level;

public class LevelDefaultColoredRendererHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private LevelRuntimeColoredRendererHandlerBase _coloredRenderer; //Field offset: 0x20
	[SerializeField]
	private PWSpriteColorType _colorType; //Field offset: 0x28
	[SerializeField]
	private Color _color; //Field offset: 0x2C
	private bool _didOnReadyPostLoad; //Field offset: 0x3C

	public LevelDefaultColoredRendererHandler() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	private void OnDestroy() { }

	private void OnEnable() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

}

