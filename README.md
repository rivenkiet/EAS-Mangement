# EAS Management — Education Administration System

> Hệ thống quản lý và hỗ trợ vận hành các nghiệp vụ trong trường học, định hướng phân quyền theo vai trò, quản lý dữ liệu tập trung trên Oracle Database và truy vết hoạt động phục vụ kiểm soát nội bộ.

## 1. Giới thiệu dự án

**EAS Management** (Education Administration System) hướng đến việc xây dựng một nền tảng quản lý nghiệp vụ trường học, kết nối hoạt động của ban quản trị, các phòng ban, giáo viên và học sinh trên cùng một hệ thống.

Thay vì để từng bộ phận quản lý dữ liệu rời rạc, hệ thống hướng đến một quy trình làm việc thống nhất: dữ liệu được quản lý tập trung, người dùng chỉ được truy cập chức năng và thông tin thuộc phạm vi được cấp phép, còn các thao tác quan trọng có thể được ghi nhận để phục vụ kiểm tra và truy vết.

### Mục tiêu

- Tập trung hóa dữ liệu và quy trình nghiệp vụ của nhà trường.
- Phân tách quyền quản trị hệ thống với quyền xử lý nghiệp vụ của từng phòng ban.
- Xây dựng cơ chế **Authentication** (xác thực danh tính) và **Authorization** (ủy quyền/phân quyền) rõ ràng.
- Tổ chức dữ liệu trên **Oracle Database**, đồng thời định hướng ghi nhận lịch sử thay đổi và hoạt động quan trọng.
- Tăng tính minh bạch, giảm thao tác thủ công và hỗ trợ truy vết khi xảy ra sai sót.
- Tạo nền tảng có thể mở rộng thêm chức năng theo nhu cầu thực tế của nhà trường.

> **Phạm vi triển khai:** Các mục chức năng bên dưới mô tả phạm vi nghiệp vụ và định hướng thiết kế của hệ thống. Trạng thái triển khai thực tế của từng chức năng cần được đối chiếu với mã nguồn hiện tại trước khi xem là tính năng đã hoàn thành.

## 2. Nhóm người dùng và mô hình phân quyền

Hệ thống được định hướng theo mô hình **RBAC (Role-Based Access Control)**: người dùng được gán một hoặc nhiều vai trò; mỗi vai trò được liên kết với các quyền thao tác. Có thể kết hợp thêm điều kiện theo đơn vị, lớp học hoặc quan hệ phụ trách để giới hạn phạm vi dữ liệu.

| Vai trò | Phạm vi trách nhiệm |
|---|---|
| System Administrator | Cấu hình và quản trị hệ thống, tài khoản, vai trò, quyền và các thiết lập chung |
| Ban giám hiệu | Theo dõi tình hình hoạt động, xem báo cáo và phê duyệt các nghiệp vụ thuộc thẩm quyền |
| Phòng đào tạo | Quản lý năm học, học kỳ, lớp, môn học, thời khóa biểu, phân công giảng dạy và kết quả học tập |
| Phòng công tác học sinh/sinh viên | Quản lý hồ sơ, tình trạng học tập, chuyên cần, khen thưởng, kỷ luật và các nghiệp vụ hỗ trợ người học |
| Phòng khảo thí | Quản lý kế hoạch kiểm tra/thi, lịch thi, kết quả và quy trình công bố điểm theo phạm vi được giao |
| Phòng tài chính/kế toán | Quản lý các khoản thu, học phí, trạng thái thanh toán và báo cáo tài chính nếu thuộc phạm vi hệ thống |
| Giáo viên | Xem lớp/môn được phân công, quản lý chuyên cần, nhập điểm và theo dõi học sinh thuộc phạm vi phụ trách |
| Học sinh | Xem hồ sơ cá nhân, thời khóa biểu, điểm, chuyên cần, thông báo và các thông tin học tập được phép |
| Auditor / người kiểm tra | Đọc nhật ký audit và báo cáo kiểm tra theo phạm vi được cấp, không mặc nhiên có quyền sửa dữ liệu nghiệp vụ |

Tên gọi và số lượng vai trò có thể được điều chỉnh theo cơ cấu tổ chức thực tế. Không nên cấp quyền chỉ dựa vào tên vai trò ở giao diện; backend cần kiểm tra quyền trên từng thao tác và từng tài nguyên.

## 3. Chức năng quản trị hệ thống

### 3.1. Quản lý tài khoản

- Tạo, cập nhật, kích hoạt, khóa hoặc vô hiệu hóa tài khoản.
- Liên kết tài khoản với hồ sơ nhân sự, giáo viên hoặc học sinh.
- Gán và thu hồi vai trò theo trách nhiệm công việc.
- Hỗ trợ quy trình đổi mật khẩu hoặc đặt lại thông tin xác thực theo chính sách bảo mật.
- Tìm kiếm và lọc tài khoản theo trạng thái, vai trò hoặc đơn vị.
- Kiểm soát tài khoản đã nghỉ việc, chuyển đơn vị hoặc không còn thuộc phạm vi sử dụng hệ thống.

### 3.2. Quản lý vai trò và quyền hạn

- Khai báo vai trò cho các nhóm người dùng.
- Quản lý quyền theo chức năng, ví dụ: `Student.Read`, `Student.Update`, `Grade.Read`, `Grade.Update`, `Audit.Read`.
- Tách quyền xem, tạo mới, chỉnh sửa, xóa, phê duyệt và xuất dữ liệu.
- Gán quyền theo vai trò và kiểm soát việc thay đổi quyền.
- Áp dụng nguyên tắc **Least Privilege** — chỉ cấp quyền tối thiểu cần thiết.
- Ngăn người dùng tự nâng quyền hoặc tự cấp quyền vượt thẩm quyền.
- Hỗ trợ giới hạn dữ liệu theo phòng ban, lớp học hoặc đối tượng được phân công khi nghiệp vụ yêu cầu.

### 3.3. Quản lý danh mục và cấu hình chung

- Quản lý danh mục phòng ban, chức vụ, năm học, học kỳ, khối lớp và trạng thái nghiệp vụ.
- Quản lý các tham số chung của ứng dụng.
- Kiểm tra tính hợp lệ của cấu hình trước khi áp dụng.
- Ghi nhận người thực hiện và thời điểm thay đổi đối với các cấu hình quan trọng.

### 3.4. Dashboard và báo cáo quản trị

- Tổng hợp số lượng tài khoản theo vai trò và trạng thái.
- Theo dõi các chỉ số nghiệp vụ mà tài khoản quản trị được phép xem.
- Hỗ trợ lọc báo cáo theo năm học, học kỳ, đơn vị hoặc trạng thái.
- Cung cấp thông tin phục vụ kiểm tra và vận hành; không hiển thị dữ liệu nhạy cảm vượt quyền người dùng.

## 4. Chức năng quản lý của các phòng ban

### 4.1. Ban giám hiệu

- Theo dõi báo cáo tổng quan về học sinh, giáo viên, lớp học và kết quả học tập.
- Xem báo cáo tổng hợp từ các phòng ban theo thẩm quyền.
- Theo dõi tiến độ xử lý công việc và các trường hợp cần phê duyệt.
- Phê duyệt các đề xuất hoặc nghiệp vụ cần cấp quản lý thông qua.
- Tra cứu lịch sử xử lý để xác định người phụ trách và thời điểm thực hiện.

### 4.2. Phòng đào tạo

- Quản lý năm học, học kỳ, khối lớp, lớp học và danh mục môn học.
- Tổ chức phân lớp và quản lý danh sách học sinh theo lớp.
- Xây dựng thời khóa biểu và phân công giáo viên giảng dạy.
- Quản lý kế hoạch giảng dạy, lịch kiểm tra và các mốc học vụ.
- Tiếp nhận, kiểm tra và tổng hợp kết quả học tập từ giáo viên.
- Theo dõi tiến độ nhập điểm và trạng thái hoàn tất kết quả.
- Hạn chế việc chỉnh sửa kết quả đã khóa hoặc đã công bố; các thay đổi ngoại lệ cần đúng thẩm quyền và có lịch sử.

### 4.3. Phòng công tác học sinh/sinh viên

- Quản lý hồ sơ học sinh và thông tin liên hệ cần thiết.
- Theo dõi tình trạng học tập, chuyển lớp, bảo lưu hoặc thôi học theo quy trình của trường.
- Quản lý dữ liệu chuyên cần, trường hợp vắng mặt và các yêu cầu xác nhận.
- Ghi nhận khen thưởng, kỷ luật hoặc hoạt động hỗ trợ học sinh nếu được triển khai.
- Tiếp nhận và theo dõi yêu cầu, phản ánh hoặc đề nghị của học sinh.
- Tra cứu hồ sơ theo phạm vi nghiệp vụ được phân quyền.

### 4.4. Phòng khảo thí

- Lập và quản lý kế hoạch kiểm tra, thi theo học kỳ.
- Quản lý lịch thi, phòng thi và danh sách dự thi nếu nằm trong phạm vi hệ thống.
- Tiếp nhận, rà soát và tổng hợp kết quả thi.
- Quản lý trạng thái công bố kết quả.
- Kiểm soát việc sửa điểm sau khi chốt kết quả theo quy trình phê duyệt.
- Tra cứu lịch sử thay đổi dữ liệu điểm phục vụ đối soát.

### 4.5. Phòng tài chính/kế toán (nếu thuộc phạm vi triển khai)

- Quản lý danh mục khoản thu và thông tin nghĩa vụ tài chính của học sinh.
- Theo dõi số phải thu, số đã thu và trạng thái thanh toán.
- Tra cứu và tổng hợp báo cáo theo kỳ.
- Giới hạn quyền xem thông tin tài chính theo đúng chức trách.
- Ghi nhận lịch sử thay đổi đối với các dữ liệu tài chính quan trọng.

> Các phân hệ nghiệp vụ có thể được triển khai độc lập. Chỉ mô tả một phân hệ là đã hoạt động khi đã có module, API và dữ liệu tương ứng trong mã nguồn.

## 5. Chức năng dành cho giáo viên

- Đăng nhập và truy cập không gian làm việc theo tài khoản được cấp.
- Xem hồ sơ cá nhân, lớp học, môn học và lịch giảng dạy được phân công.
- Xem danh sách học sinh trong lớp hoặc môn học thuộc phạm vi phụ trách.
- Ghi nhận chuyên cần và cập nhật tình trạng vắng mặt nếu được phân quyền.
- Nhập, cập nhật và tra cứu điểm trong thời gian và phạm vi được phép.
- Xem tiến độ hoàn thành nhập điểm.
- Gửi hoặc tiếp nhận thông báo liên quan đến lớp học.
- Xem lịch sử hoặc trạng thái xử lý của những nghiệp vụ mình thực hiện khi hệ thống hỗ trợ.

Giáo viên không mặc nhiên có quyền truy cập toàn bộ hồ sơ học sinh, chỉnh sửa dữ liệu của lớp khác hoặc thay đổi điểm đã khóa. Những hành động này cần được kiểm soát ở backend.

## 6. Chức năng dành cho học sinh

- Xem và cập nhật các thông tin cá nhân được phép chỉnh sửa.
- Xem lớp học, môn học và thời khóa biểu của bản thân.
- Tra cứu điểm theo môn, học kỳ hoặc năm học.
- Theo dõi chuyên cần và tình trạng học tập của bản thân.
- Xem thông báo từ nhà trường hoặc giáo viên.
- Gửi yêu cầu hoặc đề nghị đến bộ phận phụ trách nếu chức năng này được triển khai.
- Theo dõi trạng thái xử lý yêu cầu của mình.

Học sinh chỉ được xem dữ liệu thuộc tài khoản của bản thân. Backend cần xác minh quyền sở hữu tài nguyên thay vì chỉ tin vào `studentId` do client gửi lên.

## 7. Authentication và Authorization

### 7.1. Authentication — xác thực

Authentication xác định người dùng là ai. Luồng xác thực dự kiến gồm:

1. Người dùng gửi thông tin đăng nhập qua endpoint được bảo vệ bằng HTTPS khi triển khai thực tế.
2. Backend kiểm tra thông tin xác thực bằng cơ chế phù hợp với thiết kế hiện tại.
3. Khi xác thực thành công, hệ thống tạo hoặc cấp session/token theo cơ chế được cấu hình.
4. Những endpoint yêu cầu đăng nhập kiểm tra danh tính và trạng thái tài khoản.
5. Khi tài khoản bị khóa hoặc thu hồi quyền, hệ thống cần có cơ chế hạn chế việc tiếp tục sử dụng quyền đã bị thu hồi.

Không lưu mật khẩu dạng văn bản thuần. Nếu hệ thống tự quản lý mật khẩu, cần dùng thuật toán băm mật khẩu chuyên dụng và quy trình đặt lại mật khẩu an toàn. Không đưa thông tin kết nối Oracle hoặc secret vào mã nguồn.

### 7.2. Authorization — phân quyền

Authorization xác định người dùng được phép làm gì sau khi đã xác thực.

- **Role-based access:** quyền được gán thông qua vai trò.
- **Permission-based checks:** endpoint hoặc thao tác kiểm tra quyền cụ thể, không chỉ kiểm tra người dùng đã đăng nhập.
- **Scope-based access:** giới hạn dữ liệu theo đơn vị, lớp, môn học hoặc quan hệ phụ trách.
- **Separation of duties:** phân tách các nhiệm vụ nhạy cảm, chẳng hạn người nhập điểm và người phê duyệt/chốt điểm có thể là hai vai trò khác nhau.
- **Deny by default:** mặc định từ chối nếu không có quyền rõ ràng.
- **Server-side enforcement:** mọi kiểm tra quyền quan trọng phải được thực hiện ở backend; ẩn nút trên giao diện không phải là biện pháp bảo vệ đầy đủ.

Ví dụ ma trận quyền định hướng:

| Tài nguyên / thao tác | Admin | Phòng đào tạo | Giáo viên | Học sinh |
|---|---|---|---|---|
| Quản lý vai trò và quyền | Có | Không mặc định | Không | Không |
| Quản lý danh mục học vụ | Có thể cấu hình | Theo nghiệp vụ | Chỉ xem dữ liệu liên quan | Chỉ xem thông tin liên quan |
| Xem danh sách lớp | Theo quyền | Có | Lớp được phân công | Lớp của bản thân |
| Nhập điểm | Không mặc định | Theo quy trình | Môn/lớp được phân công | Không |
| Xem điểm | Theo phạm vi được cấp | Có | Lớp/môn được phân công | Điểm của bản thân |
| Xem audit | Theo quyền quản trị/audit | Phạm vi được cấp nếu có | Không mặc định | Không |

Ma trận trên là mô hình tham khảo; quyền thực tế cần được chốt theo quy chế nghiệp vụ và kiểm tra trong mã nguồn.

## 8. Oracle Database và quản lý dữ liệu

Oracle Database là nền tảng dữ liệu mà repository hiện tại thể hiện qua tên solution/thư mục `ConnectToOracle`. Cách tổ chức chi tiết cần được xác nhận từ cấu hình và mã nguồn thực tế.

Các nguyên tắc thiết kế dữ liệu được đề xuất:

- Tách cấu hình kết nối khỏi mã nguồn; dùng biến môi trường hoặc secret manager khi triển khai.
- Sử dụng tài khoản database có quyền tối thiểu cần thiết, tránh dùng tài khoản quản trị cao nhất cho kết nối ứng dụng.
- Dùng tham số truy vấn để hạn chế SQL injection.
- Xác định khóa chính, khóa ngoại, ràng buộc và transaction phù hợp với nghiệp vụ.
- Kiểm tra tính hợp lệ dữ liệu ở backend trước khi ghi vào cơ sở dữ liệu.
- Có kế hoạch sao lưu, khôi phục và quản lý thay đổi schema.
- Không ghi mật khẩu, token, dữ liệu cá nhân nhạy cảm hoặc thông tin bí mật vào log.

## 9. Audit log và khả năng truy vết

Audit nhằm trả lời các câu hỏi: **ai đã thực hiện thao tác gì, trên dữ liệu nào, vào thời điểm nào và kết quả ra sao?**

### 9.1. Các sự kiện nên ghi nhận

- Đăng nhập thành công/thất bại và các sự kiện liên quan đến phiên đăng nhập.
- Tạo, khóa, mở khóa hoặc cập nhật tài khoản.
- Gán, thu hồi hoặc thay đổi vai trò và quyền.
- Tạo mới, cập nhật hoặc xóa dữ liệu nghiệp vụ quan trọng.
- Nhập, sửa, khóa hoặc công bố điểm.
- Thay đổi cấu hình hệ thống.
- Các thao tác xuất dữ liệu hoặc truy cập chức năng nhạy cảm khi cần kiểm soát.

### 9.2. Trường dữ liệu audit đề xuất

| Trường | Ý nghĩa |
|---|---|
| `AuditId` | Mã định danh sự kiện |
| `ActorId` | Tài khoản thực hiện thao tác |
| `Action` | Loại thao tác |
| `EntityName` | Loại tài nguyên bị tác động |
| `EntityId` | Mã bản ghi liên quan |
| `OccurredAt` | Thời điểm phát sinh |
| `Result` | Thành công/thất bại |
| `CorrelationId` | Mã liên kết các log trong cùng một request |
| `Changes` | Thông tin thay đổi đã được lọc dữ liệu nhạy cảm, nếu cần |

Tên cột và kiểu dữ liệu là đề xuất, không khẳng định rằng schema hiện tại đã có đúng các trường này.

### 9.3. Phân biệt audit ứng dụng và Oracle Database Audit

- **Application audit:** ghi nhận ngữ cảnh nghiệp vụ như tài khoản ứng dụng, thao tác, bản ghi bị tác động và kết quả xử lý.
- **Oracle Database auditing:** có thể cấu hình để ghi nhận hoạt động ở tầng database, tùy phiên bản Oracle, cấu hình và chính sách audit được triển khai.

Hai cơ chế bổ trợ nhau nhưng không thay thế hoàn toàn cho nhau. Nếu cần truy vết xuyên suốt, nên liên kết log bằng mã request/correlation và đồng bộ thời gian giữa các thành phần.

### 9.4. Bảo vệ audit log

- Hạn chế quyền đọc và đặc biệt là quyền sửa/xóa nhật ký.
- Không ghi mật khẩu, access token hoặc dữ liệu nhạy cảm không cần thiết.
- Xác định thời gian lưu trữ và quy trình truy xuất log.
- Theo dõi các lỗi ghi audit đối với thao tác quan trọng.
- Cân nhắc lưu trữ tập trung hoặc cơ chế chống sửa đổi nếu yêu cầu tuân thủ đòi hỏi.

> Audit chỉ được xem là đã triển khai khi có cơ chế ghi log thực tế, nơi lưu trữ và chính sách truy cập tương ứng. Việc dùng Oracle không tự động đồng nghĩa với việc mọi thao tác ứng dụng đã được audit.

## 10. Luồng xử lý tổng quát

```text
Người dùng
    |
    v
Đăng nhập / Authentication
    |
    v
Backend xác minh danh tính và trạng thái tài khoản
    |
    v
Authorization: kiểm tra role, permission và phạm vi dữ liệu
    |
    +---- Không hợp lệ / không đủ quyền ---> Từ chối truy cập
    |
    v
Xử lý nghiệp vụ
    |
    v
Oracle Database: đọc / ghi dữ liệu
    |
    v
Ghi nhận audit cho các sự kiện được cấu hình
    |
    v
Trả kết quả cho người dùng
```

Sơ đồ thể hiện luồng thiết kế mục tiêu. Cách triển khai thực tế có thể khác tùy kiến trúc và code hiện tại.

## 11. Công nghệ và kiến trúc

### Công nghệ có thể xác nhận từ repository

- **C#/.NET solution:** repository có file `ConnectToOracle.sln`.
- **Oracle Database connectivity:** tên solution/thư mục cho thấy dự án có định hướng kết nối Oracle; thư viện cụ thể và cách kết nối cần kiểm tra trong project file và source code.

### Các thành phần kiến trúc cần mô tả theo triển khai thực tế

- Presentation/UI: giao diện dành cho từng nhóm người dùng (nếu có).
- Application/API: xử lý yêu cầu, xác thực, phân quyền và điều phối nghiệp vụ.
- Business/domain logic: quy tắc nghiệp vụ trường học.
- Data access: truy cập Oracle Database.
- Audit/logging: ghi nhận hoạt động và hỗ trợ truy vết.

Không nên ghi thêm framework UI, ORM, JWT, ASP.NET Core, kiến trúc Clean Architecture/DDD hoặc công nghệ khác vào danh sách “đang sử dụng” nếu chưa xác minh từ file project và mã nguồn.

## 12. Cài đặt và chạy dự án

Hướng dẫn dưới đây là khung tổng quát; cần điều chỉnh theo framework, phiên bản .NET, thư viện Oracle và cấu hình thực tế của repository.

### Yêu cầu

- Git.
- .NET SDK tương thích với `TargetFramework` trong file `.csproj`.
- Oracle Database hoặc một Oracle instance mà bạn có quyền sử dụng.
- IDE hoặc trình soạn thảo hỗ trợ C# (ví dụ Visual Studio).

### Bước 1: Clone repository

```bash
git clone https://github.com/rivenkiet/EAS-Mangement.git
cd EAS-Mangement
```

### Bước 2: Kiểm tra solution và project

Mở `ConnectToOracle.sln` bằng IDE tương thích hoặc kiểm tra project bằng CLI:

```bash
dotnet --info
dotnet sln ConnectToOracle.sln list
```

Nếu solution không dùng SDK-style project hoặc phụ thuộc vào môi trường đặc biệt, hãy làm theo cấu hình của project.

### Bước 3: Cấu hình Oracle

1. Chuẩn bị thông tin kết nối Oracle theo môi trường phát triển.
2. Tìm vị trí cấu hình kết nối trong project.
3. Đưa thông tin nhạy cảm ra khỏi source control; dùng biến môi trường hoặc secret manager phù hợp.
4. Đảm bảo tài khoản database chỉ có quyền cần thiết.
5. Không commit mật khẩu, connection string chứa credential hoặc file secret lên GitHub.

Tên biến môi trường và định dạng connection string phải lấy từ cấu hình mà ứng dụng thực sự đọc; không có tên biến mặc định nào được giả định trong tài liệu này.

### Bước 4: Restore và build

Với project .NET SDK-style tương thích:

```bash
dotnet restore ConnectToOracle.sln
dotnet build ConnectToOracle.sln
```

### Bước 5: Chạy ứng dụng

Xác định project khởi chạy trong solution, sau đó chạy project tương ứng:

```bash
dotnet run --project path/to/YourProject.csproj
```

Thay `path/to/YourProject.csproj` bằng đường dẫn thực tế. Nếu đây chỉ là project thử nghiệm kết nối Oracle, hãy chạy theo entry point hiện có.

## 13. Cấu trúc repository

Cấu trúc nhìn thấy trên GitHub hiện gồm:

```text
EAS-Mangement/
├── ConnectToOracle/
├── ConnectToOracle.sln
├── .gitattributes
└── .gitignore
```

Các file và thư mục con bên trong `ConnectToOracle/` cần được bổ sung sau khi kiểm tra source code. Khi dự án phát triển thành hệ thống nhiều phân hệ, nên tổ chức cấu trúc sao cho ranh giới giữa nghiệp vụ, truy cập dữ liệu, bảo mật và giao diện rõ ràng.

## 14. Bảo mật và nguyên tắc vận hành

- Áp dụng quyền tối thiểu cho cả tài khoản ứng dụng lẫn tài khoản Oracle.
- Xác thực và kiểm tra quyền tại backend trên mỗi request cần bảo vệ.
- Kiểm tra quyền sở hữu/phạm vi của bản ghi để tránh truy cập dữ liệu của người khác.
- Xác thực đầu vào và dùng parameterized query.
- Bảo vệ thông tin đăng nhập, secret, token và dữ liệu cá nhân.
- Không để audit log chứa thông tin xác thực hoặc dữ liệu nhạy cảm không cần thiết.
- Có quy trình sao lưu, khôi phục và cập nhật cấu hình an toàn.
- Kiểm thử các trường hợp truy cập trái quyền, tài khoản bị khóa và quyền bị thu hồi.
- Các nghiệp vụ nhạy cảm như sửa điểm đã chốt cần có quy trình kiểm soát và dấu vết audit phù hợp.

## 15. Kiểm thử đề xuất

- Đăng nhập đúng/sai và xử lý tài khoản bị vô hiệu hóa.
- Người dùng không có quyền không thể gọi trực tiếp endpoint bị bảo vệ.
- Giáo viên không thể sửa dữ liệu của lớp/môn ngoài phạm vi phụ trách.
- Học sinh không thể xem hồ sơ hoặc điểm của học sinh khác bằng cách thay ID.
- Thay đổi vai trò/quyền có hiệu lực theo chính sách phiên đăng nhập.
- Thao tác quan trọng tạo ra audit event với actor và thời điểm phù hợp.
- Lỗi kết nối Oracle được xử lý an toàn, không làm lộ credential hoặc thông tin nội bộ.
- Các thao tác cập nhật nhiều bản ghi bảo đảm tính nhất quán transaction.

## 16. Định hướng phát triển

- Hoàn thiện mô hình dữ liệu và các phân hệ nghiệp vụ theo nhu cầu thực tế.
- Chuẩn hóa role/permission và phạm vi truy cập dữ liệu.
- Hoàn thiện audit trail cho các thao tác nhạy cảm.
- Bổ sung kiểm thử tự động cho authorization và nghiệp vụ.
- Xây dựng dashboard và báo cáo theo quyền.
- Bổ sung tài liệu API, sơ đồ dữ liệu và hướng dẫn triển khai.
- Hoàn thiện quy trình backup/restore, giám sát lỗi và quản lý cấu hình theo môi trường.

## 17. Đóng góp

Nếu muốn đóng góp cho dự án:

1. Tạo issue mô tả lỗi hoặc đề xuất chức năng.
2. Tạo branch riêng cho thay đổi.
3. Bổ sung kiểm thử cho nghiệp vụ và phân quyền liên quan.
4. Không đưa credential, dữ liệu học sinh thật hoặc thông tin nhạy cảm vào commit.
5. Gửi pull request kèm mô tả thay đổi và cách kiểm thử.

## 18. Tác giả

- GitHub: [@rivenkiet](https://github.com/rivenkiet)
- Repository: [EAS-Mangement](https://github.com/rivenkiet/EAS-Mangement)

---

**Lưu ý khi hoàn thiện README:** Sau khi đối chiếu mã nguồn, hãy cập nhật framework/version thực tế, cách cấu hình Oracle, các module đã triển khai, cách chạy ứng dụng và trạng thái audit. Chỉ chuyển các chức năng từ “phạm vi/định hướng” sang “đã triển khai” khi có bằng chứng tương ứng trong source code.
