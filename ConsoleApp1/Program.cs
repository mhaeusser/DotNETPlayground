public class Animal { public virtual void Speak() => Console.WriteLine("Animal speaks"); }
public class Dog : Animal { public void Speak() => Console.WriteLine("Woof!"); }
public class Cat : Animal { public override void Speak() => Console.WriteLine("Meow!"); }

public class Program
{
	public static void MainOff()
	{
		Animal a = new Dog();
		a.Speak();
		a = new Cat();
		a.Speak();
	}
}
