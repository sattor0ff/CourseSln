using Domain.Models;
using Infrastructure.Services;

System.Console.WriteLine("Insert: show, insert, update, delete.");

var courseService = new CourseService();
int counter = 1;
while(true)
{
    string option = Console.ReadLine();
    if(option == "stop") break;

    _ = option switch
    {
        "show" => Show(),
        "update" => Update(),
        "delete" => Delete(),
        "insert" => Insert(),
        _ => false,
    };
    System.Console.WriteLine("\nInsert: show, insert, update, delete.\n");
}


bool Show()
{
    var courses = courseService.GetCourses();
    System.Console.WriteLine($"Id     Title     Description     Free     Discount");
    foreach(var cour in courses)
    {
        System.Console.WriteLine($"{cour.Id}       {cour.Title}     {cour.Description}     {cour.Free}     {cour.HasDiscount}");
    }
    return true;
}

bool Insert()
{
    var console = new Course(counter);
    System.Console.Write("Your Title: ");
    console.Title = Console.ReadLine();

    System.Console.Write("Your Description: ");
    console.Description = Console.ReadLine();

    System.Console.Write("Your Free: ");
    console.Free = Convert.ToDecimal(Console.ReadLine());

    System.Console.Write("Your Discount: ");
    console.HasDiscount = Convert.ToBoolean(Console.ReadLine());

    courseService.AddCourse(console);
    counter++;

    return true;
}

bool Update()
{
    System.Console.Write("Course ID for Update: ");
    int id = Convert.ToInt32(Console.ReadLine());
    var course = new Course(id);
    System.Console.Write("Your Updated Title: ");
    course.Title = Console.ReadLine();

    System.Console.Write("Your Updated Description: ");
    course.Description = Console.ReadLine();

    System.Console.Write("Your Free: ");
    course.Free = Convert.ToDecimal(Console.ReadLine());

    System.Console.Write("Your Discount: ");
    course.HasDiscount = Convert.ToBoolean(Console.ReadLine());

    courseService.UpdateCourse(course);
    return true;
}

bool Delete()
{
    System.Console.Write("Course ID to Delete: ");
    int id = Convert.ToInt32(Console.ReadLine());
    courseService.Delete(id);
    return true;
}