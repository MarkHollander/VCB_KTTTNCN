using Qlud.KTTTNCN.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Qlud.KTTTNCN.Configuration;
using Abp.Domain.Repositories;
using Qlud.KTTTNCN.ChungTuKTTs;
using System.IO;
using Qlud.KTTTNCN.ToChucTraThuNhaps;
using Abp.AspNetZeroCore.Net;

namespace Qlud.KTTTNCN.BaoCaoChungTus
{
    public class BaoCaoChungTusExporter : KTTTNCNAppServiceBase, IBaoCaoChungTusExporter
    {
        private readonly IConfigurationRoot _appConfiguration;
        private readonly object missing = Missing.Value;
        private readonly IRepository<ChungTuKTT, long> _chungTuRepository;
        private readonly IRepository<ToChucTraThuNhap> _toChucTraThuNhapRepository;
        public BaoCaoChungTusExporter(IAppConfigurationAccessor appConfigurationAccessor, IRepository<ChungTuKTT, long> chungTuRepository)
        {
            _appConfiguration = appConfigurationAccessor.Configuration;
            _chungTuRepository = chungTuRepository;
        }

        public Task<FileDto> ExportToPDF(long chungTuId)
        {
            throw new NotImplementedException();
        }

        public async Task<FileDto> ExportToWord(long chungtuId)
        {
            Logger.Info("BaoCaoChungTusExporter - ExportToWord: Start");
            object missing = Missing.Value;
            Application wordApp = new Application();
            Document aDoc = null;
            object fileTemplatePath = AppContext.BaseDirectory + _appConfiguration["BaoCaoQuanLyChungTu:ChungTuTemplatePath"];
            string savedFileName = "ChungTuWord_" + Guid.NewGuid().ToString() + ".docx";
            object saveAsPath = AppContext.BaseDirectory + _appConfiguration["BaoCaoQuanLyChungTu:SaveAsPath"] + "//" + savedFileName;
            try
            {
                #region Lay thong tin chung tu theo ID
                ChungTuKTT chungTuKTT = await _chungTuRepository.GetAsync(chungtuId);
                ToChucTraThuNhap toChucTraThuNhap = await _toChucTraThuNhapRepository.GetAsync(chungTuKTT.ToChucId);
                #endregion
                if (File.Exists(fileTemplatePath.ToString()))
                {
                    DateTime today = DateTime.Now;
                    object readOnly = false;
                    object invisible = false;
                    wordApp.Visible = false;
                    aDoc = wordApp.Documents.Open(ref fileTemplatePath, ref missing, ref readOnly,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing);           
                        
                    //Find and Replace
                    FindAndReplace(wordApp, "«MauSo»", chungTuKTT.MauSo);
                    FindAndReplace(wordApp, "«KyHieu»", chungTuKTT.KyHieu);
                    FindAndReplace(wordApp, "«SoChungTu»", chungTuKTT.SoChungTu);
                    FindAndReplace(wordApp, "«TenToChucTraThuNhap»", toChucTraThuNhap.TenToChuc);
                    FillMaSoThue(1, toChucTraThuNhap.MaSoThue, ref aDoc);
                    FindAndReplace(wordApp, "«DiaChi»", toChucTraThuNhap.DiaChi);
                    FindAndReplace(wordApp, "«DienThoaiToChuc»", toChucTraThuNhap.SoDienThoai);
                    FindAndReplace(wordApp, "«HoTen»", chungTuKTT.HoTen);
                    FillMaSoThue(2, chungTuKTT.MaSoThue, ref aDoc);
                    FindAndReplace(wordApp, "«QuocTich»", chungTuKTT.QuocTich);
                    FindAndReplace(wordApp, "«DienThoaiNguoiNopThue»", chungTuKTT.DiaChi);
                    FindAndReplace(wordApp, "«CMNDNguoiNopThue»", chungTuKTT.CCCD);
                    FindAndReplace(wordApp, "«NoiCap»", chungTuKTT.NoiCap);
                    FindAndReplace(wordApp, "«NgayCap»", chungTuKTT.NgayCap.ToString());
                    FindAndReplace(wordApp, "«KhoanThuNhap»", chungTuKTT.KhoanThuNhap.ToString());
                    FindAndReplace(wordApp, "«BaoHiemBatBuoc»", chungTuKTT.BaoHiemBatBuoc.ToString());
                    FindAndReplace(wordApp, "«DongGopTuThien»", chungTuKTT.KhoanDongGop.ToString());
                    FindAndReplace(wordApp, "«ThangTra»", chungTuKTT.ThoiDiemTraThuNhapThang);
                    FindAndReplace(wordApp, "«NamTra»", chungTuKTT.ThoiDiemTraThuNhapNam);
                    FindAndReplace(wordApp, "«TNChiuThuePhaiKhauTru»", chungTuKTT.TongThuNhapChiuThue.ToString());
                    FindAndReplace(wordApp, "«TongThuNhapTinhThue»", chungTuKTT.TongThuNhapTinhThue.ToString());
                    FindAndReplace(wordApp, "«ThueDaKhauTru»", chungTuKTT.SoThueTNCNDaKhauTru.ToString());
                    FindAndReplace(wordApp, "«ThuNhapNhanDuoc»", chungTuKTT.SoThuNhapDuocNhan.ToString());

                    //save file
                    aDoc.SaveAs2(ref saveAsPath, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                    FileDto fileDto = new FileDto(saveAsPath.ToString(), MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentWordprocessingmlDocument);
                    return fileDto;
                }
                else
                {
                    throw new Exception("Template File Not Found");
                }

            }
            catch (Exception ex)
            {
                Logger.Info("BaoCaoChungTusExporter - ExportToWord - ex: "+ ex.Message);
                return new FileDto(fileTemplatePath.ToString(), MimeTypeNames.ApplicationMsword);
            }
            finally 
            {
                Logger.Info("BaoCaoChungTusExporter - ExportToWord: End");
            }
        }

        private void FillMaSoThue(int tableIndex, string maSoThue, ref Document wordDoc)
        {
            Logger.Info("BaoCaoChungTusExporter - FillMaSoThue: Start");
            Logger.Info("BaoCaoChungTusExporter - FillMaSoThue - tableIndex: " + tableIndex.ToString());
            Table table = wordDoc.Tables[tableIndex];
            int totalCells = table.Rows[0].Cells.Count;
            int count = totalCells <=  maSoThue.Length ? totalCells: maSoThue.Length;
            for (int i =0; i < count; i++) 
            {
                Cell cell = table.Rows[0].Cells[i];
                cell.Range.Text = maSoThue[i].ToString();
                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }
            Logger.Info("BaoCaoChungTusExporter - FillMaSoThue: End");
        }

        public Task<FileDto> ExportToXML(long chungTuId)
        {
            throw new NotImplementedException();
        }

        private bool FindAndReplace (Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object matchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            //bool read_only = false;
            //bool visible = true;
            object replace = 2;
            object wrap = 1;
            return wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                                                    ref matchWholeWord, ref matchWildCards,
                                                    ref matchSoundLike, ref matchAllForms, 
                                                    ref forward, ref wrap, 
                                                    ref format, ref replaceWithText,
                                                    ref replace, ref matchKashida, 
                                                    ref matchDiactitics, ref matchAlefHamza, 
                                                    ref matchControl);

        }




    }
}
