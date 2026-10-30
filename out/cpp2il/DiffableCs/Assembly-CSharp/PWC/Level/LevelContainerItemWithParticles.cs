namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelContainerItemWithParticles : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public bool value; //Field offset: 0x10
		public LevelContainerItemWithParticles <>4__this; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <Animate>b__0() { }

	}

	[SerializeField]
	private GameObject _sprite; //Field offset: 0x348
	[SerializeField]
	protected ParticleSystem _particleSystem; //Field offset: 0x350
	[Range(0, 360)]
	[SerializeField]
	private float _angle; //Field offset: 0x358
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x360
	[SerializeField]
	private string _soundName; //Field offset: 0x368

	public LevelContainerItemWithParticles() { }

	protected override void Animate(bool value) { }

	protected override void OnAnimate(bool value) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected override void OnBeginDragSpecific() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

}

