using System;
using System.Net;
using System.Net.Mail;

namespace QuanLyBida.DAL
{
    public class EmailDAL
    {
        // CẤU HÌNH EMAIL (Dùng App Password nếu là Gmail)
        private static readonly string senderEmail = "dauphuongdung300825@gmail.com";
        private static readonly string senderPassword = "wsag qaio octk xgit";

        // Hàm gửi mail cơ bản
        public bool SendMail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true; // Để gửi định dạng HTML đẹp

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587; // Port chuẩn của Gmail
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true; // Gửi thành công
            }
            catch (Exception)
            {
                // Có thể log lỗi lại nếu cần
                return false; // Gửi thất bại
            }
        }
    }
}