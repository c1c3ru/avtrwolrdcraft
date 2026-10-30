namespace Game.Level;

public class LevelCrossWalkAreaHandler : MonoBehaviour
{
	[SerializeField]
	private int _numberOfInteractingVehicles; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _levelDropArea; //Field offset: 0x28

	public int NumberOfInteractingVehicles
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelCrossWalkAreaHandler() { }

	public void AddVehicle() { }

	public void DecreaseVehicle() { }

	public int get_NumberOfInteractingVehicles() { }

	public int GetNumberOfCrossingCharacters() { }

	public void set_NumberOfInteractingVehicles(int value) { }

}

