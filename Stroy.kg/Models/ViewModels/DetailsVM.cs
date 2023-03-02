namespace Stroy.kg.Models.ViewModels
{
	public class DetailsVM
	{
		public DetailsVM()
		{
			Product=new Product2();
		}
		public Product2 Product { get; set; }
		public bool ExistsInCard { get; set; }
	}
}
