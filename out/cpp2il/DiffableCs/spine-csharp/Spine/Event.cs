namespace Spine;

public class Event
{
	internal readonly EventData data; //Field offset: 0x10
	internal readonly float time; //Field offset: 0x18
	internal int intValue; //Field offset: 0x1C
	internal float floatValue; //Field offset: 0x20
	internal string stringValue; //Field offset: 0x28
	internal float volume; //Field offset: 0x30
	internal float balance; //Field offset: 0x34

	public float Balance
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public EventData Data
	{
		 get { } //Length: 8
	}

	public float Float
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int Int
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string String
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Time
	{
		 get { } //Length: 8
	}

	public float Volume
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Event(float time, EventData data) { }

	public float get_Balance() { }

	public EventData get_Data() { }

	public float get_Float() { }

	public int get_Int() { }

	public string get_String() { }

	public float get_Time() { }

	public float get_Volume() { }

	public void set_Balance(float value) { }

	public void set_Float(float value) { }

	public void set_Int(int value) { }

	public void set_String(string value) { }

	public void set_Volume(float value) { }

	public virtual string ToString() { }

}

