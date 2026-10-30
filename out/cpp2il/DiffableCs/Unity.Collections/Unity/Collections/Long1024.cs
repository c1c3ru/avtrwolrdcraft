namespace Unity.Collections;

internal struct Long1024 : IIndexable<Int64>
{
	internal Long512 f0; //Field offset: 0x0
	internal Long512 f1; //Field offset: 0x1000

	public override int Length
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public override long ElementAt(int index) { }

	public override int get_Length() { }

	public override void set_Length(int value) { }

}

