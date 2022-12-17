using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace RepeatScroll
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log { get; set; }

        /// <summary>
        /// The amount of time in milliseconds that a scroll will complete.
        /// </summary>
        public static long ScrollSpeedMilliseconds { get; set; }
        public static int ScrollRepeatDelay { get; set; }

        private void Awake()
        {
            ScrollRepeatDelay = Config.Bind("General", nameof(ScrollRepeatDelay), 250,
                "When holding the scroll key down, indicates how often the scroll will repeat").Value;

            ScrollSpeedMilliseconds = Config.Bind("General", nameof(ScrollSpeedMilliseconds), 0,
                "The amount of time that a scroll will take to complete.  Use zero for the game's default speed.").Value;

            LastKeyTracker.RepeatMilliseconds = ScrollRepeatDelay;

            Log = Logger;

            Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

        }

        public static void LogInfo(string text)
        {
            Plugin.Log.LogInfo(text);
        }

        public static string GetGameObjectPath(GameObject obj)
        {
            GameObject searchObject = obj;

            string path = "/" + searchObject.name;
            while (searchObject.transform.parent != null)
            {
                searchObject = searchObject.transform.parent.gameObject;
                path = "/" + searchObject.name + path;
            }
            return path;
        }

    }
}