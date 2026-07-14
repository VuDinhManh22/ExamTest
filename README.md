# Online Exam Management System (Hệ Thống Quản Lý Đề Thi Trực Tuyến)

Hệ thống Backend được xây dựng bằng **ASP.NET Core Web API** nhằm hỗ trợ quản lý ngân hàng câu hỏi, tạo đề thi, tổ chức thi trực tuyến và chấm điểm tự động cho 3 đối tượng người dùng: Admin, Giáo viên và Thí sinh.

## 🚀 Tính Năng Cốt Lõi
- **Quản lý phân quyền (RBAC):** Admin (Quản trị hệ thống), Giáo viên (Tạo môn học, quản lý ngân hàng câu hỏi, đề thi), Thí sinh (Làm bài thi, xem lịch sử).
- **Bảo mật:** Xác thực và phân quyền qua JWT (JSON Web Token) & Role-based Authorization.
- **Quản lý đề thi:** Tạo đề thi ngẫu nhiên từ ngân hàng câu hỏi theo cấu trúc và độ khó thiết lập sẵn.
- **Thống kê & Báo cáo:** Tự động chấm điểm, lưu lịch sử chỉnh sửa đề thi và xuất báo cáo kết quả thi.
- **Tài liệu hóa:** Tích hợp Swagger UI giúp kiểm thử API dễ dàng.

## 🛠️ Công Nghệ Sử Dụng
- **Backend Framework:** ASP.NET Core Web API (.NET 8 / .NET 9)
- **Database ORM:** Entity Framework Core (Code-First)
- **Database Engine:** SQL Server
- **Security:** JWT Authentication, Role-based Authorization, Password Hashing (BCrypt/Identity)
- **API Documentation:** Swagger / OpenAPI

## 📐 Kiến Trúc Cơ Sở Dữ Liệu (Database Schema)
*Hệ thống bao gồm 10+ bảng nghiệp vụ chính được tối ưu hóa quan hệ:*
- `Users` & `Roles`: Quản lý thông tin và phân quyền người dùng.
- `Subjects`: Quản lý các môn học.
- `Questions` & `Answers`: Ngân hàng câu hỏi trắc nghiệm và đáp án.
- `Exams` & `ExamQuestions`: Quản lý đề thi và danh sách câu hỏi trong đề.
- `StudentExams` & `StudentAnswers`: Lưu vết kết quả bài thi và chi tiết câu trả lời của thí sinh.

## 💻 Hướng Dẫn Cài Đặt & Chạy Khởi Động (Getting Started)

### Yêu cầu hệ thống (Prerequisites)
- .NET SDK (Phiên bản phù hợp với dự án của bạn)
- SQL Server LocalDB hoặc SQL Server Management Studio (SSMS)

### Các bước triển khai dưới Local

1. **Clone dự án về máy:**
   ```bash
   git clone https://github.com
   cd ExamTest
   ```

2. **Cấu hình chuỗi kết nối Database:**
   Mở file `appsettings.json` và cập nhật lại đoạn `ConnectionStrings` phù hợp với SQL Server của bạn:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=ExamManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. **Chạy Migration để tạo Database và dữ liệu mẫu (Seed Data):**
   ```bash
   dotnet ef database update
   ```

4. **Khởi chạy ứng dụng:**
   ```bash
   dotnet run
   ```
   Sau khi ứng dụng chạy thành công, truy cập `https://localhost:[PORT]/swagger` để xem giao diện tài liệu API Swagger.

## 📌 Các Endpoint API Chính (Main API Endpoints)
- `POST /api/auth/login`: Đăng nhập hệ thống và nhận Access Token.
- `GET /api/questions`: Lấy danh sách ngân hàng câu hỏi (Yêu cầu quyền Giáo viên/Admin).
- `POST /api/exams/generate`: Tự động tạo đề thi từ ngân hàng câu hỏi.
- `POST /api/student-exams/submit`: Thí sinh nộp bài và nhận kết quả chấm điểm tự động.
