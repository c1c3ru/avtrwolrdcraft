namespace Game.Level;

public class CurrentWeatherTypeCondition : GenericConditionBase
{
	public WeatherType expectedWeatherType; //Field offset: 0x10

	public CurrentWeatherTypeCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

