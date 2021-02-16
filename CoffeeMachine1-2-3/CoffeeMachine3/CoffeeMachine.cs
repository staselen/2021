using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class CoffeeMachine
    {
        public bool Power { get; set; }
        public Filter filter { get; set; }

        public CoffeeBeanContainer coffeeBeanContainer { get; set; }
        public WaterContainer waterContainer { get; set; }

        public CoffeeMachine()
        {
            Power = false;

            coffeeBeanContainer = new CoffeeBeanContainer();
            waterContainer = new WaterContainer();
        }

        public Cup Make(string x)
        {
            if(x == "Coffee")
            {

                return MakeCoffee();
            }
            if(x =="Tea")
            {
                return MakeTea();
            }
            if(x == "Espresso")
            {
                return MakeEspresso();
            }


            return null;
        }

        Cup MakeEspresso()
        {
            if (Power && filter != null && filter.Used == false && coffeeBeanContainer.Contains.Count >= 5 && waterContainer.Contains.Count != 0)
            {

                filter.Used = true;

                for (int i = 0; i < 5; i++)
                {
                    coffeeBeanContainer.Contains.Remove("Bean");
                }

                waterContainer.Contains.Remove("Water");

                return new Cup("Espresso");
            }
            return null;

        }
        Cup MakeCoffee()
        {
            if (Power && filter != null && filter.Used == false && coffeeBeanContainer.Contains.Count >= 5 && waterContainer.Contains.Count != 0)
            {

                filter.Used = true;

                for (int i = 0; i < 5; i++)
                {
                    coffeeBeanContainer.Contains.Remove("Bean");
                }

                waterContainer.Contains.Remove("Water");

                return new Cup("Coffee");
            }
            return null;
        }

        Cup MakeTea()
        {
            if (Power && waterContainer.Contains.Count != 0)
            {
                waterContainer.Contains.Remove("Water");
                return new Cup("Tea");
            }
            return null;
        }

        public void AddFilter()
        {
            filter = new Filter();
        }

        public void AddBeans()
        {
            coffeeBeanContainer.Contains.Add("Bean");
        }

        public void AddWater()
        {
            waterContainer.Contains.Add("Water");
        }

        public string Status()
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
            if (filter == null)
            {
                statusFilter = "Machine has no filter";
            }
            else if (filter.Used)
            {
                statusFilter = "Machine has a filter but it has been used";
            }
            else if (filter.Used == false)
            {
                statusFilter = "Machine has a clean filter";
            }

            string statusCoffeeBeanContainer = "";

            if (coffeeBeanContainer.Contains.Count == 0)
            {
                statusCoffeeBeanContainer = "Coffee bean container is empty";
            }
            else
            {
                statusCoffeeBeanContainer = "Coffee bean container contains " + coffeeBeanContainer.Contains[0] + "(" + coffeeBeanContainer.Contains.Count + "g)";
            }


            string statusWaterContainer = "";
            if (waterContainer.Contains.Count == 0)
            {
                statusWaterContainer = "Coffee bean container is empty";
            }
            else
            {
                statusWaterContainer = "Water container contains " + waterContainer.Contains[0] + "(" + Convert.ToInt32(waterContainer.Contains.Count) * 100 + "ml)";
            }

            return "Coffee Machine Status\n~~~~~~~~~~~~~~~~~~~~~\n" + statusPower + "\n" + statusFilter + "\n" + statusCoffeeBeanContainer + "\n" + statusWaterContainer;
        }

    }




}

