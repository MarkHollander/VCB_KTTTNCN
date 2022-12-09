using System;
using Abp.AutoMapper;
using Qlud.KTTTNCN.Sessions.Dto;

namespace Qlud.KTTTNCN.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}