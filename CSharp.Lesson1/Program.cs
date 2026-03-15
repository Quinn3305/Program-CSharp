namespace CSharp.Lession1;

class Program
{
    static void Main(string[] args)
    {
        //Trong C# có 2 kiểu dữ liệu giống Java tên hơi khác xí
        //- ValueType và Reference Type
        //ValueType
        /* Số nguyên 
         * sbyte    1 Byte
         * byte     1 Byte
         * short    2 Byte
         * ushort   2 Byte
         * int      4 Byte
         * uint     4 Byte
         * long     8 Byte
         * ulong    8 Byte
         */
        
        /* Số thực
         *  float      4 Byte   6 - 9 số đúng  
         *  double     8 Byte   15 - 17
         *  decimal    16 Byte  28 - 29
         */
        
        //Logic & ký tự 
        //char  2 byte
        //bool  1 byte
        
        //Cấu trúc tự định nghĩa : struct & enum
        //struct khác gì với class
        /*
         * struct nằm ở value type
         * Stack
         * khởi tạo không cần new
         * không hỗ trợ kế thừa
         * nhanh với dữ liệu nhỏ
         * sao chép toàn bộ giá trị
         */
        
        /*
         * class nằm ở reference type
         * Heap
         * bắt buộc dùng new
         * hỗ trợ kế thừa
         * Tốn nhiều tài nguyên quản lý vùng nhớ
         * Sao chép địa chỉ vùng nhớ
         */
        
        //struct: hint 
        //trong c là kiểu nhái object
        
        /* Reference Type
         * Class: Mọi lớp bạn tạo ra (ví dụ: Customer, Student).
         * Interface: Các giao diện.
         * Delegate: Các hàm ủy quyền.
         * Dynamic types: object, string, dynamic, array.
         */
            //class: mọi class mà bạn định nghĩa
            //array: 
            //string:
            //object: 
        
        //Về vùng nhớ
        // int a = 2; khai báo này thì 1 vùng nhớ (Stack - Ram)
        // int b = 3; đang được sử dụng
        
        // Anh có 1 class student
        // Sau đó a new mới student s = new Student()
        // Khi mà gõ câu lệnh này thì sẽ có 2 vùng nhớ được sử dụng (Stack và Heap)
        //     keyword s (biến tham chiếu) sẽ sử dụng vùng Stack
        //     và tham chiếu đến object vừa được tạo ra trong HEAP 
        //     thì làm sao để tham chiếu được ? nó lưu lại địa chỉ của thằng tạo ra trong HEAP
        //
        // Student s1 = new Student()
        // Student s2 = s1
        // có 3 vùng nhớ đc sdung s1 và new Student() và tham chiếu s2
        // Vùng nhớ đc tạo ra khác với phân vùng 
        // s1 và s2 sẽ được tạo ra trên Stack
        // 1 object Student sẽ được tạo ra trên HEAP
        // lúc này s1 và s2 sẽ cùng tham chiếu đến đối tượng đc tạo ra trên HEAP
        //
        // những biến hoặc hàm được khai báo static thì nó sẽ nằm ở 1 vùng nhớ riêng, và tồn tại 
        //     //suốt vòng đời của app/ chương trình (Bài OOP sẽ demo 1 thứ căng thẳng)
        //
        // //Các kiểu in ra màn hình 
        // int c = 4;
        // int d = 5;
        // Console.WriteLine(c + d);
        // Console.WriteLine(b);
        // Console.WriteLine("Number b = " + a);
        // Console.WriteLine("Number c = " + c);
        
        // //Modern Style - Placeholder
        // Console.WriteLine("PlaceHolder Number a = {0}", a ,b); //useless nha b ko có tác dụng
        // Console.WriteLine("PlaceHolder Number b = {0}", b);
        // Console.WriteLine("PlaceHolder Number a and b = {0}, {1}", a, b);
        //
        // //Modern Style - Interpolation
        // Console.WriteLine($"Interpolation - Number a = {a}");
        // Console.WriteLine($"Interpolation - Number b = {b}");
        // Console.WriteLine($"Interpolation - Number a and b = {a}, {b}");
        //
        // //Implicit declaration (Khai báo ngầm)
        // //Tại sao nên dùng var ?
        // nó hay khuyên mình khai báo var để nó tự động lựa chọn phù hợp input của mình 
        // nó sợ mik khai báo dư ra quá trời mà sài ko hết
        // var i = 36;
        // Console.WriteLine(i);
        // Console.WriteLine(i.GetType()); //nó là datatype của system
        
        //Function - Method
        // pass by value
         // static void InSoRaManHinh(int a)
         // {
         //     Console.WriteLine(a + 1);
         // }
         // InSoRaManHinh(a:36);
         
         // Pass By Reference
        //C# nó ra đời 2 cái món mới, độc la là out và ref
        //thì hàm này sẽ nhận tham số là 1 con trỏ
        
        // int m = 3;
        // static void PassByReference(ref int a)
        // {
        //     a = 36;
        // }
        // Console.WriteLine("Before Number m = " + m);
        // PassByReference(ref m);
        // Console.WriteLine("After Number m = " + m);
        //Ref truyền vô r muốn xử lý hay ko thì tùy mình 
        //Ref này là bth rồi ,out nè
        //Khi chơi với out là phải bắt buộc sửa lại tham số, độ lại value cho tham số 
        //Out này có nghĩa rằng là, tao hứa sẽ OUT cho m một giá trị
        //Out này ko cần phải khai báo giá trị biến bên ngoài chuyển vô luông
        //out int thì = tôi return 1 con số nguyên
        
        int b = 8;
        static void PassByReferenceV2(out int b) //out int b là tham số tham khảo từ giá trị b mình khai báo trước
        {
            b = 23; //sửa lại tham số
            
        }

        int n ;
        // Console.WriteLine("Before Number n = " + n);
        PassByReferenceV2(out n);
        Console.WriteLine("After Number n = " + n);
        //Đưa rỗng cũng đươcj đầu ra chắc chắn cho bạn một giá trị
        // Console.WriteLine("Before Number l = " + l);
        // PassByReferenceV2(out int l); // khai bóa giá trị vô lun cho nó lẹ lẹ
        // Console.WriteLine("After Number l = " + l);
        
        //Viết nhận vào số n
        //hàm tính tổng từ 0 đến n trả ra sum không cần return

        static void SumInt(int n, out int result)
        {
            result = 0;
            for (int i = 0; i < n; i++)
            {
                result += i;
            }
        }
        SumInt(n:10, out int result);
        Console.WriteLine("Result result = " + result);
        
    
        //Struct va class khác  nhau ở đâu
        //struct là value type, nhỏ gọn hơn so với class, ko có kế thừa, method nhu là class
        Student1 s1 = new Student1() { Age = 10 };
        Student1 s2 = s1;
        s2.Age = 20;
        // Console.WriteLine("Age s1 = "+ s1.Age);
        // Console.WriteLine("Age s2 = "+ s2.Age);
        Point p1 = new Point() { x = 1, y = 2 };
        p1 = new Point(){x = 1, y = 2};
        Point p2 = p1;
        p2.x = 2;
        Console.WriteLine("Age p1 = "+ p1.x);
        Console.WriteLine("Age p2 = "+ p2.y);
    }

    class Student1
    {
        public int Age { get; set; }
    }
    struct Point
    {
        public int x;
        public int y;
    }
    
}