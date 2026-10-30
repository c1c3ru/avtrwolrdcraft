namespace Unity.Properties.Internal;

internal class RectIntPropertyBag : ContainerPropertyBag<RectInt>
{
	private class HeightProperty : Property<RectInt, Int32>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public HeightProperty() { }

		public virtual string get_Name() { }

	}

	private class WidthProperty : Property<RectInt, Int32>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public WidthProperty() { }

		public virtual string get_Name() { }

	}

	private class XProperty : Property<RectInt, Int32>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public XProperty() { }

		public virtual string get_Name() { }

	}

	private class YProperty : Property<RectInt, Int32>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public YProperty() { }

		public virtual string get_Name() { }

	}


	public RectIntPropertyBag() { }

}

