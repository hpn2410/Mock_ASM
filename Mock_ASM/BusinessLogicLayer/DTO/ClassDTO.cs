using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO
{
    public partial class ClassDTO
    {
        public int ClassId { get; set; }

        public string ClassCode { get; set; } = null!;
    }
    /*Tác dụng của DTO bao gồm:

Tối ưu hóa việc chuyển dữ liệu: DTO giúp tối ưu hóa việc chuyển dữ liệu giữa các thành phần của ứng dụng
    bằng cách đóng gói dữ liệu cần thiết vào một đối tượng duy nhất. giúp giảm thiểu lượng dữ liệu được
    truyền qua mạng và giúp cải thiện hiệu suất 

Bảo vệ dữ liệu: DTO có thể được sử dụng để che giấu cấu trúc dữ liệu thực sự của ứng dụng và chỉ hiển thị 
    những thông tin cần thiết cho thành phần nhận dữ liệu. Điều này giúp bảo vệ dữ liệu và đảm bảo tính riêng 
    tư.

Phân chia logic: Sử dụng DTO giúp phân chia logic giữa lớp dịch vụ và lớp giao diện người dùng. Lớp dịch vụ 
    có thể xử lý logic kinh doanh mà không phải lo lắng về cách dữ liệu được truyền tải hoặc hiển thị trên 
    giao diện người dùng.

Dễ bảo trì và mở rộng: Sử dụng DTO làm giao diện giữa các thành phần giúp làm cho ứng dụng dễ bảo trì và mở rộng. 
    Bằng cách này, nếu cấu trúc dữ liệu hoặc yêu cầu thay đổi, chỉ cần sửa đổi DTO mà không cần thay đổi code ở các thành phần khác.*/
}
