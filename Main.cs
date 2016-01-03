using System;

namespace CSharpTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SellerTool.getInstance().CreatTable();
		

			while (true) {
				Menu menu = new Menu ();
				menu.Start ();
			}
		}
	}

	public class Menu
	{

		public void Start ()
		{
			ShowStartType ();
		}

		//-----------------------------  一级选项  -----------------------------

		public void ShowStartType ()
		{
			Console.WriteLine ("选择功能:");
			Console.WriteLine ("1.登陆");
			Console.WriteLine ("2.注册");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				ShowLoginType ();
				break;
			case "2":
				ShowRegistType ();
				break;
			default:
				break;
			}
		}

		//-----------------------------  二级选项  -----------------------------

		public void ShowLoginType ()
		{
			Console.WriteLine ("选择登陆:");
			Console.WriteLine ("1.买家");
			Console.WriteLine ("2.卖家");
			Console.WriteLine ("3.管理员");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				break;
			case "2":
				break;
			case "3":
				ShowAdminOption ();
				break;
			default:
				break;
			}
		}

		public void ShowRegistType ()
		{
			Console.WriteLine ("选择注册:");
			Console.WriteLine ("1.买家");
			Console.WriteLine ("2.卖家");
			Console.WriteLine ("3.返回");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				break;
			case "2":
				ShowRegistSeller ();
				break;
			case "3":
				ShowStartType ();
				break;
			default:
				break;
			}
		}

		//-----------------------------  三级选项  -----------------------------

		public void ShowRegistSeller ()
		{
			Console.WriteLine ("注册卖家");
			Console.WriteLine ("输入用户名:");
			String inputUserName = Console.ReadLine ();
			Console.WriteLine ("输入密码:");
			String inputPassWord = Console.ReadLine ();
			if (true) {//可以注册
				Seller seller = new Seller ();
//				seller.Id=
//				DateTime now=DateTime.Now;
//				Console.WriteLine (now.ToString());
				seller.UserName = inputUserName;
				seller.PassWord = inputPassWord;
				//存入数据库
				SellerTool.getInstance().Add(seller);
			}
		}

		public void ShowAdminOption ()
		{
			Console.WriteLine ("选择管理员功能:");
			Console.WriteLine ("1.查看所有买家信息");
			Console.WriteLine ("2.查看所有卖家信息");
			Console.WriteLine ("3.查看所有商品信息");
			Console.WriteLine ("4.查看本月所有消费总额");
			Console.WriteLine ("5.退出");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				break;
			case "2":
				break;
			case "3":
				break;
			case "4":
				break;
			case "5":
				ShowStartType ();
				break;
			default:
				break;
			}
		}



	}
}
