using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.抽象工厂
{

    public class Program : OpenDesign
    {
        public override void Open()
        {
            AbstractFactory ren = new ChineseFactory();
            Hand hand = ren.WhoHand();
            hand.PrintHand();

            AbstractFactory ren2 = new AmericaFactory();
            Hand hand2 = ren2.WhoHand();
            hand2.PrintHand();
            

        }
    }

    //抽象工厂
    public abstract class AbstractFactory
    {
        public abstract Head WhoHead();

        public abstract Hand WhoHand();

        public abstract Foot WhoFoot();

        public abstract Leg WhoLeg();

    }


    //各个工厂 
    public class ChineseFactory : AbstractFactory
    {
        public override Head WhoHead()
        {
            return new ChineseHead();
        }

        public override Hand WhoHand()
        {
            return new ChineseHand();
        }

        public override Foot WhoFoot()
        {
            return new ChineseFoot();
        }

        public override Leg WhoLeg()
        {
            return new ChineseLeg();
        }
    }

    public class AmericaFactory : AbstractFactory
    {
        public override Head WhoHead()
        {
            return new AmericaHead();
        }

        public override Hand WhoHand()
        {
            return new AmericaHand();
        }

        public override Foot WhoFoot()
        {
            return new AmericaFoot();
        }

        public override Leg WhoLeg()
        {
            return new AmericaLeg();
        }
    }



    public abstract class Head
    {
        public abstract void PrintHead();
    }

    public class AmericaHead:Head
    {
        public override void PrintHead()
        {
            Console.WriteLine("美国人的头");
        }
    }

    public class ChineseHead : Head
    {
        public override void PrintHead()
        {
            Console.WriteLine("中国人的头");
        }
    }

    public abstract class Hand
    {
        public abstract void PrintHand();
    }

    public class AmericaHand : Hand
    {
        public override void PrintHand()
        {
            Console.WriteLine("美国人的手");
        }
    }

    public class ChineseHand : Hand
    {
        public override void PrintHand()
        {
            Console.WriteLine("中国人的手");
        }
    }

    public abstract class Foot
    {
        public abstract void PrintFoot();
    }

    public class AmericaFoot : Foot
    {
        public override void PrintFoot()
        {
            Console.WriteLine("美国人的脚");
        }
    }

    public class ChineseFoot : Foot
    {
        public override void PrintFoot()
        {
            Console.WriteLine("中国人的脚");
        }
    }

    public abstract class Leg
    {
        public abstract void PrintLeg();
    }

    public class AmericaLeg : Leg
    {
        public override void PrintLeg()
        {
            Console.WriteLine("美国人的腿");
        }
    }

    public class ChineseLeg : Leg
    {
        public override void PrintLeg()
        {
            Console.WriteLine("中国人的腿");
        }
    }
}
