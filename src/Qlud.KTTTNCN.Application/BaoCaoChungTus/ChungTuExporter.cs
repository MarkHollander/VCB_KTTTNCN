using Qlud.KTTTNCN.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlud.KTTTNCN.BaoCaoChungTus
{
    public class ChungTuExporter : KTTTNCNAppServiceBase, IBaoCaoChungTusExporter
    {
        public FileDto ExportToPDF(long chungTuId)
        {
            return new FileDto();
        }

        public FileDto ExportToXML(long chungTuId)
        {
            return new FileDto();
        }
    }
}
