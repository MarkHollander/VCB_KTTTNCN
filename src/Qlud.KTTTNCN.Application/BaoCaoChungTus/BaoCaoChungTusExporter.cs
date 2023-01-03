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

namespace Qlud.KTTTNCN.BaoCaoChungTus
{
    public class BaoCaoChungTusExporter : KTTTNCNAppServiceBase, IBaoCaoChungTusExporter
    {
        private readonly IConfigurationRoot _appConfiguration;
        private readonly object missing = Missing.Value;
        private readonly IRepository<ChungTuKTT, long> _chungTuRepository;
        public BaoCaoChungTusExporter(IAppConfigurationAccessor appConfigurationAccessor, IRepository<ChungTuKTT, long> chungTuRepository)
        {
            _appConfiguration = appConfigurationAccessor.Configuration;
            _chungTuRepository = chungTuRepository;
        }

        public FileDto ExportToPDF(long chungTuId)
        {
            throw new NotImplementedException();
        }

        public FileDto ExportToXML(long chungTuId)
        {
            throw new NotImplementedException();
        }
       

        public async Task<FileDto> ExportToWord(long chungtuId)
        {

            string fileTemplatePath = AppContext.BaseDirectory + _appConfiguration["BaoCaoQuanLyChungTu:ChungTuTemplatePath"];
            try
            {
                #region Lay thong tin chung tu theo ID
                ChungTuKTT chungTuKTT = await _chungTuRepository.GetAsync(chungtuId);
                #endregion

            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool FindAndReplace (Application wordApp, string findText, string replaceWithText)
        {
            bool matchCase = true;
            bool matchWholeWord = true;
            bool matchWildCards = false;
            bool matchSoundLike = false;
            bool matchAllForms = false;
            bool forward = true;
            bool format = false;
            bool matchKashida = false;
            bool matchDiactitics = false;
            bool matchAlefHamza = false;
            bool matchControl = false;
            //bool read_only = false;
            //bool visible = true;
            int replace = 2;
            int wrap = 1;
            return wordApp.Selection.Find.Execute(findText, matchCase,
                                                    matchWholeWord, matchWildCards,
                                                    matchSoundLike, matchAllForms, 
                                                    forward, wrap, 
                                                    format, replaceWithText,
                                                    replace, matchKashida, 
                                                    matchDiactitics, matchAlefHamza, 
                                                    matchControl);

        }


    }
}
