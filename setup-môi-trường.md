1. Tại sao lại set up : 
	 - **Microsoft.EntityFrameworkCor**e, (Repo)
	 - **Microsoft.EntityFrameworkCore.Design**, (Api, Repo) 
	 - **Npgsql.EntityFrameworkCore.PostgreSQL** (Repo)
	 - **Swashbuckle.AspNetCore** (Api)
	
	- **Microsoft.EntityFrameworkCor**e:
		- Đây là trái tim của EF Core
		- Nó cung cấp các thằng như:
			- DbContext: Cầu nối giữ C# và Database(đại diện), nó:
				- Quản lí connection
				- Quản lí entity
				- Theo dõi thay đỏi
				- Thực hiện SaveChanges()
			- DbSet: đại diện cho 1 table, ex:
				- `_context.Users.Add(user);`
				- `_context.Users.Add(user);`
				- `_context.Users.Remove(user);`
			- LING query: viết query bằng C# thay vì SQL, ví dụ:
				- sql: `SELECT * FROM Users WHERE Age > 18`
				- LINQ:` var users = _context.Users`
					    `.Where(u => u.Age > 18)`
					    `.ToList();`
				- EF sẽ tự convert sang SQL.
			- Change Tracking
				- Theo dõi object bạn lấy ra
				- Biết nó thay đổi gì
				- Khi SaveChange() -> generate SQL phù hợp
			- Relationship mapping
			- SaveChanges(): lệnh commit toàn bộ thay đổi xuống DB, EF sẽ:
				- Phân tích change tracker
				- Tạo SQL phù hợp
				- Gửi xuống database
				- Commit transaction
	- **Npgsql.EntityFrameworkCore.PostgreSQL**:
		- Đây là Database Provider
		- EF Core là ORM, nếu muốn nói chuyện với DB cụ thể -> cần provider
		- Ex:
			- SQL Server -> Microsoft.EntityFrameworkCore.SqlServer
			- PostgreSQL -> Npgsql.EntityFrameworkCore.PostgreSQL
	- **Microsoft.EntityFrameworkCore.Design**:
		- Thằng này dùng cho Migration, hỗ trợ các lệnh như: Add-Migration, Update-Database
		- Nó giúp: 
			- Sinh ra file migration
			- So sánh model với DB
			- Generate SQL script
	- **Swashbuckle.AspNetCore**:
		- Swashbuckle: là một thư viện giúp:
			- Generate Swagger / OpenAPI documentation
			- Tạo giao diện web test API tự động
			- Khi bạn chạy project - cái UI hiện ra đó chính là Swashbuckle
		- Tại sao lại setup nó ở layerAPI
			- Bởi vì swagger chỉ liên quan đến
				- Controller
				- Route
				- Req/ Res
				- HTTP method
		- Các mà swagger hoạt động như thế nào ? Khi app chạy Swashbuckle sẽ
			- Scan toàn bộ Controller
			- Đọc attribute:
				- `[HttpGet]`
				- `[HttpPost]`
				- `[Route("api/users")]`
			- Generate OpenAPI JSON
			- Render thành UI
		- Nó có khác PostMan không:
			- Auto generate từ code - postman tạo req thủ công
			- Dùng cho team - postman dùng có cá nhân/ test
2. Reference giữa các project là gì? Tại sao lại set cái này:
	- Ta có 3 layers: Api, Service, Repository
	- Ta reference: Api -> Service, Service - Repository
	- **Reference**: cho phép project này xài code của project kia
3. Nếu muốn connect xuống DB thì làm sao ?
	- B1: Cấu hình đường dẫn tới database
		- Bước 1: Cấu hình connection strong trong file appsettings.json:
			- `"ConnectionStrings": {`
			  `"DefaultConnection": "Host=localhost;Port=5432;Database=hahahuhu;Username=postgres;Password=123456"
				}`
		- Bước 2: Đăng ký DbContext trong Program.cs
			-` builder.Services.AddDbContext<AppDbContext>(options =>`
					`... ration.GetConnectionString("DefaultConnection")));`
	- B2: Tạo database
	- B3: Chạy migration
	- B4: update database