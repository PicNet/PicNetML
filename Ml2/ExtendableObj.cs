using System;
using System.Collections.Generic;
using System.Linq;
using Ml2.Arff;

namespace Ml2
{
  [Serializable] public class ExtendableObj : ExtendableObj<object>
  {
    public ExtendableObj() : base(new object()) {}

    public static ExtendableObj<T> Create<T>(T t) where T : new() { return new ExtendableObj<T>(t); }    
  }

  internal interface IExtendableObj<out T> {
    T BaseObject { get; }
  }

  [Serializable] public abstract class ExtendableObjBase : IGetValue {
    protected IDictionary<string, bool> base_obj_keys;
    protected readonly IDictionary<string, Tuple<EAttributeType, object>> namevalmap = new Dictionary<string, Tuple<EAttributeType, object>>(); 

    internal ExtendableObjBase() {
      Properties = new List<ExtendedProperty>();
    }

    internal object BaseObjectObj;

    public IList<ExtendedProperty> Properties { get; set; }
    
    internal ICollection<object> GetExtendedPropertiesValues() { 
      return Properties.Select(p => p.Value).ToArray(); 
    }

    public object GetValue(string name) { 
      return base_obj_keys.ContainsKey(name) ? 
          Helpers.GetValue(BaseObjectObj, name) : 
          namevalmap[name].Item2;
    }

    public void AddProperty(string name, EAttributeType type, object value) {
      namevalmap.Add(name, Tuple.Create(type, value));
      Properties.Add(new ExtendedProperty { Type = type, Name = name, Value = value });
    }
  }

  [Serializable] public class ExtendableObj<T> : ExtendableObjBase, IExtendableObj<T> where T : new() {            
    public ExtendableObj() { throw new ApplicationException("Create ExtendableObj using ExtendableObj.Create."); }

    internal ExtendableObj(T t) { 
      BaseObjectObj = BaseObject = t; 
      if (base_obj_keys == null) base_obj_keys = Helpers.GetProps(typeof(T)).Select(p => p.Name).ToDictionary(n => n, n => true);
    }    

    public T BaseObject { get; private set; }     
    
    public ExtendableObj<T> AddString(string name, string value) {
      AddProperty(name, EAttributeType.String, value);
      return this;
    }

    public ExtendableObj<T> AddNominal(string name, string value) {
      AddProperty(name, EAttributeType.Nominal, value);
      return this;
    }

    public ExtendableObj<T> AddNumerical(string name, double value) {
      AddProperty(name, EAttributeType.Numeric, value);
      return this;
    }

    public ExtendableObj<T> AddBinary(string name, bool value) {
      AddProperty(name, EAttributeType.Binary, value);
      return this;
    }

    public ExtendableObj<T> AddDate(string name, DateTime value) {
      AddProperty(name, EAttributeType.Date, value);
      return this;
    }    

    public object Clone() { 
      var cloned = new ExtendableObj<T> {
        Properties = Properties.ToArray(), 
        BaseObject = (T) (BaseObject is ICloneable ? 
            ((ICloneable) BaseObject).Clone() : BaseObject)
      };
      return cloned;
    }

    public bool Contains(string prop) {
      return base_obj_keys.ContainsKey(prop) || 
          namevalmap.ContainsKey(prop);
    }

    public void SetPropertyValue(string name, double value) {
      var current = namevalmap[name];
      namevalmap[name] = Tuple.Create(current.Item1, (object) value);
    }
  }

  [Serializable] public class ExtendedProperty {
    internal EAttributeType Type { get;set; }
    public string Name { get;set; }
    internal object Value { get;set; }
  }
}