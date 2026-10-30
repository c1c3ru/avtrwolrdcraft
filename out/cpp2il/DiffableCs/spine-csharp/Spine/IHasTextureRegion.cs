namespace Spine;

public interface IHasTextureRegion
{

	public float A
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public float B
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public float G
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string Path
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public float R
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public TextureRegion Region
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Sequence Sequence
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public float get_A() { }

	public float get_B() { }

	public float get_G() { }

	public string get_Path() { }

	public float get_R() { }

	public TextureRegion get_Region() { }

	public Sequence get_Sequence() { }

	public void set_A(float value) { }

	public void set_B(float value) { }

	public void set_G(float value) { }

	public void set_Path(string value) { }

	public void set_R(float value) { }

	public void set_Region(TextureRegion value) { }

	public void set_Sequence(Sequence value) { }

	public void UpdateRegion() { }

}

