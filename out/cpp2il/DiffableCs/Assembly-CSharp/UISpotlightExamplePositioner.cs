//Type is in global namespace

public class UISpotlightExamplePositioner : MonoBehaviour
{
	[SerializeField]
	private UISpotlight _uiSpotlight; //Field offset: 0x20
	[SerializeField]
	private float _radius; //Field offset: 0x28
	[SerializeField]
	private float _softness; //Field offset: 0x2C

	public UISpotlightExamplePositioner() { }

	private void OnValidate() { }

	private void Start() { }

	private void Update() { }

}

