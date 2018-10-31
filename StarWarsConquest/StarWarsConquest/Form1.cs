using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Controls;

namespace StarWarsConquest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Player One will start the game. Do you want to read the instructions?");
            PlayerOneCredits.Text = PlayerOneCreds.ToString();
            PlayerOneHP.Text = PlayerOneStationHP.ToString();
            PlayerOneTurn.Text = Turn.ToString();
            PlayerTwoCredits.Text = PlayerTwoCreds.ToString();
            PlayerTwoHP.Text = PlayerTwoStationHP.ToString();
            PlayerTwoTurn.Text = Turn.ToString();
            PhilListHere();
            
        }

        #region Variables
        public int phase = 1;
        public bool Clicked = false;
        public string SelectedButton = "";
        public int PlayerOneCreds = 8000; //initial credits player one
        public int PlayerTwoCreds = 8000; //initial credits player two
        public int PlayerOneStationHP = 15000; //initial station hp player one
        public int PlayerTwoStationHP = 15000; //initial station hp player two
        public int Turn = 1; //turn counter
        public int WhosTurn = 0; //Determines who's turn it is
        public Building_Interface Buildings = new Building_Interface(); //Gets selected building from phase 4
        public string BuiltBuilding = "";
        Random GenNumber = new Random(); //random number to draw cards
        int CardSelect = 0; //The card that has been selected by the random
        //An array of all cards in the game
        public string[,] Cards = new string[,] { {"TIE Fighter", "Fighter", "10", "2", "1", "Properties.Resources.TIE_FIGHTER" }, {"TIE Bomber", "Fighter", "25", "5", "3", "Properties.Resources.TIE_BOMBER"} };
        //An array of all buildings in the game
        public string[,] PossibleBuildings = new string[,] { { "Mining Facility Level One", "Income", "500", "1500", "0", "Properties.Resources.Mine1", "Income1" },
        { "Mining Facility Level Two", "Income", "1000", "3000", "0", "Properties.Resources.Mine2", "Income2"},
        { "Mining Facility Level Three", "Income", "2000", "5000", "0", "Properties.Resources.Mine3", "Income3" },
        { "XQ 1 Defence Station", "Hangar Station", "750", "2000", "200", "Properties.Resources.XQ1", "Hangar1"},
        { "XQ 2 Defence Station", "Hangar Station", "1500", "3000", "500", "Properties.Resources.XQ2", "Hangar2"},
        { "XQ 3 Defence Station", "Hangar Station", "2000", "5000", "1000", "Properties.Resources.XQ3", "Hangar3" },
        { "Golan I Defence Station", "Battle Station", "3000", "8000", "2000", "Properties.Resources.Golan1", "Defence1"},
        { "Golan II Defence Station", "Battle Station", "5000", "15000", "5000", "Properties.Resources.Golan2", "Defence2"},
        { "Golan III Defence Station", "Battle Station", "10000", "30000", "8000", "Properties.Resources.Golan3", "Defence3"},
        { "Light Shipyard", "Shipyard", "5000", "2000", "100", "Properties.Resources.LightShipyard", "Shipyard1"},
        { "Medium Shipyard", "Shipyard", "9000", "4000", "400", "Properties.Resources.MediumShipyard", "Shipyard2"},
        { "Heavy Shipyard", "Shipyard", "15000", "10000", "1000", "Properties.Resources.HeavyShipyard", "Shipyard3"},
        { "Laser Defence Satelite", "Defence Satelite", "100", "200", "100", "Properties.Resources.LaserSatalite", "Defence 4"},
        { "Missile Defence Satelite", "Defence Satelite", "200", "300", "500", "Properties.Resources.MissileSatalite", "Defence 5"},
        { "Ion Defence Satelite", "Defence Satelite", "1000", "500", "0", "Properties.Resources.IonSatalite", "Defence 6"} };
        //An array of all abilities in the game
        public string[] Abilities = new string[] {"Income1", "Income2", "Income3", "Hangar1", "Hangar2", "Hangar3", "Defence1", "Defence2", "Defence3", "Defence4", "Defence5", "Defence6", "Shipyard1", "Shipyard2", "Shipyard3" };
        //An array of all buttons in the game
        public string[] Buttons = new string[] { "PlayerOneRïnforcements", "PlayerTwoReïnforcements",
        "PlayerOneCardOne", "PlayerOneCardTwo", "PlayerOneCardThree", "PlayerOneCardFour", "PlayerOneCardFive", "PlayerOneCardSix", "PlayerOneCardSeven", "PlayerOneCardEight", "PlayerOneCardNine", "PlayerOneCardTen",
        "PlayerTwoCardOne", "PlayerTwoCardTwo", "PlayerTwoCardThree", "PlayerTwoCardFour", "PlayerTwoCardFive", "PlayerTwoCardSix", "PlayerTwoCardSeven", "PlayerTwoCardEight", "PlayerTwoCardNine", "PlayerTwoCardTen",
        "PlayerOneBuildingOne", "PlayerOneBuildingTwo", "PlayerOneBuildingThree", "PlayerOneBuildingFour", "PlayerOneBuildingFive", "PlayerOneBuildingEight",
        "PlayerTwoBuildingOne", "PlayerTwoBuildingTwo", "PlayerTwoBuildingThree", "PlayerTwoBuildingFour", "PlayerTwoBuildingFive", "PlayerTwoBuildingEight",
        "PlayerOneSpaceStation", "PlayerTwoSpaceStation",
        "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10", "A11", "A12", "A13", "A14", "A15", "A16",
        "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10", "B11", "B12", "B13", "B14", "B15", "B16"};
        public List<Card> CardsInPlay = new List<Card>(); //A list of all cards currently in play
        public List<Building> BuildingsInPlay = new List<Building>(); //A list of all buildings currently in play
        public List<System.Windows.Forms.Button> Buttons2 = new List<System.Windows.Forms.Button>
        (
        )
        ; //3spooky5me
        public int Identification = 0; //Adds an ID to a drawn card
        public int BuildingIdentification = 0; //Adds an ID to a built building
        public int SelectedCard = 0; //Keeps track which card you have currently selected
        public bool Failed = false; //In case you failed placing a card
        public int BuildingIndex = 0; //Index of the building you are building
        #endregion

        public void PhilListHere()
        {
            Buttons2.Add(PlayerOneReïnforcements);
            Buttons2.Add(PlayerTwoReinforcements);
            Buttons2.Add(PlayerOneCardOne);
            Buttons2.Add(PlayerOneCardTwo);
            Buttons2.Add(PlayerOneCardThree);
            Buttons2.Add(PlayerOneCardFour);
            Buttons2.Add(PlayerOneCardFive);
            Buttons2.Add(PlayerOneCardSix);
            Buttons2.Add(PlayerOneCardSeven);
            Buttons2.Add(PlayerOneCardEight);
            Buttons2.Add(PlayerOneCardNine);
            Buttons2.Add(PlayerOneCardTen);
            Buttons2.Add(PlayerTwoCardOne);
            Buttons2.Add(PlayerTwoCardTwo);
            Buttons2.Add(PlayerTwoCardThree);
            Buttons2.Add(PlayerTwoCardFour);
            Buttons2.Add(PlayerTwoCardFive);
            Buttons2.Add(PlayerTwoCardSix);
            Buttons2.Add(PlayerTwoCardSeven);
            Buttons2.Add(PlayerTwoCardEight);
            Buttons2.Add(PlayerTwoCardNine);
            Buttons2.Add(PlayerTwoCardTen);
            Buttons2.Add(PlayerOneBuildingOne);
            Buttons2.Add(PlayerOneBuildingTwo);
            Buttons2.Add(PlayerOneBuildingThree);
            Buttons2.Add(PlayerOneBuildingFour);
            Buttons2.Add(PlayerOneBuildingFive);
            Buttons2.Add(PlayerOneBuildingSix);
            Buttons2.Add(PlayerOneBuildingSeven);
            Buttons2.Add(PlayerOneBuildingEight);
            Buttons2.Add(PlayerTwoBuildingOne);
            Buttons2.Add(PlayerTwoBuildingTwo);
            Buttons2.Add(PlayerTwoBuildingThree);
            Buttons2.Add(PlayerTwoBuildingFour);
            Buttons2.Add(PlayerTwoBuildingFive);
            Buttons2.Add(PlayerTwoBuildingSix);
            Buttons2.Add(PlayerTwoBuildingSeven);
            Buttons2.Add(PlayerTwoBuildingEight);
            Buttons2.Add(A1);
            Buttons2.Add(A2);
            Buttons2.Add(A3);
            Buttons2.Add(A4);
            Buttons2.Add(A5);
            Buttons2.Add(A6);
            Buttons2.Add(A7);
            Buttons2.Add(A8);
            Buttons2.Add(A9);
            Buttons2.Add(A10);
            Buttons2.Add(A11);
            Buttons2.Add(A12);
            Buttons2.Add(A13);
            Buttons2.Add(A14);
            Buttons2.Add(A15);
            Buttons2.Add(A16);
            Buttons2.Add(B1);
            Buttons2.Add(B2);
            Buttons2.Add(B3);
            Buttons2.Add(B4);
            Buttons2.Add(B5);
            Buttons2.Add(B6);
            Buttons2.Add(B7);
            Buttons2.Add(B8);
            Buttons2.Add(B9);
            Buttons2.Add(B10);
            Buttons2.Add(B11);
            Buttons2.Add(B12);
            Buttons2.Add(B13);
            Buttons2.Add(B14);
            Buttons2.Add(B15);
            Buttons2.Add(B16);
            Buttons2.Add(PlayerOneSpaceStation);
            Buttons2.Add(PlayerTwoSpaceStation);

        }

        public void UpdateVitals()
        {
            PlayerOneCredits.Text = PlayerOneCreds.ToString();
            PlayerOneHP.Text = PlayerOneStationHP.ToString();
            PlayerOneTurn.Text = Turn.ToString();
            PlayerTwoCredits.Text = PlayerTwoCreds.ToString();
            PlayerTwoHP.Text = PlayerTwoStationHP.ToString();
            PlayerTwoTurn.Text = Turn.ToString();
        }

        public void Clicks (string SelectedButton)
        {
            Clicked = !Clicked;
            Clicked = ClickHandler(Clicked, phase, SelectedButton);
        }

        public void ButtonDoStuff(string Selection, string Category)
        {
            //MessageBox.Show(Selection);
            if (Category == "ChangeName")
            {
                for (int i = 0; i < Buttons2.Count; i++)
                {
                    if (Selection == Buttons2[i].Name)
                    {
                        //yes
                    }
                }
            }
            else if (Category == "AssignNew")
            {
                for (int i = 0; i < Buttons2.Count; i++)
                {
                    if (Selection == Buttons2[i].Name)
                    {
                        //yes
                        
                    }
                }
            }
            else if (Category == "Find")
            {
                if (WhosTurn == 0)
                {
                    for (int i = 0; i < Buttons2.Count; i++)
                    {
                        if (Selection == Buttons2[i + 2].Name)
                        {
                            //MessageBox.Show(phase.ToString());
                            if (phase == 2)
                            {
                                MessageBox.Show("You have selected : " + CardsInPlay[i].Name);
                                Buttons2[i + 2].Image = null;
                                i = Buttons2.Count;
                            }
                            else if (phase == 3)
                            {
                                if (Clicked)
                                {
                                    //MessageBox.Show("Geile Beer");
                                    if (Selection == Buttons2[i + 2].Name)
                                    {
                                        CardsInPlay[CardsInPlay.Count - 1].LinkedButton = Buttons2[i + 2].Name; //Assign the linked button to the card
                                        i = Buttons2.Count; //To break out of the loop when a photo (card) has been assigned
                                        //MessageBox.Show("Appelsapsaus");
                                        for (int j = 0; j < CardsInPlay.Count; j++) //Finding the card that you clicked
                                        {
                                            if (CardsInPlay[j].LinkedButton == Selection) //when the linked button of the current card in the list is equal to the selected button
                                            {
                                                SelectedCard = j; //set the SelectedCard to i for future reference
                                            }
                                        }
                                        MessageBox.Show("You selected " + CardsInPlay[SelectedCard].Name + " on " + CardsInPlay[SelectedCard].LinkedButton);
                                        //Clicked = !Clicked;
                                    }
                                }

                                

                                else if (!Clicked)
                                {
                                    if (Selection == Buttons2[i + 2].Name)
                                    {
                                        if (Selection == Buttons2[i + 2].Name)
                                        {
                                            CardsInPlay[CardsInPlay.Count - 1].LinkedButton = Buttons2[i + 2].Name; //Assign the linked button to the card
                                            i = Buttons2.Count; //To break out of the loop when a photo (card) has been assigned
                                                                //MessageBox.Show("Appelsapsaus");
                                            for (int j = 0; j < CardsInPlay.Count; j++) //Finding the card that you clicked
                                            {
                                                if (CardsInPlay[j].LinkedButton == Selection) //when the linked button of the current card in the list is equal to the selected button
                                                {
                                                    SelectedCard = j; //set the SelectedCard to i for future reference
                                                }
                                            }
                                        }
                                            //MessageBox.Show("Ik heb kk geil rn");
                                        if (CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoBuildingOne" || CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoBuildingTwo" || CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoBuildingThree" || CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoBuildingFour" || CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoBuildingFive" || CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoBuildingSix" || CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoBuildingSeven" || CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoBuildingEight")
                                        {
                                            MessageBox.Show("You attacked the enemy [BUILDING NAME] on [COORDENATES]"); //When you attacked an enemy building
                                        }
                                        else if (CardsInPlay[SelectedCard].LinkedButton == "PlayerTwoSpaceStation")
                                        {
                                            MessageBox.Show("You attacked the enemy space station!"); //When you attacked the enemy station
                                        }
                                        else
                                        {
                                            MessageBox.Show("You attacked " + CardsInPlay[SelectedCard].Name + " on " + CardsInPlay[SelectedCard].LinkedButton); //When you attacked an enemy card
                                        }
                                        i = Buttons2.Count;
                                    }
                                }


                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Buttons2.Count; i++)
                    {
                        if (Selection == Buttons2[i + 2].Name)
                        {
                            //MessageBox.Show(phase.ToString());
                            if (phase == 2)
                            {
                                MessageBox.Show("You have selected : " + CardsInPlay[i].Name);
                                Buttons2[i + 2].Image = null;
                                i = Buttons2.Count;
                            }
                            else if (phase == 3)
                            {
                                if (Clicked)
                                {
                                    //MessageBox.Show("Geile Beer");
                                    if (Selection == Buttons2[i + 2].Name)
                                    {
                                        CardsInPlay[CardsInPlay.Count - 1].LinkedButton = Buttons2[i + 2].Name; //Assign the linked button to the card
                                        i = Buttons2.Count; //To break out of the loop when a photo (card) has been assigned
                                        //MessageBox.Show("Appelsapsaus");
                                        for (int j = 0; j < CardsInPlay.Count; j++) //Finding the card that you clicked
                                        {
                                            if (CardsInPlay[j].LinkedButton == Selection) //when the linked button of the current card in the list is equal to the selected button
                                            {
                                                SelectedCard = j; //set the SelectedCard to i for future reference
                                            }
                                        }
                                        MessageBox.Show("You selected " + CardsInPlay[SelectedCard].Name + " on " + CardsInPlay[SelectedCard].LinkedButton);
                                        //Clicked = !Clicked;
                                    }
                                }



                                else if (!Clicked)
                                {
                                    if (Selection == Buttons2[i + 2].Name)
                                    {
                                        if (Selection == Buttons2[i + 2].Name)
                                        {
                                            CardsInPlay[CardsInPlay.Count - 1].LinkedButton = Buttons2[i + 2].Name; //Assign the linked button to the card
                                            i = Buttons2.Count; //To break out of the loop when a photo (card) has been assigned
                                                                //MessageBox.Show("Appelsapsaus");
                                            for (int j = 0; j < CardsInPlay.Count; j++) //Finding the card that you clicked
                                            {
                                                if (CardsInPlay[j].LinkedButton == Selection) //when the linked button of the current card in the list is equal to the selected button
                                                {
                                                    SelectedCard = j; //set the SelectedCard to i for future reference
                                                }
                                            }
                                        }
                                        //MessageBox.Show("Ik heb kk geil rn");
                                        if (CardsInPlay[SelectedCard].LinkedButton == "PlayerOneBuildingOne" || CardsInPlay[SelectedCard].LinkedButton == "PlayerOneBuildingTwo" || CardsInPlay[SelectedCard].LinkedButton == "PlayerOneBuildingThree" || CardsInPlay[SelectedCard].LinkedButton == "PlayerOneBuildingFour" || CardsInPlay[SelectedCard].LinkedButton == "PlayerOneBuildingFive" || CardsInPlay[SelectedCard].LinkedButton == "PlayerOneBuildingSix" || CardsInPlay[SelectedCard].LinkedButton == "PlayerOneBuildingSeven" || CardsInPlay[SelectedCard].LinkedButton == "PlayerOneBuildingEight")
                                        {
                                            MessageBox.Show("You attacked the enemy [BUILDING NAME] on [COORDENATES]"); //When you attacked an enemy building
                                        }
                                        else if (CardsInPlay[SelectedCard].LinkedButton == "PlayerOneSpaceStation")
                                        {
                                            MessageBox.Show("You attacked the enemy space station!"); //When you attacked the enemy station
                                        }
                                        else
                                        {
                                            MessageBox.Show("You attacked " + CardsInPlay[SelectedCard].Name + " on " + CardsInPlay[SelectedCard].LinkedButton); //When you attacked an enemy card
                                        }
                                        i = Buttons2.Count;
                                    }
                                }
                            }
                        }
                    }
                }
                


            }
            else if (Category == "ChangePhoto") //When you want to change the photo (card) on a button
            {
                if (WhosTurn == 0)
                {
                    for (int i = 0; i < Buttons2.Count; i++)
                    {


                        if (phase == 1)
                        {
                            //MessageBox.Show("Ja let's go");
                            if (Buttons2[i].Image == null) //When the selected button has no photo (card) assigned
                            {
                                //Checks weither the button being checked is eligble
                                if (Buttons2[i].Name == "PlayerOneCardOne" || Buttons2[i].Name == "PlayerOneCardTwo" || Buttons2[i].Name == "PlayerOneCardThree" || Buttons2[i].Name == "PlayerOneCardFour" || Buttons2[i].Name == "PlayerOneCardFive" || Buttons2[i].Name == "PlayerOneCardSix" || Buttons2[i].Name == "PlayerOneCardSeven" || Buttons2[i].Name == "PlayerOneCardEight" || Buttons2[i].Name == "PlayerOneCardNine" || Buttons2[i].Name == "PlayerOneCardTen")
                                {
                                    Buttons2[i].Image = Properties.Resources.TIE_FIGHTER; //Sets the proper image to the button
                                    CardsInPlay[CardsInPlay.Count - 1].LinkedButton = Buttons2[i].Name;
                                    for (int j = 0; j < CardsInPlay.Count; j++) //Finding the card that you clicked
                                    {
                                        if (CardsInPlay[j].LinkedButton == Buttons2[i].Name) //when the linked button of the current card in the list is equal to the selected button
                                        {
                                            SelectedCard = j; //set the SelectedCard to i for future reference
                                        }
                                    } //Assign the linked button to the card
                                    i = Buttons2.Count; //To break out of the loop when a photo (card) has been assigned
                                }
                                else //If no elligble buttons are found, that means that the player's hand is already full
                                {
                                    if (i > 1) //prevents the first two buttons from returning the full hand error
                                    {
                                        MessageBox.Show("Your hand is already full");
                                    }

                                }
                            }
                        }
                        else if (phase == 2)
                        {
                            //MessageBox.Show("Sappig");
                            if (Buttons2[i].Image == null)
                            {
                                //if (Buttons2[i].Name == "A1" || Buttons2[i].Name == "A2" || Buttons2[i].Name == "A3" || Buttons2[i].Name == "A4" || Buttons2[i].Name == "A5" || Buttons2[i].Name == "A6" || Buttons2[i].Name == "A7" || Buttons2[i].Name == "A8" || Buttons2[i].Name == "A9" || Buttons2[i].Name == "A10" || Buttons2[i].Name == "A11" || Buttons2[i].Name == "A12" || Buttons2[i].Name == "A13" || Buttons2[i].Name == "A14" || Buttons2[i].Name == "A15" || Buttons2[i].Name == "A16")
                                if (Selection == Buttons2[i].Name)
                                {
                                    Buttons2[i].Image = Properties.Resources.TIE_FIGHTER; //Sets the proper image to the button
                                    CardsInPlay[CardsInPlay.Count - 1].LinkedButton = Buttons2[i].Name; //Assign the linked button to the card
                                    i = Buttons2.Count; //To break out of the loop when a photo (card) has been assigned
                                    MessageBox.Show("You deployed " + CardsInPlay[SelectedCard].Name + " To " + CardsInPlay[SelectedCard].LinkedButton);
                                    if (Turn == 1)
                                    {
                                        phase++;
                                    }
                                }
                                /*else
                                {
                                    if (i > 38)
                                    {
                                        MessageBox.Show("Chinezen stinken");
                                    }
                                }*/
                            }

                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Buttons2.Count; i++)
                    {


                        if (phase == 1)
                        {
                            //MessageBox.Show("Ja let's go");
                            if (Buttons2[i].Image == null) //When the selected button has no photo (card) assigned
                            {
                                //Checks weither the button being checked is eligble
                                if (Buttons2[i].Name == "PlayerTwoCardOne" || Buttons2[i].Name == "PlayerTwoCardTwo" || Buttons2[i].Name == "PlayerTwoCardThree" || Buttons2[i].Name == "PlayerTwoCardFour" || Buttons2[i].Name == "PlayerTwoCardFive" || Buttons2[i].Name == "PlayerTwoCardSix" || Buttons2[i].Name == "PlayerTwoCardSeven" || Buttons2[i].Name == "PlayerTwoCardEight" || Buttons2[i].Name == "PlayerTwoCardNine" || Buttons2[i].Name == "PlayerTwoCardTen")
                                {
                                    Buttons2[i].Image = Properties.Resources.TIE_FIGHTER; //Sets the proper image to the button
                                    CardsInPlay[CardsInPlay.Count - 1].LinkedButton = Buttons2[i].Name;
                                    for (int j = 0; j < CardsInPlay.Count; j++) //Finding the card that you clicked
                                    {
                                        if (CardsInPlay[j].LinkedButton == Buttons2[i].Name) //when the linked button of the current card in the list is equal to the selected button
                                        {
                                            SelectedCard = j; //set the SelectedCard to i for future reference
                                        }
                                    } //Assign the linked button to the card
                                    i = Buttons2.Count; //To break out of the loop when a photo (card) has been assigned
                                }
                                else //If no elligble buttons are found, that means that the player's hand is already full
                                {
                                    if (i > 1) //prevents the first two buttons from returning the full hand error
                                    {
                                        MessageBox.Show("Your hand is already full");
                                    }

                                }
                            }
                        }
                        else if (phase == 2)
                        {
                            //MessageBox.Show("Sappig");
                            if (Buttons2[i].Image == null)
                            {
                                //if (Buttons2[i].Name == "A1" || Buttons2[i].Name == "A2" || Buttons2[i].Name == "A3" || Buttons2[i].Name == "A4" || Buttons2[i].Name == "A5" || Buttons2[i].Name == "A6" || Buttons2[i].Name == "A7" || Buttons2[i].Name == "A8" || Buttons2[i].Name == "A9" || Buttons2[i].Name == "A10" || Buttons2[i].Name == "A11" || Buttons2[i].Name == "A12" || Buttons2[i].Name == "A13" || Buttons2[i].Name == "A14" || Buttons2[i].Name == "A15" || Buttons2[i].Name == "A16")
                                if (Selection == Buttons2[i].Name)
                                {
                                    Buttons2[i].Image = Properties.Resources.TIE_FIGHTER; //Sets the proper image to the button
                                    CardsInPlay[CardsInPlay.Count - 1].LinkedButton = Buttons2[i].Name; //Assign the linked button to the card
                                    i = Buttons2.Count; //To break out of the loop when a photo (card) has been assigned
                                    MessageBox.Show("You deployed " + CardsInPlay[SelectedCard].Name + " To " + CardsInPlay[SelectedCard].LinkedButton);
                                    if (Turn == 1)
                                    {
                                        phase++;
                                    }
                                }
                                /*else
                                {
                                    if (i > 38)
                                    {
                                        MessageBox.Show("Chinezen stinken");
                                    }
                                }*/
                            }

                        }
                    }
                }

            }
        }


        public bool ClickHandler(bool FirstClick, int Gamephase, string Button)
        {
            if (WhosTurn == 0)
            {
                #region P1Phase1
                if (Gamephase == 1) //Executes when it is the first phase (Drawing cards)
                {
                    if (FirstClick)
                    {
                        if (Button == "PlayerOneReïnforcements")  //Did you press the right button?
                        {

                            MessageBox.Show("Reïnforcements have arrived sir! [CARD NAME] has joined your fleet!");
                            CardSelect = GenNumber.Next(0, 1); //To draw a random card from the stack
                            Card NewCard = new Card() //gets the right stats for the card that you drew
                            {
                                ID = Identification,
                                Name = Cards[CardSelect, 0],
                                Class = Cards[CardSelect, 1],
                                Cost = Convert.ToInt32(Cards[CardSelect, 2]),
                                Health = Convert.ToInt32(Cards[CardSelect, 3]),
                                Damage = Convert.ToInt32(Cards[CardSelect, 4]),
                                Photo = Cards[CardSelect, 5]
                            };
                            Identification++;
                            CardsInPlay.Add(NewCard);
                            
                            ButtonDoStuff(CardsInPlay[CardsInPlay.Count - 1].Name, "ChangePhoto");

                            MessageBox.Show("Name: " + CardsInPlay[CardsInPlay.Count-1].Name + "\nClass: " + CardsInPlay[CardsInPlay.Count - 1].Class + "\nCost: " +  CardsInPlay[CardsInPlay.Count - 1].Cost + "\nHealth: " + CardsInPlay[CardsInPlay.Count - 1].Health + "\nDamage: " + CardsInPlay[CardsInPlay.Count - 1].Damage + "\nPosition: " + CardsInPlay[CardsInPlay.Count - 1].LinkedButton);
                            phase++;//So the game advances to the next phase
                            FirstClick = !FirstClick;
                            Clicked = FirstClick; //Indicates you used the first click so the next click will be the second click
                        }
                        else //Did you press the wrong button?
                        {
                            MessageBox.Show("You picked the wrong card, fool");
                            FirstClick = !FirstClick;
                            Clicked = FirstClick;
                        }
                    }
                }
#endregion
                #region P1Phase2
                else if (Gamephase == 2) //Executes when it is the second phase (Placing cards)
                {
                    if (FirstClick) //Execute when you used first click
                    {
                        if (Button == "PlayerOneCardOne" || Button == "PlayerOneCardTwo" || Button == "PlayerOneCardThree" || Button == "PlayerOneCardFour" || Button == "PlayerOneCardFive" || Button == "PlayerOneCardSix" || Button == "PlayerOneCardSeven" || Button == "PlayerOneCardEight" || Button == "PlayerOneCardNine" || Button == "PlayerOneCardTen") //Did you select the right card?
                        {
                            ButtonDoStuff(Button, "Find");
                        }
                        else //Did you select the wrong card?
                        {
                            MessageBox.Show("You selected the wrong card, fool");
                            
                        }
                    }
                    else //Execute when you used second click
                    {
                        if (Button == "A1" || Button == "A2" || Button == "A3" || Button == "A4" || Button == "A5" || Button == "A6" || Button == "A7" || Button == "A8" || Button == "A9" || Button == "A10" || Button == "A11" || Button == "A12" || Button == "A13" || Button == "A14" || Button == "A15" || Button == "A16") //Did you select the right button?
                        {
                            ButtonDoStuff(Button, "ChangePhoto");
                            phase++;


                            PlayerOneCreds = PlayerOneCreds - CardsInPlay[SelectedCard].Cost; // Substracts the cost of the card from your credit pool
                            UpdateVitals(); //so the new credit count is displayed properly

                            
                        }
                        else //Did you select the wrong button
                        {
                            MessageBox.Show("You picked the wrong card, fool");
                        }
                        if (Failed)
                        {
                            if (PlayerOneCardOne.Image == null) //Assigns the card to your hand. Will shuffle through your hand to find an empty spot. If there are none the action is canceled or something idk
                            {
                                PlayerOneCardOne.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardTwo.Image == null)
                            {
                                PlayerOneCardTwo.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardThree.Image == null)
                            {
                                PlayerOneCardThree.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardFour.Image == null)
                            {
                                PlayerOneCardFour.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardFive.Image == null)
                            {
                                PlayerOneCardFive.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardSix.Image == null)
                            {
                                PlayerOneCardSix.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardSeven.Image == null)
                            {
                                PlayerOneCardSeven.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardEight.Image == null)
                            {
                                PlayerOneCardEight.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardNine.Image == null)
                            {
                                PlayerOneCardNine.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerOneCardTen.Image == null)
                            {
                                PlayerOneCardTen.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else
                            {
                                MessageBox.Show("Your hand is already full");
                            }
                            Failed = !Failed;
                        }
                    }

                }
#endregion
                #region P1Phase3
                else if (Gamephase == 3)
                {
                    if (FirstClick)
                    {
                        ButtonDoStuff(Button, "Find");                       
                    }
                    else
                    {
                        ButtonDoStuff(Button, "Find");
                        phase++;
                    }
                }
#endregion
                #region P1Phase4
                else if (Gamephase == 4)
                {
                    if (Clicked)
                    {
                        if (Button == "PlayerOneBuildingOne" || Button == "PlayerOneBuildingTwo" || Button == "PlayerOneBuildingThree" || Button == "PlayerOneBuildingFour" || Button == "PlayerOneBuildingFive" || Button == "PlayerOneBuildingSix" || Button == "PlayerOneBuildingSeven" || Button == "PlayerOneBuildingEight")
                        {
                            MessageBox.Show("You selected [COORDINATES]"); //which building slot did you select
                            BuiltBuilding = null;
                            Buildings.Show(); //loads the building selection form


                            while (!Building_Interface.Closed) //wait for the user to select a building
                            {
                                Application.DoEvents();
                                Thread.Sleep(1);
                            }
                            Building_Interface.Closed = false;
                            //Building_Interface.Closed = false;
                            BuiltBuilding = Building_Interface.Building; //sets the building you selected to a local variable for future reference
                            for (int i = 0; i <= PossibleBuildings.GetLength(0) - 1; i++)
                            {
                                if (BuiltBuilding == PossibleBuildings[i, 0])
                                {
                                    BuildingIndex = i; //determines which building has been selected so it can assign the things
                                }
                            }
                            Building NewBuilding = new Building() //sets the proper stats to the selected building
                            {
                                ID = BuildingIdentification,
                                LinkedButton = Building_Interface.Building,
                                Name = PossibleBuildings[BuildingIndex, 0],
                                Class = PossibleBuildings[BuildingIndex,1],
                                Cost = Convert.ToInt32(PossibleBuildings[BuildingIndex,2]),
                                Health = Convert.ToInt32(PossibleBuildings[BuildingIndex, 3]),
                                Damage = Convert.ToInt32(PossibleBuildings[BuildingIndex,4]),
                                Ability = PossibleBuildings[BuildingIndex, 6]
                            };
                            BuildingIdentification++; //so the next building gets another ID
                            BuildingsInPlay.Add(NewBuilding); //Adds the new building to the list of buildings in play
                            //Debugging messagebox
                            MessageBox.Show("Name: " + BuildingsInPlay[BuildingsInPlay.Count - 1].Name + "\nClass: " + BuildingsInPlay[BuildingsInPlay.Count - 1].Class + "\nCost: " + BuildingsInPlay[BuildingsInPlay.Count - 1].Cost + "\nHealth: " + BuildingsInPlay[BuildingsInPlay.Count-1].Health + "\nDamage: " + BuildingsInPlay[BuildingsInPlay.Count-1].Damage + "\nAbility: " + BuildingsInPlay[BuildingsInPlay.Count - 1].Ability);
                            phase++; //advance to next phase
                            
                        }

                        else
                        {
                            MessageBox.Show("You picked the wrong card, fool"); //when you pick the wrong card
                        }
                    }
                }
#endregion
                #region P1Phase5
                else if (Gamephase == 5)
                {
                    MessageBox.Show("Your turn has been ended."); //notification that your turn has ended
                    phase = 1; //resets the turn
                    Turn++; //advanced the turn
                    WhosTurn = 1;
                    UpdateVitals();
                    MessageBox.Show("Player Two is on the turn. Set it up!");

                }
#endregion
                return FirstClick;
            }
            else
            {
                #region P2Phase1

                if (Gamephase == 1) //Executes when it is the first phase (Drawing cards)
                {
                    if (FirstClick)
                    {
                        if (Button == "PlayerTwoReïnforcements")  //Did you press the right button?
                        {
                            MessageBox.Show("Reïnforcements have arrived sir! [CARD NAME] has joined your fleet!");
                            CardSelect = GenNumber.Next(0, 1); //To draw a random card from the stack
                            Card NewCard = new Card() //gets the right stats for the card that you drew
                            {
                                ID = Identification,
                                Name = Cards[CardSelect, 0],
                                Class = Cards[CardSelect, 1],
                                Cost = Convert.ToInt32(Cards[CardSelect, 2]),
                                Health = Convert.ToInt32(Cards[CardSelect, 3]),
                                Damage = Convert.ToInt32(Cards[CardSelect, 4]),
                                Photo = Cards[CardSelect, 5]
                            };
                            Identification++;
                            CardsInPlay.Add(NewCard);

                            ButtonDoStuff(CardsInPlay[CardsInPlay.Count - 1].Name, "ChangePhoto");
                            MessageBox.Show("Name: " + CardsInPlay[CardsInPlay.Count - 1].Name + "\nClass: " + CardsInPlay[CardsInPlay.Count - 1].Class + "\nCost: " + CardsInPlay[CardsInPlay.Count - 1].Cost + "\nHealth: " + CardsInPlay[CardsInPlay.Count - 1].Health + "\nDamage: " + CardsInPlay[CardsInPlay.Count - 1].Damage + "\nPosition: " + CardsInPlay[CardsInPlay.Count - 1].LinkedButton);
                            phase++;//So the game advances to the next phase
                            FirstClick = !FirstClick;
                            Clicked = FirstClick; //Indicates you used the first click so the next click will be the second click
                        }
                        else //Did you press the wrong button?
                        {
                            MessageBox.Show("You picked the wrong card, fool");
                            FirstClick = !FirstClick;
                            Clicked = FirstClick;
                        }
                    }
                }
                #endregion
                #region P2Phase2
                else if (Gamephase == 2) //Executes when it is the second phase (Placing cards)
                {
                    if (FirstClick) //Execute when you used first click
                    {
                        if (Button == "PlayerTwoCardOne" || Button == "PlayerTwoCardTwo" || Button == "PlayerTwoCardThree" || Button == "PlayerTwoCardFour" || Button == "PlayerTwoCardFive" || Button == "PlayerTwoCardSix" || Button == "PlayerTwoCardSeven" || Button == "PlayerTwoCardEight" || Button == "PlayerTwoCardNine" || Button == "PlayerTwoCardTen") //Did you select the right card?
                        {
                            ButtonDoStuff(Button, "Find");
                        }
                        else //Did you select the wrong card?
                        {
                            MessageBox.Show("You selected the wrong card, fool");
                        }
                    }
                    else //Execute when you used second click
                    {
                        if (Button == "B1" || Button == "B2" || Button == "B3" || Button == "B4" || Button == "B5" || Button == "B6" || Button == "B7" || Button == "B8" || Button == "B9" || Button == "B10" || Button == "B11" || Button == "B12" || Button == "B13" || Button == "B14" || Button == "B15" || Button == "B16") //Did you select the right button?
                        {
                            ButtonDoStuff(Button, "ChangePhoto");
                            phase++;
                            PlayerTwoCreds = PlayerTwoCreds - CardsInPlay[SelectedCard].Cost; // Substracts the cost of the card from your credit pool
                            UpdateVitals(); //so the new credit count is displayed properly

                        }
                        else //Did you select the wrong button
                        {
                            MessageBox.Show("You picked the wrong card, fool");
                        }

                        if (Failed)
                        {
                            if (PlayerTwoCardOne.Image == null) //Assigns the card to your hand. Will shuffle through your hand to find an empty spot. If there are none the action is canceled or something idk
                            {
                                PlayerTwoCardOne.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardTwo.Image == null)
                            {
                                PlayerTwoCardTwo.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardThree.Image == null)
                            {
                                PlayerTwoCardThree.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardFour.Image == null)
                            {
                                PlayerTwoCardFour.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardFive.Image == null)
                            {
                                PlayerTwoCardFive.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardSix.Image == null)
                            {
                                PlayerTwoCardSix.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardSeven.Image == null)
                            {
                                PlayerTwoCardSeven.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardEight.Image == null)
                            {
                                PlayerTwoCardEight.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardNine.Image == null)
                            {
                                PlayerTwoCardNine.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else if (PlayerTwoCardTen.Image == null)
                            {
                                PlayerTwoCardTen.Image = Properties.Resources.TIE_FIGHTER;
                            }
                            else
                            {
                                MessageBox.Show("Your hand is already full");
                            }
                            Failed = !Failed;
                        }
                    }

                }
                #endregion
                #region P2Phase3
                else if (Gamephase == 3)
                {
                    if (FirstClick)
                    {
                        ButtonDoStuff(Button, "Find");
                    }
                    else
                    {
                        ButtonDoStuff(Button, "Find");
                        phase++;
                    }
                }
                #endregion
                #region P2Phase4
                else if (Gamephase == 4)
                {
                    if (Clicked)
                    {
                        if (Button == "PlayerTwoBuildingOne" || Button == "PlayerTwoBuildingTwo" || Button == "PlayerTwoBuildingThree" || Button == "PlayerTwoBuildingFour" || Button == "PlayerTwoBuildingFive" || Button == "PlayerTwoBuildingSix" || Button == "PlayerTwoBuildingSeven" || Button == "PlayerTwoBuildingEight")
                        {
                            MessageBox.Show("You selected [COORDINATES]"); //which building slot did you select
                            Buildings.Show(); //loads the building selection form
                            BuiltBuilding = "";

                            while (!Building_Interface.Closed) //wait for the user to select a building
                            {
                                Application.DoEvents();
                                Thread.Sleep(1);
                            }
                            BuiltBuilding = Building_Interface.Building; //sets the building you selected to a local variable for future reference
                            MessageBox.Show(BuiltBuilding);
                            phase++; //advance to next phase

                        }

                        else
                        {
                            MessageBox.Show("You picked the wrong card, fool"); //when you pick the wrong card
                        }
                    }
                }
                #endregion
                #region P2Phase5
                else if (Gamephase == 5)
                {
                    MessageBox.Show("Your turn has been ended."); //notification that your turn has ended
                    phase = 1; //resets the turn
                    Turn++; //advanced the turn
                    WhosTurn = 0;
                    MessageBox.Show("Player One is on the turn. Set it up!");
                    UpdateVitals();

                }
                #endregion
                return FirstClick;
            }
            
        }

        #region Buttons

        private void PlayerOneReinForcements_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneReïnforcements.Name);
        }

        private void PlayerOneCardOne_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardOne.Name);
        }

        private void PlayerOneCardTwo_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardTwo.Name);
        }

        private void PlayerOneCardThree_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardThree.Name);
        }

        private void PlayerOneCardFour_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardFour.Name);
        }

        private void PlayerOneCardFive_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardFive.Name);
        }

        private void PlayerOneCardSix_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardSix.Name);
        }

        private void PlayerOneCardSeven_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardSeven.Name);
        }

        private void PlayerOneCardEight_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardEight.Name);
        }

        private void PlayerOneCardNine_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardNine.Name);
        }

        private void PlayerOneCardTen_Click(object sender, EventArgs e)
        {
            Clicks(PlayerOneCardTen.Name);
        }

        private void A1_Click(object sender, EventArgs e)
        {
            SelectedButton = "A1";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A2_Click(object sender, EventArgs e)
        {
            SelectedButton = "A2";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A3_Click(object sender, EventArgs e)
        {
            SelectedButton = "A3";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A4_Click(object sender, EventArgs e)
        {
            SelectedButton = "A4";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A5_Click(object sender, EventArgs e)
        {
            SelectedButton = "A5";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A6_Click(object sender, EventArgs e)
        {
            SelectedButton = "A6";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A7_Click(object sender, EventArgs e)
        {
            SelectedButton = "A7";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A8_Click(object sender, EventArgs e)
        {
            SelectedButton = "A8";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A9_Click(object sender, EventArgs e)
        {
            SelectedButton = "A9";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A10_Click(object sender, EventArgs e)
        {
            SelectedButton = "A10";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A11_Click(object sender, EventArgs e)
        {
            SelectedButton = "A11";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A12_Click(object sender, EventArgs e)
        {
            SelectedButton = "A12";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A13_Click(object sender, EventArgs e)
        {
            SelectedButton = "A13";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A14_Click(object sender, EventArgs e)
        {
            SelectedButton = "A14";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A15_Click(object sender, EventArgs e)
        {
            SelectedButton = "A15";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void A16_Click(object sender, EventArgs e)
        {
            SelectedButton = "A16";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B1_Click(object sender, EventArgs e)
        {
            SelectedButton = "B1";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B2_Click(object sender, EventArgs e)
        {
            SelectedButton = "B2";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B3_Click(object sender, EventArgs e)
        {
            SelectedButton = "B3";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B4_Click(object sender, EventArgs e)
        {
            SelectedButton = "B4";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B5_Click(object sender, EventArgs e)
        {
            SelectedButton = "B5";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B6_Click(object sender, EventArgs e)
        {
            SelectedButton = "B6";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B7_Click(object sender, EventArgs e)
        {
            SelectedButton = "B7";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B8_Click(object sender, EventArgs e)
        {
            SelectedButton = "B8";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B9_Click(object sender, EventArgs e)
        {
            SelectedButton = "B9";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B10_Click(object sender, EventArgs e)
        {
            SelectedButton = "B10";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B11_Click(object sender, EventArgs e)
        {
            SelectedButton = "B11";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B12_Click(object sender, EventArgs e)
        {
            SelectedButton = "B12";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B13_Click(object sender, EventArgs e)
        {
            SelectedButton = "B13";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B14_Click(object sender, EventArgs e)
        {
            SelectedButton = "B14";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B15_Click(object sender, EventArgs e)
        {
            SelectedButton = "B15";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void B16_Click(object sender, EventArgs e)
        {
            SelectedButton = "B16";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneBuildingOne_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneBuildingOne";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneBuildingTwo_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneBuildingTwo";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneBuildingThree_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneBuildingThree";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneBuildingFour_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneBuildingFour";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneBuildingFive_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneBuildingFive";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneBuildingSix_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneBuildingSix";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneBuildingSeven_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneBuildingSeven";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneBuildingEight_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneBuildingEight";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerOneSpaceStation_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerOneSpaceStation";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoBuildingOne_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoBuildingOne";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoBuildingTwo_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoBuildingTwo";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoBuildingThree_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoBuildingThree";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoBuildingFour_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoBuildingFour";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoSpaceStation_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoSpaceStation";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoBuildingFive_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoBuildingFive";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoBuildingSix_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoBuildingSix";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoBuildingSeven_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoBuildingSeven";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoBuildingEight_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoBuildingEight";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoReinforcements_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoReïnforcements";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardOne_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardOne";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardTwo_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardTwo";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardThree_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardThree";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardFour_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardFour";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardFive_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardFive";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardSix_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardSix";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardSeven_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardSeven";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardEight_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardEight";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardNine_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardNine";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        private void PlayerTwoCardTen_Click(object sender, EventArgs e)
        {
            SelectedButton = "PlayerTwoCardTen";
            if (!Clicked)
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);

            }
            else
            {
                Clicked = !Clicked;
                Clicked = ClickHandler(Clicked, phase, SelectedButton);
            }
        }

        #endregion
    }
}
