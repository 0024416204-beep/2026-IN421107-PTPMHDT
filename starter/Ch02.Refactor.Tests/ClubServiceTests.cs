using EduHub.Ch02.Domain;
using EduHub.Ch02.Factories;
using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Services;
using Moq;
using System.Timers;
using Xunit;

namespace EduHub.Ch02.Refactor.Tests;

public class ClubServiceTests
{
    [Fact]
    public void CreateClub_ValidData_ShouldAddClubAndNotify()
    {
        // 1. Arrange (Chuẩn bị Mock và dữ liệu giả lập)
        var mockRepo = new Mock<IClubRepository>();
        var mockFactory = new Mock<INotificationServiceFactory>();
        var mockNotif = new Mock<INotificationService>();

        // Giả lập khi Factory gọi Create thì trả về mockNotif
        mockFactory.Setup(f => f.Create(It.IsAny<NotificationChannel>()))
                   .Returns(mockNotif.Object);

        // Khởi tạo ClubService với các dependency đã mock
        var service = new ClubService(mockRepo.Object, mockFactory.Object);

        string clubName = "AI Club";
        string description = "Learn Artificial Intelligence";
        string email = "president@gmail.com";

        // 2. Act (Thực thi hành động cần test)
        service.CreateClub(clubName, description, email, NotificationChannel.Gmail);

        // 3. Assert (Kiểm tra xem các hàm có được gọi đúng như kỳ vọng không)
        // Kiểm tra xem repository có thực hiện hàm AddClub đúng 1 lần không
        mockRepo.Verify(r => r.AddClub(It.IsAny<Club>()), Times.Once());

        // Kiểm tra xem dịch vụ thông báo có gửi tin nhắn đúng 1 lần không
        mockNotif.Verify(n => n.Send(email, It.IsAny<string>()), Times.Once());
    }
}