namespace Poly2Tri.Triangulation;

public class TriangulationConstraint : Edge
{
	[CompilerGenerated]
	private uint <ConstraintCode>k__BackingField; //Field offset: 0x20

	public private uint ConstraintCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public TriangulationPoint P
	{
		 get { } //Length: 124
		 set { } //Length: 88
	}

	public TriangulationPoint Q
	{
		 get { } //Length: 124
		 set { } //Length: 88
	}

	public TriangulationConstraint(Point2D p1, Point2D p2) { }

	public void CalculateContraintCode() { }

	public static uint CalculateContraintCode(TriangulationPoint p, TriangulationPoint q) { }

	[CompilerGenerated]
	public uint get_ConstraintCode() { }

	public TriangulationPoint get_P() { }

	public TriangulationPoint get_Q() { }

	[CompilerGenerated]
	private void set_ConstraintCode(uint value) { }

	public void set_P(TriangulationPoint value) { }

	public void set_Q(TriangulationPoint value) { }

	public virtual string ToString() { }

}

