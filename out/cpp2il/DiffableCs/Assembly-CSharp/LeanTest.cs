//Type is in global namespace

public class LeanTest
{
	public static int expected; //Field offset: 0x0
	private static int tests; //Field offset: 0x4
	private static int passes; //Field offset: 0x8
	public static float timeout; //Field offset: 0xC
	public static bool timeoutStarted; //Field offset: 0x10
	public static bool testsFinished; //Field offset: 0x11

	private static LeanTest() { }

	public LeanTest() { }

	public static void debug(string name, bool didPass, string failExplaination = null) { }

	public static void expect(bool didPass, string definition, string failExplaination = null) { }

	public static string formatB(string str) { }

	public static string formatBC(string str, string color) { }

	public static string formatC(string str, string color) { }

	public static void overview() { }

	public static string padRight(int len) { }

	public static float printOutLength(string str) { }

}

