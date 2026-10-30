namespace PazuCore;

public class Country
{
	public string title; //Field offset: 0x10
	public string flagAssetName; //Field offset: 0x18
	public String[] CountryCode; //Field offset: 0x20

	public Country() { }

	public virtual bool Equals(object obj) { }

}

