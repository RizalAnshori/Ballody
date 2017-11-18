using System;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UIManager : BFSMSystem
    {
        public UI_Shop stateShop;
        public UI_HallOfFame stateHallOfFame;
        public UI_Collection stateCollection;
        public UI_Setting stateSetting;
        public UI_Map stateMap;
        public UI_Idle stateIdle;

        [Space]
        public Button shopButton;
        public Button hallOfFameButton;
        public Button collectionButton;
        public Button settingButton;
        public Button mapButton;

        void Start()
        {
            InitializeStates();
            InitializeButton();
        }
        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GoToState(stateIdle);
            }
        }

        void InitializeStates()
        {
            RegisterState(stateShop);
            RegisterState(stateHallOfFame);
            RegisterState(stateCollection);
            RegisterState(stateSetting);
            RegisterState(stateMap);
            RegisterState(stateIdle);

            stateShop.parent = this;
            stateCollection.parent = this;
            stateHallOfFame.parent = this;
            stateSetting.parent = this;
            stateMap.parent = this;
            stateIdle.parent = this;
        }

        void InitializeButton()
        {
            stateShop.InitButton(shopButton);
            stateHallOfFame.InitButton(hallOfFameButton);
            stateCollection.InitButton(collectionButton);
            stateSetting.InitButton(settingButton);
            stateMap.InitButton(mapButton);
        }
    }
}

