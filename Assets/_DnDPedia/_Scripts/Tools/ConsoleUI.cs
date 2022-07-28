//----------------------------------------------------------------
// @Description: A script to display the DatabaseManager action log on the screen.
// 
// @Author: Luis Betancourt
// 
// @Date: 27/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//----------------------------------------------------------------

namespace DnDPedia.Tools
{
    public class ConsoleUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI logTextArea;	// The text object where to print the received logs

        void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        void HandleLog(string receivedLog, string stackTrace, LogType type) => logTextArea.text += receivedLog + "\n";
    }
}
