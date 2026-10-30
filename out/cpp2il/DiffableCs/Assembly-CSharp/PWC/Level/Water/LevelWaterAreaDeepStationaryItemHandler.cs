namespace PWC.Level.Water;

public class LevelWaterAreaDeepStationaryItemHandler : LevelWaterAreaItemHandlerBase
{
	[SerializeField]
	private float _waterLineXOffset; //Field offset: 0x5C
	private Renderer _renderer; //Field offset: 0x60

	public LevelWaterAreaDeepStationaryItemHandler() { }

	public void Init(LevelWaterArea waterArea) { }

	private bool ShouldShowWaterLine() { }

}

