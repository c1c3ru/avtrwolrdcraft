namespace Game.Level;

public class LevelRoomba : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public float right; //Field offset: 0x10
		public float left; //Field offset: 0x14
		public float middle; //Field offset: 0x18
		public LevelRoomba <>4__this; //Field offset: 0x20
		public Action <>9__2; //Field offset: 0x28

		public <>c__DisplayClass10_0() { }

		internal void <Animate>b__1() { }

		internal void <Animate>b__2() { }

	}

	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x348
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x350
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x358
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x360
	private bool _isOn; //Field offset: 0x368
	private SpriteRenderer _spriteRenderer; //Field offset: 0x370

	public LevelRoomba() { }

	[CompilerGenerated]
	private void <Animate>b__10_3() { }

	[CompilerGenerated]
	private void <Animate>g__Move|10_0() { }

	private void Animate(bool value) { }

	protected virtual void Awake() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual LevelDropArea OnEndLand() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void ParticleSystemSetActive(bool value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

