using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.Editions.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}