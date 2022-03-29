using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace state
{
    public class SelectOrDetect : MonoBehaviour
    {
        static public bool select = false; // on est dans le mode detect dans le d�but
        static public bool detect = true;

        static public void Select_Or_Detect()
        {
            // Si on appuie sur le boutton on d�clanche le mode select si on est dans le mode detect et vis-vers-ca 
            select = !select;
            detect = !detect;
        }

        public bool Select
        {
            get { return select; }
        }

        public bool Detect
        {
            get { return detect; }
        }
    }
}


