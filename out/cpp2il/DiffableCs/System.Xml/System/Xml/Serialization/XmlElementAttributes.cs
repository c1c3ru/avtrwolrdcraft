namespace System.Xml.Serialization;

[DefaultMember("Item")]
public class XmlElementAttributes : CollectionBase
{

	public XmlElementAttribute Item
	{
		 get { } //Length: 256
	}

	internal int Order
	{
		internal get { } //Length: 716
	}

	public XmlElementAttributes() { }

	public int Add(XmlElementAttribute attribute) { }

	internal void AddKeyHash(StringBuilder sb) { }

	public XmlElementAttribute get_Item(int index) { }

	internal int get_Order() { }

}

