# 📚 Hệ Thống Quản Lý Đề Thi Trực Tuyến

## 🚀 Giới thiệu

Hệ thống **Quản Lý Đề Thi Trực Tuyến** là một ứng dụng backend được xây dựng bằng **ASP.NET Core Web API**, cho phép người dùng tạo, chỉnh sửa, quản lý và thống kê các đề thi theo nhiều tiêu chí khác nhau như môn học, cấp độ và thời gian.

Ứng dụng tích hợp:

* 🔐 JWT Authentication (xác thực & phân quyền)
* 📄 Swagger (test API trực quan)
* 🗄️ Entity Framework Core (ORM làm việc với database)

---

## ✨ Tính năng chính

### 🔑 Xác thực & phân quyền

* Đăng ký, đăng nhập
* Cấp token JWT
* Phân quyền: **Admin** / **User**

### 📝 Quản lý đề thi

* Tạo đề thi mới
* Chỉnh sửa đề thi
* Xóa đề thi

**API endpoints:**

* `POST /exams` – Tạo đề thi
* `GET /exams` – Lấy danh sách đề thi (lọc theo `subject`, `level`)
* `PUT /exams/{id}` – Cập nhật đề thi
* `DELETE /exams/{id}` – Xóa đề thi

---

### 🕓 Lịch sử thay đổi

* Tự động lưu lịch sử khi thay đổi:

  * `level`
  * `examDate`
* Lưu vào bảng `ExamHistory`

**API:**

* `GET /exams/{id}/history` – Xem lịch sử chỉnh sửa

---

### 📊 Thống kê

* Tổng số đề thi đã tạo
* Số lượng đề theo cấp độ:

  * EASY
  * MEDIUM
  * HARD
* Số lượng theo môn học
* Tỷ lệ đề HARD

**API:**

* `GET /exams/statistics`

---

## 🛠️ Công nghệ sử dụng

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger (Swashbuckle)

---

## ⚙️ Cài đặt & chạy dự án

### 1️⃣ Clone source code

```bash
git clone https://github.com/VuDinhManh22/ExamTest
cd BETest
```

### 2️⃣ Cấu hình database

Mở file `appsettings.json` và chỉnh sửa:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=\\SQLEXPRESS;Database=ExamUserDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

### 3️⃣ Cài đặt dependencies

```bash
dotnet restore
```

### 4️⃣ Migration database

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5️⃣ Chạy ứng dụng

```bash
dotnet run
```

---

## 📌 Ghi chú

* Đảm bảo SQL Server đang chạy
* Cài đặt **.NET SDK** phù hợp (>= .NET 6/7/8)
* Có thể test API qua Swagger tại:

  ```
  https://localhost:<port>/swagger
  ```

---
