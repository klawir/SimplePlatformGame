using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    namespace Core
    {
        public abstract class GUI : MonoBehaviour
        {
            public Text txtToDisplay;

            public abstract void RenderDefault();

            public void DisableInfo()
            {
                txtToDisplay.gameObject.SetActive(false);
            }
            public void EnableInfo()
            {
                txtToDisplay.gameObject.SetActive(true);
            }
            
        }
    }
}