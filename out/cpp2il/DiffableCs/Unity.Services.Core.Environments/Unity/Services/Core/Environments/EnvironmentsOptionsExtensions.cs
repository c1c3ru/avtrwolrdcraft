namespace Unity.Services.Core.Environments;

[Extension]
public static class EnvironmentsOptionsExtensions
{
	internal const string EnvironmentNameKey = "com.unity.services.core.environment-name"; //Field offset: 0x0
	internal const string EnvironmentDefaultNameValue = "production"; //Field offset: 0x0

	[Extension]
	public static InitializationOptions SetEnvironmentName(InitializationOptions self, string environmentName) { }

}

