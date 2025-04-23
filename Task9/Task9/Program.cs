using System;
using System.Reflection;

// Custom Attribute
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
}

// Sample classes with [Runnable] methods
public class MathOperations
{
    [Runnable]
    public void Add()
    {
        Console.WriteLine("Add: 5 + 3 = " + (5 + 3));
    }

    [Runnable]
    public void Multiply()
    {
        Console.WriteLine("Multiply: 4 * 2 = " + (4 * 2));
    }

    public void NotRunnable()
    {
        Console.WriteLine("You shouldn't see this.");
    }
}

public class StringOperations
{
    [Runnable]
    public void Greet()
    {
        Console.WriteLine("Hello from StringOperations!");
    }
}

// Main
class Program
{
    static void Main()
    {
        Console.WriteLine("Discovering and Executing [Runnable] methods...\n");

        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                if (method.GetCustomAttribute<RunnableAttribute>() != null)
                {
                    Console.WriteLine($"Executing {type.Name}.{method.Name}...");
                    method.Invoke(instance, null);
                    Console.WriteLine();
                }
            }
        }

        Console.WriteLine("Done.");
    }
}
