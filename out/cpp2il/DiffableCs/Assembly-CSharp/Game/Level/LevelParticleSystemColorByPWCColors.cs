namespace Game.Level;

public class LevelParticleSystemColorByPWCColors : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer[] _spriteRenderers; //Field offset: 0x28

	public LevelParticleSystemColorByPWCColors() { }

	private void Awake() { }

	private void OnCustomizationUIItemClick(CustomizationUIItemBase customizationUIItem) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void UpdateColors() { }

}

