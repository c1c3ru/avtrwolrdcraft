namespace Unity.Properties.Internal;

internal class Vector3PropertyBag : ContainerPropertyBag<Vector3>
{
	private class XProperty : Property<Vector3, Single>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public XProperty() { }

		public virtual string get_Name() { }

	}

	private class YProperty : Property<Vector3, Single>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public YProperty() { }

		public virtual string get_Name() { }

	}

	private class ZProperty : Property<Vector3, Single>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public ZProperty() { }

		public virtual string get_Name() { }

	}


	public Vector3PropertyBag() { }

}

