using System.Dynamic;

namespace Utilities
{
    /// <summary>
    /// dynamic 帮助类
    /// 声明方式
    /// 1: var  d = new TDynamic(object).GetDynamic();
    /// 2: dynamic d = new TDynamic(object);
    /// 调用方式
    /// d.Property
    /// </summary>
    public class TDynamic : DynamicObject
    {
        private object _obj;
        public TDynamic(object obj)
        {
            this._obj = obj;
        }

        public dynamic GetDynamic()
        {
            dynamic r = this;
            return r;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (_obj != null)
                result= _obj.GetType().GetProperty(binder.Name)?.GetValue(_obj) ?? null;
            return true;
        }
    }
}
