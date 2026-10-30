namespace PazuCore;

public class InnerScrollRect : ScrollRect
{
	private ScrollRect _parentScrollRect; //Field offset: 0x130
	private bool _isAffectingParent; //Field offset: 0x138

	public InnerScrollRect() { }

	protected virtual void Awake() { }

	public virtual void OnBeginDrag(PointerEventData eventData) { }

	public virtual void OnDrag(PointerEventData eventData) { }

	public virtual void OnEndDrag(PointerEventData eventData) { }

}

