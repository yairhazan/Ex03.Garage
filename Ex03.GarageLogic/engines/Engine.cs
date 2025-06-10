using Ex03.GarageLogic;
public abstract class Engine
{
    // can be either fuel or electric
    public float m_MaxEnergyAmount { get; set; }
    public float m_CurrentEnergyAmount { get; set; }

    public Engine(float i_MaxEnergyAmount, float i_CurrentEnergyAmount)
    {
        m_MaxEnergyAmount = i_MaxEnergyAmount;
        m_CurrentEnergyAmount = i_CurrentEnergyAmount;
    }

    public void FillEnergy(float i_EnergyToAdd)
    {
        m_CurrentEnergyAmount += i_EnergyToAdd;
        if (m_CurrentEnergyAmount > m_MaxEnergyAmount)
        {
            throw new ValueRangeException("Fuel amount", 0f, (float)m_MaxEnergyAmount);
        }
    }

    public override string ToString()
    {
        return $"Current energy: {m_CurrentEnergyAmount:F2}/{m_MaxEnergyAmount:F2}";
    }
}