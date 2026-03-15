namespace CSharp.Lesson2;

class Program
{
    public class Student
    {
        // Instance Variables - Biến dùng để lưu trữ INFO của 1 OBJECT
        // Age, Name, Gender
        
        //Trong C# thuật ngu Instance Variables //
            //- Được gọi tên là Backed-Field, Data Field
            // - Biến dùng để lưu INFO của 1 OBJECT
            
        // Neu ma minh ko gi public thì mac dinh sẽ là private
        // Access Modifier: public - private - protected - default
        // string _id = "36";
        // int b = 36;
        // double c = 3.6;
        
        // Neu ma minh ko bo gia tri khoi tao, thi se duoc mang cac gia tri mac dinh
        // int: 0
        // bool: false
        // Datetime: 01/01/0001 00:00:00
        // string: null
        // class: null
        // array: null
        // struct: 0

        // public string name;
        
        // Constructor - ham khoi tao, phễu
        // 1 Class có thể có nhieu constructor dc ko ? Yes I do
        // 1 Class thi ko co 1 doan code nao ve contructor duoc khong | Yes I do
            // 1 Empty Constructor se duoc khoi tao mac dinh, ngay ca khi chung ta khong khai bao luon
        // Khi co nhieu constructor trong class thi no duoc goi la - Constructor Overloading
        
        // public string name;
        // public int age;
        //
        // public Student(string name, int age)
        // {
        //     this.name = name;
        //     this.age = age;
        // }
        //
        // public Student()
        // {
        //     this.name = "Hào";
        //     this.age = 10;
        // }

        //Mục tiêu, hieu duoc | public string Name {get; set;}
        // In the old time: Ngay xua ngay xua, ghi can get va set gia tri cho 1 field
            // Thi ta can getter va setter
            
        private string _name;
        
        public string GetName()
        {
            return _name;
        }
        
        public void SetName(string name)
        {
            this._name = name; //this ở đây là thừa ko cần thiết
        }
        
        // Expression Body, neu nhu 1 ham chi xu ly 1 và chi 1 logic don gian 
        // thi minh co the thay the {} bang =>
        
        private string _age;
        public string GetAge() => _age;
        public void SetAge(string age) => this._age = age;
        
        // Property - thuoc tinh | Dai dien cho Backed-Field
        private string _gender;

        public string Gender
        {
            get {return _gender;}
            set {_gender = value;}
        }
        
        //
        
        private string _boyFriendName;
        
        //Full-Property
        public string BoyFriendName
        {
            set => _boyFriendName = value;
            get => _boyFriendName;
        }


        private string _money;
        public string Money
        {
            set => _money = value;
            get => _money + "VND";
        }
        
        public string House { set; get; }
    }

    public class Person
    {
        public static int Age { get; set; } //nằm ở vùng nhớ riêng ko chơi heap và stack
        public string Name { get; set; }
        public string Gender { get; set; }

        public Person(int age, string name, string gender)
        {
            Age = age;
            Name = name;
            Gender = gender;
        }

        public string GetAge()
        {
            return Age.ToString();
        }
    }
    
    //Static la 1 vung nho rieng, khong choi chung voi may thang con lai
    public abstract class Shape
    {
        public string Name;
        public abstract double Area();
    }

    // class: Parent Class, Interface1, Interface2
    // 1 class trong C# chi co ke thua 1 cha
    // tai sao 1 class chi co the có 1 cha trong C# ? 
    /*
         * // Cú pháp: ClassCon : ClassCha, Interface1, Interface2...
    public class Rectangle : Shape, IColorable, IResizable 
    {
        // 1. Kế thừa từ Shape (Cha): Lấy các thuộc tính như Name, Color
        // 2. Thực thi Interface1: Cam kết có kỹ năng tô màu
        // 3. Thực thi Interface2: Cam kết có kỹ năng thay đổi kích thước
    }
     */
    public class Rectangle : Shape
    {
        public override double Area()
        {
            throw new NotImplementedException();
        }
    }
    /*
             // Lớp cha (Base Class)
        public abstract class Shape 
        {
            public string Name; // Field dùng chung cho mọi hình
            
            // Phương thức trừu tượng: buộc các con phải tự định nghĩa cách tính diện tích
            public abstract double Area(); 
        }

        // Lớp con (Derived Class) kế thừa từ Shape
        public class Rectangle : Shape 
        {
            public double Width { get; set; }
            public double Height { get; set; }

            // Sử dụng 'override' để viết code cụ thể cho hàm tính diện tích của hình chữ nhật
            public override double Area() 
            {
                return Width * Height;
            }
        }
     */
    static void Main(string[] args)
    {
        // Student s1 = new Student();
        // Student s2 = new Student("Hien", 18);
        // Console.WriteLine("Name: ", s1.name); //null nên ko in ra 
        
        // Demo getter/setter
        // Student s1 = new Student();
        // s1.SetName("Binh");
        // Console.WriteLine("Name: " + s1.GetName());
        //
        // s1.Gender = "Female";
        // Console.WriteLine("Gender: " + s1.Gender);
        //
        // s1.BoyFriendName = "Diep";
        // Console.WriteLine("BoyFriendName: " + s1.BoyFriendName);
        
        // Person p1 = new Person(10, "Tan", "Male");
        // Person p2 = new Person(20, "Binh", "Male");
        // // p1.Age = 123; //nam o vung nho khac, gia tri cua age dc khoi tao, 3 thang nay o 3 vung nho khac nhau ko dung 
        // //cham gi
        // Console.WriteLine("p1: " + p1.GetAge()); //20
        // Console.WriteLine("p2: " + p2.GetAge());
    }
}