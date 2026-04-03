# 🚀 Hệ Thống Quản Lý Đề Thi Trực Tuyến

![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-green)
![JWT](https://img.shields.io/badge/Auth-JWT-orange)
![Swagger](https://img.shields.io/badge/API-Swagger-brightgreen)
![EF Core](https://img.shields.io/badge/ORM-EntityFramework-purple)

---

## 📌 Giới thiệu

Hệ thống Quản Lý Đề Thi Trực Tuyến cho phép người dùng:

- Tạo, chỉnh sửa và quản lý đề thi 📚  
- Thống kê dữ liệu 📊  
- Phân quyền người dùng 🔐  

👉 Công nghệ sử dụng:

- ASP.NET Core Web API  
- JWT Authentication  
- Swagger  
- Entity Framework Core  

---

## 🔑 Chức năng chính

### 👤 Xác thực & Phân quyền
- ✅ Đăng ký / Đăng nhập  
- 🔐 Cấp token JWT  
- 👑 Phân quyền Admin / User  

---

### 📝 Quản lý đề thi
- ➕ Tạo đề thi mới  
- ✏️ Cập nhật đề thi  
- ❌ Xóa đề thi  

#### 📡 API Endpoints

| Method | Endpoint | Mô tả |
|-------|---------|------|
| POST | `/exams` | Tạo đề thi |
| GET | `/exams` | Lấy danh sách (lọc theo subject, level) |
| PUT | `/exams/{id}` | Cập nhật đề |
| DELETE | `/exams/{id}` | Xóa đề |

---

### 🕓 Lịch sử chỉnh sửa
- 🔄 Tự động lưu khi thay đổi `level` hoặc `examDate`  
- 📂 Lưu vào bảng `ExamHistory`  

| Endpoint | Mô tả |
|----------|------|
| GET `/exams/{id}/history` | Xem lịch sử |

---

### 📊 Thống kê
- 📌 Tổng số đề thi  
- 📊 Số lượng theo level: `EASY / MEDIUM / HARD`  
- 📚 Số lượng theo subject  
- 🔥 Tỉ lệ đề HARD  

| Endpoint | Mô tả |
|----------|------|
| GET `/exams/statistics` | Thống kê |
