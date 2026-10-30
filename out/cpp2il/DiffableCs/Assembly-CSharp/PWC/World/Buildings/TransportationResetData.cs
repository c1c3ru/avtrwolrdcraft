namespace PWC.World.Buildings;

[CreateAssetMenu(menuName = "AvatarWorld/World/TransportationResetData")]
public class TransportationResetData : ScriptableObject
{
	[SerializeField]
	private string _transportationSceneName; //Field offset: 0x18
	[SerializeField]
	private String[] _crossSitAreasSceneGuids; //Field offset: 0x20
	[SerializeField]
	private String[] _crossDropAreasSceneGuids; //Field offset: 0x28

	public String[] CrossDropAreasSceneGuids
	{
		 get { } //Length: 8
	}

	public String[] CrossSitAreasSceneGuids
	{
		 get { } //Length: 8
	}

	public string TransportationSceneName
	{
		 get { } //Length: 8
	}

	public TransportationResetData() { }

	public String[] get_CrossDropAreasSceneGuids() { }

	public String[] get_CrossSitAreasSceneGuids() { }

	public string get_TransportationSceneName() { }

}

