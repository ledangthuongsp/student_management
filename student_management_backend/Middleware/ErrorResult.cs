namespace student_management_backend.Middleware
{
    public class ErrorResult
    {
        // Tên lỗi, có thể là loại lỗi như "ValidationError", "Unauthorized", etc.
        public string ErrorName { get; set; } = default!;

        // Nội dung chi tiết của lỗi (có thể là thông báo lỗi hoặc mô tả)
        public string ErrorDetails { get; set; } = default!;

        // Danh sách các thông điệp lỗi nếu có nhiều lỗi
        public List<string>? Messages { get; set; }

        // Nguồn gây ra lỗi, có thể là tên lớp hoặc phương thức
        public string? Source { get; set; }

        // ID của lỗi, có thể dùng để theo dõi hoặc tìm kiếm lỗi trong hệ thống
        public string? ErrorId { get; set; }

        // Mã trạng thái HTTP liên quan đến lỗi (ví dụ 400, 404, 500...)
        public int StatusCode { get; set; }
    }
}
