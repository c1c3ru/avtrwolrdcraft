namespace Google.Play.Integrity;

public enum IntegrityErrorCode
{
	NoError = 0,
	ApiNotAvailable = 1,
	PlayStoreNotFound = 2,
	NetworkError = 3,
	PlayStoreAccountNotFound = 4,
	AppNotInstalled = 5,
	PlayServicesNotFound = 6,
	AppUidMismatch = 7,
	TooManyRequests = 8,
	CannotBindToService = 9,
	GoogleServerUnavailable = 10,
	NonceTooShort = 11,
	NonceTooLong = 12,
	NonceIsNotBase64 = 13,
	PlayStoreVersionOutdated = 14,
	PlayServicesVersionOutdated = 15,
	CloudProjectNumberIsInvalid = 16,
	ClientTransientError = 17,
	InternalError = 100,
}

