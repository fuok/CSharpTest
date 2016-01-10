using System;

namespace CSharpTest
{
	public class Pay
	{
		public int Id{get;}
		public String SellerName{set;get;}
		public String CustomerName{set;get;}
		public String ItemName{set;get;}//其实应该用id比较好
		public String PayTime{set;get;}

		public Pay ()
		{
		}

		public Pay(String sellerName,String customerName,String itemName,String payTime)
		{
			this.SellerName=sellerName;
			this.CustomerName=customerName;
			this.ItemName=itemName;
			this.PayTime=payTime;
		}

		public override string ToString ()
		{
			return string.Format ("[Pay: Id={0}, SellerName={1}, CustomerName={2}, ItemName={3}, PayTime={4}]", Id, SellerName, CustomerName, ItemName, PayTime);
		}
		
	}
}

