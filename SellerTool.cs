using System;
using Mono.Data.Sqlite;

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
			db = new DbAccess ("data source=CSharpTest.db");
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

		//查找，用于登陆
		public bool Query (Seller seller)
		{
			//查询
			SqliteDataReader sqReader = db.SelectWhere (tableName, new string[] {
				"userName",
				"passWord"
			}, new string[]{"userName"}, new string[]{"="}, new string[]{seller.UserName});
			while (sqReader.Read()) {
//				Console.WriteLine (sqReader.GetString (sqReader.GetOrdinal ("userName")) + sqReader.GetString (sqReader.GetOrdinal ("passWord")));//GetString()也可以直接写列序号
				if (seller.UserName.Equals(sqReader.GetString (sqReader.GetOrdinal ("userName")))) {
					if (seller.PassWord.Equals(sqReader.GetString (sqReader.GetOrdinal ("passWord")))) {
						return true;
					}
				}
			}
			return false;
		}
	}
}

