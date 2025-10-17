Hệ Thống Quản Lý Đề Thi Trực Tuyến 
Là hệ thống quản lý cho phép người dùng tạo, chỉnh sửa, thống kê và quản lý các đề thi theo môn học, cấp độ và thời gian thi. 
Ứng dụng được xây dựng bằng  ASP.NET Core Web API, tích hợp JWT Authentication, Swagger và Entity Framework Core để thao tác cơ sở dữ liệu.
Chức năng chính:
Xây dựng người dùng & xác thực
- Đăng ký, đăng nhập, cấp token JWT.  
- Phân quyền Admin và User.  
- Tạo hoặc admin mới được sửa / xóa đề thi.
 Quản lý Đề Thi
- POST /exams – Tạo đề thi mới.  
- GET /exams – Lấy danh sách đề thi (lọc theo `subject` hoặc `level`).  
- PUT /exams/:id – Cập nhật đề thi.  
- DELETE /exams/:id – Xóa đề thi.  
Lưu lại lịch sử chỉnh sửa
- Khi thay đổi `level` hoặc `examDate`, hệ thống tự động lưu lịch sử vào bảng `ExamHistory`.
- GET /exams/:id/history – Xem lịch sử thay đổi của đề thi.
Thống kê Đề Thi
  - GET /exams/statistics – Xem thống kê cá nhân:
  - Tổng số đề thi đã tạo.
  - Số lượng đề theo `level`: EASY / MEDIUM / HARD.
  - Số lượng đề theo `subject`.
- Tỉ lệ phần trăm đề HARD.
Cài đặt & Chạy dự án
Bước 1: Clone source code
git clone 
cd Thư mục
Bước 2: Cấu hình Database:
"ConnectionStrings": {
"DefaultConnection": "Server=.\\SQLEXPRESS;Database=ExamUserDb;TrustServerCertificate=Yes;Trusted_Connection=True;MultipleActiveResultSets=true"
 },
Bước 3: Cài đặt dependencies
dotnet restore
Bước 4: Tạo Migration
dotnet ef database update
Bước 5: Chạy ứng dụng
dotnet run
