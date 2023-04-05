using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компонувальник
{
    internal class LayoutDesigner
    {
        public interface Pizza1Component
        {
            string GetNumber();
            double GetPrice();
        }

        // Простий компонент велосипеду
        public class PizzaComponent : Pizza1Component
        {
            private string number;
            private double price;

            public PizzaComponent(string number, double price)
            {
                this.number = number;
                this.price = price;
            }

            public string GetNumber()
            {
                number = " Велосипед ";
                return this.number;
            }

            public double GetPrice()
            {
                return this.price;
            }
        }

        // Композитний компонент велосипеду
        public class Composite : Pizza1Component
        {
            private List<Pizza1Component> components;

            public Composite()
            {
                components = new List<Pizza1Component>();
            }

            public void AddComponent(Pizza1Component component)
            {
                components.Add(component);
            }

            public void RemoveComponent(Pizza1Component component)
            {
                components.Remove(component);
            }

            public PizzaComponent FindComponent(string number)
            {
                foreach (PizzaComponent component in components)
                {
                    if (component.GetNumber() == number)
                    {
                        return component;
                    }
                }

                return null;
            }

            public string GetNumber()
            {
                return "Composite";
            }

            public double GetPrice()
            {
                double price = 0;

                foreach (PizzaComponent component in components)
                {
                    price += component.GetPrice();
                }

                return price;
            }
        }

        // Декоратор компонентів велосипеду
        public abstract class BicycleDecorator : Pizza1Component
        {
            private Pizza1Component component;

            public BicycleDecorator(Pizza1Component component)
            {
                this.component = component;
            }

            public virtual string GetNumber()
            {
                return component.GetNumber();
            }

            public virtual double GetPrice()
            {
                return component.GetPrice();
            }
        }

        // Декоратор колес велосипеду
        public class WheelDecorator : BicycleDecorator
        {
            private string number;
            private double price;

            public WheelDecorator(Pizza1Component component, string number, double price) : base(component)
            {
                this.number = number;
                this.price = price;
            }

            public override string GetNumber()
            {
                return base.GetNumber() + " with " + number + " wheels";
            }

            public override double GetPrice()
            {
                return base.GetPrice() + price;
            }
        }

        // Декоратор сидіння велосипеду
        public class SeatDecorator : BicycleDecorator
        {
            private string number;
            private double price;

            public SeatDecorator(Pizza1Component component, string number, double price) : base(component)
            {
                this.number = number;
                this.price = price;
            }

            public override string GetNumber()
            {
                return base.GetNumber() + " with " + number + " seat";
            }

            public override double GetPrice()
            {
                return base.GetPrice() + price;
            }
        }

        //Декоратор керма велосипеда
        public class HandlebarDecorator : BicycleDecorator
        {
            private string number;
            private double price;
            public HandlebarDecorator(Pizza1Component component, string number, double price) : base(component)
            {
                this.number = number;
                this.price = price;
            }

            public override string GetNumber()
            {
                return base.GetNumber() + " with " + number + " handlebars";
            }

            public override double GetPrice()
            {
                return base.GetPrice() + price;
            }
        }
        // Формування складових велосипеду
        public class PizzaBuilder
        {
            private Composite pizza;
            public PizzaBuilder()
            {
                pizza = new Composite();
            }

            public void BuildFrame(string frameNumber, double framePrice)
            {
                PizzaComponent frame = new PizzaComponent(frameNumber, framePrice);
                pizza.AddComponent(frame);
            }

            public void BuildWheel(string wheelNumber, double wheelPrice)
            {
                PizzaComponent wheel = new PizzaComponent(wheelNumber, wheelPrice);
                pizza.AddComponent(wheel);
            }

            public void BuildSeat(string seatNumber, double seatPrice)
            {
                PizzaComponent seat = new PizzaComponent(seatNumber, seatPrice);
                pizza.AddComponent(seat);
            }

            public void BuildHandlebar(string handlebarNumber, double handlebarPrice)
            {
                PizzaComponent handlebar = new PizzaComponent(handlebarNumber, handlebarPrice);
                pizza.AddComponent(handlebar);
            }

            public void AddWheelDecorator(string number, double price)
            {
                Pizza1Component component = pizza.FindComponent("Wheel");

                if (component != null)
                {
                    WheelDecorator wheelDecorator = new WheelDecorator(component, number, price);
                    pizza.RemoveComponent(component);
                    pizza.AddComponent(wheelDecorator);
                }
            }

            public void AddSeatDecorator(string number, double price)
            {
                Pizza1Component component = pizza.FindComponent("Seat");

                if (component != null)
                {
                    SeatDecorator seatDecorator = new SeatDecorator(component, number, price);
                    pizza.RemoveComponent(component);
                    pizza.AddComponent(seatDecorator);
                }
            }

            public void AddHandlebarDecorator(string number, double price)
            {
                Pizza1Component component = pizza.FindComponent("Handlebar");

                if (component != null)
                {
                    HandlebarDecorator handlebarDecorator = new HandlebarDecorator(component, number, price);
                    pizza.RemoveComponent(component);
                    pizza.AddComponent(handlebarDecorator);
                }
            }
            public Composite GetPizza()
            {
                return pizza;
            }
        }
    }
}
