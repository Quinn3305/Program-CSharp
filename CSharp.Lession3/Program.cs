using System.Text;

namespace Lession3;

class Program
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Category { get; set; } = "";
    }

    public class ProductDto
    {
        public string Name { get; set; } = "";
        
        public decimal Price { get; set; }
        
        public string Category { get; set; } = "";
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        //khi chưa sdung LinQ
        List<int> list = [1, 2, 3, 4, 5];
        foreach (var item in list)
        {
            if (item % 2 != 0)
            {
                //filter số lẻ
                Console.WriteLine(item);
            }
        }
        
        //Sử dụng LinQ
        var list2 = list.Where(x => x % 2 == 0);
        //Bản chất của Where là Duyệt List, và apply điều kiện bên trong vòng for
        //công cụ lọc ra cái mình cần
        
            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    Console.WriteLine(item);
                }
            }
        
            /*
             * Giới thiệu LINQ
             * LINQ (Language Intergrated Query)
             * Là tính năng truy vấn dữ liệu được tích hợp trực tiếp vào ngôn ngữ C#
             * Trước đây:
             * 
             * - Muốn query database --> viết SQL
             * - Muốn lọc list -> viết vòng `for` sau đó ìf else // đã demo
             * - Muốn xử lý xml -> dùng API riêng
             *
             * LINQ giúp bạn:
             * 
             * - viết truy vấn dữ liệu bằng cú pháp thống nhất trong C# // xíu nữa demo
             * - Query đc nhiều nguồn dữ liệu khác nhau
             * - Không cần chuyển ngữ cảnh giữa C# và SQL // xíu nữa demo
             
             LinQ có 3 dạng chính : 
             - LinQ to Object
             - LinQ to XML (Json, Document)
             - LinQ to SQL (Entities)
             */
            
            //LinQ to Object: dung de query: List, Array, Dictationary HashSet, Stack, Queue,..
            List<int> demoLinQToObject = [1, 2, 3, 4, 5];
            var result  = demoLinQToObject.Where(x => x % 2 != 0);
            //LinQ to SQL (Entities), Dùng để query database, LinQ sẽ tự động chuyển đổi code C# sang SQl
            //LinQ + kết hợp với Entity Framework giúp bạn viết truy vấn database bằng C# thay vì SQL
            //và EF sẽ tự động chuyển sang SQL 
            //Đã demo trong UserController.cs
            //ví dụ : _dbcontext.Users.Where(x => x.FirstName.Contains("abc"))
            //Same with: SELECT * FROM Users WHERE FirstName LIKE '%abc%'
            
            // Lợi ích của LinQ
            //1. Viết code ngắn gọn, dễ đọc, dễ hiểu
            /*
             Thay vì phải Foreach(){
                if(condition){
                    //do sthing
                }
             }
             Bây giờ chỉ cần
             var result = collection.Where(x => condition)
             */
        
            //2. Dễ dàng trong việc ptrien, ko truy vấn sai
            //Khi viêt Query bằng SQL, SQL chỉ là string - chuỗi
            //bạn có thể viết sai cú pháp or sai tên bảng tên cột
            //Trong Table User có các field: Id, FirstName, LastName, Email
            //SELECT * FROM User Where FirstnName = 'abc'
            
            //khi mà sài LinQ thì đkien theo field nào thì chấm ra thôi,
            // đi theo Class ko sai đc
            /*
             * Hai cú pháp LinQ, 2 cách thể hiện LinQ
             *
             * 1. LinQ Query Syntax: giống như SQL, nhưng viết trong C#
             * var result = from p in users
             *              where p.FirstName.Contains("abc")
             * 
             * 2. Linq Method Syntax: sử dụng các method mở rộng của LinQ, viết theo kiểu chuỗi method
             * var result = users.Where(x => x.FirstName.Contains("abc"))
             *
             */
            
            /*
             * Deferred Execution (Lazy Loading) và Immediate Execution (Eager Loading)
             */
            /*
             * Deferred Execution (Lazy Loading)
             * -LinQ sẽ không chay ngay khi b vừa viết xong
             * - nó chỉ hỗ trợ xây dựng 1 biểu thức (Expression) - 1 bảng kế hoạch
             * và chờ đến khi b Duyệt (Interate),
             * thì nó (kết quả) mới thực thi
             * 
             */
            List<int> DemoDeferredExecution = [1, 2, 3, 4, 5];
            var filterList  = DemoDeferredExecution.Where(x => x % 2 == 0);
            //filterList có thể gọi là một bảng kế hoachj filter, chờ đợi đẻe duyệt và trả ra kết quả 
            //Còn đối với tương tác với db thì nó đc coi như là 1 câu Query nóng hổi vừa được viết ra
            // nhưng mà chưa được thực thi.
            
            DemoDeferredExecution.Add(6);
            //kiểu như trước foreach thì có nghĩa là nó chưa chạy duyệt cho mình
            //nên lúc mình add thêm thì nó vẫn xử lý add thêm r chạy
            //code chayj từ trên xun mà
            foreach (var num in filterList)
            {
                Console.WriteLine(num);
            }
            
            // Deffered Query Operators phổ biến
            /*
             * -Where
             * -Select
             * -OrderBy, OrderByDescending
             * -GroupBy
             * -Join
             * -Skip, SkipWhile
             * -Take, TakeWhile
             * -Distinct
             * -> Mấy thằng trên trả về IEnumerable hoặc IQueryable (interface của dotNet) // Trong tương lai sẽ biết
             * 
             */
            /*
             * Immediate Execution (Eager Loading)
             * - Query trả ra kết quả ngay lập tức khi gọi phương thức
             * Thay vì duyệt foreach thì h dùng hàm này nó chạy ra liền lun
             * 
             * Chỉ có một số ít các phương thức sẽ kích hoạt đc thực thi Query
             * ToList(), ToArray(), ToDictionary(), Count(),
             * FirstOrDefault(), First(), SingleOrDefault(), Single(),...Trả ra phần tử đầu tiên
             * 
             */
            //Ví dụ : Cái tetpee á .ToList()
            
            //Các bộ sưu tập LINQ hay sử dụng 
            //Lấy một list data
            
            
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "iPhone 15",     Price = 25000, Category = "Điện thoại" },
                new Product { Id = 2, Name = "Samsung S24",   Price = 22000, Category = "Điện thoại" },
                new Product { Id = 3, Name = "MacBook Air",   Price = 32000, Category = "Laptop" },
                new Product { Id = 4, Name = "Dell XPS",      Price = 28000, Category = "Laptop" },
                new Product { Id = 5, Name = "AirPods Pro",   Price = 6500,  Category = "Phụ kiện" },
                new Product { Id = 6, Name = "Galaxy Buds",   Price = 4500,  Category = "Phụ kiện" }
            };
            List<Product> productDemoPagings = new List<Product>
            {
                new Product { Id = 1, Name = "iPhone 15",     Price = 25000, Category = "Điện thoại" },
                new Product { Id = 2, Name = "Samsung S24",   Price = 22000, Category = "Điện thoại" },
                new Product { Id = 3, Name = "MacBook Air",   Price = 32000, Category = "Laptop" },
                new Product { Id = 4, Name = "Dell XPS",      Price = 28000, Category = "Laptop" },
                new Product { Id = 5, Name = "AirPods Pro",   Price = 6500,  Category = "Phụ kiện" },
                new Product { Id = 6, Name = "Galaxy Buds",   Price = 4500,  Category = "Phụ kiện" },
                new Product { Id = 7, Name = "iPhone 15",     Price = 25000, Category = "Điện thoại" },
                new Product { Id = 8, Name = "Samsung S24",   Price = 22000, Category = "Điện thoại" },
                new Product { Id = 9, Name = "MacBook Air",   Price = 32000, Category = "Laptop" },
                new Product { Id = 10, Name = "Dell XPS",      Price = 28000, Category = "Laptop" },
                new Product { Id = 11, Name = "AirPods Pro",   Price = 6500,  Category = "Phụ kiện" },
                new Product { Id = 12, Name = "Galaxy Buds",   Price = 4500,  Category = "Phụ kiện" },
                new Product { Id = 13, Name = "iPhone 15",     Price = 25000, Category = "Điện thoại" },
                new Product { Id = 14, Name = "Samsung S24",   Price = 22000, Category = "Điện thoại" },
                new Product { Id = 15, Name = "MacBook Air",   Price = 32000, Category = "Laptop" },
                new Product { Id = 16, Name = "Dell XPS",      Price = 28000, Category = "Laptop" },
                new Product { Id = 17, Name = "AirPods Pro",   Price = 6500,  Category = "Phụ kiện" },
                new Product { Id = 18, Name = "Galaxy Buds",   Price = 4500,  Category = "Phụ kiện" },
            };
            
            //Where, dùng để truy vấn dữ liệu 
            var phoneList = products.Where(x => x.Category == "Điện thoại").ToList();
            foreach (var phone in phoneList)
            {
                Console.WriteLine($"Điện thoại: {phone.Name} - Giá: {phone.Price}");
            }
            //Tìm sản phẩm iphone 15
            
            
            var namePhone = products.Where(p => p.Name == "iPhone 15").ToList();
            foreach (var phone1 in namePhone){
                Console.WriteLine($"Điện thoại: {phone1.Name} ");
            }
            
            //Lấy ds spham của điện thoại và Phụ kiện
            var phoneList1 = products.Where(x => x.Category == "Điện thoại" || x.Category == "Phụ kiện" ).ToList();
            foreach (var phone2 in phoneList)
            {
                Console.WriteLine($"Điện thoại: {phone2.Name}");
            } 
            
            //Lấy ds spham có Id lớn hơn 2 và bé hơn 5
            var idList = products.Where(x => x.Id > 2 && x.Id < 5 ).ToList();
            foreach (var phone3 in idList)
            {
                Console.WriteLine($"Điện thoại: {phone3.Name}");
            } 
            //Phân trang: từ khóa qtrong tránh bị lãng phí
            //
            //ở trong LinQ cungx có method hỗ trợ tỏng 
            //Skip - Take
            int pageSize = 5;
            int pageIndex = 4;
            var pageProducts =  productDemoPagings.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            foreach (var phone in pageProducts)
            {
                Console.WriteLine($"Id: {phone.Id} - Điện thoại: {phone.Name} - Giá: {phone.Price}");                
            }
            //Lession 13
            //lấy iphone15
            var iphone15Demo = products.Where(x => x.Name == "iPhone15").FirstOrDefault();
            var iphone15FirstOrDefault =  products.FirstOrDefault(x => x.Name == "iPhone15");
            //này là ra cái mảng sau đó 
            
            //FistOrDefault, SingleOrDefault, First, Single
            //
            //
            //
            //
            //Dao trong Java 
            
            //2 Projection: Tuong tư như là Map trong js
            //Tôi không mún ng dùng thấy cái nhạy cảm tôi dùng select để thay đổi thành cái user mún thấy
            // var productDtos = productDemoPagings.Select(x => new ProductDto(){
            //     Name = x.Name,
            //     Price = x.Price,
            //     Category = x.Category
            // }).ToList();
            //Nó sẽ 1 Trường hợp bắt buộc phải sử dụng trong Database khi truy vấn, nếu ko sử dụng sẽ gặp 1 lỗi rất lớn 
            //mng nhớ nhắc anh ?????
            //3. Order: Sắp xếp
            //Sắp xếp theo giá tăng dần 
            var accendingPriceProduct = productDemoPagings.OrderBy(x => x.Price).ToList();

            foreach (var phone in accendingPriceProduct)
            {
                Console.WriteLine($"Id: {phone.Id} - Điện thoại: {phone.Name} - Giá: {phone.Price}");
            }
            
            //Sắp xếp theo giá giảm dần 
            var decendingPriceProduct = productDemoPagings.OrderByDescending(x => x.Price).ToList();

            foreach (var phone in decendingPriceProduct)
            {
                Console.WriteLine($"Id: {phone.Id} - Điện thoại: {phone.Name} - Giá: {phone.Price}");
            }
            
            //Sắp xếp theo giá tăng dần, nếu giá = thì sắp xếp theo id giảm dần
            var accendingPriceProductV2 = productDemoPagings
                .OrderBy(x => x.Price)
                .ThenByDescending(y => y.Id);
            var resultV2 = accendingPriceProductV2.ToList();
            foreach (var phone in resultV2)
            {
                Console.WriteLine($"Id: {phone.Id} - Điện thoại: {phone.Name} - Giá: {phone.Price}");
            }
            
            //Tìm ra sản phẩm Galaxy Buds và Iphone 15 , sau đó sắp xếp theo giá sản phẩm giảm dần,
            //nếu giá == thì sắp xếp theo tên tăng dần 
            //và mapping sang Product Dto
            
            var phoneList2 = products
                    .OrderBy(x => x.Name == "Galaxy Buds" || x.Name == "Iphone 15" )
                    .ThenByDescending(y  => y.Price);
            
            var phoneList3 = products
                .Where(x => x.Name == "Galaxy Buds" || x.Name == "Iphone 15" )
                .OrderByDescending(y => y.Price)
                .ThenBy(z => z.Price );
           
            var productDtos = phoneList3.Select(x => new ProductDto(){
                Name = x.Name,
                Price = x.Price,
                Category = x.Category
            }).ToList();
            
            var query = productDemoPagings
                .Where(x => x.Name == "Galaxy Buds" || x.Name == "Iphone 15");
            string? searchTerm = null;
            //ví dụ mún thêm đk đi 
            if (searchTerm != null)
            {
                query = query.Where(x => x.Name.Contains(searchTerm));
            }
            
            query = query.OrderByDescending(y => y.Price).ThenBy(x => x.Name).ToList();

            var mappingQuery = query.Select(x => new ProductDto()
            {
                Name = x.Name,
                Price = x.Price,
                Category = x.Category
            });
            
            var finalResult = mappingQuery.ToList();
    } 
    
    
}