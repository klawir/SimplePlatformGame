using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    namespace ToUse
    {
        public class GUI : Core.GUI
        {
            public Text txtToDisplayState;

            public override void RenderDefault()
            {
                txtToDisplay.text = "Press 'E' to close";
            }
            public void RenderOpen()
            {
                txtToDisplay.text = "Press 'E' to open";
            }
            public void EnableInfoState()
            {
                txtToDisplayState.gameObject.SetActive(true);
            }
            public void DisableInfoState()
            {
                txtToDisplayState.gameObject.SetActive(false);
            }
            public void RenderState()
            {
                txtToDisplayState.text = "Need the key";
            }
        }
    }
}
