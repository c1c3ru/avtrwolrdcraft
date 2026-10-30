namespace Spine.Unity;

public class DoubleBuffered
{
	private readonly T a; //Field offset: 0x0
	private readonly T b; //Field offset: 0x0
	private bool usingA; //Field offset: 0x0

	public DoubleBuffered`1() { }

	public T GetCurrent() { }

	public T GetNext() { }

}

