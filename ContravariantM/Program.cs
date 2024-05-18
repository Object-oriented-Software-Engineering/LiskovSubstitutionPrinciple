using System.Diagnostics;

namespace ContravariantM {
    internal class Program {

        public class Rectangle {  
            private int height;
            private int width;
            
            public virtual void setHeight(int newHeight) {
                this.height = newHeight;
            }    
            public virtual void setWidth(int newWidth) {
                this.width = newWidth; 
            }   
            public int getWidth() {
                return width;
            }  
            public int getHeight() {
                return height;
            }
        }

        public class Square : Rectangle {  
            public override void setHeight(int height) {
                base.setHeight(height);
                base.setWidth(height);
            }
            public override void setWidth(int width) {
                base.setWidth(width);
                base.setHeight(width);
            }
        }

        public class Client {
            public void Area(Rectangle r) {
                r.setHeight(5);
                r.setWidth(4);
                Debug.Assert(r.getHeight()*r.getWidth()==4*5);
            }
        }

        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            Client c = new Client();
            Rectangle r = new Square();
            c.Area(r);   // Assertion fails

        }
    }
}
