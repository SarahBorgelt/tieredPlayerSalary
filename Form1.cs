using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TieredPlayerSalaryViaIF___Sarah_Borgelt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Author: Sarah Borgelt
        //ID: 00670481
        //Date: September 27th, 2026
        //Goal-Purpose of Program: To calculate baseball player salary
        //based on business rules, as well as display the player with the most hits.

        //Create variables outside of method so they are accesible
        String playerName = String.Empty;
        String topPlayerName = String.Empty;
        int playerHits = 0;
        int topPlayerHits = 0;
        Boolean isPlayerMvp = false;
        Boolean isTopPlayerMvp = false;
        Boolean isPlayerAllStar = false;
        Boolean isTopPlayerAllStar = false;
        Double playerSalary = 0;
        Double topPlayerSalary = 0;
        int playerTierStatus = 0;
        int topPlayerTierStatus = 0;

        //Create method to handle calculate button
        private void calculate_Click(object sender, EventArgs e)
        {
            //Reset player salary and status each calculation
            playerSalary = 0;

            //If player name field is empty, instruct user to enter player name
            if (string.IsNullOrEmpty(playerNameInput.Text))
            {
                MessageBox.Show("Please enter a player's name");
                return;
            }
            //Otherwise, set the input equal to the variable player name
            else
            {
                playerName = playerNameInput.Text;
            }

            //Check MVP and All-Star status and set them equal to variables
            isPlayerMvp = mvpInput.Checked;
            isPlayerAllStar = allStarInput.Checked;

            //Check number of hit inputs. If blank, prompt user.
            if (string.IsNullOrEmpty(numberOfHitsInput.Text))
            {
                MessageBox.Show("Please enter the player's number of hits.");
                return;
            }
            //If number of hits was entered, make it equal to player hits variable.
            else
            {
                if (int.TryParse(numberOfHitsInput.Text, out playerHits))
                {


                    //Check if the number of player hits is greater than 0 and less than 300. If not, inform user.
                    if (playerHits > 0 && playerHits <= 300)
                    {
                        //Determine player salary by hits by adding salary by hits
                        if (playerHits <= 49 && playerHits >= 1)
                        {
                            playerSalary += (playerHits * 17500);
                            playerTierStatus = 1;
                        }
                        else if (playerHits >= 50 && playerHits <= 99)
                        {
                            playerSalary += (playerHits * 20000);
                            playerTierStatus = 2;
                        }
                        else if (playerHits >= 100 && playerHits <= 149)
                        {
                            playerSalary += (playerHits * 22500);
                            playerTierStatus = 3;
                        }
                        else if (playerHits >= 150)
                        {
                            playerSalary += (playerHits * 25000);
                            playerTierStatus = 4;
                        }
                    }
                    // If player hit not within correct numbers, give the user feedback
                    else
                    {
                        MessageBox.Show("You've entered an invalid number of hits. Please try again.");
                        return;
                    }
                }
                //If the tryparse for number of hits fails, give the user feedback to enter a number
                else
                {
                    MessageBox.Show("Please enter a number.");
                    return;
                }

                //Handle bonus structure for MVP and All-Star

                if (isPlayerMvp && isPlayerAllStar)
                {
                    playerSalary += (playerSalary * 0.25);
                }

                else if (isPlayerMvp || isPlayerAllStar)
                {
                    playerSalary += (playerSalary * 0.20);
                }

                //If player hits are max, make them the new top player
                if (playerHits > topPlayerHits)
                {
                    topPlayerHits = playerHits;
                    topPlayerName = playerName;
                    topPlayerSalary = playerSalary;
                    isTopPlayerMvp = isPlayerMvp;
                    isTopPlayerAllStar = isPlayerAllStar;
                    topPlayerTierStatus = playerTierStatus;
                }

                //Display fields to user
                playerSalaryOutput.Text = $"This player earned a salary of ${playerSalary:F2}";
                playerTierStatusOutput.Text = $"{playerName} achieved a tier status of {playerTierStatus}";
                leadingPlayerName.Text = $"The top player is {topPlayerName}.";
                leadingPlayerHitsOutput.Text = $"{topPlayerName} produced {topPlayerHits} hits.";
                leadingPlayerSalary.Text = $"This player's salary is ${topPlayerSalary:F2}";
                leadingPlayerAllStarStatus.Text = $"Player All-Star Status: {isTopPlayerAllStar}";
                leadingPlayerMvpStatus.Text = $"Player MVP status: {isTopPlayerMvp}";
                leadingPlayerTier.Text = $"{topPlayerName} has a tier status of {topPlayerTierStatus}";

            }

        }

        //Create a clear button to clear all fields
        private void clear_Click(object sender, EventArgs e)
        {
            //Clear input and checked status
            playerNameInput.Text = "";
            numberOfHitsInput.Text = "";

            mvpInput.Checked = false;
            allStarInput.Checked = false;

            //Clear all outputs
            playerSalaryOutput.Text = "";
            playerTierStatusOutput.Text = "";
            leadingPlayerName.Text = "";
            leadingPlayerHitsOutput.Text = "";
            leadingPlayerSalary.Text = "";
            leadingPlayerAllStarStatus.Text = "";
            leadingPlayerMvpStatus.Text = "";
            leadingPlayerTier.Text = "";

            //Clear all variables to start fresh on next run
            playerName = "";
            topPlayerName = "";
            playerHits = 0;
            topPlayerHits = 0;
            isPlayerMvp = false;
            isTopPlayerMvp = false;
            isPlayerAllStar = false;
            isTopPlayerAllStar = false;
            playerSalary = 0;
            topPlayerSalary = 0;
            playerTierStatus = 0;
            topPlayerTierStatus = 0;
        }
    }
}

