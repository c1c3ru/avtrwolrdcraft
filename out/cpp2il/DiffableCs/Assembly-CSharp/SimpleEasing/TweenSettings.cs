namespace SimpleEasing;

public class TweenSettings
{
	[HideInInspector]
	[Obsolete("Confusing if inconsistently used, enclosing class should decide whether easing information is applied")]
	public bool eased; //Field offset: 0x10
	public bool useCustomCurve; //Field offset: 0x11
	public EasingTypes easing; //Field offset: 0x14
	[Tooltip("A curve going from 0 to 1")]
	public AnimationCurve animationCurve; //Field offset: 0x18
	public float animationLength; //Field offset: 0x20
	[Tooltip("Whether timescale affects the easing")]
	public bool unscaledTime; //Field offset: 0x24
	public TweenRepeat animationRepeat; //Field offset: 0x28

	public TweenSettings() { }

}

