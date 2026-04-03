<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <title>Exam Management System</title>
    <styles> 
       body {
    margin: 0;
    font-family: 'Segoe UI', sans-serif;
    background: #0f172a;
    color: #e2e8f0;
}

.container {
    max-width: 1000px;
    margin: auto;
    padding: 20px;
}

header {
    text-align: center;
    margin-bottom: 30px;
}

h1 {
    color: #38bdf8;
}

.badges span {
    display: inline-block;
    background: #1e293b;
    color: #38bdf8;
    padding: 5px 10px;
    margin: 5px;
    border-radius: 20px;
    font-size: 14px;
}

.card {
    background: #1e293b;
    padding: 20px;
    margin-bottom: 20px;
    border-radius: 12px;
    box-shadow: 0 0 10px rgba(0,0,0,0.5);
}

h2 {
    color: #22c55e;
}

ul {
    padding-left: 20px;
}

table {
    width: 100%;
    border-collapse: collapse;
    margin-top: 10px;
}

table, th, td {
    border: 1px solid #334155;
}

th {
    background: #334155;
}

td, th {
    padding: 10px;
    text-align: left;
}

pre {
    background: #020617;
    padding: 15px;
    border-radius: 8px;
    color: #22c55e;
}

footer {
    text-align: center;
    margin-top: 20px;
    color: #94a3b8;
}  
    </styles>
</head>
<body>

<div class="container">

    <header>
        <h1>🚀 Hệ Thống Quản Lý Đề Thi</h1>
        <div class="badges">
            <span>.NET 9</span>
            <span>ASP.NET Core</span>
            <span>JWT</span>
            <span>Swagger</span>
            <span>EF Core</span>
        </div>
    </header>

    <section class="card">
        <h2>📌 Giới thiệu</h2>
        <p>
            Hệ thống quản lý đề thi trực tuyến cho phép người dùng tạo, chỉnh sửa,
            thống kê và quản lý đề thi theo môn học và độ khó.
        </p>
    </section>

    <section class="card">
        <h2>🔑 Xác thực & Phân quyền</h2>
        <ul>
            <li>Đăng ký / Đăng nhập</li>
            <li>JWT Authentication</li>
            <li>Phân quyền Admin / User</li>
        </ul>
    </section>

    <section class="card">
        <h2>📝 API Endpoints</h2>
        <table>
            <tr>
                <th>Method</th>
                <th>Endpoint</th>
                <th>Mô tả</th>
            </tr>
            <tr>
                <td>POST</td>
                <td>/exams</td>
                <td>Tạo đề thi</td>
            </tr>
            <tr>
                <td>GET</td>
                <td>/exams</td>
                <td>Lấy danh sách</td>
            </tr>
            <tr>
                <td>PUT</td>
                <td>/exams/{id}</td>
                <td>Cập nhật</td>
            </tr>
            <tr>
                <td>DELETE</td>
                <td>/exams/{id}</td>
                <td>Xóa</td>
            </tr>
        </table>
    </section>

    <section class="card">
        <h2>📊 Thống kê</h2>
        <ul>
            <li>Tổng số đề thi</li>
            <li>Số lượng theo level: EASY / MEDIUM / HARD</li>
            <li>Số lượng theo subject</li>
            <li>Tỉ lệ đề HARD</li>
        </ul>
    </section>

    <section class="card">
        <h2>⚙️ Cài đặt</h2>
        <pre>
          git clone &lt;repo-url&gt;
          cd project
          dotnet restore
          dotnet ef database update
          dotnet run
        </pre>
    </section>

    <footer>
        <p>👨‍💻 Backend Developer - Your Name</p>
    </footer>

</div>

</body>
</html>
