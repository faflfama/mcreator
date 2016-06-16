/*
    Mcreator
    Copyright (C) 2016  Fabian D�rr <faflfama@outlook.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Windows.Forms;
using mcreator.Classes;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mcreator
{
    public partial class FrmCreateCharacter : Form
    {
        public FrmCreateCharacter()
        {
            InitializeComponent();

            // Get the user home path and set it as default
            string user_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            txtExportPath.Text = "" + user_path + "";
            
        }

        Character c = new Character();

        private void FrmCreateCharacter_Load(object sender, EventArgs e)
        {

            // Customizing the form for the different races
            if (this.Text == "MCreator - Halbling")
            {
                // Hide not needed fields
                // Handed
                mtxtHanded.Visible      = false;
                btnHanded.Visible       = false;
                lblDice20C.Visible      = false;
                // Bodysize
                mtxtBodyWeightD.Visible = false;
                txtBodySizeB.Visible    = false;
                lblBodySizeB.Visible    = false;
                lblDice6F.Visible       = false;
                //Bodyweight
                txtBodyWeightB.Visible  = false;
                lblBodyWeightB.Visible  = false;
                

                // Change Text of labels
                lblDice20A.Text     = "1W6";
                lblDice20B.Text     = "1W6";
                lblBodySizeA.Text   = "cm";
                lblBodyWeightA.Text = "kg";

                // Change texts of textfields
                // Handed
                txtHanded.Text = "Beidh�ndig";
                //BodyWeight
                mtxtBodyWeightD.Text = "0";
            }
            if (this.Text == "MCreator - Elf")
            {
                // Hide not needed fields
                // Bodysize               
                txtBodySizeB.Visible = false;
                lblBodySizeB.Visible = false;
                //Bodyweight
                txtBodyWeightB.Visible = false;
                lblBodyWeightB.Visible = false;


                // Change Text of labels
                lblDice20A.Text = "1W6";
                lblDice20B.Text = "1W6";
                lblBodySizeA.Text = "cm";
                lblBodyWeightA.Text = "kg";
            }
            if (this.Text == "MCreator - Zwerg")
            {
                // Hide not needed fields
                // Bodysize               
                txtBodySizeB.Visible    = false;
                lblBodySizeB.Visible    = false;
                lblDice20B.Visible      = false;
                mtxtBodySizeB.Visible   = false;
                //Bodyweight
                txtBodyWeightB.Visible = false;
                lblBodyWeightB.Visible = false;


                // Change Text of labels
                lblDice20A.Text = "1W6";
                lblDice20B.Text = "1W6";
                lblBodySizeA.Text = "cm";
                lblBodyWeightA.Text = "kg";

                // Change texts of textfields
                //BodySize
                mtxtBodySizeB.Text = "0";
            }
            if (this.Text == "MCreator - Gnom")
            {
                // Hide not needed fields
                // Bodysize                
                txtBodySizeB.Visible    = false;
                lblBodySizeB.Visible    = false;
                lblDice20B.Visible      = false;
                mtxtBodySizeB.Visible   = false;
                //Bodyweight
                mtxtBodyWeightD.Visible = false;
                txtBodyWeightB.Visible  = false;
                lblBodyWeightB.Visible  = false;
                lblDice6F.Visible       = false;               
                // Change Text of labels
                lblDice20A.Text = "1W6";
                lblDice20B.Text = "1W6";
                lblBodySizeA.Text = "cm";
                lblBodyWeightA.Text = "kg";

                // Change texts of textfields
                //BodySize
                mtxtBodySizeB.Text = "0";
                //BodyWeight
                mtxtBodyWeightD.Text = "0";
            }
            if (this.Text == "MCreator - Mensch")
            {
                // UnHide not needed fields
                // Bodysize 
                txtBodySizeB.Visible    = true;
                lblBodySizeB.Visible    = true;
                txtBodyWeightB.Visible  = true;
                lblBodyWeightB.Visible  = true;

                // Change Text of labels
                lblDice20A.Text     = "1W20";
                lblDice20B.Text     = "1W20";
                lblBodySizeA.Text   = "cm (Mann)";
                lblBodyWeightA.Text = "kg (Mann)";
            }
        }

        

        private void btnGetRandomCharacter_Click(object sender, EventArgs e)
        {
            // Reset the check value for the following cycle
            bool statPointCheck = false;

            while (statPointCheck == false)
            {
                Random Rnd = new Random();

                int strength = Rnd.Next(1, 101);
                int dexterity = Rnd.Next(1, 101);
                int agility = Rnd.Next(1, 101);
                int constitution = Rnd.Next(1, 101);
                int magicTalent = Rnd.Next(1, 101);
                int intelligence = Rnd.Next(1, 101);

                int gesamt = strength + dexterity + agility + constitution + magicTalent + intelligence;

                if (gesamt >= 350)
                {
                    Character c = new Character();
                    // Setting the check value to true, so that the cycle gets terminated
                    statPointCheck = true;

                    // Seetting the check field for the timer 
                    rbStats.Checked = true;

                    // Randomizing the dice values
                    mtxtStrength.Text       = Convert.ToString(strength);
                    mtxtDexterity.Text      = Convert.ToString(dexterity);
                    mtxtAgility.Text        = Convert.ToString(agility);
                    mtxtConstitution.Text   = Convert.ToString(constitution);
                    mtxtMagicalTalent.Text  = Convert.ToString(magicTalent);
                    mtxtIntelligence.Text   = Convert.ToString(intelligence);

                    if (this.Text == "MCreator - Mensch")
                    {
                        mtxtBodySizeA.Text = Convert.ToString(Rnd.Next(1, 21));
                        mtxtBodySizeB.Text = Convert.ToString(Rnd.Next(1, 21));
                    }
                    else
                    {
                        if (this.Text == "MCreator - Zwerg" || this.Text == "MCreator - Gnom")
                        {
                            mtxtBodySizeA.Text = Convert.ToString(Rnd.Next(1, 7));
                            mtxtBodySizeB.Text = Convert.ToString(0);
                        }
                        if (this.Text == "MCreator - Elf" || this.Text == "MCreator - Halbling")
                        {
                            mtxtBodySizeA.Text = Convert.ToString(Rnd.Next(1, 7));
                            mtxtBodySizeB.Text = Convert.ToString(Rnd.Next(1, 7));
                        }           
                    }

                    if (this.Text == "MCreator - Mensch")
                    {
                        mtxtBodyWeightA.Text = Convert.ToString(Rnd.Next(1, 7));
                        mtxtBodyWeightB.Text = Convert.ToString(Rnd.Next(1, 7));
                        mtxtBodyWeightC.Text = Convert.ToString(Rnd.Next(1, 7));
                        mtxtBodyWeightD.Text = Convert.ToString(Rnd.Next(1, 7));
                    }
                    else
                    {
                        if (this.Text == "MCreator - Zwerg" || this.Text == "MCreator - Elf")
                        {
                            mtxtBodyWeightA.Text = Convert.ToString(Rnd.Next(1, 7));
                            mtxtBodyWeightB.Text = Convert.ToString(Rnd.Next(1, 7));
                            mtxtBodyWeightC.Text = Convert.ToString(Rnd.Next(1, 7));
                            mtxtBodyWeightD.Text = Convert.ToString(Rnd.Next(1, 7));
                        }
                        if (this.Text == "MCreator - Gnom" || this.Text == "MCreator - Halbling")
                        {
                            mtxtBodyWeightA.Text = Convert.ToString(Rnd.Next(1, 7));
                            mtxtBodyWeightB.Text = Convert.ToString(Rnd.Next(1, 7));
                            mtxtBodyWeightC.Text = Convert.ToString(Rnd.Next(1, 7));
                            mtxtBodyWeightD.Text = Convert.ToString(Rnd.Next(0));
                        }
                    }
                                       
                    

                    mtxtAppearance.Text     = Convert.ToString(Rnd.Next(1, 101));
                    mtxtCharisma.Text       = Convert.ToString(Rnd.Next(1, 101));
                    mtxtWillpower.Text      = Convert.ToString(Rnd.Next(1, 101));
                    mtxtSelfControl.Text    = Convert.ToString(Rnd.Next(1, 100));
                    mtxtHanded.Text         = Convert.ToString(Rnd.Next(1, 21));

                    mtxtAdventurePointsA.Text   = Convert.ToString(Rnd.Next(1, 7));
                    mtxtAdventurePointsB.Text   = Convert.ToString(Rnd.Next(1, 7));
                    mtxtAdventurePointsC.Text   = Convert.ToString(Rnd.Next(1, 7));
                    mtxtLifePoints.Text         = Convert.ToString(Rnd.Next(1, 7));

                    mtxtInbornBuff.Text = Convert.ToString(Rnd.Next(1, 101));

                    

                    int DamageBuff  = 0;
                    int DefenseBuff = 0;

                    DamageBuff  = (strength / 20) + (dexterity / 30) - 3;
                    DefenseBuff = (strength / 20) + (constitution / 10) - 7;

                    if (DamageBuff >= 0)
                    {
                        txtDamageBuff.Text = Convert.ToString(DamageBuff);
                    }
                    else
                    {
                        txtDamageBuff.Text = "0";
                    }

                    if (DefenseBuff >= 0)
                    {
                        txtStaminaBuff.Text = Convert.ToString(DefenseBuff);
                    }
                    else
                    {
                        txtStaminaBuff.Text = "0";
                    }

                    txtAttackBuff.Text  = Convert.ToString(c.AttackBuff(dexterity));
                    txtDefenseBuff.Text = Convert.ToString(c.DefenseBuff(agility));
                    txtMagicBuff.Text   = Convert.ToString(c.MagicBuff(magicTalent));

                    txtRumble.Text      = Convert.ToString(((strength + agility) / 20) + Convert.ToInt32(txtAttackBuff.Text));
                    txtDefense.Text     = Convert.ToString(11 + Convert.ToInt32(txtDefenseBuff.Text));
                    txtDefense0.Text    = Convert.ToString(10 + Convert.ToInt32(txtDefenseBuff.Text));
                    txtDoMagic.Text     = Convert.ToString(10 + Convert.ToInt32(txtMagicBuff.Text));
                    txtDoMagic0.Text    = Convert.ToString(2 + Convert.ToInt32(txtMagicBuff.Text));

                    

                    if (this.Text == "MCreator - Mensch")
                    {
                        txtBodySizeA.Text = Convert.ToString(c.BodySize(mtxtBodySizeA.Text, mtxtBodySizeB.Text, mtxtStrength.Text, this.Text) + 150);
                        txtBodySizeB.Text = Convert.ToString(c.BodySize(mtxtBodySizeA.Text, mtxtBodySizeB.Text, mtxtStrength.Text, this.Text) + 140);
                    }
                    else
                    {
                        txtBodySizeA.Text = Convert.ToString(c.BodySize(mtxtBodySizeA.Text, mtxtBodySizeB.Text, mtxtStrength.Text, this.Text));
                    }

                    if (this.Text == "MCreator - Mensch")
                    {
                        txtBodyWeightA.Text = Convert.ToString(c.BodyWeight(mtxtBodyWeightA.Text,mtxtBodyWeightB.Text,mtxtBodyWeightC.Text,mtxtBodyWeightD.Text,mtxtStrength.Text,txtBodySizeA.Text,this.Text));
                        txtBodyWeightB.Text = Convert.ToString(c.BodyWeight(mtxtBodyWeightA.Text, mtxtBodyWeightB.Text, mtxtBodyWeightC.Text, mtxtBodyWeightD.Text, mtxtStrength.Text, txtBodySizeA.Text, this.Text) -4);
                    }
                    else
                    {
                        txtBodyWeightA.Text = Convert.ToString(c.BodyWeight(mtxtBodyWeightA.Text, mtxtBodyWeightB.Text, mtxtBodyWeightC.Text, mtxtBodyWeightD.Text, mtxtStrength.Text, txtBodySizeA.Text, this.Text));
                    }
                    

                    

                    c.Charisma();
                    txtWillpower.Text       = Convert.ToString(c.Willpower(mtxtWillpower.Text, mtxtConstitution.Text, mtxtIntelligence.Text));
                    txtSelfControlA.Text    = Convert.ToString(c.SelfControlA(mtxtSelfControl.Text, mtxtIntelligence.Text, txtWillpower.Text));
                    txtSelfControlB.Text    = Convert.ToString(c.SelfControlB(mtxtSelfControl.Text, mtxtIntelligence.Text, txtWillpower.Text));
                    txtSelfControlC.Text    = Convert.ToString(c.SelfControlC(mtxtSelfControl.Text, mtxtIntelligence.Text, txtWillpower.Text));

                    if (this.Text == "MCreator - Halfling")
                    {
                        txtHanded.Text = "Beidh�ndig";
                    }
                    else
                    {
                        txtHanded.Text = c.Handed(mtxtHanded.Text);
                    }

                    

                    txtAdventurePointsA.Text    = Convert.ToString(c.adventurePointsA(mtxtAdventurePointsA.Text, txtStaminaBuff.Text, this.Text));
                    txtAdventurePointsB.Text    = Convert.ToString(c.adventurePointsB(mtxtAdventurePointsB.Text, txtStaminaBuff.Text, this.Text));
                    txtAdventurePointsC.Text    = Convert.ToString(c.adventurePointsC(mtxtAdventurePointsC.Text, txtStaminaBuff.Text, this.Text));
                    txtLifePoints.Text          = Convert.ToString(c.lifePoints(mtxtConstitution.Text, mtxtLifePoints.Text, this.Text));


                    
                    txtInbornBuff.Text = c.Inborn(Convert.ToInt32(mtxtInbornBuff.Text), Convert.ToInt32(txtWillpower.Text));

                    
                    int mtBuffGhost_Body_MagicValue = 0;
                    int intBuffGhostMagicValue      = 0;
                    int CoBuffBodyMagicValue        = 0;

                    // Buff MagicTalent Ghost&Body
                    mtBuffGhost_Body_MagicValue = c.MagicTalentGhostBody(magicTalent);

                    // Buff Intelligence Ghost
                    intBuffGhostMagicValue = c.IntelligenceGhost(intelligence);

                    // Buff Constitution Body
                    CoBuffBodyMagicValue = c.ConstitutionBody(constitution);

                    // Values GhostMagic
                    txtGhostMagicFighter.Text   = Convert.ToString(14 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));
                    txtGhostMagicMagician.Text  = Convert.ToString(17 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));
                    txtGhostMagicNormal.Text    = Convert.ToString(14 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));

                    // Values BodyMagic
                    txtBodyMagicFighter.Text    = Convert.ToString(16 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));
                    txtBodyMagicMagician.Text   = Convert.ToString(17 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));
                    txtBodyMagicNormal.Text     = Convert.ToString(14 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));

                    // Values AreaMagic
                    txtAreaMagicFighter.Text    = Convert.ToString(10 + c.AgilityArea(agility));
                    txtAreaMagicMagician.Text   = Convert.ToString(13 + c.AgilityArea(agility));
                    txtAreaMagicNormal.Text     = Convert.ToString(10 + c.AgilityArea(agility));
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                //taken from https://dotnet-snippets.de/snippet/alle-textboxen-in-einer-form-loeschen/156
                if (c.GetType() == typeof(TextBox)) c.Text = "";
                if (c.GetType() == typeof(MaskedTextBox)) c.Text = "";



                string user_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                txtExportPath.Text = "" + user_path + "";
            }

        }

        private void btnBodySize_Click(object sender, EventArgs e)
        {
            
            if (this.Text == "MCreator - Mensch")
            {

                txtBodySizeA.Text = Convert.ToString(c.BodySize(mtxtBodySizeA.Text, mtxtBodySizeB.Text, mtxtStrength.Text, this.Text) + 150);
                txtBodySizeB.Text = Convert.ToString(c.BodySize(mtxtBodySizeA.Text, mtxtBodySizeB.Text, mtxtStrength.Text, this.Text) + 140);
            }
            else
            {
                txtBodySizeA.Text = Convert.ToString(c.BodySize(mtxtBodySizeA.Text, mtxtBodySizeB.Text, mtxtStrength.Text, this.Text));
            }
        }

        private void btnBodyWeight_Click(object sender, EventArgs e)
        {
            
            if (this.Text == "MCreator - Mensch")
            {
                txtBodyWeightA.Text = Convert.ToString(c.BodyWeight(mtxtBodyWeightA.Text, mtxtBodyWeightB.Text, mtxtBodyWeightC.Text, mtxtBodyWeightD.Text, mtxtStrength.Text, txtBodySizeA.Text, this.Text));
                txtBodyWeightB.Text = Convert.ToString(c.BodyWeight(mtxtBodyWeightA.Text, mtxtBodyWeightB.Text, mtxtBodyWeightC.Text, mtxtBodyWeightD.Text, mtxtStrength.Text, txtBodySizeA.Text, this.Text) - 4);
            }
            else
            {
                txtBodyWeightA.Text = Convert.ToString(c.BodyWeight(mtxtBodyWeightA.Text, mtxtBodyWeightB.Text, mtxtBodyWeightC.Text, mtxtBodyWeightD.Text, mtxtStrength.Text, txtBodySizeA.Text, this.Text));
            }
        }

        private void btnCharisma_Click(object sender, EventArgs e)
        {
            
            c.Charisma();
            //txtCharisma.Text = Convert.ToString(c.Charisma(mtxtCharisma.Text, mtxtIntelligence.Text, mtxtAppearance.Text));
        }

        private void btnWillpower_Click(object sender, EventArgs e)
        {
            
            txtWillpower.Text = Convert.ToString(c.Willpower(mtxtWillpower.Text, mtxtConstitution.Text, mtxtIntelligence.Text));
        }

        private void btnSelfControl_Click(object sender, EventArgs e)
        {
            
            txtSelfControlA.Text = Convert.ToString(c.SelfControlA(mtxtSelfControl.Text, mtxtIntelligence.Text, txtWillpower.Text));
            txtSelfControlB.Text = Convert.ToString(c.SelfControlB(mtxtSelfControl.Text, mtxtIntelligence.Text, txtWillpower.Text));
            txtSelfControlC.Text = Convert.ToString(c.SelfControlC(mtxtSelfControl.Text, mtxtIntelligence.Text, txtWillpower.Text));
        }

        private void btnInbornBuff_Click(object sender, EventArgs e)
        {
            
            txtInbornBuff.Text = c.Inborn(Convert.ToInt32(mtxtInbornBuff.Text), Convert.ToInt32(txtWillpower.Text));
        }

        private void btnHanded_Click(object sender, EventArgs e)
        {
            
            txtHanded.Text = c.Handed(mtxtHanded.Text);
        }

        private void btnAdventurePointsA_Click(object sender, EventArgs e)
        {
            
            txtAdventurePointsA.Text = Convert.ToString(c.adventurePointsA(mtxtAdventurePointsA.Text, txtStaminaBuff.Text, this.Text));
        }

        private void btnAdventurePointsB_Click(object sender, EventArgs e)
        {
            
            txtAdventurePointsB.Text = Convert.ToString(c.adventurePointsB(mtxtAdventurePointsB.Text, txtStaminaBuff.Text, this.Text));
        }

        private void btnAdventurePointsC_Click(object sender, EventArgs e)
        {
            
            txtAdventurePointsC.Text = Convert.ToString(c.adventurePointsC(mtxtAdventurePointsC.Text, txtStaminaBuff.Text, this.Text));
        }

        private void btnLifePoints_Click(object sender, EventArgs e)
        {
            
            txtLifePoints.Text = Convert.ToString(c.lifePoints(mtxtConstitution.Text, mtxtLifePoints.Text, this.Text));
        }

        private void Enable_Timer_Tick(object sender, EventArgs e)
        {
            #region Stats    
            if (mtxtStrength.Text != "" && Convert.ToInt32(mtxtStrength.Text) <= 100 && mtxtDexterity.Text != "" && Convert.ToInt32(mtxtDexterity.Text) <= 100 && mtxtAgility.Text != "" && Convert.ToInt32(mtxtAgility.Text) <= 100 && mtxtConstitution.Text != "" && Convert.ToInt32(mtxtConstitution.Text) <= 100 && mtxtIntelligence.Text != "" && Convert.ToInt32(mtxtIntelligence.Text) <= 100 && mtxtMagicalTalent.Text != "" && Convert.ToInt32(mtxtMagicalTalent.Text) <= 100)
            {
                int TotalAmount_Stat = 0;

                int strength = Convert.ToInt32(mtxtStrength.Text);
                int dexterity = Convert.ToInt32(mtxtDexterity.Text);
                int agility = Convert.ToInt32(mtxtAgility.Text);
                int constitution = Convert.ToInt32(mtxtConstitution.Text);
                int intelligence = Convert.ToInt32(mtxtIntelligence.Text);
                int magicTalent = Convert.ToInt32(mtxtMagicalTalent.Text);

                TotalAmount_Stat = strength + dexterity + agility + constitution + intelligence + magicTalent;

                if (TotalAmount_Stat < 350)
                {
                    lblStatCheck.Text = "Summe < 350";
                    lblStatCheck.ForeColor = System.Drawing.Color.Red;
                    rbStats.Checked = false;

                    // If Stat Sum is to low, values get reset
                    txtDamageBuff.Text = "";
                    txtStaminaBuff.Text = "";
                    txtAttackBuff.Text = "";
                    txtDefenseBuff.Text = "";
                    txtMagicBuff.Text = "";

                    txtRumble.Text = "";
                    txtDefense.Text = "";
                    txtDefense0.Text = "";
                    txtDoMagic.Text = "";
                    txtDoMagic0.Text = "";

                    txtGhostMagicFighter.Text = "";
                    txtGhostMagicMagician.Text = "";
                    txtGhostMagicNormal.Text = "";
                    txtBodyMagicFighter.Text = "";
                    txtBodyMagicMagician.Text = "";
                    txtBodyMagicNormal.Text = "";
                    txtAreaMagicFighter.Text = "";
                    txtAreaMagicMagician.Text = "";
                    txtAreaMagicNormal.Text = "";

                }

                if (TotalAmount_Stat >= 350)
                {
                    lblStatCheck.Text = "Summe OK";
                    lblStatCheck.ForeColor = System.Drawing.Color.Green;
                    rbStats.Checked = true;

                    

                    int DamageBuff = 0;
                    int DefenseBuff = 0;

                    DamageBuff = (Convert.ToInt32(mtxtStrength.Text) / 20) + (Convert.ToInt32(mtxtDexterity.Text) / 30) - 3;
                    DefenseBuff = (Convert.ToInt32(mtxtConstitution.Text) / 10) + (Convert.ToInt32(mtxtStrength.Text) / 20) - 7;

                    if (DamageBuff >= 0)
                    {
                        txtDamageBuff.Text = Convert.ToString(DamageBuff);
                    }
                    else
                    {
                        txtDamageBuff.Text = "0";
                    }

                    if (DefenseBuff >= 0)
                    {
                        txtStaminaBuff.Text = Convert.ToString(DefenseBuff);
                    }
                    else
                    {
                        txtStaminaBuff.Text = "0";
                    }

                    txtAttackBuff.Text = Convert.ToString(c.AttackBuff(dexterity));
                    txtDefenseBuff.Text = Convert.ToString(c.DefenseBuff(agility));
                    txtMagicBuff.Text = Convert.ToString(c.MagicBuff(magicTalent));

                    txtRumble.Text = Convert.ToString(((strength + agility) / 20) + Convert.ToInt32(txtAttackBuff.Text));
                    txtDefense.Text = Convert.ToString(11 + Convert.ToInt32(txtDefenseBuff.Text));
                    txtDefense0.Text = Convert.ToString(10 + Convert.ToInt32(txtDefenseBuff.Text));
                    txtDoMagic.Text = Convert.ToString(10 + Convert.ToInt32(txtMagicBuff.Text));
                    txtDoMagic0.Text = Convert.ToString(2 + Convert.ToInt32(txtMagicBuff.Text));

                    

                    int mtBuffGhost_Body_MagicValue = 0;
                    int intBuffGhostMagicValue = 0;
                    int CoBuffBodyMagicValue = 0;

                    //Buff MagicTalent Ghost&Body
                    mtBuffGhost_Body_MagicValue = c.MagicTalentGhostBody(magicTalent);

                    //Buff Intelligence Ghost
                    intBuffGhostMagicValue = c.IntelligenceGhost(intelligence);

                    //Buff Constitution Body
                    CoBuffBodyMagicValue = c.ConstitutionBody(constitution);

                    //Values GhostMagic
                    txtGhostMagicFighter.Text = Convert.ToString(14 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));
                    txtGhostMagicMagician.Text = Convert.ToString(17 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));
                    txtGhostMagicNormal.Text = Convert.ToString(14 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));

                    //Values BodyMagic
                    txtBodyMagicFighter.Text = Convert.ToString(16 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));
                    txtBodyMagicMagician.Text = Convert.ToString(17 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));
                    txtBodyMagicNormal.Text = Convert.ToString(14 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));

                    //Values AreaMagic
                    txtAreaMagicFighter.Text = Convert.ToString(10 + c.AgilityArea(agility));
                    txtAreaMagicMagician.Text = Convert.ToString(13 + c.AgilityArea(agility));
                    txtAreaMagicNormal.Text = Convert.ToString(10 + c.AgilityArea(agility));
                }
            }
            else
            {
                lblStatCheck.Text = "Summe < 350";
                lblStatCheck.ForeColor = System.Drawing.Color.Red;
                rbStats.Checked = false;

                // If Stat Sum is to low, values get reset
                txtDamageBuff.Text = "";
                txtStaminaBuff.Text = "";
                txtAttackBuff.Text = "";
                txtDefenseBuff.Text = "";
                txtMagicBuff.Text = "";

                txtRumble.Text = "";
                txtDefense.Text = "";
                txtDefense0.Text = "";
                txtDoMagic.Text = "";
                txtDoMagic0.Text = "";

                txtGhostMagicFighter.Text = "";
                txtGhostMagicMagician.Text = "";
                txtGhostMagicNormal.Text = "";
                txtBodyMagicFighter.Text = "";
                txtBodyMagicMagician.Text = "";
                txtBodyMagicNormal.Text = "";
                txtAreaMagicFighter.Text = "";
                txtAreaMagicMagician.Text = "";
                txtAreaMagicNormal.Text = "";
            }

            #endregion
            TimerCheck t = new TimerCheck();
            //BodySize
            btnBodySize.Enabled = t.BodySizeCheck(mtxtBodySizeA.Text, mtxtBodySizeB.Text, rbStats.Checked, this.Text); ;

            //BodyWeight
            btnBodyWeight.Enabled = t.BodyWeightCheck(mtxtBodyWeightA.Text, mtxtBodyWeightB.Text, mtxtBodyWeightC.Text, mtxtBodyWeightD.Text, rbStats.Checked, txtBodySizeA.Text);

            //Charisma
            btnCharisma.Enabled = t.CharismaCheck(mtxtAppearance.Text, rbStats.Checked, mtxtCharisma.Text);

            //Willpower
            btnWillpower.Enabled = t.WillpowerCheck(mtxtWillpower.Text, rbStats.Checked);

            //SelfControl
            btnSelfControl.Enabled = t.SelfControlCheck(mtxtSelfControl.Text, rbStats.Checked, txtWillpower.Text);

            //Handed
            btnHanded.Enabled = t.HandedCheck(mtxtHanded.Text, rbStats.Checked);

            //AP
            btnAdventurePointsA.Enabled = t.AdventurePointsACheck(mtxtAdventurePointsA.Text, txtStaminaBuff.Text);
            btnAdventurePointsB.Enabled = t.AdventurePointsBCheck(mtxtAdventurePointsB.Text, txtStaminaBuff.Text);
            btnAdventurePointsC.Enabled = t.AdventurePointsCCheck(mtxtAdventurePointsC.Text, txtStaminaBuff.Text);

            //LP
            btnLifePoints.Enabled = t.LifePointsCheck(mtxtLifePoints.Text, rbStats.Checked);

            //InbornBuff
            btnInbornBuff.Enabled = t.InbornBuffCheck(mtxtInbornBuff.Text);
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            

           

            if (txtCharacterName.Text !="")
            {
                

                if(this.Text!="MCreator - Mensch")
                {
                    txtBodySizeB.Text = "0";
                    txtBodyWeightB.Text = "0";
                }
                

                Export exp = new Export();
                exp.export();


                //Process.Start("explorer.exe", txtExportPath.Text);
                
            }
            else
            {
                MessageBox.Show("Bitte einen Charakternamen eingeben!", "Fehler");
                
            }
            
        }

        private void txtSavepathExport_Click(object sender, EventArgs e)
        {
            if (chooseExportFolder.ShowDialog(this) == DialogResult.OK)
                txtExportPath.Text = chooseExportFolder.SelectedPath;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            List<String> lines = new List<String>();
            using (StreamReader sr = new StreamReader(txtImportFile.Text, Encoding.Default))
            {
                while (sr.Peek() != -1)
                    lines.Add(sr.ReadLine());
            }




            mtxtStrength.Text = lines[53];
            mtxtDexterity.Text = lines[55];
            mtxtAgility.Text = lines[57];
            mtxtConstitution.Text = lines[59];
            mtxtIntelligence.Text = lines[61];
            mtxtMagicalTalent.Text = lines[63];

            mtxtBodySizeA.Text = lines[65];
            mtxtBodySizeB.Text = lines[67];

            mtxtBodyWeightA.Text = lines[69];
            mtxtBodyWeightB.Text = lines[71];
            mtxtBodyWeightC.Text = lines[73];
            mtxtBodyWeightD.Text = lines[75];

            mtxtAppearance.Text = lines[78];
            mtxtCharisma.Text = lines[80];
            mtxtWillpower.Text = lines[82];
            mtxtSelfControl.Text = lines[84];

            mtxtInbornBuff.Text = lines[86];
            mtxtHanded.Text = lines[88];

            mtxtAdventurePointsA.Text = lines[90];
            mtxtAdventurePointsB.Text = lines[92];
            mtxtAdventurePointsC.Text = lines[94];
            mtxtLifePoints.Text = lines[96];

            //txtCharacterName.Text = lines[];

            // Enabling the form
            int strength = Convert.ToInt32(mtxtStrength.Text);
            int dexterity = Convert.ToInt32(mtxtDexterity.Text);
            int agility = Convert.ToInt32(mtxtAgility.Text);
            int constitution = Convert.ToInt32(mtxtConstitution.Text);
            int intelligence = Convert.ToInt32(mtxtIntelligence.Text);
            int magicTalent = Convert.ToInt32(mtxtMagicalTalent.Text);

            rbStats.Checked = true;
            
            

            int DamageBuff  = 0;
            int DefenseBuff = 0;

            DamageBuff  = (strength / 20) + (dexterity / 30) - 3;
            DefenseBuff = (strength / 20) + (constitution / 10) - 7;

            if (DamageBuff >= 0)
            {
                txtDamageBuff.Text = Convert.ToString(DamageBuff);
            }
            else
            {
                txtDamageBuff.Text = "0";
            }

            if (DefenseBuff >= 0)
            {
                txtStaminaBuff.Text = Convert.ToString(DefenseBuff);
            }
            else
            {
                txtStaminaBuff.Text = "0";
            }

            txtAttackBuff.Text      = Convert.ToString(c.AttackBuff(dexterity));
            txtDefenseBuff.Text     = Convert.ToString(c.DefenseBuff(agility));
            txtMagicBuff.Text       = Convert.ToString(c.MagicBuff(magicTalent));

            txtRumble.Text          = Convert.ToString(((strength + agility) / 20) + c.AttackBuff(dexterity));
            txtDefense.Text         = Convert.ToString(11 + c.DefenseBuff(agility));
            txtDefense0.Text        = Convert.ToString(10 + c.DefenseBuff(agility));
            txtDoMagic.Text         = Convert.ToString(10 + c.MagicBuff(magicTalent));
            txtDoMagic0.Text        = Convert.ToString(2  + c.MagicBuff(magicTalent));


            

            int mtBuffGhost_Body_MagicValue = 0;
            int intBuffGhostMagicValue      = 0;
            int CoBuffBodyMagicValue        = 0;

            //Buff MagicTalent Ghost&Body
            mtBuffGhost_Body_MagicValue = c.MagicTalentGhostBody(magicTalent);

            //Buff Intelligence Ghost
            intBuffGhostMagicValue      = c.IntelligenceGhost(intelligence);

            //Buff Constitution Body
            CoBuffBodyMagicValue        = c.ConstitutionBody(constitution);

            //Values GhostMagic
            txtGhostMagicFighter.Text   = Convert.ToString(14 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));
            txtGhostMagicMagician.Text  = Convert.ToString(17 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));
            txtGhostMagicNormal.Text    = Convert.ToString(14 + c.GhostMagic(mtBuffGhost_Body_MagicValue, intBuffGhostMagicValue));

            //Values BodyMagic
            txtBodyMagicFighter.Text    = Convert.ToString(16 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));
            txtBodyMagicMagician.Text   = Convert.ToString(17 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));
            txtBodyMagicNormal.Text     = Convert.ToString(14 + c.BodyMagic(mtBuffGhost_Body_MagicValue, CoBuffBodyMagicValue));

            //Values AreaMagic
            txtAreaMagicFighter.Text    = Convert.ToString(10 + c.AgilityArea(agility));
            txtAreaMagicMagician.Text   = Convert.ToString(13 + c.AgilityArea(agility));
            txtAreaMagicNormal.Text     = Convert.ToString(10 + c.AgilityArea(agility));

        }

        private void txtImportFile_Click(object sender, EventArgs e)
        {
            string file;

            if (chooseImportFile.ShowDialog(this) == DialogResult.OK)
            {
                file = chooseImportFile.FileName;
                
                txtImportFile.Text = file;
            }         
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Beim Beenden gehen alle Werte verloren",
                               "Warnung",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }

    }
}
