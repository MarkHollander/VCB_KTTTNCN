using System.Collections.Generic;
using Abp.Auditing;

namespace Qlud.KTTTNCN.Auditing
{
    public interface IExpiredAndDeletedAuditLogBackupService
    {
        bool CanBackup();
        
        void Backup(List<AuditLog> auditLogs);
    }
}