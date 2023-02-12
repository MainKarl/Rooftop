namespace API_AnalyseSanguine.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TypeAnalyse> TypeAnalyseList { get; set; }
    }
}
