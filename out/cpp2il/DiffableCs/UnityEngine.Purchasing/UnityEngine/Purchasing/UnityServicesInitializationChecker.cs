namespace UnityEngine.Purchasing;

internal class UnityServicesInitializationChecker : IUnityServicesInitializationChecker
{
	private const string UgsUninitializedMessage = "<b>Unity In-App Purchasing</b> requires <b>Unity Gaming Services</b> to have been initialized before use.
- Find out how to initialize <b>Unity Gaming Services</b> by following the documentation <i>https://docs.unity.com/ugs-overview/services-core-api.html#InitializationExample</i>
or download the <i>06 Initialize Gaming Services</i> sample from <i>Package Manager > In-App Purchasing > Samples</i>.
- If you are using the codeless API, you may want to enable the enable <b>Unity Gaming Services</b> automatic initialization by checking the <b>Automatically initialize Unity Gaming Services</b> checkbox at the bottom of the <b>IAP Catalog</b> window"; //Field offset: 0x0
	private readonly ILogger m_Logger; //Field offset: 0x10

	public UnityServicesInitializationChecker(ILogger logger) { }

	public override void CheckAndLogWarning() { }

	private bool IsUninitialized() { }

	private void LogWarning() { }

}

