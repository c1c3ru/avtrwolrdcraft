namespace System.Diagnostics;

[AttributeUsage(AttributeTargets::All (32767))]
public class MonitoringDescriptionAttribute : DescriptionAttribute
{

	public virtual string Description
	{
		 get { } //Length: 8
	}

	public MonitoringDescriptionAttribute(string description) { }

	public virtual string get_Description() { }

}

