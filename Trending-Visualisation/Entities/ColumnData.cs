using System.Drawing;

namespace Trending_Visualisation.Entities
{
    public class ColumnData
    {
        public string ColumName { get; set; }
        public string Legend { get; set; }
        public Color Color { get; set; }

        public ColumnData(string columname, string legend, Color color)
        {
            ColumName = columname;
            Legend = legend;
            Color = color;
        }
    }
}
