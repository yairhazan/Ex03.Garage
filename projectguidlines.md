# Exercise 3 – Garage Management System

## Objectives

- Implement classes with inheritance and polymorphism
- Use of Collections
- Implement enums
- Use external assemblies (Dll)
- Work with multiple projects
- Handle Exceptions

## Required Knowledge

- Polymorphism in inheritance and OOP using C#
- Using Collections
- Using Dll development (external assembly)
- Working with multiple projects
- Handling Exceptions
- Inheriting from Object

## The Exercise

### Final Goal

A small system that "manages" a garage.  
The system should manage five types of vehicles:

- **Regular Motorcycle**  
  Fuel tank (Octan98, 5.8 liters), 2 wheels, max air pressure 30

- **Electric Motorcycle**  
  Battery (max time 3.2 hours), 2 wheels, max air pressure 30

- **Regular Car**  
  Fuel tank (Octan95, 48 liters), 4 wheels, max air pressure 32

- **Electric Car**  
  Battery (max time 4.8 hours), 4 wheels, max air pressure 32

- **Truck**  
  Fuel tank (Soler, 135 liters), 12 wheels, max air pressure 27

### Each Vehicle Has:

- Model name (string)
- License number (string)
- Energy left (%) (float)
- Collection of wheels

#### Each Wheel Has:

- Manufacturer name (string)
- Current air pressure (float)
- Max air pressure (float)
- Method to inflate air (adds pressure without exceeding max)

### Additional Properties per Vehicle Type:

#### Motorcycles (Regular/Electric):

- License type (A, A2, AB, B2)
- Engine volume (int)

#### Cars (Regular/Electric):

- Color (Yellow, Black, White, Silver)
- Number of doors (2, 3, 4, 5)

#### Trucks:

- Carries hazardous materials (bool)
- Cargo volume (float)

### Fuel-Based Vehicles:

- Fuel type (Octan95, Octan96, Octan98, Soler)
- Current fuel level (float)
- Max fuel capacity (float)
- Method to fill fuel (validates type and amount)

### Electric Vehicles:

- Battery time left (float)
- Max battery time (float)
- Method to charge battery (validates input time)

### Garage Records for Each Vehicle:

- Owner name (string)
- Owner phone (string)
- Vehicle status (InRepair, Repaired, Paid)  
  *Every vehicle starts with status "InRepair"*

---

## User Menu Options:

1. Load vehicles from `Vehicles.db`
2. Insert new vehicle into the garage
   - If vehicle already exists (by license), update status to “InRepair”
   - If not, ask for vehicle type, and input initial state: energy level, wheels pressure, fuel amount or battery status
3. Show list of all vehicles, optionally filtered by status
4. Change a vehicle's status
5. Inflate tires to max pressure
6. Refuel a vehicle (license, fuel type, amount)
7. Charge electric vehicle (license, time in minutes)
8. Display full vehicle details (license, model, owner, wheels, fuel/battery, etc.)

---

## Project Structure:

Two projects within one solution:

### 1. `Ex03.GarageLogic`

- A Dll project (Class Library)
- Contains object model and logic layer (no console interactions)
- Set in project properties: `Output type = Class Library`

### 2. `Ex03.ConsoleUI`

- An executable project (`.exe`)
- Implements user interface
- Uses the logic layer via reference to `GarageLogic`

---

## Notes

1. Carefully plan class and method structure, inheritance, and polymorphism.
2. Separate the UI layer from the logic layer (e.g., `Console` code should not reference `Vehicle` directly).
3. Use the provided `VehiclesCreator.cs`:
   - Mandatory to use
   - Do not modify
   - No vehicle object should be created elsewhere
4. The system should be easily extensible (e.g., adding a "Tractor" type).
5. Avoid code duplication and use only course-approved techniques.
6. Use `System.IO.File.ReadAllLines` for reading the file.
7. Do not change the format of the provided data file.
8. Must use:
   - `List<T>` / `Dictionary<K,V>`
   - `Enum`
   - String formatting
   - `FormatException` (parsing errors)
   - `ArgumentException` (logical errors, e.g., wrong fuel type)
   - `ValueRangeException` (custom class with `MinValue`, `MaxValue` fields for invalid input range)

---

## Submission

Submit a folder containing:

- A Word document (`.docx`) with:
  - Names + ID numbers
  - List of defined types (`class`/`enum`) with short explanations
  - Inheritance diagram showing hierarchy and relationships
- The solution file, named same as the `.docx` file
