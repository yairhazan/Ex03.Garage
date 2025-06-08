public class FuelEngine : Engine
{
    private readonly eFuelType m_FuelType;

    public FuelEngine(float i_MaxFuelAmount, float i_CurrentFuelAmount, eFuelType i_FuelType) : base(i_MaxFuelAmount, i_CurrentFuelAmount)
    {
        m_FuelType = i_FuelType;
    }

}
