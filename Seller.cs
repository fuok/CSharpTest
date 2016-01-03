using System;

namespace CSharpTest
{
	public class Seller:User
	{
//		public int Id{ set; get; }

		public String UserName{ set; get; }

		public String PassWord{ set; get; }

		public Seller ()
		{
		}

		public Seller (String userName, String passWord)
		{
			this.UserName = userName;
			this.PassWord = passWord;
		}
	}
}

