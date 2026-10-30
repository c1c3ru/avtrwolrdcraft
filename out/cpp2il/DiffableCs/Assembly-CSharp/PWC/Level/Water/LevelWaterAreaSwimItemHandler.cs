namespace PWC.Level.Water;

public class LevelWaterAreaSwimItemHandler : MonoBehaviour
{
	private int _lastUpdatedFrame; //Field offset: 0x20
	private bool _isGoingRight; //Field offset: 0x24
	private float _minX; //Field offset: 0x28
	private float _maxX; //Field offset: 0x2C
	private float _delay; //Field offset: 0x30
	private float _time; //Field offset: 0x34

	public LevelWaterAreaSwimItemHandler() { }

	private void InitSwim() { }

	public void UpdateSwim(LevelItem levelItem) { }

}

