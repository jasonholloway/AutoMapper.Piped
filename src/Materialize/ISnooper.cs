
namespace Materialize
{
    public interface ISnooper {
        void OnEvent(SnoopEvent ev);
    }




    static class SnooperExtensions
    {
        public static void Event<TObj>(this ISnooper @this, string name, TObj obj) {
            @this.OnEvent(new SnoopEvent<TObj>(name, obj));
        }
    }





    public abstract class SnoopEvent
    {
        public string Name { get; protected set; }
    }


    public class SnoopEvent<TObject> : SnoopEvent
    {
        public TObject Object { get; private set; }
        
        internal SnoopEvent(string name, TObject obj) {
            Name = name;
            Object = obj;
        }        
    }

}
