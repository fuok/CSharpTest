using System;
using System.Collections.Generic;

namespace CSharpTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SellerTool.getInstance ().CreatTable ();
			CustomerTool.getInstance ().CreatTable ();
			ItemTool.getInstance ().CreatTable ();

			while (true) {
				Menu menu = new Menu ();
				menu.Start ();
			}
		}
	}

	public class Menu
	{
		private User cacheUser;
		private List<Item> cacheShoppingCar = new List<Item> ();

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
				ShowLoginCustomer ();
				break;
			case "2":
				ShowLoginSeller ();
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
				ShowRegistCustomer ();
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

		//卖家登陆
		public void ShowLoginSeller ()//注册不缓存，登陆才缓存
		{
			Console.WriteLine ("卖家登陆");
			Console.WriteLine ("输入用户名:");
			String inputUserName = Console.ReadLine ();
			Console.WriteLine ("输入密码:");
			String inputPassWord = Console.ReadLine ();
			Seller s = new Seller (inputUserName, inputPassWord);
			if (SellerTool.getInstance ().Query (s)) {//登录成功
				Console.WriteLine ("登录成功");
				//第一次缓存数据,这个是临时数据，不完整的
				cacheUser = s;
				ShowSellerOption ();
			} else {
				Console.WriteLine ("登录失败");
			}
		}

		//卖家注册
		public void ShowRegistSeller ()
		{
			Console.WriteLine ("注册卖家");
			Console.WriteLine ("输入用户名:");
			String inputUserName = Console.ReadLine ();
			Console.WriteLine ("输入密码:");
			String inputPassWord = Console.ReadLine ();
			if (true) {//可以注册
				Seller s = new Seller ();
//				seller.Id=
//				DateTime now=DateTime.Now;
//				Console.WriteLine (now.ToString());
				s.UserName = inputUserName;
				s.PassWord = inputPassWord;
				//存入数据库
				SellerTool.getInstance ().Add (s);
			}
		}

		//买家登陆
		public void ShowLoginCustomer ()//注册不缓存，登陆才缓存
		{
			Console.WriteLine ("买家登陆");
			Console.WriteLine ("输入用户名:");
			String inputUserName = Console.ReadLine ();
			Console.WriteLine ("输入密码:");
			String inputPassWord = Console.ReadLine ();
			Customer c = new Customer (inputUserName, inputPassWord);
			if (CustomerTool.getInstance ().Query (c)) {//登录成功
				Console.WriteLine ("登录成功");
				//第一次缓存数据,这个是临时数据，不完整的
				cacheUser = c;
				ShowCustomerOption ();
			} else {
				Console.WriteLine ("登录失败");
			}
		}

		//买家注册
		public void ShowRegistCustomer ()
		{
			Console.WriteLine ("注册买家");
			Console.WriteLine ("输入用户名:");
			String inputUserName = Console.ReadLine ();
			Console.WriteLine ("输入密码:");
			String inputPassWord = Console.ReadLine ();
			if (true) {//可以注册
				Customer c = new Customer (inputUserName, inputPassWord);
				//存入数据库
				CustomerTool.getInstance ().Add (c);
			}
		}

		//-----------------------------  四级选项  -----------------------------

		//卖家界面
		public void ShowSellerOption ()
		{
			//读取卖家数据并缓存,登录时虽然缓存了卖家数据，但只是临时数据，因为要刷新金额，所以干脆把完整的缓存位置改到这里
			cacheUser = SellerTool.getInstance ().getSellerData (cacheUser.UserName);
			if (cacheUser is Seller) {
				Console.WriteLine ("缓存成功");
			}
			Console.WriteLine ("选择卖家功能:");
			Console.WriteLine ("1.查看卖家信息");
			Console.WriteLine ("2.查看订单");
			Console.WriteLine ("3.商品管理");
			Console.WriteLine ("4.退出");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				ShowSellerManage ();
				break;
			case "2":
				break;
			case "3":
				ShowItemsManage ();
				break;
			case "4":
				break;
			default:
				break;
			}
		}

		//买家界面
		public void ShowCustomerOption ()
		{
			//读取卖家数据并缓存,登录时虽然缓存了卖家数据，但只是临时数据，因为要刷新金额，所以干脆把完整的缓存位置改到这里
			cacheUser = CustomerTool.getInstance ().getCustomerData (cacheUser.UserName);
			if (cacheUser is Customer) {
				Console.WriteLine ("缓存成功");
			}
			Console.WriteLine ("选择买家功能:");
			Console.WriteLine ("1.查看买家信息");
			Console.WriteLine ("2.查看订单");
			Console.WriteLine ("3.去购物");
			Console.WriteLine ("4.退出");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				ShowCustomerManage ();
				break;
			case "2":
				break;
			case "3":
				ShowShoppingList ();
				break;
			case "4":
				break;
			default:
				break;
			}
		}

		//管理员界面
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

		//-----------------------------  五级选项  -----------------------------

		//卖家信息管理
		public void ShowSellerManage ()
		{
			Console.WriteLine ("卖家信息:");
			Console.WriteLine ("用户名:" + cacheUser.UserName + " 密码:" + cacheUser.PassWord + " 金额:" + cacheUser.Acount);
			Console.WriteLine ("1.修改密码");
			Console.WriteLine ("2.退出");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":

				break;
			case "2":
				break;
			default:
				break;
			}
		}

		public void ShowItemsManage ()
		{
			Console.WriteLine ("商品管理:");
			Console.WriteLine ("1.查看商品列表");
			Console.WriteLine ("2.添加商品");
			Console.WriteLine ("3.修改商品");
			Console.WriteLine ("4.下架商品");
			Console.WriteLine ("5.退出");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				break;
			case "2":
				ShowAddItem ();
				break;
			case "3":
				break;
			case "4":
				break;
			case "5":
				break;
			default:
				break;
			}
		}

		//买家信息管理
		public void ShowCustomerManage ()
		{
			Console.WriteLine ("买家信息:");
			Console.WriteLine ("用户名:" + cacheUser.UserName + " 密码:" + cacheUser.PassWord + " 金额:" + cacheUser.Acount);
			Console.WriteLine ("1.修改密码");
			Console.WriteLine ("2.现金充值");
			Console.WriteLine ("3.退出");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				
				break;
			case "2":
				ShowCustomerPay ();
				break;
			case "3":
				break;
			default:
				break;
			}
		}

		//购物列表
		public void ShowShoppingList ()
		{
			Console.WriteLine ("淘宝列表:");
			List<Item> itemList = ItemTool.getInstance ().GetAllItems ();
			foreach (var item in itemList) {
				Console.WriteLine (item.ToString ());
			}
			Console.WriteLine ("选择功能:");
			Console.WriteLine ("1.添加购物车");
			Console.WriteLine ("2.付款");
			Console.WriteLine ("3.退出");
			String input = Console.ReadLine ();
			switch (input) {
			case "1":
				ShowAddShoppingCar (itemList);
				break;
			case "2":
				ShowPayCheck ();
				break;
			case "3":
				break;
			default:
				break;
			}
		}

		//-----------------------------  六级选项  -----------------------------

		public void ShowAddItem ()
		{
			Console.WriteLine ("添加商品");
			Console.WriteLine ("输入商品名:");
			String inputName = Console.ReadLine ();
			Console.WriteLine ("输入单价:");
			int inputPrice = Convert.ToInt32 (Console.ReadLine ());
			Item item = new Item (inputName, inputPrice, cacheUser.UserName);
			if (true) {
				//添加数据
//				Console.WriteLine (item.Name+","+item.Price+","+item.Seller);
				ItemTool.getInstance ().Add (item);
			}
			//返回上级
			ShowItemsManage ();
		}

		//买家充值
		public void ShowCustomerPay ()
		{
			Console.WriteLine ("现金充值");
			Console.WriteLine ("输入充值金额:");
			int amount = Convert.ToInt32 (Console.ReadLine ());
			CustomerTool.getInstance ().UpdateCustomer ("acount", cacheUser.Acount + amount + "", "userName", cacheUser.UserName);
			ShowCustomerOption ();
		}

		//添加商品至购物车
		public void ShowAddShoppingCar (List<Item> list)
		{
			Console.WriteLine ("输入添加的商品id:");
			int id = Convert.ToInt32 (Console.ReadLine ());
			foreach (Item item in list) {
				if (id == item.Id) {
					cacheShoppingCar.Add (item);
				}
			}
			ShowShoppingList();
		}

		//结账
		public void ShowPayCheck ()
		{
			foreach (Item item in cacheShoppingCar) {//便利购物车
				Console.WriteLine (item.ToString ());
				//创建订单并保存

				//扣除买家金额并保存

				//添加卖家收入并保存
			}

//			清空购物车,TODO
			Console.WriteLine ("支付成功");
		}

	}
}
