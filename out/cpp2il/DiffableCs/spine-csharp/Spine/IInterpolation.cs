namespace Spine;

public abstract class IInterpolation
{
	public static IInterpolation Pow2; //Field offset: 0x0
	public static IInterpolation Pow2Out; //Field offset: 0x8

	private static IInterpolation() { }

	protected IInterpolation() { }

	protected abstract float Apply(float a) { }

	public float Apply(float start, float end, float a) { }

}

