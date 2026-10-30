namespace PWC.CarsMaker;

public class CarSpriteAnimation
{
	public string AnimationName; //Field offset: 0x10
	public List<CarSpriteAnimationTarget> Targets; //Field offset: 0x18
	public List<GameObject> ShownObjects; //Field offset: 0x20
	public List<GameObject> HiddenObjects; //Field offset: 0x28
	public float Duration; //Field offset: 0x30
	public LeanTweenType Ease; //Field offset: 0x34
	public bool PingPong; //Field offset: 0x38
	public UnityEvent OnTriggered; //Field offset: 0x40
	public UnityEvent OnStopped; //Field offset: 0x48

	public CarSpriteAnimation() { }

}

