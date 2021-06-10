using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class CoffeeMachine
    {
        private bool Power { get; set; }
        private Filter Filter { get; set; }
        private LiquidContainer LiquidContainer { get; set; }
        private SolidContainer SolidContainer { get; set; }

        public CoffeeMachine()
        {
            Power = false;

            LiquidContainer = new LiquidContainer();
            SolidContainer = new SolidContainer();
        }

        public void PowerButton()
        {
            if (Power)
                Power = false;
            else
                Power = true;
        }

        public Drink EspressoButton()
        {
            //Checks for all the things the machine needs to make a coffee, if it's all there, then return coffe, if not then return null.
            if (Power && Filter != null && Filter.Used == false && SolidContainer.Contains[0].Name == "Bean" && LiquidContainer.Contains[0].Name == "Water")
            {
                Filter.UseFilter();
                SolidContainer.Contains.RemoveAt(0);
                LiquidContainer.Contains.RemoveAt(0);

                return new Espresso();
            }
            else
                return null;
        }

        public Drink TeaButton()
        {
            //Checks for all the things the machine needs to make a coffee, if it's all there, then return coffe, if not then return null.
            if (Power && LiquidContainer.Contains[0].Name == "Water")
            {
                LiquidContainer.Contains.RemoveAt(0);

                return new Tea();
            }
            else
                return null;
        }

        public Drink CoffeeButton()
        {
            //Checks for all the things the machine needs to make a coffee, if it's all there, then return coffe, if not then return null.
            if (Power && Filter != null && Filter.Used == false && SolidContainer.Contains[0].Name == "Bean" && LiquidContainer.Contains[0].Name == "Water")
            {
                Filter.UseFilter();
                SolidContainer.Contains.RemoveAt(0);
                LiquidContainer.Contains.RemoveAt(0);

                return new Coffee();
            }
            else
                return null;
        }

        public void AddFilter()
        {
            Filter = new Filter();
        }

        public void AddBeans(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                SolidContainer.Contains.Add(new Bean());
            }
        }

        public void AddWater(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                LiquidContainer.Contains.Add(new Water());
            }
        }

        public override string ToString()
        {
            string statusPower = "";
            if (Power)
            {
                statusPower = "Power is on";
            }
            else
            {
                statusPower = "Power is off";
            }

            string statusFilter = "";
            if (Filter == null)
            {
                statusFilter = "Machine has no filter";
            }
            else if (Filter.Used)
            {
                statusFilter = "Machine has a filter but it has been used";
            }
            else if (Filter.Used == false)
            {
                statusFilter = "Machine has a clean filter";
            }

            string statusCoffeeBeanContainer = "";

            if (SolidContainer.Contains.Count == 0)
            {
                statusCoffeeBeanContainer = "Solid container is empty";
            }
            else
            {
                statusCoffeeBeanContainer = "Solid container contains " + SolidContainer.Contains[0].Name + "(" + SolidContainer.Contains.Count + ")\n";
            }


            string statusWaterContainer = "";
            if (SolidContainer.Contains.Count == 0)
            {
                statusWaterContainer = "Liquid container is empty";
            }
            else
            {
                statusWaterContainer = "Liquid container contains " + LiquidContainer.Contains[0].Name + "(" + Convert.ToInt32(LiquidContainer.Contains.Count) * 100 + "ml)";
            }

            return "Coffee Machine Status\n~~~~~~~~~~~~~~~~~~~~~\n" + statusPower + "\n" + statusFilter + "\n" + statusCoffeeBeanContainer + "\n" + statusWaterContainer;
        }

    }




}

