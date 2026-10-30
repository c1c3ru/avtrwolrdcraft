//Type is in global namespace

public interface IMovementCtrl
{

	public float GetDistance(float deltaTime) { }

	public bool IsMovementEnded() { }

	public void SetMovement(float baseValue, bool flag) { }

}

