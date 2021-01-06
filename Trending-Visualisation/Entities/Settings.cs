using System.Collections.Generic;

namespace Trending_Visualisation.Entities
{
    public class Settings
    {
        private bool Empty = true;

        private Dictionary<string, ColumnData> Columns = new Dictionary<string, ColumnData>{}; 
        private string BaseXColumn { get; set; }
        private string BaseXTitle { get; set; }
        private string BaseLegend { get; set; }

        public Settings()
        {

        }
        public bool GetEmpty()
        {
            return Empty;
        }

        public void SetEmpty(bool state)
        {
            Empty = state;
        }
        public string GetXColumn()
        {
            return BaseXColumn;
        }
        public void SetXColumn(string xcolumn)
        {
            BaseXColumn = xcolumn;
        }
        public string GetXTitle()
        {
            return BaseXTitle;
        }

        public void SetXTitle(string xtitle)
        {
            BaseXTitle = xtitle;
        }
        
        
        public string GetBaseLegend()
        {
            return BaseLegend;
        }

        public void SetBaseLegend(string legend)
        {
            BaseLegend = legend;
        }


        public Dictionary<string, ColumnData> GetColumns()
        {
            return Columns;
        }
        public void SetColumns(Dictionary<string, ColumnData> columns)
        {
            Columns = columns;
        }

    }


}
