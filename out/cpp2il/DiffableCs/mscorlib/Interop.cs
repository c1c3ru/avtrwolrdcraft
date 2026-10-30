//Type is in global namespace

internal static class Interop
{
	public enum Error
	{
		SUCCESS = 0,
		E2BIG = 65537,
		EACCES = 65538,
		EADDRINUSE = 65539,
		EADDRNOTAVAIL = 65540,
		EAFNOSUPPORT = 65541,
		EAGAIN = 65542,
		EALREADY = 65543,
		EBADF = 65544,
		EBADMSG = 65545,
		EBUSY = 65546,
		ECANCELED = 65547,
		ECHILD = 65548,
		ECONNABORTED = 65549,
		ECONNREFUSED = 65550,
		ECONNRESET = 65551,
		EDEADLK = 65552,
		EDESTADDRREQ = 65553,
		EDOM = 65554,
		EDQUOT = 65555,
		EEXIST = 65556,
		EFAULT = 65557,
		EFBIG = 65558,
		EHOSTUNREACH = 65559,
		EIDRM = 65560,
		EILSEQ = 65561,
		EINPROGRESS = 65562,
		EINTR = 65563,
		EINVAL = 65564,
		EIO = 65565,
		EISCONN = 65566,
		EISDIR = 65567,
		ELOOP = 65568,
		EMFILE = 65569,
		EMLINK = 65570,
		EMSGSIZE = 65571,
		EMULTIHOP = 65572,
		ENAMETOOLONG = 65573,
		ENETDOWN = 65574,
		ENETRESET = 65575,
		ENETUNREACH = 65576,
		ENFILE = 65577,
		ENOBUFS = 65578,
		ENODEV = 65580,
		ENOENT = 65581,
		ENOEXEC = 65582,
		ENOLCK = 65583,
		ENOLINK = 65584,
		ENOMEM = 65585,
		ENOMSG = 65586,
		ENOPROTOOPT = 65587,
		ENOSPC = 65588,
		ENOSYS = 65591,
		ENOTCONN = 65592,
		ENOTDIR = 65593,
		ENOTEMPTY = 65594,
		ENOTSOCK = 65596,
		ENOTSUP = 65597,
		ENOTTY = 65598,
		ENXIO = 65599,
		EOVERFLOW = 65600,
		EPERM = 65602,
		EPIPE = 65603,
		EPROTO = 65604,
		EPROTONOSUPPORT = 65605,
		EPROTOTYPE = 65606,
		ERANGE = 65607,
		EROFS = 65608,
		ESPIPE = 65609,
		ESRCH = 65610,
		ESTALE = 65611,
		ETIMEDOUT = 65613,
		ETXTBSY = 65614,
		EXDEV = 65615,
		ESOCKTNOSUPPORT = 65630,
		EPFNOSUPPORT = 65632,
		ESHUTDOWN = 65644,
		EHOSTDOWN = 65648,
		ENODATA = 65649,
		EOPNOTSUPP = 65597,
		EWOULDBLOCK = 65542,
	}

	public struct ErrorInfo
	{
		private Error _error; //Field offset: 0x0
		private int _rawErrno; //Field offset: 0x4

		internal Error Error
		{
			internal get { } //Length: 8
		}

		internal int RawErrno
		{
			internal get { } //Length: 108
		}

		internal ErrorInfo(int errno) { }

		internal ErrorInfo(Error error) { }

		internal Error get_Error() { }

		internal int get_RawErrno() { }

		internal string GetErrorMessage() { }

		public virtual string ToString() { }

	}

	public static class Sys
	{
		public struct DirectoryEntry
		{
			internal Byte* Name; //Field offset: 0x0
			internal int NameLength; //Field offset: 0x8
			internal NodeType InodeType; //Field offset: 0xC

			internal ReadOnlySpan<Char> GetName(Span<Char> buffer) { }

		}

		public struct FileStatus
		{
			internal FileStatusFlags Flags; //Field offset: 0x0
			internal int Mode; //Field offset: 0x4
			internal uint Uid; //Field offset: 0x8
			internal uint Gid; //Field offset: 0xC
			internal long Size; //Field offset: 0x10
			internal long ATime; //Field offset: 0x18
			internal long ATimeNsec; //Field offset: 0x20
			internal long MTime; //Field offset: 0x28
			internal long MTimeNsec; //Field offset: 0x30
			internal long CTime; //Field offset: 0x38
			internal long CTimeNsec; //Field offset: 0x40
			internal long BirthTime; //Field offset: 0x48
			internal long BirthTimeNsec; //Field offset: 0x50
			internal long Dev; //Field offset: 0x58
			internal long Ino; //Field offset: 0x60
			internal uint UserFlags; //Field offset: 0x68

		}

		[Flags]
		public enum FileStatusFlags
		{
			None = 0,
			HasBirthTime = 1,
		}

		public enum NodeType
		{
			DT_UNKNOWN = 0,
			DT_FIFO = 1,
			DT_CHR = 2,
			DT_DIR = 4,
			DT_BLK = 6,
			DT_REG = 8,
			DT_LNK = 10,
			DT_SOCK = 12,
			DT_WHT = 14,
		}

		[Flags]
		public enum Permissions
		{
			Mask = 511,
			S_IRWXU = 448,
			S_IRUSR = 256,
			S_IWUSR = 128,
			S_IXUSR = 64,
			S_IRWXG = 56,
			S_IRGRP = 32,
			S_IWGRP = 16,
			S_IXGRP = 8,
			S_IRWXO = 7,
			S_IROTH = 4,
			S_IWOTH = 2,
			S_IXOTH = 1,
		}

		public struct TimeValPair
		{
			internal long ASec; //Field offset: 0x0
			internal long AUSec; //Field offset: 0x8
			internal long MSec; //Field offset: 0x10
			internal long MUSec; //Field offset: 0x18

		}

		internal static readonly bool CanSetHiddenFlag; //Field offset: 0x0

		private static Sys() { }

		internal static int CloseDir(IntPtr dir) { }

		internal static int ConvertErrorPalToPlatform(Error error) { }

		internal static Error ConvertErrorPlatformToPal(int platformErrno) { }

		internal static int CopyFile(SafeFileHandle source, SafeFileHandle destination) { }

		internal static int DoubleToString(double value, Byte* format, Byte* buffer, int bufferLength) { }

		internal static uint GetEGid() { }

		internal static uint GetEUid() { }

		internal static ErrorInfo GetLastErrorInfo() { }

		internal static void GetNonCryptographicallySecureRandomBytes(Byte* buffer, int length) { }

		internal static int GetReadDirRBufferSize() { }

		private static int LChflagsCanSetHiddenFlag() { }

		internal static int LStat(string path, out FileStatus output) { }

		internal static int LStat(ReadOnlySpan<Char> path, out FileStatus output) { }

		internal static int LStat(ref byte path, out FileStatus output) { }

		internal static int MkDir(string path, int mode) { }

		internal static IntPtr OpenDir(string path) { }

		internal static int ReadDirR(IntPtr dir, Byte* buffer, int bufferSize, out DirectoryEntry outputEntry) { }

		private static int ReadLink(string path, Byte[] buffer, int bufferSize) { }

		public static string ReadLink(string path) { }

		internal static int RmDir(string path) { }

		internal static int Stat(ReadOnlySpan<Char> path, out FileStatus output) { }

		internal static int Stat(string path, out FileStatus output) { }

		internal static int Stat(ref byte path, out FileStatus output) { }

		internal static string StrError(int platformErrno) { }

		private static Byte* StrErrorR(int platformErrno, Byte* buffer, int bufferSize) { }

		internal static int Symlink(string target, string linkPath) { }

		internal static int Unlink(string pathname) { }

		internal static int UTimes(string path, ref TimeValPair times) { }

	}


	internal static long CheckIo(long result, string path = null, bool isDirectory = false, Func<ErrorInfo, ErrorInfo> errorRewriter = null) { }

	internal static int CheckIo(int result, string path = null, bool isDirectory = false, Func<ErrorInfo, ErrorInfo> errorRewriter = null) { }

	internal static Exception GetExceptionForIoErrno(ErrorInfo errorInfo, string path = null, bool isDirectory = false) { }

	internal static Exception GetIOException(ErrorInfo errorInfo) { }

	internal static void GetRandomBytes(Byte* buffer, int length) { }

	private static void ThrowExceptionForIoErrno(ErrorInfo errorInfo, string path, bool isDirectory, Func<ErrorInfo, ErrorInfo> errorRewriter) { }

}

