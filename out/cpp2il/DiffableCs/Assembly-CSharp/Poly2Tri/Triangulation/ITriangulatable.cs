namespace Poly2Tri.Triangulation;

public interface ITriangulatable
{

	public Rect2D Bounds
	{
		 get { } //Length: 0
	}

	public bool DisplayFlipX
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool DisplayFlipY
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public float DisplayRotate
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public double MaxX
	{
		 get { } //Length: 0
	}

	public double MaxY
	{
		 get { } //Length: 0
	}

	public double MinX
	{
		 get { } //Length: 0
	}

	public double MinY
	{
		 get { } //Length: 0
	}

	public double Precision
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IList<DelaunayTriangle> Triangles
	{
		 get { } //Length: 0
	}

	public TriangulationMode TriangulationMode
	{
		 get { } //Length: 0
	}

	public void AddTriangle(DelaunayTriangle t) { }

	public void AddTriangles(IEnumerable<DelaunayTriangle> list) { }

	public void ClearTriangles() { }

	public Rect2D get_Bounds() { }

	public bool get_DisplayFlipX() { }

	public bool get_DisplayFlipY() { }

	public float get_DisplayRotate() { }

	public double get_MaxX() { }

	public double get_MaxY() { }

	public double get_MinX() { }

	public double get_MinY() { }

	public double get_Precision() { }

	public IList<DelaunayTriangle> get_Triangles() { }

	public TriangulationMode get_TriangulationMode() { }

	public void Prepare(TriangulationContext tcx) { }

	public void set_DisplayFlipX(bool value) { }

	public void set_DisplayFlipY(bool value) { }

	public void set_DisplayRotate(float value) { }

	public void set_Precision(double value) { }

}

