namespace UnityEngine;

public struct Pose : IEquatable<Pose>
{
	private static readonly Pose k_Identity; //Field offset: 0x0
	public Vector3 position; //Field offset: 0x0
	public Quaternion rotation; //Field offset: 0xC

	private static Pose() { }

	public Pose(Vector3 position, Quaternion rotation) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(Pose other) { }

	public virtual int GetHashCode() { }

	public virtual string ToString() { }

}

