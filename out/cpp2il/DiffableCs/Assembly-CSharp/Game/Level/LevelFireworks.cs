namespace Game.Level;

public class LevelFireworks : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public Color color; //Field offset: 0x10
		public SpriteRenderer explosionParticles; //Field offset: 0x20

		public <>c__DisplayClass15_0() { }

		internal void <AnimateExplosion>b__1(float alphaValue) { }

	}

	[SerializeField]
	private GameObject _sprite; //Field offset: 0x348
	[SerializeField]
	private GameObject _mask; //Field offset: 0x350
	[SerializeField]
	private float _maskFinalLocalYPosition; //Field offset: 0x358
	[SerializeField]
	private ParticleSystem _fireParticleSystem; //Field offset: 0x360
	[SerializeField]
	private ParticleSystem _smokeParticleSystem; //Field offset: 0x368
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x370
	[SerializeField]
	private SpriteRenderer[] _explosionParticlesSequence; //Field offset: 0x378
	private LTDescr _shakeTween; //Field offset: 0x380

	public LevelFireworks() { }

	[CompilerGenerated]
	private void <AnimateBlastOff>b__14_0() { }

	[CompilerGenerated]
	private void <AnimateExplosion>b__15_0() { }

	[CompilerGenerated]
	private void <AnimateMask>b__11_0() { }

	[CompilerGenerated]
	private void <AnimateMask>b__11_1() { }

	private void AnimateBlastOff() { }

	private void AnimateExplosion() { }

	private void AnimateMask() { }

	protected virtual void Awake() { }

	private void FireParticlesSetActive(bool value) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void SmokeParticlesSetActive(bool value) { }

	private void StartBlastOffSequence() { }

}

