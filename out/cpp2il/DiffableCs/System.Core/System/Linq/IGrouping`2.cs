namespace System.Linq;

public interface IGrouping : IEnumerable<TElement>, IEnumerable
{

	public TKey Key
	{
		 get { } //Length: 0
	}

	public TKey get_Key() { }

}

