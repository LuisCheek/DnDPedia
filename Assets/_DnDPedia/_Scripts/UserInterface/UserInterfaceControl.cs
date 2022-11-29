//----------------------------------------------------------------
// @Description: A UI ViusalElement to establish the hierarchy
// of the various screens that make up the application's user interface.
// It's the main control for the UserInterface uxml document.
// 
// @Author: Luis Betancourt
// 
// @Date: 01/08/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using UnityEngine.UIElements;
using UnityEngine;
using System.Xml.Linq;
using Unity.VisualScripting;
//----------------------------------------------------------------

namespace DnDPedia
{
    public class UserInterfaceControl : VisualElement
    {
        private VisualElement searchTabScreen;
        private VisualElement myListsTabScreen;
        private VisualElement DatabaseTabScreen;

        // Default UXMLFactory needed to create the custom VisualElement
        public new class UxmlFactory : UxmlFactory<UserInterfaceControl, UxmlTraits> { }

        // 1. It is used by the factory to initialize the newly created object.
        // 2. It is analyzed by the schema generation process to get information about the element.
        // This information is translated into XML schema directives.

		public new class UxmlTraits : VisualElement.UxmlTraits { }

        public UserInterfaceControl()
		{

		}

        private void EnableSearchTabScreen()
		{
            Debug.Log("Search Tab Screen enabled.");
		}

        private void EnablemyListsTabScreen()
        {
            Debug.Log("My Lists Tab Screen enabled.");
        }

        private void EnableDatabaseTabScreen()
        {
            Debug.Log("Database Tab Screen enabled.");
        }

    }
}
