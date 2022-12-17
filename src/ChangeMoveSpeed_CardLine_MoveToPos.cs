using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using DG.Tweening;
using HarmonyLib;

namespace RepeatScroll
{
    [HarmonyPatch(typeof(CardLine), nameof(CardLine.MoveToPos), new Type[] {
        typeof(float), typeof(float), typeof(Ease) , typeof(TweenCallback)
    })]
    internal static class ChangeMoveSpeed_CardLine_MoveToPos
    {
        private static float ScrollSpeedMilliseconds = Plugin.ScrollSpeedMilliseconds / 1000f;

        public static bool Prepare()
        {
            return ScrollSpeedMilliseconds != 0;
        }

        public static void Prefix(ref float _Time)
        {
            _Time = ScrollSpeedMilliseconds;
        }

    }
}
