namespace UnityEngine.CrashReportHandler;

[NativeHeader("Modules/CrashReporting/Public/CrashReporter.h")]
[StaticAccessor("CrashReporting::CrashReporter::Get()", StaticAccessorType::Dot (0))]
public class CrashReportHandler
{

	[NativeThrows]
	public static void SetUserMetadata(string key, string value) { }

}

