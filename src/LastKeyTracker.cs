using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RepeatScroll
{
    /// <summary>
    /// Tracks the last key that was pressed and how long ago.
    /// </summary>
    internal static class LastKeyTracker
    {
        public static KeyCode LastKey{ get; set; }

        public static Stopwatch LastKeyTimer { get; } = Stopwatch.StartNew();

        /// <summary>
        /// The number of milliseconds to elapse to allow a key to repeat
        /// </summary>
        public static int RepeatMilliseconds { get; set; } = 500;


        public static bool GetKeyIsRepeat(KeyCode keyCode)
        {
            //Check if matches and held
            if (Input.GetKey(keyCode))
            {

                //Check if player tapped key
                if (Input.GetKeyDown(keyCode))
                {
                    LastKey = keyCode;
                    LastKeyTimer.Restart();
                    return true;
                }

                return IsKeyRepeat(keyCode);
            }

            return false;
        }

        /// <summary>
        /// returns true 
        /// </summary>
        /// <param name="key"></param>
        public static bool IsKeyRepeat(KeyCode key)
        {

            if(LastKey == key)
            {
                if(LastKeyTimer.ElapsedMilliseconds < RepeatMilliseconds)
                {
                    return false;
                }
                else
                {
                    LastKeyTimer.Restart();
                    return true;
                }
            }
            else
            {
                LastKey = key;
                LastKeyTimer.Restart();
                return true;
            }
        }
    }
}
