namespace System.Xml.Schema;

internal class DoubleLinkAxis : Axis
{
	internal Axis next; //Field offset: 0x40

	internal Axis Next
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal DoubleLinkAxis(Axis axis, DoubleLinkAxis inputaxis) { }

	internal static DoubleLinkAxis ConvertTree(Axis axis) { }

	internal Axis get_Next() { }

	internal void set_Next(Axis value) { }

}

