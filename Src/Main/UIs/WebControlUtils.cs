using System;
using System.Web.UI.WebControls;

namespace USC.GISResearchLab.Common.Utils.Web.UIs
{
    public class WebControlUtils
    {
        public static TableRow BuildTableHeaderRow(string text)
        {
            return BuildTableRow("module-nav-header", text);
        }

        public static TableRow BuildButtonTableRow(string rowStyle, string buttonText, string buttonStyle, CommandEventHandler command)
        {
            TableRow ret = new TableRow();
            try
            {
                TableCell cell = new TableCell();

                Button button = new Button();
                button.Text = buttonText;
                button.CssClass = buttonStyle;
                button.Command += command;

                cell.Controls.Add(button);
                ret.Cells.Add(cell);
                ret.CssClass = rowStyle;
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in BuildButtonTableRow: " + e.Message, e);
            }

            return ret;
        }

        public static TableRow BuildTableRow(string cssClass, string text)
        {
            return BuildTableRow(cssClass, new string[] {text});
        }

        public static TableRow BuildTableRow(string cssClass, string[] values)
        {
            TableRow ret = new TableRow();
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ret.Cells.Add(BuildTableCell(cssClass, values[i]));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in BuildTableRow: " + e.Message, e);
            }
            return ret;
        }

        public static TableCell BuildTableHeaderCell(string text)
        {
            return BuildTableCell("module-nav-header", text);
        }

        public static TableCell BuildTableCell(string cssClass, string text)
        {
            TableCell ret = BuildTableCell(cssClass);
            ret.Text = text;
            return ret;
        }

        public static TableCell BuildTableCell(string cssClass)
        {
            TableCell ret = new TableCell();
            ret.CssClass = cssClass;
            ret.HorizontalAlign = HorizontalAlign.Left;
            return ret;
        }

        public static TableRow BuildHyperLinkTableRow(string cssClass, string url, string text)
        {
            TableRow ret = new TableRow();
            try
            {
                TableCell cell = BuildTableCell(cssClass);
                cell.Controls.Add(BuildHyperLink(url, text));
                ret.Cells.Add(cell);
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in BuildHyperLinkTableRow: " + e.Message, e);
            }
            return ret;
        }

        public static TableCell BuildTextBoxTableCell(string cssClassCell, string cssClassTextBox, string textBoxId, string textBoxValue, int length)
        {
            TableCell ret = BuildTableCell(cssClassCell);
            ret.Controls.Add(BuildTextBox(cssClassTextBox, textBoxId, textBoxValue, length));
            return ret;
        }

        public static TableCell BuildTextAreaTableCell(string cssClassCell, string cssClassTextBox, string textBoxId, string textBoxValue, int rows, int cols)
        {
            TableCell ret = BuildTableCell(cssClassCell);
            ret.Controls.Add(BuildTextArea(cssClassTextBox, textBoxId, textBoxValue, rows, cols));
            return ret;
        }

        public static TableCell BuildHyperLinkImageTableCell(string cssClass, string imageUrl, string linkUrl)
        {
            TableCell ret = BuildTableCell(cssClass);
            ret.Controls.Add(BuildHyperLinkImage(imageUrl, linkUrl));
            return ret;
        }

        public static TableCell BuildHyperLinkTableCell(string cssClass, string url, string text)
        {
            TableCell ret = BuildTableCell(cssClass);
            ret.Controls.Add(BuildHyperLink(url, text));
            return ret;
        }

        public static TableCell BuildButtonTableCell(string cssClass, string text, CommandEventHandler commandEventHandler, string args)
        {
            TableCell ret = BuildTableCell("");
            ret.Controls.Add(BuildButton(cssClass , text, commandEventHandler, args));
            return ret;
        }

        public static HyperLink BuildHyperLink(string url, string text)
        {
            return BuildHyperLink(url, text, null);
        }
        public static HyperLink BuildHyperLink(string url, string text, string target)
        {
            HyperLink ret = new HyperLink();
            ret.NavigateUrl = url;
            ret.Text = text;
            if (target != null)
            {
                ret.Target = target;
            }

            return ret;
        }

        public static HyperLink BuildHyperLinkImage(string imageUrl, string linkUrl)
        {
            HyperLink ret = new HyperLink();
            ret.NavigateUrl = linkUrl;

            Image image = new Image();
            image.ImageUrl = imageUrl;

            ret.Controls.Add(image);

            return ret;
        }

        public static TextBox BuildTextBox(string cssClass, string textBoxId, string textBoxValue, int length)
        {
            TextBox ret = new TextBox();
            ret.CssClass = cssClass;
            ret.ID = textBoxId;
            ret.Text = textBoxValue;
            ret.Width = new Unit(length);

            return ret;
        }

        public static TextBox BuildTextArea(string cssClass, string textBoxId, string textBoxValue, int rows, int cols)
        {
            TextBox ret = new TextBox();
            ret.CssClass = cssClass;
            ret.ID = textBoxId;
            ret.Text = textBoxValue;
            ret.Wrap = false;
            ret.Rows = rows;
            ret.Columns = cols;
            ret.TextMode = TextBoxMode.MultiLine;
            return ret;
        }

        public static Button BuildButton(string cssClass, string text, CommandEventHandler commandEventHandler, string args)
        {
            Button ret = new Button();
            ret.Command += commandEventHandler;
            ret.CommandArgument = args;
            ret.CssClass = cssClass;
            ret.Text = text;

            return ret;
        }

        public static RadioButtonList BuildRadioButtonList(string cssClass, string[] texts, string[] values)
        {
            RadioButtonList ret = new RadioButtonList();
            try
            {
                ret.CssClass = cssClass;
                if (texts != null)
                {
                    for (int i = 0; i < texts.Length; i++)
                    {
                        ret.Items.Add(new ListItem(texts[i], values[i], true));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in BuildRadioButtonList: " + e.Message, e);
            }


            return ret;
        }

        public static RadioButton BuildRadioButton(string cssClass, string id, string text)
        {
            RadioButton ret = new RadioButton();
            try
            {
                ret.ID = id;
                ret.CssClass = cssClass;
                ret.Text = text;
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in BuildRadioButton: " + e.Message, e);
            }

            return ret;
        }

        public static CheckBoxList BuildCheckBoxList(string cssClass, string[] texts, string[] values)
        {
            CheckBoxList ret = new CheckBoxList();
            try
            {
                ret.CssClass = cssClass;
                if (texts != null)
                {
                    for (int i = 0; i < texts.Length; i++)
                    {
                        ret.Items.Add(new ListItem(texts[i], values[i], true));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in BuildCheckBoxList: " + e.Message, e);
            }

            return ret;
        }

        public static CheckBox BuildCheckBox(string cssClass, string id, string text)
        {
            CheckBox ret = new CheckBox();
            try
            {
                ret.ID = id;
                ret.CssClass = cssClass;
                ret.Text = text;
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in BuildCheckBox: " + e.Message, e);
            }
            return ret;
        }

        public static void SetDropDownSelectedText(DropDownList list, string text)
        {
            try
            {
                if (list != null)
                {
                    if (list.Items.Count > 0)
                    {
                        for (int i = 0; i < list.Items.Count; i++)
                        {
                            string itemText = list.Items[i].Text;
                            if (String.Compare(itemText, text, true) == 0)
                            {
                                list.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in SetDropDownSelectedText: " + e.Message, e);
            }
        }
    }
}
