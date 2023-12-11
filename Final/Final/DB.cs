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

    public static void UpdatePlayer(Player player)
    {
        var existingPlayer = conn.Table<Player>().FirstOrDefault(p => p.Id == player.Id);

        if (existingPlayer != null)
        {
            existingPlayer.IsPlaying = player.IsPlaying;
            conn.Update(existingPlayer);
        }
    }

    public static void UpdatePlayerStat(Player player, string stat)
    {
        var existingPlayer = conn.Table<Player>().FirstOrDefault(p => p.Id == player.Id);

        if (existingPlayer != null)
        {
            switch(stat)
            {
                case "Catch":
                    existingPlayer.Catches += 1;
                    break;
                case "Completion":
                    existingPlayer.Completions += 1;
                    break;
                case "Score":
                    existingPlayer.Points += 1;
                    break;
                case "ThrowAway":
                    existingPlayer.ThrowAways += 1;
                    break;
                default: 
                    break;
            }
            conn.Update(existingPlayer);
        }
    }

    public static List<Player> GetAllPlayers()
    {
        return conn.Table<Player>().ToList();
    }

    public static void DeletePlayer(Player player)
    {
        conn.Delete(player);
    }

    public static void ResetPlayers()
    {
        List<Player> all = conn.Table<Player>().ToList();
        foreach(Player p in all)
        {
            p.IsPlaying = false;
            DB.UpdatePlayer(p);
        }
    }

    public static void Clear()
    {
        var allPlayers = conn.Table<Player>().ToList();

        foreach (var player in allPlayers)
        {
            conn.Delete(player);
        }
    }
    public static List<Player> Top5()
    {
        string query = "SELECT * " +
                       "FROM Player " +
                       "ORDER BY catches DESC " +
                       "LIMIT 5";

        return conn.Query<Player>(query).ToList();
    }
}
