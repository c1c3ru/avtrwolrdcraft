namespace PazuCore.PazuCoreAddressables.AFC;

public abstract class AFCUnityMessageDrivenHandlerBase : MonoBehaviour
{
	internal enum CallType
	{
		None = 0,
		Awake = 1,
		OnEnable = 2,
		Start = 3,
		OnDisable = 4,
		OnDestroy = 5,
	}

	[SerializeField]
	protected CallType _callType; //Field offset: 0x20

	protected AFCUnityMessageDrivenHandlerBase() { }

	protected override void Awake() { }

	protected override void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	public abstract void PerformAction() { }

	protected override void Start() { }

}

