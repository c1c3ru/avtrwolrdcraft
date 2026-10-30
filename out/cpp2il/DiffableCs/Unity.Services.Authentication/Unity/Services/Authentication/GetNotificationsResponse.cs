namespace Unity.Services.Authentication;

internal class GetNotificationsResponse
{
	[JsonProperty("notifications")]
	public List<NotificationResponse> Notifications; //Field offset: 0x10

	[Preserve]
	public GetNotificationsResponse() { }

	public List<Notification> ToNotificationList() { }

}

