using System;
using System.Collections.Generic;
namespace Start_Of_Computer_Science_Project
{
    public static class Globals
    {
        public static int ResistorNum = 1; // Globals to give the components unique names
        public static int ParralellNum = 1;
        public static int SeriesNum = 1;
        public static ResistiveComponent CreateSimpleComponent(double resistance)
        {

            string componentName = "R" + Globals.ResistorNum.ToString(); // Creates the Name of the component, with globals to ensure it will be unique
            ResistiveComponent NewBasicComponent = new ResistiveComponent(componentName);// Creates new instance of the most basic component 
            NewBasicComponent.AssignResistance(resistance);// Assigns the resistance the user has given
            Globals.ResistorNum++;// Increments Global variable
            return NewBasicComponent;
        }
    }
    public class ResistiveComponent
    {
        // All values are double as this has a maximum value of 10^308 and stores decimal values
        protected double resistance;
        protected double voltage;
        protected double current;
        protected string name;

        public ResistiveComponent(string AssignedName)
        {
            name = AssignedName;
        }
        public virtual bool ComponentSearch(string NameOfComponent,string Action,string[] value)
        {
            if(NameOfComponent == name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void AssignResistance(double InitialResistance)// Assigns the vaule of the resistor when it is created
        {
            resistance = InitialResistance;
        }
        public virtual void assignVFromA(double GivenCurrent) // Assigns both Voltage and Current with the Equation V = IR, given A
        {
            current = GivenCurrent;
            voltage = GivenCurrent * resistance;
        }
        public virtual void assignAFromV(double GivenVoltage)// Assigns both Voltage and Current with the Equation V = IR, given V
        {
            voltage = GivenVoltage;
            current = GivenVoltage / resistance;
        }
        public double GetResistance()// Returns resistance of component 
        {
            return resistance;
        }
        public virtual string GetMyType()
        {
            return "BASE";
        }
    }
    public abstract class CompositeComponent : ResistiveComponent
    {
        protected List<ResistiveComponent> ComponentList = new List<ResistiveComponent>();
        public CompositeComponent(string AssignedName) : base(AssignedName)
        {
            name = AssignedName;

        }
        public virtual void CalculateResistance()
        {
            Console.WriteLine("TERMINAL ERROR"); // Should be unreachable as must be ovveriden for code to work
        }
        public override bool ComponentSearch(string NameOfComponent, string Action, string[] Values)// Searches for component and performs relevant action
        {
            // string[] Values is used to provide data along with the Action
            if (NameOfComponent == name) // Returns to previous recursive call that component is found
            {
                return true;
            }

            foreach (ResistiveComponent component in ComponentList)// Itterates through that component list to find match
            {
                if (component.ComponentSearch(NameOfComponent, Action, Values) == true) // if found, performs relevant action 
                {
                    switch (Action)
                    {
                        case "Insert":
                            InsertComponent(component, Convert.ToDouble(Values[0]), Convert.ToChar(Values[1]));
                            break;
                    }
                }
            }
            return false;
        }
        public void InsertComponent(ResistiveComponent component, double Resistance, char Mode) // Inserts new component
        {
            if ((Mode == 'p' && (GetMyType() == "PARRALLEL")) || (Mode == 's' && (GetMyType() == "SERIES")))
            {
                ComponentList.Add(Globals.CreateSimpleComponent(Resistance));//Adds to the current component list
                CalculateResistance();//Re-calculates the resistance after new component has been added

            }
            else if (Mode == 's')
            {
                // Creates new Composite component
                string componentName = "RS" + Globals.SeriesNum.ToString(); 
                SeriesComponent NewComponent = new SeriesComponent(componentName);
                Globals.SeriesNum++;
                // Adds both the old component and the new one to this composite one
                NewComponent.AddComponent(component);
                NewComponent.AddComponent(Globals.CreateSimpleComponent(Resistance));
                // Removes the old and replaces with the new
                ComponentList.Remove(component);
                ComponentList.Add(NewComponent);
            }
            else if (Mode == 'p')
            {
                // Same as above but with a parrallel component 
                string componentName = "RP" + Globals.ParralellNum.ToString();
                ParrallelComponent NewComponent = new ParrallelComponent(componentName);
                Globals.ParralellNum++;
                NewComponent.AddComponent(component);
                NewComponent.AddComponent(Globals.CreateSimpleComponent(Resistance));
                ComponentList.Remove(component);
                ComponentList.Add(NewComponent);
            }
            else
            {
                Console.WriteLine("p or s expected");
            }
        }
        public void AddComponent(ResistiveComponent Component)
        {
            ComponentList.Add(Component);//Adds to the current list
            CalculateResistance();//Recalculates resistance
        }

    }

    public class ParrallelComponent : CompositeComponent
    {

        public ParrallelComponent(string AssignedName) : base(AssignedName)
        {
            name = AssignedName;
            
        }
        public override string GetMyType()
        {
            return "PARRALLEL";
        }
        

        public override void assignAFromV(double GivenVoltage) // Ovverides the Voltage calculation as now needs to assign to each component
        {
            base.assignAFromV(GivenVoltage);
            voltage = GivenVoltage;
            current = GivenVoltage / resistance;
            foreach (ResistiveComponent element in ComponentList)// Voltage across components in parallel is the same so all sub-components are assigned the same voltage
            {
                element.assignAFromV(GivenVoltage);
            }
        }
        public override void assignVFromA(double GivenCurrent)// Ovverides as now needs to assign to sub components
        {
            base.assignVFromA(GivenCurrent);
            current = GivenCurrent;
            voltage = GivenCurrent * resistance;
            foreach (ResistiveComponent element in ComponentList)// In Parrallel, those with higher resistance receive less Current, path of least resistance (I = V/R)
            {
                element.assignVFromA(voltage / element.GetResistance());// V allready calculated 
            }
        }
        public override void CalculateResistance() // Calculating Sum of resistance using the parrallel resistance law
        {
            double total = 0;
            foreach (ResistiveComponent element in ComponentList)
            {
                total += 1 / element.GetResistance();
            }
            resistance = 1 / total;
        }

    }
    public class SeriesComponent : CompositeComponent
    {
        public SeriesComponent(string AssignedName) : base(AssignedName)
        {
            name = AssignedName;
        }
        public override void assignAFromV(double GivenVoltage) // Similar to the parrallel implementation
        {
            base.assignAFromV(GivenVoltage);
            voltage = GivenVoltage;
            current = GivenVoltage / resistance;
            foreach (ResistiveComponent element in ComponentList)
            {
                element.assignAFromV((voltage * element.GetResistance()) / resistance);
            }
        }
        public override void assignVFromA(double GivenCurrent)
        {
            base.assignVFromA(GivenCurrent);
            current = GivenCurrent;
            voltage = GivenCurrent * resistance;
            foreach (ResistiveComponent element in ComponentList)
            {
                element.assignVFromA(GivenCurrent);
            }
        }
        public override void CalculateResistance()// Calculating Sum of resistance using the series resistance law
        {
            double total = 0;
            foreach (ResistiveComponent element in ComponentList)
            {
                total += element.GetResistance();
            }
            resistance = total;
        }
        public override string GetMyType()
        {
            return "Series";
        }
    }
    public class TestingClass
    {
        static void Main(string[] args)
        {
            
            SeriesComponent Main = new SeriesComponent("R"+Globals.ResistorNum);
            Globals.ResistorNum++;
            Main.ComponentSearch
        }

    }

    
}
