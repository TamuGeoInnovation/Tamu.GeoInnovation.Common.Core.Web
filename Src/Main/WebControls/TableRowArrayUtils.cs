using System.Web.UI.WebControls;

namespace USC.GISResearchLab.Common.Core.Utils.Arrays
{
    public class TableRowArrayUtils
    {


        public static TableRow[] Add(TableRow[] array, TableRow o)
        {
            if (array == null)
            {
                array = new TableRow[0];
            }

            TableRow[] newList = new TableRow[array.Length + 1];
            for (int j = 0; j < array.Length; j++)
            {
                newList[j] = array[j];
            }

            newList[newList.Length - 1] = o;

            return newList;
        }

    }
}
