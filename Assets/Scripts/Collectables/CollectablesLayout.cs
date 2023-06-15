using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Collectables
{
    public class CollectablesLayout : MonoBehaviour
    {
        private CollectablesSetup _collectablesSetup;
        public Image uiIcon;
        public TextMeshProUGUI uiValue;

        private void Update()
        {
            uiValue.text = _collectablesSetup.soInt.value.ToString();
        }

        public void Load(CollectablesSetup collectablesSetup)
        {
            collectablesSetup = _collectablesSetup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _collectablesSetup.icon;
        }
    }
}
