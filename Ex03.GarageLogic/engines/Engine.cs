public abstract class Engine
{
    // can be either fuel or electric
    private readonly float m_MaxEnergyAmount;
    private float m_CurrentEnergyAmount;

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
            m_CurrentEnergyAmount = m_MaxEnergyAmount;
        }
    }
}