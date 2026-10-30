namespace PWC.Level;

public interface ILevelPlant
{

	public bool DidGrowComplete() { }

	public bool IsAlive() { }

	public float PlayIncrementSound() { }

	public void SetPlantPot(LevelPlantPot plantPot) { }

	public bool TryIncrementPlant() { }

}

