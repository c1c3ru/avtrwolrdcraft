namespace ClipperLib;

public class Clipper : ClipperBase
{
	public enum NodeType
	{
		ntAny = 0,
		ntOpen = 1,
		ntClosed = 2,
	}

	public const int ioReverseSolution = 1; //Field offset: 0x0
	public const int ioStrictlySimple = 2; //Field offset: 0x0
	public const int ioPreserveCollinear = 4; //Field offset: 0x0
	private ClipType m_ClipType; //Field offset: 0x44
	private Maxima m_Maxima; //Field offset: 0x48
	private TEdge m_SortedEdges; //Field offset: 0x50
	private List<IntersectNode> m_IntersectList; //Field offset: 0x58
	private IComparer<IntersectNode> m_IntersectNodeComparer; //Field offset: 0x60
	private bool m_ExecuteLocked; //Field offset: 0x68
	private PolyFillType m_ClipFillType; //Field offset: 0x6C
	private PolyFillType m_SubjFillType; //Field offset: 0x70
	private List<Join> m_Joins; //Field offset: 0x78
	private List<Join> m_GhostJoins; //Field offset: 0x80
	private bool m_UsingPolyTree; //Field offset: 0x88
	[CompilerGenerated]
	private bool <ReverseSolution>k__BackingField; //Field offset: 0x89
	[CompilerGenerated]
	private bool <StrictlySimple>k__BackingField; //Field offset: 0x8A

	public bool ReverseSolution
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool StrictlySimple
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public Clipper(int InitOptions = 0) { }

	private void AddEdgeToSEL(TEdge edge) { }

	private void AddGhostJoin(OutPt Op, IntPoint OffPt) { }

	private void AddJoin(OutPt Op1, OutPt Op2, IntPoint OffPt) { }

	private void AddLocalMaxPoly(TEdge e1, TEdge e2, IntPoint pt) { }

	private OutPt AddLocalMinPoly(TEdge e1, TEdge e2, IntPoint pt) { }

	private OutPt AddOutPt(TEdge e, IntPoint pt) { }

	internal static void AddPolyNodeToPaths(PolyNode polynode, NodeType nt, List<List`1<IntPoint>> paths) { }

	private void AppendPolygon(TEdge e1, TEdge e2) { }

	internal double Area(OutPt op) { }

	internal double Area(OutRec outRec) { }

	public static double Area(List<IntPoint> poly) { }

	private void BuildIntersectList(long topY) { }

	private void BuildResult(List<List`1<IntPoint>> polyg) { }

	private void BuildResult2(PolyTree polytree) { }

	public static List<IntPoint> CleanPolygon(List<IntPoint> path, double distance = 1,415) { }

	public static List<List`1<IntPoint>> CleanPolygons(List<List`1<IntPoint>> polys, double distance = 1,415) { }

	public static List<List`1<IntPoint>> ClosedPathsFromPolyTree(PolyTree polytree) { }

	private void CopyAELToSEL() { }

	private void DeleteFromSEL(TEdge e) { }

	private void DisposeAllPolyPts() { }

	private static double DistanceFromLineSqrd(IntPoint pt, IntPoint ln1, IntPoint ln2) { }

	private static double DistanceSqrd(IntPoint pt1, IntPoint pt2) { }

	private void DoMaxima(TEdge e) { }

	private void DoSimplePolygons() { }

	private OutPt DupOutPt(OutPt outPt, bool InsertAfter) { }

	private bool E2InsertsBeforeE1(TEdge e1, TEdge e2) { }

	private bool EdgesAdjacent(IntersectNode inode) { }

	private static OutPt ExcludeOp(OutPt op) { }

	public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType subjFillType, PolyFillType clipFillType) { }

	public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType FillType = 0) { }

	public bool Execute(ClipType clipType, List<List`1<IntPoint>> solution, PolyFillType subjFillType, PolyFillType clipFillType) { }

	public bool Execute(ClipType clipType, List<List`1<IntPoint>> solution, PolyFillType FillType = 0) { }

	private bool ExecuteInternal() { }

	private bool FirstIsBottomPt(OutPt btmPt1, OutPt btmPt2) { }

	internal void FixHoleLinkage(OutRec outRec) { }

	private void FixupFirstLefts1(OutRec OldOutRec, OutRec NewOutRec) { }

	private void FixupFirstLefts2(OutRec innerOutRec, OutRec outerOutRec) { }

	private void FixupFirstLefts3(OutRec OldOutRec, OutRec NewOutRec) { }

	private bool FixupIntersectionOrder() { }

	private void FixupOutPolygon(OutRec outRec) { }

	private void FixupOutPolyline(OutRec outrec) { }

	[CompilerGenerated]
	public bool get_ReverseSolution() { }

	[CompilerGenerated]
	public bool get_StrictlySimple() { }

	private OutPt GetBottomPt(OutPt pp) { }

	private double GetDx(IntPoint pt1, IntPoint pt2) { }

	private void GetHorzDirection(TEdge HorzEdge, out Direction Dir, out long Left, out long Right) { }

	private OutPt GetLastOutPt(TEdge e) { }

	private OutRec GetLowermostRec(OutRec outRec1, OutRec outRec2) { }

	internal TEdge GetMaximaPair(TEdge e) { }

	internal TEdge GetMaximaPairEx(TEdge e) { }

	private TEdge GetNextInAEL(TEdge e, Direction Direction) { }

	private OutRec GetOutRec(int idx) { }

	private bool GetOverlap(long a1, long a2, long b1, long b2, out long Left, out long Right) { }

	private bool HorzSegmentsOverlap(long seg1a, long seg1b, long seg2a, long seg2b) { }

	private void InsertEdgeIntoAEL(TEdge edge, TEdge startEdge) { }

	private void InsertLocalMinimaIntoAEL(long botY) { }

	private void InsertMaxima(long X) { }

	private void IntersectEdges(TEdge e1, TEdge e2, IntPoint pt) { }

	private static int IntersectNodeSort(IntersectNode node1, IntersectNode node2) { }

	private void IntersectPoint(TEdge edge1, TEdge edge2, out IntPoint ip) { }

	private bool IsContributing(TEdge edge) { }

	private bool IsEvenOddAltFillType(TEdge edge) { }

	private bool IsEvenOddFillType(TEdge edge) { }

	private bool IsIntermediate(TEdge e, double Y) { }

	private bool IsMaxima(TEdge e, double Y) { }

	private bool IsMinima(TEdge e) { }

	private void JoinCommonEdges() { }

	private bool JoinHorz(OutPt op1, OutPt op1b, OutPt op2, OutPt op2b, IntPoint Pt, bool DiscardLeft) { }

	private bool JoinPoints(Join j, OutRec outRec1, OutRec outRec2) { }

	internal static List<List`1<IntPoint>> Minkowski(List<IntPoint> pattern, List<IntPoint> path, bool IsSum, bool IsClosed) { }

	public static List<List`1<IntPoint>> MinkowskiDiff(List<IntPoint> poly1, List<IntPoint> poly2) { }

	public static List<List`1<IntPoint>> MinkowskiSum(List<IntPoint> pattern, List<IntPoint> path, bool pathIsClosed) { }

	public static List<List`1<IntPoint>> MinkowskiSum(List<IntPoint> pattern, List<List`1<IntPoint>> paths, bool pathIsClosed) { }

	public static List<List`1<IntPoint>> OpenPathsFromPolyTree(PolyTree polytree) { }

	public static bool Orientation(List<IntPoint> poly) { }

	private bool OutRec1RightOfOutRec2(OutRec outRec1, OutRec outRec2) { }

	private static OutRec ParseFirstLeft(OutRec FirstLeft) { }

	private int PointCount(OutPt pts) { }

	public static int PointInPolygon(IntPoint pt, List<IntPoint> path) { }

	private static int PointInPolygon(IntPoint pt, OutPt op) { }

	private static bool PointsAreClose(IntPoint pt1, IntPoint pt2, double distSqrd) { }

	private static bool Poly2ContainsPoly1(OutPt outPt1, OutPt outPt2) { }

	public static List<List`1<IntPoint>> PolyTreeToPaths(PolyTree polytree) { }

	internal bool PopEdgeFromSEL(out TEdge e) { }

	private void ProcessEdgesAtTopOfScanbeam(long topY) { }

	private void ProcessHorizontal(TEdge horzEdge) { }

	private void ProcessHorizontals() { }

	private bool ProcessIntersections(long topY) { }

	private void ProcessIntersectList() { }

	public static void ReversePaths(List<List`1<IntPoint>> polys) { }

	private void ReversePolyPtLinks(OutPt pp) { }

	internal static long Round(double value) { }

	[CompilerGenerated]
	public void set_ReverseSolution(bool value) { }

	[CompilerGenerated]
	public void set_StrictlySimple(bool value) { }

	private void SetHoleState(TEdge e, OutRec outRec) { }

	private void SetWindingCount(TEdge edge) { }

	public static List<List`1<IntPoint>> SimplifyPolygon(List<IntPoint> poly, PolyFillType fillType = 0) { }

	public static List<List`1<IntPoint>> SimplifyPolygons(List<List`1<IntPoint>> polys, PolyFillType fillType = 0) { }

	private static bool SlopesNearCollinear(IntPoint pt1, IntPoint pt2, IntPoint pt3, double distSqrd) { }

	internal void SwapPoints(ref IntPoint pt1, ref IntPoint pt2) { }

	private static void SwapPolyIndexes(TEdge edge1, TEdge edge2) { }

	private void SwapPositionsInSEL(TEdge edge1, TEdge edge2) { }

	private static void SwapSides(TEdge edge1, TEdge edge2) { }

	private static long TopX(TEdge edge, long currentY) { }

	private static List<IntPoint> TranslatePath(List<IntPoint> path, IntPoint delta) { }

	private void UpdateOutPtIdxs(OutRec outrec) { }

}

