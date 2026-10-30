namespace UnityEngine.ResourceManagement.ResourceProviders;

[DisplayName("JSON Asset Provider")]
public class JsonAssetProvider : TextDataProvider
{

	public JsonAssetProvider() { }

	public virtual object Convert(Type type, string text) { }

}

