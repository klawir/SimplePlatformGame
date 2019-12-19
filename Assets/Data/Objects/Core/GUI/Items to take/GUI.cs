using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    namespace ToTake
    {
        public class GUI : Core.GUI
        {
            public override void RenderDefault()
            {
                txtToDisplay.text = "Press 'E' to take";
            }
        }
    }
}