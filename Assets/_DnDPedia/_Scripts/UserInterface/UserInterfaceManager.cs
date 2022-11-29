//----------------------------------------------------------------
// @Description: A manager to handle all the User Interface elements.
// 
// @Author: Luis Betancourt
// 
// @Date: 29/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using UnityEngine;
using UnityEngine.UIElements;
//----------------------------------------------------------------

namespace DnDPedia.UserInterface
{
    public class UserInterfaceManager : MonoBehaviour
    {
        // Action to perform when button is pressed.
        Action Hide = () =>
        {
            print("Iteraction!");
        };

        private VisualElement userInterfaceDocumentRoot;    // The root element of the UIDocument

        private VisualElement tabBarRoot;           // The whole tab bar interface

        private VisualElement searchRoot;           // The whole content of the Search tab interface
        private VisualElement myListsRoot;          // The whole content of the My Lists tab interface
        private VisualElement databasesRoot;        // The whole content of the database tab interface

        private Button searchTab;                   // The search tab button
        private Button myListsTab;                  // The my lists tab button
        private Button databaseTab;                 // The database tab button

        private TextField searchBar;                // The search bar for spells
        private ListView resultsList;               // The results list of spells
        private Button searchButton;                // The button to start a search
        private Button resetButton;                 // The button to reset the filters
        private Slider levelSlider;                 // The slider to select the level of the spell
        private DropdownField classesDropdown;      // The dropdown field to select the class spell list

		private void OnEnable()
		{
            // Get the root element of the whole UI
            userInterfaceDocumentRoot = GetComponentInChildren<UIDocument>().rootVisualElement;

            // Get the root element of the tab bar
            tabBarRoot = userInterfaceDocumentRoot.Q<VisualElement>("TabBar");

            // Get the root elements of the tabs
            searchRoot = userInterfaceDocumentRoot.Q<VisualElement>("SearchTab");
            myListsRoot = userInterfaceDocumentRoot.Q<VisualElement>("MyListsTab");
            databasesRoot = userInterfaceDocumentRoot.Q<VisualElement>("databaseTab");

            // Get the elements of the tab bar
            searchTab = tabBarRoot.Q<Button>("search-tab");
            searchTab.RegisterCallback<ClickEvent>((evt) => HideAll());
		}

		void Start()
        {
         

            /*myListsButton = searchContent.Q<Button>("myListsButton");
           /* searchButton.RegisterCallback<ClickEvent>((evt) => SwitchTab());*/
        }

        void Update()
        {
        
        }

        private void ShowTabContent()
		{
            HideAll();

		}

        private void HideAll()
		{
            tabBarRoot.style.display = DisplayStyle.None;
            searchRoot.style.display = DisplayStyle.None;
            myListsRoot.style.display = DisplayStyle.None;
		}
    }
}
