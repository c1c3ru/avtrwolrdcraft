namespace Unity.Properties;

public sealed class ArrayPropertyBag : IndexedCollectionPropertyBag<TElement[], TElement>
{

	protected virtual InstantiationKind InstantiationKind
	{
		 get { } //Length: 8
	}

	public ArrayPropertyBag`1() { }

	protected virtual InstantiationKind get_InstantiationKind() { }

	protected virtual TElement[] Instantiate() { }

	protected virtual TElement[] InstantiateWithCount(int count) { }

}

