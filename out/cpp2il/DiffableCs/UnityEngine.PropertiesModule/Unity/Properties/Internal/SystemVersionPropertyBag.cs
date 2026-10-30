namespace Unity.Properties.Internal;

internal class SystemVersionPropertyBag : ContainerPropertyBag<Version>
{
	private class BuildProperty : Property<Version, Int32>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public BuildProperty() { }

		public virtual string get_Name() { }

	}

	private class MajorProperty : Property<Version, Int32>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public MajorProperty() { }

		public virtual string get_Name() { }

	}

	private class MinorProperty : Property<Version, Int32>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public MinorProperty() { }

		public virtual string get_Name() { }

	}

	private class RevisionProperty : Property<Version, Int32>
	{

		public virtual string Name
		{
			 get { } //Length: 64
		}

		public RevisionProperty() { }

		public virtual string get_Name() { }

	}


	public SystemVersionPropertyBag() { }

}

