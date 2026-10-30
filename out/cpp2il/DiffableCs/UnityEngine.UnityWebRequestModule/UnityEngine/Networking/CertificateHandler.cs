namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequest/Public/CertificateHandler/CertificateHandlerScript.h")]
public class CertificateHandler : IDisposable
{
	internal IntPtr m_Ptr; //Field offset: 0x10

	protected CertificateHandler() { }

	private static IntPtr Create(CertificateHandler obj) { }

	public override void Dispose() { }

	protected virtual void Finalize() { }

	[NativeMethod(IsThreadSafe = True)]
	private void Release() { }

	protected override bool ValidateCertificate(Byte[] certificateData) { }

	[RequiredByNativeCode]
	internal bool ValidateCertificateNative(Byte[] certificateData) { }

}

