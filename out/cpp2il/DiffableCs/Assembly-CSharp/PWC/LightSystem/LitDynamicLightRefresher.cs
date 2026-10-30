namespace PWC.LightSystem;

public class LitDynamicLightRefresher : MonoBehaviour
{
	[SerializeField]
	private Transform root; //Field offset: 0x20
	private readonly List<LitBase> lits; //Field offset: 0x28

	public LitDynamicLightRefresher() { }

	public void UpdateDynamicLightOnChildren() { }

}

