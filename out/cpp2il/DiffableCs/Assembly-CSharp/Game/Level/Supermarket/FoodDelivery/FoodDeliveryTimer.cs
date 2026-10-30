namespace Game.Level.Supermarket.FoodDelivery;

public class FoodDeliveryTimer : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite[] _states; //Field offset: 0x28
	private int _timeLimit; //Field offset: 0x30
	private int _currentSpriteIndex; //Field offset: 0x34

	public FoodDeliveryTimer() { }

	public int OnTimeLeftChanged(int timeLeft) { }

	public void SetTimeLimit(int timeLimit) { }

	public void SyncAppearance(int timeLeft) { }

	private void UpdateSprite() { }

}

