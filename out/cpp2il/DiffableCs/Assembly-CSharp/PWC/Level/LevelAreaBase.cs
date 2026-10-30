namespace PWC.Level;

public abstract class LevelAreaBase : MonoBehaviour
{
	protected CShape _cShape; //Field offset: 0x20
	[CompilerGenerated]
	private ILevelEntity <OwnerEntity>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private GameShape <MyGameShape>k__BackingField; //Field offset: 0x30

	public CShape MyCShape
	{
		 get { } //Length: 8
	}

	public private GameShape MyGameShape
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private ILevelEntity OwnerEntity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	protected LevelAreaBase() { }

	protected override void Awake() { }

	public CShape get_MyCShape() { }

	[CompilerGenerated]
	public GameShape get_MyGameShape() { }

	[CompilerGenerated]
	public ILevelEntity get_OwnerEntity() { }

	public Bounds1D GetLocalXBounds() { }

	public Bounds GetWorldBounds() { }

	public Bounds1D GetWorldXBounds() { }

	protected override void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	public void RefreshGameShape() { }

	[CompilerGenerated]
	private void set_MyGameShape(GameShape value) { }

	[CompilerGenerated]
	private void set_OwnerEntity(ILevelEntity value) { }

}

