namespace Unity.Collections;

public interface IIndexable
{

	public int Length
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public T ElementAt(int index) { }

	public int get_Length() { }

	public void set_Length(int value) { }

}

