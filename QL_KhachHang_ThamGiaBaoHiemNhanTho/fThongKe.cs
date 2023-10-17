using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QL_KhachHang_ThamGiaBaoHiemNhanTho
{
    public partial class fThongKe : Form
    {
        public fThongKe()
        {
            InitializeComponent();
            Load += FThongKe_Load;
        }

        private void FThongKe_Load(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("kh");

            var pipeline = new List<BsonDocument>
            {
                BsonDocument.Parse("{ $unwind: '$GoiBaoHiem' }"),
                BsonDocument.Parse("{ $group: { _id: '$GoiBaoHiem.tenGoiBaoHiem', Count: { $sum: 1 } } }")
            };

            var result = collection.Aggregate<BsonDocument>(pipeline).ToList();

            var chart = new Chart();
            chart.Size = new System.Drawing.Size(600, 400);

            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = "CustomerCount";
            series.ChartType = SeriesChartType.Bar;

            foreach (var item in result)
            {
                var packageName = item["_id"].AsString;
                var count = item["Count"].AsInt32;
                series.Points.AddXY(packageName, count);
            }

            chart.Series.Add(series);

            Controls.Add(chart);
        }
    }
}
