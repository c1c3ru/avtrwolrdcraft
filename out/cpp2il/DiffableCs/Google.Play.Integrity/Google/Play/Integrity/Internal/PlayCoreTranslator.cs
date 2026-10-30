namespace Google.Play.Integrity.Internal;

internal static class PlayCoreTranslator
{
	private static class JavaIntegrityErrorCode
	{
		public const int NoError = 0; //Field offset: 0x0
		public const int CloudProjectNumberIsInvalid = -16; //Field offset: 0x0
		public const int PlayServicesVersionOutdated = -15; //Field offset: 0x0
		public const int PlayStoreVersionOutdated = -14; //Field offset: 0x0
		public const int NonceIsNotBase64 = -13; //Field offset: 0x0
		public const int GoogleServerUnavailable = -12; //Field offset: 0x0
		public const int NonceTooLong = -11; //Field offset: 0x0
		public const int NonceTooShort = -10; //Field offset: 0x0
		public const int ClientTransientError = -17; //Field offset: 0x0
		public const int CannotBindToService = -9; //Field offset: 0x0
		public const int AppUidMismatch = -7; //Field offset: 0x0
		public const int PlayServicesNotFound = -6; //Field offset: 0x0
		public const int AppNotInstalled = -5; //Field offset: 0x0
		public const int PlayStoreAccountNotFound = -4; //Field offset: 0x0
		public const int NetworkError = -3; //Field offset: 0x0
		public const int PlayStoreNotFound = -2; //Field offset: 0x0
		public const int ApiNotAvailable = -1; //Field offset: 0x0
		public const int TooManyRequests = -8; //Field offset: 0x0
		public const int InternalError = -100; //Field offset: 0x0

	}

	private static class JavaStandardIntegrityErrorCode
	{
		public const int NoError = 0; //Field offset: 0x0
		public const int ClientTransientError = -18; //Field offset: 0x0
		public const int RequestHashTooLong = -17; //Field offset: 0x0
		public const int CloudProjectNumberIsInvalid = -16; //Field offset: 0x0
		public const int PlayServicesVersionOutdated = -15; //Field offset: 0x0
		public const int PlayStoreVersionOutdated = -14; //Field offset: 0x0
		public const int GoogleServerUnavailable = -12; //Field offset: 0x0
		public const int IntegrityTokenProviderInvalid = -19; //Field offset: 0x0
		public const int CannotBindToService = -9; //Field offset: 0x0
		public const int AppUidMismatch = -7; //Field offset: 0x0
		public const int PlayServicesNotFound = -6; //Field offset: 0x0
		public const int AppNotInstalled = -5; //Field offset: 0x0
		public const int NetworkError = -3; //Field offset: 0x0
		public const int PlayStoreNotFound = -2; //Field offset: 0x0
		public const int ApiNotAvailable = -1; //Field offset: 0x0
		public const int TooManyRequests = -8; //Field offset: 0x0
		public const int InternalError = -100; //Field offset: 0x0

	}

	private static readonly Dictionary<Int32, IntegrityErrorCode> PlayCoreToIntegrityErrors; //Field offset: 0x0
	private static readonly Dictionary<Int32, StandardIntegrityErrorCode> PlayCoreToStandardIntegrityErrors; //Field offset: 0x8

	private static PlayCoreTranslator() { }

	public static IntegrityErrorCode TranslatePlayCoreErrorCode(int javaIntegrityErrorCode) { }

	public static StandardIntegrityErrorCode TranslatePlayCoreStandardIntegrityErrorCode(int javaStandardIntegrityErrorCode) { }

}

