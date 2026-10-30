namespace Game.Level.ContextualAnimation;

[DisallowMultipleComponent]
public class LevelCASnowSurfaceDogHandler : LevelCAByWeatherCharacterHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public PDPrefab footPrint; //Field offset: 0x10
		public Action <>9__1; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <AddFootPrint>b__0() { }

		internal void <AddFootPrint>b__1() { }

	}

	private int _soundIndex; //Field offset: 0x84
	private LevelItem _levelItem; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCASnowSurfaceDogHandler() { }

	private void AddFootPrint(LevelDog levelDog, string prefab) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private PDPrefab GetPrefab(string name, Vector2 position) { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public void OnContact(LevelAnimal levelAnimal, Event spineEvent) { }

	public void OnPickup(DragDropItemBase arg1, PointerEventData arg2) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

