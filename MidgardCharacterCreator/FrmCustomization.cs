﻿/*
    Mcreator
    Copyright (C) 2017  Fabian Dörr <faflfama@outlook.com>

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
using mcc.Classes;

namespace mcc
{
    public partial class FrmCustomization : Form
    {
        public FrmCustomization()
        {
            InitializeComponent();            
        }

        Customization c = new Customization();

        private void CbStartWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int weaponValue = Convert.ToInt32(cbStartWeapons.SelectedItem.ToString());
            if (weaponValue <= 10)
            {
                txtStartWeaponsA.Text = "3E";
                txtStartWeaponsB.Text = "2E";
                txtStartWeaponsC.Text = "1E";
                txtStartWeaponsD.Text = "2E";
            }
            if (weaponValue <= 20 && weaponValue > 10)
            {
                txtStartWeaponsA.Text = "3E, 1A";
                txtStartWeaponsB.Text = "1E, 1A";
                txtStartWeaponsC.Text = "1A";
                txtStartWeaponsD.Text = "1E, 1A";
            }
            if (weaponValue <= 30 && weaponValue > 20)
            {
                txtStartWeaponsA.Text = "2E, 2A";
                txtStartWeaponsB.Text = "2E, 1A";
                txtStartWeaponsC.Text = "2E";
                txtStartWeaponsD.Text = "3E";
            }
            if (weaponValue <= 60 && weaponValue > 30)
            {
                txtStartWeaponsA.Text = "3E, 2A";
                txtStartWeaponsB.Text = "3E, 1A";
                txtStartWeaponsC.Text = "1E, 1A";
                txtStartWeaponsD.Text = "2E, 1A";
            }
            if (weaponValue <= 80 && weaponValue > 60)
            {
                txtStartWeaponsA.Text = "2E, 3A";
                txtStartWeaponsB.Text = "2E, 2A";
                txtStartWeaponsC.Text = "1E, 1A";
                txtStartWeaponsD.Text = "1E, 2A";
            }
            if (weaponValue <= 95 && weaponValue > 80)
            {
                txtStartWeaponsA.Text = "5A";
                txtStartWeaponsB.Text = "4A";
                txtStartWeaponsC.Text = "2A";
                txtStartWeaponsD.Text = "3A";

            }
            if (weaponValue <= 100 && weaponValue > 95)
            {
                txtStartWeaponsA.Text = "1E*, 4A";
                txtStartWeaponsB.Text = "1E*, 3A";
                txtStartWeaponsC.Text = "1E*, 1A";
                txtStartWeaponsD.Text = "1E*, 2A";
            }
        }

        private void CbStartArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int armorValue = Convert.ToInt32(cbStartArmor.SelectedItem.ToString());
            if (armorValue <= 10)
            {
                txtStartArmorA.Text = "OR";
                txtStartArmorB.Text = "OR";
                txtStartArmorC.Text = "OR";
                txtStartArmorD.Text = "OR";
            }
            if (armorValue <= 20 && armorValue > 10)
            {
                txtStartArmorA.Text = "TR";
                txtStartArmorB.Text = "TR";
                txtStartArmorC.Text = "OR";
                txtStartArmorD.Text = "TR";
            }
            if (armorValue <= 30 && armorValue > 20)
            {
                txtStartArmorA.Text = "LR";
                txtStartArmorB.Text = "LR";
                txtStartArmorC.Text = "OR";
                txtStartArmorD.Text = "TR";
            }
            if (armorValue <= 60 && armorValue > 30)
            {
                txtStartArmorA.Text = "KR";
                txtStartArmorB.Text = "LR";
                txtStartArmorC.Text = "TR";
                txtStartArmorD.Text = "LR";
            }
            if (armorValue <= 80 && armorValue > 60)
            {
                txtStartArmorA.Text = "KR";
                txtStartArmorB.Text = "KR";
                txtStartArmorC.Text = "TR";
                txtStartArmorD.Text = "LR";
            }
            if (armorValue <= 95 && armorValue > 80)
            {
                txtStartArmorA.Text = "KR";
                txtStartArmorB.Text = "KR";
                txtStartArmorC.Text = "LR";
                txtStartArmorD.Text = "LR";

            }
            if (armorValue <= 100 && armorValue > 95)
            {
                txtStartArmorA.Text = "PR";
                txtStartArmorB.Text = "KR";
                txtStartArmorC.Text = "LR";
                txtStartArmorD.Text = "LR";
            }
        }
      
        private void BtnReset_Click(object sender, EventArgs e)
        {
            cbStartArmor.Items.Clear();
        }

        private void CbStartMoneyA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStartMoneyB.Enabled == false)
            {
                cbStartMoneyB.Enabled = true;

            }
            if(cbStartMoneyA.SelectedItem != null && cbStartMoneyB.SelectedItem != null && cbStartMoneyC.SelectedItem != null)
            {
                double startMoneyCalcA = 0;
                double startMoneyCalcB = 0;
                double startMoneyCalcC = 0;


                startMoneyCalcA = Convert.ToDouble(cbStartMoneyA.SelectedItem.ToString());
                startMoneyCalcB = Convert.ToDouble(cbStartMoneyB.SelectedItem.ToString());
                startMoneyCalcC = Convert.ToDouble(cbStartMoneyC.SelectedItem.ToString());

                if (txtSocialRankGeneral.Text == "Volk" || txtSocialRankGeneral.Text == "Mittelschicht")
                {
                    txtMoneyA.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0);
                    txtMoneyB.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC);
                    txtMoneyC.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0);
                    txtMoneyD.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0);
                }

                if (txtSocialRankGeneral.Text == "Unfrei")
                {
                    txtMoneyA.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0) / 2.0);
                    txtMoneyB.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC) / 2.0);
                    txtMoneyC.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0) / 2.0);
                    txtMoneyD.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0) / 2.0);
                }

                if (txtSocialRankGeneral.Text == "Adel")
                {
                    txtMoneyA.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0) * 2.0);
                    txtMoneyB.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC) * 2.0);
                    txtMoneyC.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0) * 2.0);
                    txtMoneyD.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0) * 2.0);
                }
                else
                {
                    txtMoneyA.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0);
                    txtMoneyB.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC);
                    txtMoneyC.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0);
                    txtMoneyD.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0);
                }
            }
        }

        private void CbStartMoneyB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStartMoneyC.Enabled == false)
            {
                cbStartMoneyC.Enabled = true;

            }
            if (cbStartMoneyA.SelectedItem != null && cbStartMoneyB.SelectedItem != null && cbStartMoneyC.SelectedItem != null)
            {
                double startMoneyCalcA = 0;
                double startMoneyCalcB = 0;
                double startMoneyCalcC = 0;

                startMoneyCalcA = Convert.ToDouble(cbStartMoneyA.SelectedItem.ToString());
                startMoneyCalcB = Convert.ToDouble(cbStartMoneyB.SelectedItem.ToString());
                startMoneyCalcC = Convert.ToDouble(cbStartMoneyC.SelectedItem.ToString());

                if (txtSocialRankGeneral.Text == "Volk" || txtSocialRankGeneral.Text == "Mittelschicht")
                {
                    txtMoneyA.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0);
                    txtMoneyB.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC);
                    txtMoneyC.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0);
                    txtMoneyD.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0);
                }

                if (txtSocialRankGeneral.Text == "Unfrei")
                {
                    txtMoneyA.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0) / 2.0);
                    txtMoneyB.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC) / 2.0);
                    txtMoneyC.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0) / 2.0);
                    txtMoneyD.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0) / 2.0);
                }

                if (txtSocialRankGeneral.Text == "Adel")
                {
                    txtMoneyA.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0) * 2.0);
                    txtMoneyB.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC) * 2.0);
                    txtMoneyC.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0) * 2.0);
                    txtMoneyD.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0) * 2.0);
                }
                else
                {
                    txtMoneyA.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3);
                    txtMoneyB.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC);
                    txtMoneyC.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6);
                    txtMoneyD.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3);
                }
            }
        }

        private void CbStartMoneyC_SelectedIndexChanged(object sender, EventArgs e)
        {
            double startMoneyCalcA = 0;
            double startMoneyCalcB = 0;
            double startMoneyCalcC = 0;

            startMoneyCalcA = Convert.ToDouble(cbStartMoneyA.SelectedItem.ToString());
            startMoneyCalcB = Convert.ToDouble(cbStartMoneyB.SelectedItem.ToString());
            startMoneyCalcC = Convert.ToDouble(cbStartMoneyC.SelectedItem.ToString());

            if(txtSocialRankGeneral.Text == "Volk" || txtSocialRankGeneral.Text == "Mittelschicht")
            {
                txtMoneyA.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0);
                txtMoneyB.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC);
                txtMoneyC.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0);
                txtMoneyD.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0);
            }

            if (txtSocialRankGeneral.Text == "Unfrei")
            {
                txtMoneyA.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0) / 2.0);
                txtMoneyB.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC) / 2.0);
                txtMoneyC.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0) / 2.0);
                txtMoneyD.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0) / 2.0);
            }

            if (txtSocialRankGeneral.Text == "Adel")
            {
                txtMoneyA.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0) * 2.0);
                txtMoneyB.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC) * 2.0);
                txtMoneyC.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0) * 2.0);
                txtMoneyD.Text = Convert.ToString((startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0) * 2.0);
            }
            else
            {
                txtMoneyA.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC - 3.0);
                txtMoneyB.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC);
                txtMoneyC.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 6.0);
                txtMoneyD.Text = Convert.ToString(startMoneyCalcA + startMoneyCalcB + startMoneyCalcC + 3.0);
            }
        }

        private void CbSocialRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSocialRankB.Enabled == false)
            {
                cbSocialRankB.Enabled = true;
            }
            if (cbSocialRankB.SelectedItem != null)
            {      
                    if (cbSocialRankB.SelectedItem.ToString() == "Barde" || cbSocialRankB.SelectedItem.ToString() == "Beschwörer" || cbSocialRankB.SelectedItem.ToString() == "Priester")
                    {
                        int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString()) + 20;
                        txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
                    }
                    if (cbSocialRankB.SelectedItem.ToString() == "Druide" || cbSocialRankB.SelectedItem.ToString() == "Heiler" || cbSocialRankB.SelectedItem.ToString() == "Magier" || cbSocialRankB.SelectedItem.ToString() == "Thraumaturg")
                    {
                        int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString()) + 10;
                        txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
                    }
                    if (cbSocialRankB.SelectedItem.ToString() == "Assasine" || cbSocialRankB.SelectedItem.ToString() == "Händler" || cbSocialRankB.SelectedItem.ToString() == "Kundschafter" || cbSocialRankB.SelectedItem.ToString() == "Waldläufer")
                    {
                        int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString()) - 10;
                        txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
                    }
                    if (cbSocialRankB.SelectedItem.ToString() == "Spitzbube")
                    {
                        int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString()) - 20;
                        txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
                    }
                    if (cbSocialRankB.SelectedItem.ToString() == "Andere")
                    {
                        int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString());
                        txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
                    }                                            
            }           
        }

        private void CbSocialRankB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSocialRankB.SelectedItem.ToString() == "Barde" || cbSocialRankB.SelectedItem.ToString() == "Beschwörer" || cbSocialRankB.SelectedItem.ToString() == "Priester")
            {
                int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString()) + 20;
                txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
            }
            if (cbSocialRankB.SelectedItem.ToString() == "Druide" || cbSocialRankB.SelectedItem.ToString() == "Heiler" || cbSocialRankB.SelectedItem.ToString() == "Magier" || cbSocialRankB.SelectedItem.ToString() == "Thraumaturg")
            {
                int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString()) + 10;
                txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
            }
            if (cbSocialRankB.SelectedItem.ToString() == "Assasine" || cbSocialRankB.SelectedItem.ToString() == "Händler" || cbSocialRankB.SelectedItem.ToString() == "Kundschafter" || cbSocialRankB.SelectedItem.ToString() == "Waldläufer")
            {
                int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString()) - 10;
                txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
            }
            if (cbSocialRankB.SelectedItem.ToString() == "Spitzbube")
            {
                int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString()) - 20;
                txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
            }
            if (cbSocialRankB.SelectedItem.ToString() == "Andere")
            {
                int socialRankValue = Convert.ToInt32(cbSocialRankA.SelectedItem.ToString());
                txtSocialRankGeneral.Text = c.SocialRank(socialRankValue);
            }
        }

        private void CbFachkenntnisseA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFachkenntnisseB.Enabled == false)
            {
                cbFachkenntnisseB.Enabled = true;

            }
            if(cbFachkenntnisseB.SelectedItem != null)
            {
                int fachkenntnisse = 0;
                int fachkenntnisse_ValueA = 0;
                int fachkenntnisse_ValueB = 0;

                fachkenntnisse_ValueA = Convert.ToInt32(cbFachkenntnisseA.SelectedItem.ToString());
                fachkenntnisse_ValueB = Convert.ToInt32(cbFachkenntnisseB.SelectedItem.ToString());
                fachkenntnisse = fachkenntnisse_ValueA + fachkenntnisse_ValueB;

                txtFachkenntnisse.Text = Convert.ToString(fachkenntnisse);
            }
        }

        private void CbFachkenntnisseB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fachkenntnisse = 0;
            int fachkenntnisse_ValueA = 0;
            int fachkenntnisse_ValueB = 0;

            fachkenntnisse_ValueA = Convert.ToInt32(cbFachkenntnisseA.SelectedItem.ToString());
            fachkenntnisse_ValueB = Convert.ToInt32(cbFachkenntnisseB.SelectedItem.ToString());
            fachkenntnisse = fachkenntnisse_ValueA + fachkenntnisse_ValueB;

            txtFachkenntnisse.Text = Convert.ToString(fachkenntnisse);
        }

        private void CbWaffenfertigkeitenA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWaffenfertigkeitenB.Enabled == false)
            {
                cbWaffenfertigkeitenB.Enabled = true;
            }
            if (cbWaffenfertigkeitenB.SelectedItem != null)
            {              
                txtWaffenfertigkeiten.Text = Convert.ToString(c.WeaponSkills(cbWaffenfertigkeitenA.SelectedItem.ToString(), cbWaffenfertigkeitenB.SelectedItem.ToString()));
            }
        }

        private void CbWaffenfertigkeitenB_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWaffenfertigkeiten.Text = Convert.ToString(c.WeaponSkills(cbWaffenfertigkeitenA.SelectedItem.ToString(), cbWaffenfertigkeitenB.SelectedItem.ToString()));
        }

        private void CbAllgemeinwissen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int allgemeinwissen = 0;

            allgemeinwissen = Convert.ToInt32(cbAllgemeinwissen.SelectedItem.ToString()) + 1;

            txtAllgemeinwissen.Text = Convert.ToString(allgemeinwissen);
        }

        private void CbUngewoehnlicheFertigkeiten_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ungewoehnlicheFertigkeiten = 0;

            ungewoehnlicheFertigkeiten = Convert.ToInt32(cbUngewoehnlicheFertigkeiten.SelectedItem.ToString());

            txtUngewoehnlicheFertigkeiten.Text = Convert.ToString(ungewoehnlicheFertigkeiten);
        }

        private void CbZauberkünsteA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbZauberkünsteB.Enabled == false)
            {
                cbZauberkünsteB.Enabled = true;

            }
            if (cbZauberkünsteB.SelectedItem != null)
            {
                txtZauberkuenste.Text = Convert.ToString(c.MagicArts(cbZauberkünsteA.SelectedItem.ToString(), cbZauberkünsteB.SelectedItem.ToString()));
            }
        }

        private void CbZauberkünsteB_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtZauberkuenste.Text = Convert.ToString(c.MagicArts(cbZauberkünsteA.SelectedItem.ToString(), cbZauberkünsteB.SelectedItem.ToString()));
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
