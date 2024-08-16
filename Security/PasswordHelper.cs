using BCrypt.Net;

public static class PasswordHelper
{
    // Hàm để băm mật khẩu
    public static string HashPassword(string password)
    {
        // Băm mật khẩu với độ phức tạp mặc định
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    // Hàm để kiểm tra mật khẩu
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Kiểm tra mật khẩu so với giá trị băm
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}