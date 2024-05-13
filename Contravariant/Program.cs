namespace Contravariant {
    internal class Program {
        static void Main(string[] args) {
            IContravariant<SuperClass> superImplementor = new SuperClassImplementor();
            IContravariant<SubClass> sumImplementor1 =superImplementor;

            SuperClassImplementor superClassImplementor = new SuperClassImplementor();
            // SubClassImplementor subClassImplementor = superClassImplementor; error CS0266: Cannot implicitly
            // convert type 'SuperClassImplementor' to 'SubClassImplementor'.
            // An explicit conversion exists (are you missing a cast?) 
        }
    } 
    public interface IContravariant<in T> {
        void DoSomething(T value);
        // T GetSomething(); error CS1961: The covariant type parameter 'T' must be
        // contravariantly valid on 'IContravariant<T>.GetSomething()'. 'T' is covariant.
    }

    public class SuperClass{ }
    public class SubClass : SuperClass { }

    public class SuperClassImplementor : IContravariant<SuperClass> {
        public void DoSomething(SuperClass value) {
            Console.WriteLine("SuperImplementor.DoSomething");
        }
    }
    public class SubClassImplementor : IContravariant<SubClass> {
        public void DoSomething(SubClass value) {
            Console.WriteLine("SubImplementor.DoSomething");
        }
    }


   
}
