namespace PazuCore.GameUpdate;

public class GameUpdateWindow : Window
{
	[SerializeField]
	private WindowWithCat _windowWithCat; //Field offset: 0x30
	[SerializeField]
	private TextureComponent _textureComponent; //Field offset: 0x38
	[SerializeField]
	private GameObject _closeButton; //Field offset: 0x40
	[SerializeField]
	private ParticleSystem[] _burstParticleSystems; //Field offset: 0x48
	private string _coverUrl; //Field offset: 0x50
	private bool _isRequired; //Field offset: 0x58

	public GameUpdateWindow() { }

	[CompilerGenerated]
	private void <OnCTAClick>b__10_0() { }

	[CompilerGenerated]
	private void <OnCTAClick>b__10_1(bool success) { }

	private void Awake() { }

	public virtual void CloseWindow() { }

	private void FixBurstParticleSystemsGravity() { }

	private void Init(string coverUrl, bool isRequired) { }

	public void OnCTAClick() { }

	public static void Open(string coverUrl, bool isRequired, bool isReopening = false) { }

	private void Start() { }

}

