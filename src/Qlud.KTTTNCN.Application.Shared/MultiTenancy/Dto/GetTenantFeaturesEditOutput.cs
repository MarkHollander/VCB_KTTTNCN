using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.Editions.Dto;

namespace Qlud.KTTTNCN.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}