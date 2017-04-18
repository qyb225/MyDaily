using MyDaily.Models;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyDaily.Database {
    public static class NoteDatabase {
        public readonly static string DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Note.db");

        public static SQLiteConnection GetDbConnection() {
            // 连接数据库，如果数据库文件不存在则创建一个空数据库。
            var conn = new SQLiteConnection(new SQLitePlatformWinRT(), DbPath);
            // 创建 TodoItem 模型对应的表，如果已存在，则忽略该操作。
            conn.CreateTable<NoteItem>();
            return conn;
        }
    }
}
