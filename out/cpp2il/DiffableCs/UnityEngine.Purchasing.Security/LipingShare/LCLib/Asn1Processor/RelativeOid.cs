namespace LipingShare.LCLib.Asn1Processor;

internal class RelativeOid : Oid
{

	public RelativeOid() { }

	public virtual string Decode(Stream bt) { }

	public virtual void Encode(Stream bt, string oidStr) { }

}

