using System;
using System.Collections.Generic;

namespace Physics_Engine
{

    public class Test { }
    public static class PhysicsGlobals
    {
        public static int ResistorNum = 1; // Globals to give the components unique names
        public static int ParralellNum = 1;
        public static int SeriesNum = 1;
        public static GeneralComponent CreateSimpleComponent(double resistance,string name ="")
        {
            string componentName;
            if (name == "")
            {
                componentName = "R" + PhysicsGlobals.ResistorNum.ToString(); // Creates the Name of the component, with globals to ensure it will be unique
                PhysicsGlobals.ResistorNum++;// Increments Global variable
            }
            else
            {
                componentName = name;
            }
            GeneralComponent NewBasicComponent = new GeneralComponent(componentName);// Creates new instance of the most basic component 
            NewBasicComponent.AssignResistance(resistance);// Assigns the resistance the user has given
            return NewBasicComponent;
        }
    }

    public class Circuit
    {
        char Type;
        double emfValue;
        public GeneralComponent Main;
        public Circuit(char typeOfPsource, double valueofPsource, double IntRes,double ValOfFirstRes)
        {
            Main = new GeneralComponent("Main");
            Main.AssignType('s');
            Main.AddComponent(PhysicsGlobals.CreateSimpleComponent(IntRes,"IntRes"));
            Main.AddComponent(PhysicsGlobals.CreateSimpleComponent(ValOfFirstRes));
            Type = typeOfPsource;
            emfValue = valueofPsource;
            RunVoltageCalcs();
        }
        public void RunVoltageCalcs()
        {
            if (Type == 'v')
            {
                Main.assignAFromV(emfValue);
            }
            if (Type == 'a')
            {
                Main.assignVFromA(emfValue);
            }
        }
        public double GetEmfValue()
        {
            return emfValue;
        }
    }
    public class TestingClass
    {
        static void Testing(string[] args)
        {

            Circuit circuit = new Circuit('v', 12.0, 1,6);
            circuit.Main.CalculateResistance();
            circuit.Main.ComponentSearch("R1", "Insert", new string[] { "6.0", "s" });
            circuit.Main.assignAFromV(circuit.Main.GetVoltage());
            Console.ReadLine();
        }

    }

    ///////////////////////////////////////////////////////////////////////////////////
    ///
    public class GeneralComponent
    {
        private  List<GeneralComponent> ComponentList = new List<GeneralComponent>();
        private char Type; // (Can be 'b' for Basic 'p' for parralel and 's' for Series)
        protected double resistance;
        protected double voltage;
        protected double current;
        protected string name;
        protected internal int ysize;
        protected internal int xsize;
        protected bool IsTargetedCurrentProbe;

        public GeneralComponent(string Assignedname)
        {
            name = Assignedname;
            Type = 'b';
            IsTargetedCurrentProbe = false;
        }
        public string GetName()
        {
            return name;
        }
        public double GetCurrent()
        {
            return current;
        }
        public List<GeneralComponent> GetCopyOfSubList()
        {
            return ComponentList;
        }
        public new char GetType()
        {
            return Type;
        }
        public double GetVoltage()
        {
            return voltage;
        }
        public bool ComponentSearch(string NameOfComponent,  string Action,params string[] Values)
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
                                    InsertComponent(component, Convert.ToDouble(Values[0]), Convert.ToChar(Values[1]));// Resistance, Mode(s/p)
                                    goto Done;
                                case "Remove":
                                    RemoveComponent(component);
                                    goto Done;
                            }
                        }
                    }
                }
                Done:
                return false;
            }

        }
        public void RemoveComponent(GeneralComponent component)
        {
            ComponentList.Remove(component);
            if (ComponentList.Count == 1)
            {
                GeneralComponent CarryComponent = ComponentList[0];
                Type = 'b';
                resistance = CarryComponent.GetResistance();
                ysize = 1;
                xsize = 1;
                name = CarryComponent.GetName();
                IsTargetedCurrentProbe = CarryComponent.IsTargetedCurrentProbe;
                ComponentList.Clear();
            }

        }

        public GeneralComponent FindComponentFromName(string NameOfComponent)
        {
            if(NameOfComponent == name)
            {
                return this;
            }
            else
            {
                if(Type == 'p' || Type == 's')
                {
                    foreach (GeneralComponent element in ComponentList)
                    {
                       return element.FindComponentFromName(NameOfComponent);
                    }
                }
            }
            return null;
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
                ComponentList[ComponentList.IndexOf(component)] = NewComponent;
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
                ComponentList[ComponentList.IndexOf(component)] = NewComponent;

            }
            else
            {
                Console.WriteLine("p or s expected");
            }
            CalculateResistance();
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
                ysize = 0;
                xsize = 0;
                foreach (GeneralComponent element in ComponentList)
                {
                    element.CalculateResistance();
                    if (element.GetName() != "IntRes")
                    {
                        ysize = Math.Max(ysize, element.ysize);
                        xsize += element.xsize;
                    }
                    total += element.GetResistance();
                }
                resistance = total;
            }
            else if (Type == 'p')
            {
                double total = 0;
                ysize = 0;
                xsize = 0;
                foreach (GeneralComponent element in ComponentList)
                {
                    // These two bits basicly say , ok whats my max height gonna be and ok how long am I gonna be
                    element.CalculateResistance();
                    ysize += element.ysize; // This might cause issues later as I don't really understand what internal does 
                    xsize = Math.Max(xsize, element.xsize);
                    total += 1 / element.GetResistance();
                }
                xsize += 2;
                resistance = 1 / total;
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
            xsize = 1;
            ysize = 1;
        }
    }
}
