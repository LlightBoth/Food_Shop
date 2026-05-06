namespace FoodShop.WebApps.Services
{
    public class ChartDataset
    {
        public string Label { get; set; }
        public double[] Data { get; set; }
        public string[] BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public bool? Fill { get; set; }
    }

    public class ChartData
    {
        public string[] Labels { get; set; }
        public List<ChartDataset> Datasets { get; set; }
    }

    public class ChartConfig
    {
        public string Type { get; set; }
        public ChartData Data { get; set; }
        public object Options { get; set; }
    }

}
