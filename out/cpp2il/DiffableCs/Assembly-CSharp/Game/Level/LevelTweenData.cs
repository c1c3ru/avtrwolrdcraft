namespace Game.Level;

public class LevelTweenData
{
	internal enum TweenMovement
	{
		Position = 0,
		Scale = 1,
		Rotation = 2,
	}

	public TweenMovement movement; //Field offset: 0x10
	[ConditionalField("movement", TweenMovement::Position (0), True, (array) null)]
	public Vector2 position; //Field offset: 0x14
	[ConditionalField("movement", TweenMovement::Scale (1), True, (array) null)]
	public Vector2 scale; //Field offset: 0x1C
	[ConditionalField("movement", TweenMovement::Rotation (2), True, (array) null)]
	public float angle; //Field offset: 0x24
	public float time; //Field offset: 0x28
	public LeanTweenType tweenType; //Field offset: 0x2C
	public int loopCount; //Field offset: 0x30
	public LeanTweenType loopType; //Field offset: 0x34
	public bool callOnCompleteOnRepeat; //Field offset: 0x38
	public UnityEvent onComplete; //Field offset: 0x40

	public LevelTweenData() { }

}

