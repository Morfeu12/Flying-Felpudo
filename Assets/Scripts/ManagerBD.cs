using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;
// using Npgsql;

public class ManagerBD : MonoBehaviour
{
    private Text txtNickname;
    private bool insertNickname = false;
    //private string score = "0";
    // Start is called before the first frame update
    void Start()
    {
        txtNickname = GameObject.Find("Text Nickname").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (txtNickname.text != "") {
            print("Nickname: "+txtNickname.text);

            if (insertNickname) { // Start insert

                //var dateNow = GetDateTime();
                /*var dateNow = "2020-01-04";

                var connectionString = "Host=ep-shrill-pine-516796.us-east-2.aws.neon.tech;Username=AMg7MQg6kuR3;Password=uDO2TsXK0zPk;Database=flying-felpudo";
                await using var dataSource = NpgsqlDataSource.Create(connectionString);

                await using (var cmd = dataSource.CreateCommand("INSERT INTO rank_geral(nickname, point, created_on) VALUES ("+txtNickname+", "+score+", "+dateNow+")"))
                {
                    await cmd.ExecuteNonQueryAsync();
                }*/
            } // End Insert
        }
        
    }

   /* public string GetDateTime() {
        DateTime utcDate = DateTime.UtcNow;
        utcDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

        return utcDate;
    }*/
}
