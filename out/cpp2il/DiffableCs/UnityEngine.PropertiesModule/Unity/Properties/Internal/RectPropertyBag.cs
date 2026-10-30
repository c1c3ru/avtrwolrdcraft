namespace Unity.Properties.Internal;

internal class RectPropertyBag : ContainerPropertyBag<Rect>
{
	private class HeightProperty : Property<Rect, Single>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public HeightProperty() { }

		public virtual string get_Name() { }

	}

	private class WidthProperty : Property<Rect, Single>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public WidthProperty() { }

		public virtual string get_Name() { }

	}

	private class XProperty : Property<Rect, Single>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public XProperty() { }

		public virtual string get_Name() { }

	}

	private class YProperty : Property<Rect, Single>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public YProperty() { }

		public virtual string get_Name() { }

	}


	public RectPropertyBag() { }

}

