//Type is in global namespace

public class InfiniteVerticalScroll : InfiniteScroll
{

	public InfiniteVerticalScroll() { }

	protected virtual float GetDimension(Vector2 vector) { }

	protected virtual float GetPos(RectTransform item) { }

	protected virtual float GetSize(RectTransform item) { }

	protected virtual Vector2 GetVector(float value) { }

	protected virtual int OneOrMinusOne() { }

}

