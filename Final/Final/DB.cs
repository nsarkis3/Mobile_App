using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final;

public class DB
{
    private static string DBName = "log.db";
    public static SQLiteConnection conn;
    public static void OpenConnection()
    {
        string libFolder = FileSystem.AppDataDirectory;
        string fname = System.IO.Path.Combine(libFolder, DBName);
        conn = new SQLiteConnection(fname);
        conn.CreateTable<Player>();
    }

    public static void InsertPlayer(Player player)
    {
        conn.Insert(player);
    }

    public static List<Player> GetAllPlayers()
    {
        return conn.Table<Player>().ToList();
    }

    public static void DeletePlayer(Player player)
    {
        conn.Delete(player);
    }
}
