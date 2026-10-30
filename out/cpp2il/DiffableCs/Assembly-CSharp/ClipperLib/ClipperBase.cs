namespace ClipperLib;

public class ClipperBase
{
	internal const double horizontal = -3,4E+38; //Field offset: 0x0
	internal const int Skip = -2; //Field offset: 0x0
	internal const int Unassigned = -1; //Field offset: 0x0
	internal const double tolerance = 1E-20; //Field offset: 0x0
	public const long loRange = 1073741823; //Field offset: 0x0
	public const long hiRange = 4611686018427387903; //Field offset: 0x0
	internal LocalMinima m_MinimaList; //Field offset: 0x10
	internal LocalMinima m_CurrentLM; //Field offset: 0x18
	internal List<List`1<TEdge>> m_edges; //Field offset: 0x20
	internal Scanbeam m_Scanbeam; //Field offset: 0x28
	internal List<OutRec> m_PolyOuts; //Field offset: 0x30
	internal TEdge m_ActiveEdges; //Field offset: 0x38
	internal bool m_UseFullRange; //Field offset: 0x40
	internal bool m_HasOpenPaths; //Field offset: 0x41
	[CompilerGenerated]
	private bool <PreserveCollinear>k__BackingField; //Field offset: 0x42

	public bool PreserveCollinear
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	internal ClipperBase() { }

	public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed) { }

	public bool AddPaths(List<List`1<IntPoint>> ppg, PolyType polyType, bool closed) { }

	public override void Clear() { }

	internal OutRec CreateOutRec() { }

	internal void DeleteFromAEL(TEdge e) { }

	private void DisposeLocalMinimaList() { }

	internal void DisposeOutRec(int index) { }

	private TEdge FindNextLocMin(TEdge E) { }

	[CompilerGenerated]
	public bool get_PreserveCollinear() { }

	public static IntRect GetBounds(List<List`1<IntPoint>> paths) { }

	private void InitEdge(TEdge e, TEdge eNext, TEdge ePrev, IntPoint pt) { }

	private void InitEdge2(TEdge e, PolyType polyType) { }

	private void InsertLocalMinima(LocalMinima newLm) { }

	internal void InsertScanbeam(long Y) { }

	internal static bool IsHorizontal(TEdge e) { }

	internal bool LocalMinimaPending() { }

	internal static bool near_zero(double val) { }

	internal bool PointIsVertex(IntPoint pt, OutPt pp) { }

	internal bool PointOnLineSegment(IntPoint pt, IntPoint linePt1, IntPoint linePt2, bool UseFullRange) { }

	internal bool PointOnPolygon(IntPoint pt, OutPt pp, bool UseFullRange) { }

	internal bool PopLocalMinima(long Y, out LocalMinima current) { }

	internal bool PopScanbeam(out long Y) { }

	private TEdge ProcessBound(TEdge E, bool LeftBoundIsForward) { }

	internal bool Pt2IsBetweenPt1AndPt3(IntPoint pt1, IntPoint pt2, IntPoint pt3) { }

	private void RangeTest(IntPoint Pt, ref bool useFullRange) { }

	private TEdge RemoveEdge(TEdge e) { }

	internal override void Reset() { }

	private void ReverseHorizontal(TEdge e) { }

	[CompilerGenerated]
	public void set_PreserveCollinear(bool value) { }

	private void SetDx(TEdge e) { }

	internal static bool SlopesEqual(TEdge e1, TEdge e2, bool UseFullRange) { }

	internal static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, bool UseFullRange) { }

	internal static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, IntPoint pt4, bool UseFullRange) { }

	public void Swap(ref long val1, ref long val2) { }

	internal void SwapPositionsInAEL(TEdge edge1, TEdge edge2) { }

	internal void UpdateEdgeIntoAEL(ref TEdge e) { }

}

