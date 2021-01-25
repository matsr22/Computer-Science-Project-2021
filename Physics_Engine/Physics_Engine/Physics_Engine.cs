﻿using System;
using System.Collections.Generic;

namespace Physics_Engine
{

    public class Test { }
    public static class PhysicsGlobals
    {
        public static int ResistorNum = 1; // Globals to give the components unique names
        public static int ParralellNum = 1;
        public static int SeriesNum = 1;
        public static GeneralComponent CreateSimpleComponent(double resistance)
        {

            string componentName = "R" + PhysicsGlobals.ResistorNum.ToString(); // Creates the Name of the component, with globals to ensure it will be unique
            GeneralComponent NewBasicComponent = new GeneralComponent(componentName);// Creates new instance of the most basic component 
            NewBasicComponent.AssignResistance(resistance);// Assigns the resistance the user has given
            PhysicsGlobals.ResistorNum++;// Increments Global variable
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
        protected internal int[] size;

        public ResistiveComponent(string AssignedName)
        {
            name = AssignedName;
            size = new int[]{1,1};
            
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
        public virtual string GetMyType()// Change this
        {
            return "BASE";
        }
    }
    public abstract class CompositeComponent : ResistiveComponent
    {
        public static List<ResistiveComponent> ComponentList = new List<ResistiveComponent>();
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
                ComponentList.Add(PhysicsGlobals.CreateSimpleComponent(Resistance));//Adds to the current component list
                CalculateResistance();//Re-calculates the resistance after new component has been added

            }
            else if (Mode == 's')
            {
                // Creates new Composite component
                string componentName = "RS" + PhysicsGlobals.SeriesNum.ToString(); 
                SeriesComponent NewComponent = new SeriesComponent(componentName);
                PhysicsGlobals.SeriesNum++;
                // Adds both the old component and the new one to this composite one
                NewComponent.AddComponent(component);
                NewComponent.AddComponent(PhysicsGlobals.CreateSimpleComponent(Resistance));
                // Removes the old and replaces with the new
                ComponentList.Remove(component);
                ComponentList.Add(NewComponent);
            }
            else if (Mode == 'p')
            {
                // Same as above but with a parrallel component 
                string componentName = "RP" + PhysicsGlobals.ParralellNum.ToString();
                ParrallelComponent NewComponent = new ParrallelComponent(componentName);
                PhysicsGlobals.ParralellNum++;
                NewComponent.AddComponent(component);
                NewComponent.AddComponent(PhysicsGlobals.CreateSimpleComponent(Resistance));
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
        public override void CalculateResistance() // Calculating Sum of resistance using the parrallel resistance law and height
        {
            double total = 0;
            foreach (ResistiveComponent element in ComponentList)
            {
                // These two bits basicly say , ok whats my max height gonna be and ok how long am I gonna be
                size[0] += element.size[0]; // This might cause issues later as I don't really understand what internal does 
                size[1] = Math.Max(size[1], element.size[1]);
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
                size[0] = Math.Max(size[0], element.size[0]);
                size[1] += element.size[1];
                total += element.GetResistance();
            }
            resistance = total;
        }
        public override string GetMyType()
        {
            return "Series";
        }
    }
    public class Circuit
    {
        char Type;
        double emfValue;
        public GeneralComponent Main;
        public Circuit(char typeOfPsource, double valueofPsource, double IntRes)
        {
            Main = new GeneralComponent("Main");
            Main.AssignType('s');
            Main.AddComponent(PhysicsGlobals.CreateSimpleComponent(IntRes));
            Type = typeOfPsource;
            emfValue = valueofPsource;
            if (Type == 'v')
            {
                Main.assignAFromV(emfValue);
            }
            if (Type == 'a')
            {
                Main.assignVFromA(emfValue);
            }
        }
    }
    public class TestingClass
    {
        static void Main(string[] args)
        {

            Circuit circuit = new Circuit('v', 12.0, 1);
            circuit.Main.ComponentSearch("R1", "Insert", new string[] { "6.0", "s" });
            Console.ReadLine();
        }

    }

    ///////////////////////////////////////////////////////////////////////////////////
    ///
    public class GeneralComponent
    {
        public static List<GeneralComponent> ComponentList = new List<GeneralComponent>();
        private char Type; // (Can be 'b' for Basic 'p' for parralel and 's' for Series)
        protected double resistance;
        protected double voltage;
        protected double current;
        protected string name;
        protected internal int[] size;
        public GeneralComponent(string Assignedname)
        {
            name = Assignedname;
            Type = 'b';
        }



        public bool ComponentSearch(string NameOfComponent, string Action, string[] Values)
        {
            if (NameOfComponent == name)
            {
                return true;
            }
            else
            {
                if (Type == 'p' || Type == 's')
                {
                    foreach (GeneralComponent component in ComponentList)// Itterates through that component list to find match
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
                }
                return false;
            }

        }
        public void AssignType(char type)
        {
            Type = type;
        }
        public void InsertComponent(GeneralComponent component, double Resistance, char Mode) // Inserts new component
        {
            if ((Mode == 'p' && (Type == 'p')) || (Mode == 's' && (Type == 's')))
            {
                ComponentList.Add(PhysicsGlobals.CreateSimpleComponent(Resistance));//Adds to the current component list
                CalculateResistance();//Re-calculates the resistance after new component has been added

            }
            else if (Mode == 's')
            {
                // Creates new Composite component
                string componentName = "RS" + PhysicsGlobals.SeriesNum.ToString();
                GeneralComponent NewComponent = new GeneralComponent(componentName);
                PhysicsGlobals.SeriesNum++;
                NewComponent.AssignType('s');
                // Adds both the old component and the new one to this composite one
                NewComponent.AddComponent(component);
                NewComponent.AddComponent(PhysicsGlobals.CreateSimpleComponent(Resistance));
                // Removes the old and replaces with the new
                ComponentList.Remove(component);
                ComponentList.Add(NewComponent);
            }
            else if (Mode == 'p')
            {
                // Same as above but with a parrallel component 
                string componentName = "RP" + PhysicsGlobals.ParralellNum.ToString();
                GeneralComponent NewComponent = new GeneralComponent(componentName);
                PhysicsGlobals.ParralellNum++;
                NewComponent.AssignType('p');
                NewComponent.AddComponent(component);
                NewComponent.AddComponent(PhysicsGlobals.CreateSimpleComponent(Resistance));
                ComponentList.Remove(component);
                ComponentList.Add(NewComponent);
            }
            else
            {
                Console.WriteLine("p or s expected");
            }
        }
        public void AddComponent(GeneralComponent Component)
        {
            ComponentList.Add(Component);//Adds to the current list
            CalculateResistance();//Recalculates resistance
        }
        public void CalculateResistance()
        {
            if (Type == 's')
            {
                double total = 0;
                foreach (GeneralComponent element in ComponentList)
                {
                    size[0] = Math.Max(size[0], element.size[0]);
                    size[1] += element.size[1];
                    total += element.GetResistance();
                }
                resistance = total;
            }
            else if (Type == 'p')
            {
                double total = 0;
                foreach (GeneralComponent element in ComponentList)
                {
                    // These two bits basicly say , ok whats my max height gonna be and ok how long am I gonna be
                    size[0] += element.size[0]; // This might cause issues later as I don't really understand what internal does 
                    size[1] = Math.Max(size[1], element.size[1]);
                    total += 1 / element.GetResistance();
                }
                resistance = 1 / total;
            }
            else
            {
                Console.WriteLine("Unexpected Type");
            }
        }
        public void assignAFromV(double GivenVoltage) // Ovverides the Voltage calculation as now needs to assign to each component
        {
            voltage = GivenVoltage;
            current = GivenVoltage / resistance;
            foreach (GeneralComponent element in ComponentList)// Voltage across components in parallel is the same so all sub-components are assigned the same voltage
            {
                if (Type == 'p')
                {
                    element.assignAFromV(GivenVoltage);
                }
                else if (Type == 's')
                {
                    element.assignAFromV(voltage * element.GetResistance() / resistance);
                }
            }
        }
        public void assignVFromA(double GivenCurrent)// Ovverides as now needs to assign to sub components
        {
            current = GivenCurrent;
            voltage = GivenCurrent * resistance;
            foreach (GeneralComponent element in ComponentList)// In Parrallel, those with higher resistance receive less Current, path of least resistance (I = V/R)
            {
                if (Type == 'p')
                {
                    element.assignVFromA(voltage / element.GetResistance());// V allready calculated 
                }
                else if (Type == 's')
                {
                    element.assignVFromA(current);
                }
            }
        }
        public double GetResistance()
        {
            return resistance;
        }
        public void AssignResistance(double AssignedRes)
        {
            resistance = AssignedRes;
            size = new int[] { 1, 1 };
        }
    }
}
