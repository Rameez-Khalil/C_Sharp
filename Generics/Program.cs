class Program
{
    public static void Main(string[] args)
    {
        Student<string> name = new Student<string>("Rameez"); 
        name.printDetails();

    }


   
}


//DEFINING A GENERIC CLASS.
class Student<T>
{
    public T data;

    public Student(T data)
    {
        this.data = data;
        
    }

    public T printDetails()
    {
        Console.WriteLine(this.data);
        return this.data; 
    }


}

 

/*
 * A single class that can be used with multiple other classes - A type that is parameterized by another type.
 * 
 * 
 */