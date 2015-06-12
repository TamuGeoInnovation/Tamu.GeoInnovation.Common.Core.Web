using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ViewUtils
/// </summary>
/// 
namespace USC.GISResearchLab.Common.Utils.Web.UIs
{

    public class DropDownListUtils
    {
        public static void FillDropDownList(DropDownList d, DataTable dt, string textField, string valueField)
        {
            try
            {
                if (d != null)
                {
                    if (dt != null)
                    {
                        d.DataSource = dt;

                        DataColumn dataColumnTextField = dt.Columns[textField];

                        if (dataColumnTextField != null)
                        {
                            d.DataTextField = dataColumnTextField.ColumnName;

                            DataColumn dataColumnValueField = dt.Columns[valueField];
                            if (dataColumnValueField != null)
                            {
                                d.DataValueField = dataColumnValueField.ColumnName;
                                d.DataBind();
                                if (d.Items.Count > 0)
                                {
                                    d.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                throw new Exception("FillDropDownList Error - Value field missing: " + valueField);
                            }
                        }
                        else
                        {
                            throw new Exception("FillDropDownList Error - Text field missing: " + textField);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("FillDropDownList Error: " + e.Message, e);
            }
        }
    }
}