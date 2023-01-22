using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManagement
{
    public static string username;
    public static string userid;

    public static string id = "1";

    public static string profuname = "2";

    public static bool LoggedIn 
    {
        get {return username != null; }
    }

    
    public static void LogOut()
    {
        username = null;
    }
}
