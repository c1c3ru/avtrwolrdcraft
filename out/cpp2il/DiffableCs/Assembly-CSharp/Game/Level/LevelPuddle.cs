namespace Game.Level;

public class LevelPuddle : LevelConsumerAreaBase, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public Color color; //Field offset: 0x10
		public LevelPuddle <>4__this; //Field offset: 0x20

		public <>c__DisplayClass10_0() { }

		internal void <FadeOut>b__0(float alphaValue) { }

		internal void <FadeOut>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Color color; //Field offset: 0x10
		public LevelPuddle <>4__this; //Field offset: 0x20

		public <>c__DisplayClass9_0() { }

		internal void <InitSprite>b__0(float alphaValue) { }

	}

	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x58
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x60
	[SerializeField]
	private LevelDestroyableObjectHandler _destroyable; //Field offset: 0x68
	[SerializeField]
	private bool _isCleanedForEver; //Field offset: 0x70
	private int _tweenID; //Field offset: 0x74

	public LevelPuddle() { }

	protected virtual void Awake() { }

	public void FadeOut() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitSprite() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPositInit() { }

	public void PauseFadeOut() { }

	public void SetDontRestoreAfterCleaning() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Start() { }

}

