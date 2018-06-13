using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Models.Characteristics;

namespace WorldBuilder.Helpers
{
    public static class EnumConverter
    {
        public static SelectList ConvertDBEnumToSelectList(IEnumerable<DBEnum> enumValues)
        {
            return new SelectList(enumValues.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }), "Value", "Text");
        }
    }
}