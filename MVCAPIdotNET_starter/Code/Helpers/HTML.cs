using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MVCAPIdotNET_starter.Code.Helpers
{
    public static class HTML
    {
        public static string CreateEnumSelect(Type TypeEnum, string selectName = "", string selectValue = "", string selectClasses = "")
        {
            string keyname = TypeEnum.ToString();
            if (selectName == "")
                selectName = TypeEnum.Name;
            try {
                List<string> dataList = Enum.GetNames(TypeEnum).ToList();
                StringBuilder sb = new StringBuilder();
                sb.Append("<select name=\"");
                sb.Append(selectName);
                sb.Append("\"");
                if (selectClasses != "")
                {
                    sb.Append(" class=\"");
                    sb.Append(selectClasses);
                    sb.Append("\"");
                }
                sb.Append(" >");
                foreach (var name in dataList)
                {
                    short num = (short)Enum.Parse(TypeEnum, name);
                    sb.Append("<option ");
                    sb.Append("value=\"");
                    sb.Append(num);
                    sb.Append("\"");
                    if (selectValue == name || selectValue == "" + num)
                        sb.Append(" selected=\"selected\"");
                    sb.Append(">");
                    sb.Append(name);
                    sb.Append("</option>");
                }
                sb.Append("</select>");

                return sb.ToString();
            }
            catch (Exception e)
            {
                return "Error: Select non creata. <span hidden>" + e.Message + "</span>";
            }
        }
        public static string CreateFlagEnumCheckList(Type TypeEnum, string inputHiddenName = "", string inputHiddenValue = "", string selectClasses = "")
        {
            string keyname = TypeEnum.ToString();
            try
            {
                List<string> dataList = Enum.GetNames(TypeEnum).ToList();
                StringBuilder sb = new StringBuilder();
                sb.Append("<div class=\"form-form form-inline form-flag-enum ");
                sb.Append(selectClasses);
                sb.Append("\" >");
                sb.Append("<input name=\"" + ((inputHiddenName != "") ? inputHiddenName : keyname) + "\" value=\"" + inputHiddenValue + "\" type=\"hidden\" />");
                foreach (var name in dataList)
                {
                    int num = (int)Enum.Parse(TypeEnum, name);
                    sb.Append("<label class=\"form-check-label\">");
                    sb.Append("<input name=\""+ name + "\" type=\"checkbox\" class=\"form-check-input\" value=\"");
                    sb.Append(num);
                    sb.Append("\" /> ");
                    sb.Append(name);
                    sb.Append(" <span class=\"bitsNumber\">(");
                    sb.Append(num);
                    sb.Append(")</span>");
                    sb.Append("</label>");
                }
                sb.Append("</div>");

                return sb.ToString();
            }
            catch (Exception e)
            {
                return "Error: Select non creata. <span class=\"hidden\">" + e.Message + "</span>";
            }
        }
    }
}