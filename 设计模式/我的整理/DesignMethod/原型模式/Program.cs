using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DesignMethod.原型模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //原型
            MonkeyKingPrototype prototypeKing = new ConcretePrototype("1");
            //变一个
            MonkeyKingPrototype cloneMokeyKing = prototypeKing.Clone() as ConcretePrototype;
            Console.Write(cloneMokeyKing.Id);

            //变两个
            MonkeyKingPrototype cloneMokeyKing2 = prototypeKing.Clone() as ConcretePrototype2;
            Console.Write(cloneMokeyKing2.Id);
            Console.Read();
        }
    }

    /// <summary>
    /// 孙悟空原型
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        public MonkeyKingPrototype(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }

        //克隆方法
        public abstract MonkeyKingPrototype Clone();
    }

    /// <summary>
    /// 创建具体
    /// </summary>
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id)
            : base(id)
        { }

        public override MonkeyKingPrototype Clone()
        {
            //浅复制
            return (MonkeyKingPrototype)this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 创建具体
    /// </summary>
   [Serializable]
    public class ConcretePrototype2 : MonkeyKingPrototype
    {
        public ConcretePrototype2(string id)
            : base(id)
        { }

        public override MonkeyKingPrototype Clone()
        {  //深复制
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as ConcretePrototype2;            
        }
    }

}

/*
  MemberwiseClone 方法创建一个浅表副本，具体来说就是创建一个新对象，然后将当前对象的非静态字段复制到该新对象。如果字段是值类型的，则对该字段执行逐位复制。如果字段是引用类型，则复制引用但不复制引用的对象；因此，原始对象及其复本引用同一对象。
为了实现深度复制，我们就必须遍历有相互引用的对象构成的图，并需要处理其中的循环引用结构。
先将对象序列化到内存流中，此时对象和对象引用的所用对象的状态都被保存到内存中。.Net的序列化机制会自动处理循环引用的情况。然后将内存流中的状态信息反序列化到一个新的对象中。这样一个对象的深度复制就完成了。在原型设计模式中CLONE技术非常关键。
 *  使用原型模式创建对象比直接new一个对象在性能上要好的多，因为Object类的clone方法是一个本地方法，它直接操作内存中的二进制流，特别是复制大对象时，性能的差别非常明显。
 *  在需要重复地创建相似对象时可以考虑使用原型模式。比如需要在一个循环体内创建对象，假如对象创建过程比较复杂或者循环次数很多的话，使用原型模式不但可以简化创建过程，而且可以使系统的整体性能提高很多
*/