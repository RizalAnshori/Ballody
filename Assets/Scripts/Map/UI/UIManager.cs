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
        public UI_ChangeLanguage stateChangeLanguage;
        public UI_Message stateMessage;
        public UI_Energy stateEnergy;
        public UI_Diamond stateDiamond;
        public UI_Coin stateCoin;
        public UI_ChoosingLevel stateChoosingLevel;
        public UI_Idle stateIdle;

        [Space]
        public Button shopButton;
        public Button hallOfFameButton;
        public Button collectionButton;
        public Button settingButton;
        public Button mapButton;
        public Button messageButton;
        public Button energyButton;
        public Button diamondButton;
        public Button coinButton;

        void Start()
        {
            InitializeStates();
            InitializeButton();
            GoToState(stateChoosingLevel);
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
            RegisterState(stateChangeLanguage);
            RegisterState(stateMessage);
            RegisterState(stateEnergy);
            RegisterState(stateDiamond);
            RegisterState(stateCoin);
            RegisterState(stateChoosingLevel);
            RegisterState(stateIdle);

            stateShop.parent = this;
            stateCollection.parent = this;
            stateHallOfFame.parent = this;
            stateSetting.parent = this;
            stateMap.parent = this;
            stateChangeLanguage.parent = this;
            stateMessage.parent = this;
            stateCoin.parent = this;
            stateDiamond.parent = this;
            stateEnergy.parent = this;
            stateChoosingLevel.parent = this;
            stateIdle.parent = this;
        }

        void InitializeButton()
        {
            stateShop.InitButton(shopButton);
            stateHallOfFame.InitButton(hallOfFameButton);
            stateCollection.InitButton(collectionButton);
            stateSetting.InitButton(settingButton);
            stateMap.InitButton(mapButton);
            stateMessage.InitButton(messageButton);
            stateEnergy.InitButton(energyButton);
            stateDiamond.InitButton(diamondButton);
            stateCoin.InitButton(coinButton);
            stateChoosingLevel.InitButton(null);
            stateChangeLanguage.InitButton(null);
        }
    }
}

