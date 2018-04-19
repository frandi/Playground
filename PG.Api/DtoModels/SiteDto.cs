using PG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PG.Api.DtoModels
{
    public class SiteDto
    {
        public SiteDto()
        {

        }

        public SiteDto(Site site)
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Site ToSite()
        {
            return new Site();
        }
    }
}