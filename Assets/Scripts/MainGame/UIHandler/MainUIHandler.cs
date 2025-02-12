﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KWY
{
    public class MainUIHandler : MonoBehaviour
    {
        [SerializeField]
        MainGameData data;

        [SerializeField]
        TMP_Text turnText;

        public void Init()
        {
        }

        public void UpdateTurnText()
        {
            turnText.text = data.TurnNum.ToString();
        }
    }
}