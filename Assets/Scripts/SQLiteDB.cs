using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SQLiteDB : MonoBehaviour
{
    public static SQLiteDB instance;
    private string dbName = "URI=file:DnDHelper.db";
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //CreateAlphabetTable();
    }
     public void CreateAlphabetTable()
    {
        Debug.Log("creating...");
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                string sqlcreation = "";
                sqlcreation += "CREATE TABLE Alphabet (";
                sqlcreation += "id INTEGER NOT NULL ";
                sqlcreation += "PRIMARY KEY AUTOINCREMENT,";
                sqlcreation += "name     TEXT NOT NULL";
                sqlcreation += ");";
                command.CommandText = sqlcreation;
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        Debug.Log("created");

    }
}
