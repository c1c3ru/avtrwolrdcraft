namespace PWC.Level;

public class LevelJugDrinkable : LevelDrinkableWithFillItemHandler
{
	[SerializeField]
	private LevelJugContainer _jugContainer; //Field offset: 0x110
	[SerializeField]
	private float _emptyLiquidYPosition; //Field offset: 0x118

	public LevelJugDrinkable() { }

	public virtual bool CanBeDrinked() { }

	public virtual float GetEmptyLiquidYPosition() { }

}

