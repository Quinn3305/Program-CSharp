### Đầu tiên chúng ta phải hiểu được Google bot hoạt động như thế nào?
- Khi một trang web xuất hiện trên Internet, **bot của Google** (ví dụ: Googlebot) sẽ:
	- Gửi **HTTP request** đến server của website
	- Server trả về **HTML của trang web**
	- Bot **đọc nội dung HTML**
	- Google **index nội dung đó vào database tìm kiếm**
	- Ví dụ:
		- Resquest:
			- ```CSharp
			  GET https://example.com/products
			  ```
		- Server trả về HTML
		- ```HTML
			  <h1>Danh sách sản phẩm</h1>  
				<ul>  
					<li>Iphone</li>  
					<li>Táo</li>  
					<li>Cam</li>  
				</ul>
		  ```
		- Google bot **đọc được ngay nội dung** "Danh sách sản phẩm", "Iphone", "Táo"....
		- => Google sẽ biết được trang này đang nói về sản phẩm => SEO tốt
### SSR hoạt động như thế nào?
- Trong SSR:
	- Bot gửi request lên server
	- Server render trang hoàn chỉnh trước
	- Server gửi HTML đã có dữ liệu cho client
	- Ví dụ server render sẵn:
		- ```CSharp
		  <h1>Danh sách sản phẩm</h1>  
				<ul>  
					<li>Iphone</li>  
					<li>Táo</li>  
					<li>Cam</li>  
				</ul>

		  ```
	     - Ní Bot đó đọc được nội dung thật ngay lập tức, ngon ơ luôn

### CSR hoạt động như thế nào?
- Server chỉ trả ra HTML rỗng + file js
	- ```CSharp
	  <div id="root"></div>
	  <script src="app.js"></script>
	  ```
	- Lúc này Client tả JS
	- JS gọi API
	- Rồi JS mới render nội dung. Sau đó mới ra:
		- ```HTML
		  <h1>Danh sách sản phẩm</h1>  
			<ul>  
				<li>Iphone</li>  
				<li>Táo</li>  
				<li>Cam</li>  
			</ul>
		  ``` 
	- Vài vấn đề nổ ra:
		- Google bot không phải lúc vào cũng load file Js này để lấy được nội dung mà đánh giá
		- Hoặc là việc chạy tốn time vãi cả nồi
		- => Google khó đọc được nội dung của web mình hơn
### Vì sao SSR SEO tốt hơn
1. Nội dung có sẵn trong HTML, không cần phải load Js => Google khó đọc nội dung hơn
2. Index nhanh hơn:
	- Google không cần
	- Tải JS
	- Chạy JS
	- gọi API
3. Metadata đầy đủ
	- SSR render được:
		- ```HTML
		  <title>Danh sách sản phẩm</title>
			<meta name="description" content="Các sản phẩm tốt nhất">
		  ```
	- Google hiểu được web đang nói cái gì
4. Tốc độ tải trang nhanh hơn cho bot: Bot chỉ cần đọc HTML