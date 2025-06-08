public class FuelCar : Vehicle
{   
    private eCarColor m_Color{get; set;}
    private eCarDoors m_Doors{get; set;}

    public FuelCar(string i_LicenseID, string i_ModelName, eCarColor i_Color, eCarDoors i_Doors) : base(i_LicenseID, i_ModelName)
    {
        m_Color = i_Color;
        m_Doors = i_Doors;
        //create 4 tires with max air pressure 30
        m_Tires = new List<Tire>(4,30);
        //set the tires to the vehicle
        base.m_Tires = m_Tires;
        //set the energy percentage to 0
        base.m_EnergyPercentage = 0;
    }
}