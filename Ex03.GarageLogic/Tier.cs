public class Tier
{
    public string TierModel { get; set; }
    public float CurrentAirPressure { get; set; }
    public float MaxAirPressure { get; set; }

    public Tier(string i_TierModel, float i_CurrentAirPressure, float i_MaxAirPressure)
    {
        TierModel = i_TierModel;
        CurrentAirPressure = i_CurrentAirPressure;
        MaxAirPressure = i_MaxAirPressure;
    }
}