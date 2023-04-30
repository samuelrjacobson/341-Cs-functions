 /* receive test scores and display summary data */
void scores()
{	
	string name;
	int score;
	int min = -1;
    string minName = "";
    int max = -1;
    string maxName = "";
    double avg = 0;
    int countStudents = 0;

    while (true)
    {
        Console.Write("Enter a name and score: ");
        string line = Console.ReadLine();

        if (line == "-1") break; /* quit when user inputs -1 */
		
		string[] words = line.Split(" ");
		name = words[0];
		score = Convert.ToInt32(words[1]);

        /* set variables in first iteration */
        if (countStudents == 0)
        {
            minName = name;
            maxName = name;
            min = score;
            max = score;
        }
        else
        {
            if (score < min) /* Find minimum score */
            {
                min = score;
                minName = name;
            }
            if (score > max) /* Find maximum score */
            {
                max = score;
                maxName = name;
            }
        }
        avg += score; /* calculate average */
        countStudents++;
    }
    avg /= countStudents;

    /* display summary data */
    Console.WriteLine("Average: " + avg + "\nMinimum: " + min + "\nMaximum: " + max);
    Console.WriteLine("Student with lowest score: " + minName);
    Console.WriteLine("Student with highest score: " + maxName);
}
/* generate user ID and password based on name */
void createIdPassword(string last, string first)
{
	/* convert name to uppercase */
    first = first.ToUpper();
    last = last.ToUpper();
	
	/* set user id */
    string id = first[0] + last;
	
	/* set password */
    string pw = "" + first[0] + first[first.Length - 1] + last.Substring(0, 3) + first.Length + last.Length;
	
	/* print id and password */
    Console.WriteLine("ID: " + id);
    Console.WriteLine("Password: " + pw);
}
/* read student information from file, sort and output to file */
static void fileSort(string infile, string outfile)
{
	StreamReader fin = new StreamReader(infile); /* open file for reading */
	
	string line = fin.ReadLine();
	int numStudents = Convert.ToInt32(line); /* get number of students */ 
    
	/* create arrays to hold data */
	int[] id = new int[numStudents];
	char[] grade = new char[numStudents];
	double[] gpa = new double[numStudents];


    /* read values to arrays */
    for (int i = 0; i < numStudents; i++)
    {
		line = fin.ReadLine();
		string[] words = line.Split(" ");
		id[i] = Convert.ToInt32(words[0]); /* add value to id array */
        grade[i] = words[1][0]; /* add value to grade array */
        gpa[i] = Convert.ToDouble(words[2]); /* add value to gpa array */
    }

    /* insertion sort by id */
    for (int i = 1; i < numStudents; i++)
    {
        int idToSort = id[i];
        char gradeToSort = grade[i];
        double gpaToSort = gpa[i];

        int j;
        for(j = i - 1; j >= 0; j--)
        {
           if(id[j] < idToSort) break;
           id[j + 1] = id[j];
           grade[j + 1] = grade[j];
           gpa[j + 1] = gpa[j];
        }
        id[j + 1] = idToSort;
        grade[j + 1] = gradeToSort;
        gpa[j + 1] = gpaToSort;
    }

	/* write info to output file */
	StreamWriter fout = new StreamWriter(outfile);
	fout.WriteLine(numStudents);
    for(int i = 0; i < numStudents; i++)
    {
        fout.WriteLine(id[i] + " " + grade[i] + " " + gpa[i]);
    }

    fin.Close();
    fout.Close();
}
/* Rectangle class defines a rectangle */
class Rectangle
{
	private int width;
	private int height;
	
	/* constructors */
	public Rectangle()
	{
		width = 0;
		height = 0;
	}
	public Rectangle(int size)
	{
		width = size;
		height = size;
	}
	public Rectangle(int width, int height)
	{
		this.width = width;
		this.height = height;
	}
	
	/* setters */
	public void setWidth(int width)
	{
		this.width = width;
	}
	public void setHeight(int height)
	{
		this.height = height;
	}
	
	/* getters */
	public int getWidth()
	{
		return width;
	}
	public int getHeight()
	{
		return height;
	}
	public int area()
	{
		return width * height;
	}
	
	/* print data */
	public void display()
	{
		Console.WriteLine("Width is " + width + " and height is " + height);
	}
}
/* Person class defines a Person */
class Person
{
	private string name;
	private int age;
	
	/* constructor */
	public Person(string name, int age)
	{
		this.name = name;
		this.age = age;
	}
	
	/* setters */
	public void setName(string name)
	{
		this.name = name;
	}
	public void setAge(int age)
	{
		this.age = age;
	}
	
	/* getters */
	public string getName()
	{
		return name;
	}
	public int getAge()
	{
		return age;
	}
}
/* Student class defines student, inherits name and age from Person */
class Student : Person
{
	private int id;
	private double gpa;
	
	/* setters */
	public void setId(int id)
	{
		this.id = id;
	}
	public void setGpa(double gpa)
	{
		this.gpa = gpa;
	}
	
	/* getters */
	public int getId()
	{
		return id;
	}
	public double getGpa()
	{
		return gpa;
	}
	
	/* print data */
	public void show()
	{
		Console.WriteLine("Name: " + name);
		Console.WriteLine("Age: " + age);
		Console.WriteLine("ID: " + id);
		Console.WriteLine("GPA: " + gpa);
	}
}