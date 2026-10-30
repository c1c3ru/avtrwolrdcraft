namespace Google.Play.Integrity;

public enum StandardIntegrityErrorCode
{
	NoError = 0,
	ApiNotAvailable = -1,
	PlayStoreNotFound = -2,
	NetworkError = -3,
	AppNotInstalled = -5,
	PlayServicesNotFound = -6,
	AppUidMismatch = -7,
	TooManyRequests = -8,
	CannotBindToService = -9,
	GoogleServerUnavailable = -12,
	PlayStoreVersionOutdated = -14,
	PlayServicesVersionOutdated = -15,
	CloudProjectNumberIsInvalid = -16,
	RequestHashTooLong = -17,
	ClientTransientError = -18,
	IntegrityTokenProviderInvalid = -19,
	InternalError = -100,
}

