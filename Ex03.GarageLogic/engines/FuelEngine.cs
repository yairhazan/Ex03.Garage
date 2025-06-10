public class FuelEngine : Engine
{
    public eFuelType m_FuelType { get; set; }

    public FuelEngine(float i_MaxFuelAmount, float i_CurrentFuelAmount, eFuelType i_FuelType) : base(i_MaxFuelAmount, i_CurrentFuelAmount)
    {
        m_FuelType = i_FuelType;
    }

    public override string ToString()
    {
        return $"Fuel type: {m_FuelType}, {base.ToString()}";
    }
}
