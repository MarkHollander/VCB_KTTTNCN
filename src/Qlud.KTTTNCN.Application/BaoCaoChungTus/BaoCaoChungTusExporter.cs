using Qlud.KTTTNCN.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlud.KTTTNCN.BaoCaoChungTus
{
    public class BaoCaoChungTusExporter : KTTTNCNAppServiceBase, IBaoCaoChungTusExporter
    {
        public Task<FileDto> ExportToPDF(long chungTuId)
        {
            throw new NotImplementedException();
        }

        public Task<FileDto> ExportToWord(long chungTuId)
        {
            throw new NotImplementedException();
        }

        public Task<FileDto> ExportToXML(long chungTuId)
        {
            throw new NotImplementedException();
        }
    }
}
