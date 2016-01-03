using System;

namespace CSharpTest
{
	public class SellerTool
	{
		private const String tableName = "seller";
		private static SellerTool instance;
		private DbAccess db;

		static SellerTool ()
		{
			instance = new SellerTool ();
		}
		
		private SellerTool ()
		{
			
		}

		public static SellerTool getInstance ()
		{
			return instance;
		}

		public void CreatTable ()
		{
			db = new DbAccess ("data source=CSharpTest.db");//数据库名//("Server=127.0.0.1;UserId=root;Password=;Database=li")
			//创建数据库表，与字段
			db.CreateTable (tableName, new string[]{"userName","passWord"}, new string[] {
				"text",
				"text"
			});
		}

		public void Add (Seller seller)
		{
			//添加数据
			db.InsertInto (tableName, new string[] {//表名
				"'" + seller.UserName + "'",
				"'" + seller.PassWord + "'"
			});
		}
	}
}

