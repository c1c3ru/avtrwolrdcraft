namespace Game.Level;

public class SpriteAlphaSetter : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private float _changeTime; //Field offset: 0x28

	public SpriteAlphaSetter() { }

	public void StopTransition() { }

	public void TransitionToNewAlpha(float alphaTarget) { }

}

