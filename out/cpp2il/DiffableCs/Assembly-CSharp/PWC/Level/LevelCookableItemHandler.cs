namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelCookableItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	protected Sprite _friedSprite; //Field offset: 0x28
	[CompilerGenerated]
	private Action onCookAction; //Field offset: 0x30
	public UnityEvent OnCook; //Field offset: 0x38
	private ParticleSystem _cookingSmoke; //Field offset: 0x40
	[CompilerGenerated]
	private bool <IsCooked>k__BackingField; //Field offset: 0x48

	public event Action onCookAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public private bool IsCooked
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public LevelCookableItemHandler() { }

	[CompilerGenerated]
	public void add_onCookAction(Action value) { }

	public void CookingSmokeSetActive(bool value) { }

	[CompilerGenerated]
	public bool get_IsCooked() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	[CompilerGenerated]
	public void remove_onCookAction(Action value) { }

	[CompilerGenerated]
	private void set_IsCooked(bool value) { }

	public void SetCooked() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

