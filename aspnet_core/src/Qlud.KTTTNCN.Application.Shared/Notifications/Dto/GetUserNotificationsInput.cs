using System;
using Abp.Notifications;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}