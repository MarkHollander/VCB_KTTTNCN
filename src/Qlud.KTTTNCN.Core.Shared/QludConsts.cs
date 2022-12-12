using System;
using System.Collections.Generic;
using System.Text;

namespace Qlud.KTTTNCN
{
    public class QludConsts
    {
        /// <summary>
        /// Trạng thái bán ghi: Kế hoạch, Triển khai
        /// </summary>
        public class TrangThai
        {
            public const string INIT = "0";
            public const string SAVE_DRAFT = "1";
            public const string PENDING = "2";
            public const string RETURNED = "3";
            public const string APPROVED = "4";
            public const string REJECTED = "5";
            public const string DELETED = "6";

            //public static Dictionary<string, ILocalizableString> Names = new Dictionary<string, ILocalizableString> {
            //    { INIT , L("INIT") },
            //    { SAVE_DRAFT, L("SAVE_DRAFT") },
            //    { PENDING, L("PENDING") },
            //    { RETURNED, L("RETURNED") },
            //    { APPROVED, L("APPROVED") },
            //    { REJECTED, L("REJECTED") },
            //    { DELETED, L("DELETED") }
            //};

            public static Dictionary<string, string> DisplayList = new Dictionary<string, string> {
                { INIT , "Khởi tạo" },
                { SAVE_DRAFT, "Lưu nháp" },
                { PENDING, "Chờ duyệt" },
                { RETURNED, "Trả lại" },
                { APPROVED, "Duyệt" },
                { REJECTED, "Từ chối" },
                { DELETED, "Xóa" }
            };

            public static Dictionary<string, string> MappingList = new Dictionary<string, string> {
                { nameof(INIT), INIT },
                { nameof(SAVE_DRAFT), SAVE_DRAFT },
                { nameof(PENDING), PENDING },
                { nameof(RETURNED), RETURNED },
                { nameof(APPROVED), APPROVED },
                { nameof(REJECTED), REJECTED },
                { nameof(DELETED), DELETED }
            };
        }
    }
}
