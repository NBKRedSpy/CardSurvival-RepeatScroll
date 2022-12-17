using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace RepeatScroll
{
    [HarmonyPatch(typeof(GraphicsManager), "Hotkeys")]
    [HarmonyBefore("RemapHotkeys")]
    public static class AddDelay_GraphicsManager_Hotkeys_Patch
    {
        private static CodeInstruction IsKeyRepeatCall = CodeInstruction.Call<KeyCode, bool>(keyCode => LastKeyTracker.GetKeyIsRepeat(keyCode));
        private static MethodInfo GetKeyDownMethod = AccessTools.Method(
            typeof(UnityEngine.Input), 
            nameof(UnityEngine.Input.GetKeyDown), 
            new Type[] {typeof(KeyCode)});

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {

            List<CodeInstruction> orig = new List<CodeInstruction>(instructions);

            return new CodeMatcher(orig)
                .ReplaceGetKey(KeyCode.Q)
                .ReplaceGetKey(KeyCode.W)
                .ReplaceGetKey(KeyCode.A)
                .ReplaceGetKey(KeyCode.S)
                .InstructionEnumeration();
        }

        /// <summary>
        /// Searches for and replaces a keycode call with the delay key code.
        /// </summary>
        /// <param name="codeMatcher"></param>
        /// <param name="keySearch">For informational purposes.  Keys may be remapped for this mod runs.</param>
        /// <returns></returns>
        private static CodeMatcher ReplaceGetKey(this CodeMatcher codeMatcher, KeyCode keySearch)
        {
            codeMatcher
                .MatchForward(true,
                    new CodeMatch(OpCodes.Ldc_I4_S),
                    new CodeMatch(OpCodes.Call, GetKeyDownMethod))
                .ThrowIfNotMatch($"Did not find {keySearch}")
                .RemoveInstruction()
                .InsertAndAdvance(IsKeyRepeatCall);
                    

            return codeMatcher;
        }

        private static bool Testing(KeyCode key)
        {
            Plugin.LogInfo($"hit: {key}");
            return true;
        }

        private static bool Testing()
        {
            Plugin.LogInfo($"hit");
            return true;
        }

    }
}
