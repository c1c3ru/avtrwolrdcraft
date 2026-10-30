namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCTweenScale : AFCTweenBase
{
	[SerializeField]
	protected Vector2 _from; //Field offset: 0x48
	[SerializeField]
	protected Vector2 _to; //Field offset: 0x50

	public AFCTweenScale() { }

	public virtual void PlayTween() { }

}

