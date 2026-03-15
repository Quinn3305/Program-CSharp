### Content:
1. Client side rendering / Server side rendering ?
2. SEO liên quan gì đến CSR và SSR
3. Lịch sử phát triển của ngôn ngữ lập trình C/C++, Java -> .Net.
4. Runtime, compile -> hiểu rõ hơn về "write once, run anywhere"
5. Bytecode & Native code
6. Flow build & run trong .Net
7. Kiến thức bổ sung:
	- API [[API]]
	- SEO ? Các loại SEO [[SEO]]
### Server side rendering and Client side rendering
#### - SSR(Server side rendering):
- Khái niệm: Là cách render HTML tại server, sau đó gửi HTML hoàn chỉnh(ở đây có nghĩa là đã được "xáo nấu - chế biến") về trình duyệt.
- Luồng xử lý:
		- ![[../images/Pasted image 20260306203038.png]]
- Ưu điểm: 
	- SEO tốt - **Tại sao?** [[Here1]]
	- Máy yếu vẫn dùng tốt
	- Bảo mật cao
- Nhược điểm:
	- Server chịu tải lớn (vì mọi thứ hầu như xảy ra ở server (truy vấn, xử lí, render HTML), còn client chỉ hiển thị nên máy yếu vẫn dùng tốt được)
	- Khó tái sử dụng FE (điều này là hiển nhiên, vì cá lóc nấu canh chua xong, lấy cá lóc đó ra rồi đi kho tộ thì ối dồi ôi thật)
#### - CSR(Client side rendering)
- Khái niệm: là cách render HTML tại browser(trình duyệt), Server chỉ trả ra HTML rỗng
- Luồng xử lí:
	- ![[../images/Pasted image 20260306210900.png]]
- Ưu điểm: 
	- Tái sử dụng data, API, 
	- Server chịu tải nhej
- Nhược điểm:
	- SEO chưa tốt -> [[../Store/Here1|Here1]] Có cách xử lí 
	- Nặng cho client
	- Lộ code JS -> vì server đưa ra HTML rỗng + JS cho Client load

### Tìm hiểu về thế giới thế giới .Net thông qua phân tích C - Java - .NET

##### ByteCode là gì ?
- Là mã trung gian được sinh ra sau khi compile, không chạy được trên CPU mà chạy trên máy ảo (Virtual Machine(VM) hiểu và thực thi được)
##### Native code là gì ?
- Là mã máy - CPU hiểu và chạy được

##### Write one time, run anywhere
###### Các đuôi của java
- .java -> code bạn viết
- .class -> File bytecode
- jar -> đóng gói Java
- war -> đóng gói Web app Java 
###### Khẩu hiệu Write Once, Run Anywhere (WORA) nghĩa là:
- Chỉ cần viết chương trình một lần nhưng có thể chạy trên nhiều hệ điều hành khác nhau mà không cần sửa code. (across-platform).(Nghĩa là chúng ta chỉ cần viết code một lần. Code Java sẽ được biên dịch thành bytecode (.class). Bytecode này không chạy trực tiếp trên CPU mà sẽ được chạy thông qua JVM. JVM sẽ chuyển bytecode thành native code phù hợp với hệ điều hành. Vì mỗi hệ điều hành đều có JVM riêng nên cùng một file bytecode có thể chạy trên nhiều hệ điều hành khác nhau.)
###### Luồng chạy của Java
![[../images/Pasted image 20260306214915.png]]
-  ![[../images/Pasted image 20260306220032.png]]
##### Phân biệt Compile và Runtime
- Compile:
	- Dịch trước khi chạy
	- Complier (Javac, Rosyln)
	- Tạo file mới (.class hoặc .dll hoặc .exe)
	- **Chuyển từ source code -> Byte code**
- Runtime:
	- Vừa chạy vừa dịch
	- Máy ảo (JVM)
	- Không tạo file mới
	- **Chuyển từ Byte code -> Native Code**

##### JDK (Java Development kit): bộ công cụ để phát triển java, bên trong nó chưa:
- JRE(Java runtime environment): chứa thêm 2 thằng
	- JVM: máy ảo để chuyển bytecode -> native code
	- Thư viện
- Compiler (javac)
- Tools

##### Trước khi có Java
- C/C++ được compile -> native code -> chạy trên đúng 1 HĐH(dependence platform)
##### Sự hình thành của Java
- Một bước tiến mới WORA -> cross platform
##### Tiền đề về sự ra đời của .Net
- Một vài đuôi:
	- dll (cho app thực thi)
	- exe (cho thư viện)
	- 2 thằng này chứ mã trung gian là IL (bytecode): được tạo ra sau khi compile
- Ra đời 2002, thấy Java ngon => chế ra .Net Framework nhưng chưa cross-framework
- .NET Framework giống JDK -> nhưng lúc này chỉ chạy trên window mà thôi
- .NET Frameword ra đời giúp chuyển (C#, C++, .Net, F#) -> compiler (Rosyln) thành byte code -> runtime(CLR) thành native code 
- Mấy anh cộng đồng mạng thấy nó ngon mà tiếc quá vì nó chỉ chạy được trên windows nên đã chế ra MONO chạy được trên hệ điều hành Linux
- Khi MONO quá phát triển thì MS mua lại MONO và chế ra **.NET Core**
- MS có thứ anh:
	- .NET Core
	- .NET framwork (windows - only)
	- => Kết hợp tạo ra **.NET** (cross-platform)
##### NET APPLICATION được build và run như thế nào
- Ảnh hệ thống:
	- **.Net SDK**: Bộ công cụ được thiết kế để phát triển, build, test ứng dụng, gồm:
		- **.Net CLI:** Dùng gỡ bỏ mấy câu lệnh linh tinh
		- .Net Runtime: được tích hợp trong SDK gồm CLR(giống JVM ha) và tools
		- .Net Libraries
		- Builds tools và còn nhiều thứ khác nữa
	- ![[../images/Pasted image 20260307051741.png]]
- **Flow chi tiết hơn**:
	- Viết code (development): là viết mấy cái như class, method, variables đồ gì gì đó trong **file .cs**
	- qua complier(Rosyln): giúp chuyển (compiler kiểm tra syntax, type error, ...)
		- **code người -> IL (byte code)**
		- **file .cs -> .dll và .exe**
	- Nhờ thằng trung gian: **CLR(Common Language Runtime)**:
		- Nằm trong .Net Runtime
		-  1 máy giống JVM
		- **Load assembly** (verify CIL/IL) có an toàn không
		- Trong CLR có **1 JIT(Just-In-Time complication)** giúp chuyển IL/CIL -> Native code phù hợp OS mong muốn
		- **Quản lí memory** garbage, collection, exception, ..