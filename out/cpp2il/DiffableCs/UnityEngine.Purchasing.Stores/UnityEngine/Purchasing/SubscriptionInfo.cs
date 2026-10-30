namespace UnityEngine.Purchasing;

public class SubscriptionInfo
{
	private readonly Result is_subscribed; //Field offset: 0x10
	private readonly Result is_expired; //Field offset: 0x14
	private readonly Result is_cancelled; //Field offset: 0x18
	private readonly Result is_free_trial; //Field offset: 0x1C
	private readonly Result is_auto_renewing; //Field offset: 0x20
	private readonly Result is_introductory_price_period; //Field offset: 0x24
	private readonly string productId; //Field offset: 0x28
	private readonly DateTime purchaseDate; //Field offset: 0x30
	private readonly DateTime subscriptionExpireDate; //Field offset: 0x38
	private readonly DateTime subscriptionCancelDate; //Field offset: 0x40
	private readonly TimeSpan remainedTime; //Field offset: 0x48
	private readonly string introductory_price; //Field offset: 0x50
	private readonly TimeSpan introductory_price_period; //Field offset: 0x58
	private readonly long introductory_price_cycles; //Field offset: 0x60
	private readonly TimeSpan freeTrialPeriod; //Field offset: 0x68
	private readonly TimeSpan subscriptionPeriod; //Field offset: 0x70
	private readonly string free_trial_period_string; //Field offset: 0x78
	private readonly string sku_details; //Field offset: 0x80

	public SubscriptionInfo(AppleInAppPurchaseReceipt r, string intro_json) { }

	public SubscriptionInfo(string skuDetails, bool isAutoRenewing, DateTime purchaseDate, bool isFreeTrial, bool hasIntroductoryPriceTrial, bool purchaseHistorySupported, string updateMetadata) { }

	public SubscriptionInfo(string productId) { }

	private TimeSpan accumulateIntroductoryDuration(TimeSpanUnits units, long cycles) { }

	private double computeExtraTime(string metadata, double new_sku_period_in_seconds) { }

	private TimeSpan computePeriodTimeSpan(TimeSpanUnits units) { }

	public DateTime getCancelDate() { }

	public DateTime getExpireDate() { }

	public TimeSpan getFreeTrialPeriod() { }

	public string getFreeTrialPeriodString() { }

	public string getIntroductoryPrice() { }

	public TimeSpan getIntroductoryPricePeriod() { }

	public long getIntroductoryPricePeriodCycles() { }

	public string getProductId() { }

	public DateTime getPurchaseDate() { }

	public TimeSpan getRemainingTime() { }

	public string getSkuDetails() { }

	public string getSubscriptionInfoJsonString() { }

	public TimeSpan getSubscriptionPeriod() { }

	public Result isAutoRenewing() { }

	public Result isCancelled() { }

	public Result isExpired() { }

	public Result isFreeTrial() { }

	public Result isIntroductoryPricePeriod() { }

	public Result isSubscribed() { }

	private DateTime nextBillingDate(DateTime billing_begin_date, TimeSpanUnits units) { }

	private TimeSpanUnits parsePeriodTimeSpanUnits(string time_span) { }

	private TimeSpan parseTimeSpan(string period_string) { }

}

