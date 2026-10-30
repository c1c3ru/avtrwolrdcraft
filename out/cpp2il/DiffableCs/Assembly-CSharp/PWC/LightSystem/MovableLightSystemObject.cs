namespace PWC.LightSystem;

public class MovableLightSystemObject
{
	private readonly GameObject _gameObject; //Field offset: 0x10
	private LitBase[] _litComponents; //Field offset: 0x18
	private LightSource[] _lightSources; //Field offset: 0x20

	public MovableLightSystemObject(GameObject gameObject) { }

	public void OnBeginMove() { }

	public void OnMove() { }

	private void SyncComponents() { }

	private void UpdateLightsIfNeeded() { }

}

