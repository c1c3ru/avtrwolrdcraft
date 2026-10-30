namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCTweenRotation : AFCTweenBase
{
	[SerializeField]
	protected float _from; //Field offset: 0x48
	[SerializeField]
	protected float _to; //Field offset: 0x4C

	public AFCTweenRotation() { }

	public virtual void PlayTween() { }

}

