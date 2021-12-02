using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;

public static class AnalyticsManager
{
    private static void LogEvent(string eventName, params Parameter[] parameters)
    {
        //Method utama untuk menembakkan Firebase
        FirebaseAnalytics.LogEvent(eventName, parameters);
    }

    public static void LogUpgradeEvent(int resourceIndex, int level)
    {
        //Kita memakai Event dan Parameter yang tersedia di Firebase (tidak memakai custom)
        //agar dapat muncul sebagai report data di Analitycs Firebase
        LogEvent(
            FirebaseAnalytics.EventLevelUp,
            new Parameter(FirebaseAnalytics.ParameterIndex, resourceIndex.ToString()),
            new Parameter(FirebaseAnalytics.ParameterLevel, level)
        );
        //Karena resourceIndex digunakan sebagai ID, maka seharusnya kita menyimpannya
        //sebagai string bukan integer
    }

    public static void LogUnlockEvent(int resourceIndex)
    {
        LogEvent(
            FirebaseAnalytics.EventUnlockAchievement,
            new Parameter(FirebaseAnalytics.ParameterIndex, resourceIndex.ToString())
        );
    }

    public static void SetUserProperties(string name, string value)
    {
        FirebaseAnalytics.SetUserProperty(name, value);
    }
}
