### Content:
1. Value Type and Reference Type là gì ?
2. Các kiểu in ra màn hình
3. Implicit decleration
4. Ref và Out

### Value Type and Reference Type
#### Value Type
- Số nguyên:  ` short | int    | long`
	`ushort | uint | ulong`
- Số thực:       `float  | double | decimal`
-  `char | bool`
- `struct`
###### Struct: là gì ? Khác gì với class ?
- **Struct:** là **gom** nhiều **biến** liên quan **lại với nhau** 
- **Class:** là gom nhóm dữ liệu và **hành vi** -> dùng cho các đối tượng có hành vi phức tạp 
```Csharp
struct Point  
{  
    public double point;  
    public int rank;  
    public string mssv;  
}
```
- Struct là Value Type còn Class là Reference Type 
#### Reference Type:
- `class | array | string | object`

#### Tổng kết:
| Summize            | Value Type                | Reference Type      |
| ------------------ | ------------------------- | ------------------- |
| Lưu                | Giá trị                   | Địa chỉ             |
| Khi gán            | Copy giá trị              | Copy địa chỉ        |
| Ảnh hưởng lẫn nhau | Không                     | Có                  |
| Ví dụ              | int, double, decimal, ... | stribg, class, .... |
#### Sự khác nhau giữa Stack và Heap và vùng nhớ liên quan đến Value Type & Reference Type
##### Sự khác nhau giữa Stack và Heap 
- **Stack**:
	- Value Type + biến cục bộ (dù là thuộc kiểu Value hay Reference đi chăng nữa thì cũng đều nằm trên bộ nhớ Stack)
	- Hoạt động chồng đĩa (LIFO)
	- Hàm kết thúc, stack xóa sạch
- **Heap**:
	- Dùng cho Reference Type
	- Quản lí bằng Garbage Collector (GC)
- **VD:**
```CSharp
class Person{
	public int Age;
}
Person p = new Person();
```
- ![[../images/Pasted image 20260308111637.png]]
- Nếu:
```CSharp
p.Age = 40; // thì điều gì sẽ xảy ra vậy H ơi ???
```
	- Lúc này: CPU đọc giá trị của P -> lấy giá trị được lưu ở P
	- CPU theo địa chỉ đó sang Heap
	- CPU truy cập và field: Age nằm trong Person ở Heap
	- Gán trị cho field Age = 40
##### Hiện tượng 2 chàng trỏ 1 nàng (tình tay ba)
```CSharp
class Person{
	public int Age;
}
Person p1 = new Person();
Person p2 = p1;
p2.Age = 50; // càng ngày càng hấp dẫn :))

//Lúc này ta có được
Stack              Heap
p1 = 0x01AB   ->   {Age = 50} 
p2 = 0x02AC   -------|
//ta thấy 2 anh này đang trỏ vào 1 nàng
```
- Lúc trước mình suy nghĩ rằng, khi mà: **Person p2 = p1;** thì p2 trỏ vô p1 rồi p1 trỏ vô Person
- Nhưng không phải vậy đâu bạn nhé
- Đây mới là flow của nó:
```CSharp
Person p2 = p1;
```
	- CPU đọc giá trị của p1 (giá trị đó là địa chỉ của Person)
	- Copy y nguyên địa chỉ đó cho P2
	- Rồi đi flow như cũ truy cập vào field Age và gán = 50;
##### Những biến hoặc hàm được khai báo static thì nó sẽ ở 1 vùng nhớ riêng, và tồn tại suốt vòng đời của app/ chương trình
- ![[../images/Pasted image 20260308115337.png]]
> Giải thích: static thuộc vùng nhớ riêng đó là Type mà Type phụ thuộc vào App.
Bạn còn nhớ 2 file được sinh ra khi compile không (.dell .exe). Trong quá trình CLR chuyển từ bytecode sang native code í, nó sẽ load assembly để verity IL có ok không rồi sau đó nhờ JIT chuyển IL thành native code. 
Trong khi load assembly nó sẽ tiến hình load các Type luôn -> Type chạy -> Static nó tồn tại, lúc này App chạy, khi App kết thức thì Type end-> static hết tồn tại.

### Các kiểu in ra màn hình
#### Traditional Style
```CSharp
int a = 1;
int b = 2;
```

```CSharp
Console.WriteLine("Number a = " + a);
Console.WriteLine("Number b = " + b);
//nối chuỗi, C# có cơ chế ngầm
//chuyển int -> toString -> nối chuỗi
```
#### Modern Style - PlaceHolder
```CSharp
Console.WriteLine("Placeholder - Number a = {0}", a);
Console.WriteLine("Placeholder - Number b = {0}", b);
Console.WriteLine("Placeholder - Number a and b = {0}, {1}", a, b);
//{0}, {1}, ... gọi là placeHolder (chỗ trống)
//{0} -> lấy tham số thứ 1 sau dấu,
//{1} -> lấy tham số thứ 2
```
#### Modern Style - Interpolation
```CSharp
Console.WriteLine($"Interpolation - Number a = {a}");
Console.WriteLine($"Interpolation - Number b = {b}");
Console.WriteLine($"Interpolation - Number a and b = {a}, {b}");
//nói với C# rằng:
//Chuỗi này có chứa biến, hãy thay giá trị vào
//{a} = lấy giá trị của biến a
// {b} = lấy giá trị của biến b
```

### Implicit declaration 
	- Tại sao lại nên dùng var ?
	+ Vì var giúp xác định kiển dữ liệu để giảm bộ nhớ lưu trữ 
	+ Giúp để hứng giá trị trả về 
	- Đọc tới đây, hãy liên tưởng đến câu chuyện, nguyên một rảnh đất rộng ơi là rộng, nhưng chỉ trồng một cái cây thui. Var sẽ giúp bạn, xác định vùng đất cần thiết để trồng cây, thu hẹp phạm vi diện tích mà cần dùng để trồng cây.

### Function - Method
	- C# ra đời 2 món độc lạ: out và ref
	- Hàm này sẽ nhận tham số là 1 con trỏ
	- Thằng này gọi là Pass By Reference
#### Ref
```CSharp
int m = 3;  
static void PassByReference(ref int a)  
{  
    a = 36;  
}  
Console.WriteLine("Before Number m = " + m);//3
PassByReference(ref m);  
Console.WriteLine("After Number m = " + m);//36
//tới địa chỉ của biến được bỏ hàm, và gán giá trị khác -> sự thay đổi luôn ở bên ngoài
```
#### Out
```CSharp
static void PassByReferenceV2(out int b)  
{  
    b = 36;// sửa lại tham số
}
int n = 3;  
Console.WriteLine("Before Number n = " + n); //3
PassByReferenceV2(out n);  
Console.WriteLine("After Number n = " + n);//36
```
	- Out có nghĩa là: hứa sẽ OUT ra một giá trị(nên không cần return)
	- Khi chơi với out, bắt buộc phải sửa lại tham số, độ lại value cho tham số
	- Out này không cần phải báo giá trị biến bên ngoài mà chuyền vô luôn

	- Viết hàm tính tổng ừ 0 -> n trả ra sum không cần return lun return là gà
```CSharp
static void SumInt(int n, out int sum)  
{  
    sum = 0;  //nếu ko có dòng này sẽ bị lỗi
    //hiểu đơn giản: out là trả ra, mà muốn trả ra thì phải sửa
    for (int i = 0; i <= n; i++)  
    {        
	    sum += i;    
    }
}
SumInt(10, out int sum);// tương tự như return ở dưới thui
Console.WriteLine($"Gia tri la: {sum}");//55

```
``

### Ta đào sâu hơn một tí về ref out để hiểu rõ hơn nữa
#### I. Ref với Value Type
```CSharp
int h = 0; //phải gán một giá trị khi dùng ref, nếu ko thì bị lỗi  
static void ChangeOrNo(ref int x)  
{  
    x = 100;  
}  
ChangeOrNo(ref h);  
Console.WriteLine("value of h = " + h); // 100
```
![[../images/Pasted image 20260308142744.png]]
#### II. Ref với Reference Type
```CSharp
public class Student  
{  
    public int Age;  
}
static void Change(ref Student student)  
{  
    student = new Student();  
    student.Age = 30;  
}  
Student stu1 = new Student();  
stu1.Age = 10;  
Change(ref stu1);  
Console.WriteLine(stu1.Age);//đón được kết quả không: 30;
```
![[../images/Pasted image 20260308151013.png]]
###### Ref + Value Type -> sửa biến
###### Ref +  Reference Type -> đổi object

```CSharp
int a = 10;// bắt buộc (a = 10),nếu ko có = 10 sẽ lỗi đối với ref
Change(ref a) // dòng này có nghĩa là sửa, mà phải có giá trị thì mới sửa được, nên a phải có giá trị ban đầu, chớ ko thì lỗi đó
//Kiểu như là: Có giá trị ban đầu thì t mới sửa cho m được
```
#### Out
	- Out cũng tương tự là truyền địa chỉ, khác ref ở chỗ ko cần có giá trị tạo trước, nhưng bên trong hàm buộc phải có

```CSharp
void Change(out int x)
{
 x = 10;// đối với out thì lệnh này bắt buộc phải có
 //Kiểu như là: tao không quan tâm m như thế nào, vì tao phải trả ra, nên vào hàm tao phải thay đổi giá trị
}
int a;
Change(out a);//a = 10
```

#### IN: có thằng này nữa nhé
	-Thằng này thì cũng truyền vào địa chỉ biến, nhưng chỉ đọc mà thoi

#### Những câu hỏi ngớ người ?
	- Tại soa Struct không thể null, còn class lại có thể null?
		- Vì struct là Value Type, bản chất nó đã chứa giá trị rồi thì làm sao mà nó null được
		- Còn class null khi nó không trỏ tới Object nào hết