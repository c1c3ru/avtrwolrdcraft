namespace PWC.Level;

public class LevelTargetsArea : LevelConsumerAreaBase
{
	[SerializeField]
	private GameObject[] _targets; //Field offset: 0x58
	[SerializeField]
	private PDPrefabReference[] _pdPrefabReferences; //Field offset: 0x60
	[SerializeField]
	public UnityEvent onSpawnOnTargets; //Field offset: 0x68

	public PDPrefabReference[] PdPrefabReferences
	{
		 get { } //Length: 8
	}

	public GameObject[] Targets
	{
		 get { } //Length: 8
	}

	public LevelTargetsArea() { }

	public PDPrefabReference[] get_PdPrefabReferences() { }

	public GameObject[] get_Targets() { }

}

