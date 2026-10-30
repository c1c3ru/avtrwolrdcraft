namespace PWC.World;

public class WorldStreetEntry : WorldEnterableEntity
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public Color color; //Field offset: 0x10
		public WorldStreetEntry <>4__this; //Field offset: 0x20

		public <>c__DisplayClass8_0() { }

		internal void <OnBackgroundPlanetClick>b__0(float alphaValue) { }

	}

	[SerializeField]
	private WorldMakerStreetType _streetType; //Field offset: 0x3C
	[SerializeField]
	private PDSceneObject _pdSceneObject; //Field offset: 0x40
	[SerializeField]
	private SpriteRenderer _house; //Field offset: 0x48
	[SerializeField]
	private SpriteRenderer _nightLight; //Field offset: 0x50
	private bool _isBuilt; //Field offset: 0x58

	public WorldStreetEntry() { }

	protected virtual void Awake() { }

	private void OnBackgroundPlanetClick() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnPointerClickInternal() { }

	public void Start() { }

}

