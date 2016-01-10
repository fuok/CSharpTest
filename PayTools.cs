using System;

namespace CSharpTest
{
	public class PayTools
	{
		private const String tableName = "payChecksTable";
		private const String dbPath = "data source=CSharpTest.db";
		private static PayTools instance;
		private DbAccess db;

		static PayTools ()
		{
			instance = new PayTools ();
		}

		private PayTools ()
		{
			db = new DbAccess (dbPath);
		}

		public static PayTools getInstance ()
		{
			return instance;
		}

		public void CreatTable ()
		{
			//			db = new DbAccess (dbPath);
			db.OpenDB (dbPath);
			//创建数据库表，与字段
			db.CreateTable (tableName, new string[]{ "sellerName", "customerName", "itemName", "payTime" }, new string[] {
				"text", "text", "text", "text"
			}, true);
			db.CloseSqlConnection ();
		}

		public void Add (Pay pay)
		{
			db.OpenDB (dbPath);
			//添加数据
			db.InsertIntoSpecific (tableName, new string[]{ "sellerName", "customerName", "itemName", "payTime" }, new string[] {
				"'" + pay.SellerName + "'", "'" + pay.CustomerName + "'", "'" + pay.ItemName + "'", "'" + pay.PayTime + "'"
			});
			db.CloseSqlConnection ();
		}
	}
}

