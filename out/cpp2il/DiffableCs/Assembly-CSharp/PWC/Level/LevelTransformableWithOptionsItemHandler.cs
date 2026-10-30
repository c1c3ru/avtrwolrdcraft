namespace PWC.Level;

[DisallowMultipleComponent]
[HideParentPropertiesInInspector(new IL2CPP_TYPE_STRING[] {"_prefabReference"})]
[RequireComponent(typeof(LevelItem))]
public class LevelTransformableWithOptionsItemHandler : LevelTransformableItemHandler
{
	[SerializeField]
	protected List<PDPrefabReference> _prefabReferences; //Field offset: 0x98
	[SerializeField]
	protected bool _isRandom; //Field offset: 0xA0

	public LevelTransformableWithOptionsItemHandler() { }

	protected virtual void Awake() { }

	public void ForceClickOption(int index) { }

}

