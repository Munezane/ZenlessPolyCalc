using System;
using System.Collections.Generic;
using System.Text;
using ZenlessPolyCalc.Config;

namespace ZenlessPolyCalc
{
    internal class PolychromeManager
    {
        private const short ShiyuCyclesPerPatch = 3;
        private const short ShiyuPolychromesPerCycle = 780;
        private const short DeadlyAssaultCyclesPerPatch = 3;
        private const short DeadlyAssaultPolychromesPerCycle = 300;
        private const short DailyPolychromes = 60;
        private const short WeeklyPolychromes = 240;//160 from hollow zero + 60 from weekly errands
        private ConfigManager configManager;
        public PolychromeManager(ConfigManager ConfigManager)
        {
            configManager = ConfigManager;
        }

        public PolychromeResultDTO CalculateResults()
        {
            PolychromeResultDTO results = new PolychromeResultDTO();
            //get what we currently have
            results.TotalPolychromes = configManager.CurrentPolychromes + (configManager.CurrentTapes * 160); //converting any tapes we have back to polys for calculation
            TimeSpan dateDiff = configManager.PatchEndDate.Subtract(DateTime.Now.Date);
            int daysLeft = dateDiff.Days;
            //dailies
            results.TotalPolychromes += (daysLeft - 1) * DailyPolychromes; //we assume we already got today's dailies
            //weeklies
            results.TotalPolychromes += WeeklyPolychromes * ((int)Math.Round((decimal)(daysLeft / 7), MidpointRounding.AwayFromZero)); //rounding up because should be able to get weeklies on final day!
            //a patch is roughly 6 weeks, cycling between shiyu and deadly assault. This won't be entirely accurate as we don't know whether this month started with shiyu or deadly assault. We'll assume it started with deadly assault
            int weeksLeft = (int)(Math.Round((decimal)(dateDiff.Days) / 7));
            //we'll split the weeks left, half assuming shiyu, half deadly assault
            int deadlyAssaultsLeft = 0;
            int shiyusLeft = 0;
            //if no weeks left, we'll assume we don't even have time for final endgame mode
            if (weeksLeft > 0)
            {
                deadlyAssaultsLeft = (int)(Math.Round((decimal)(weeksLeft / 2), MidpointRounding.ToZero));
                shiyusLeft = (int)(Math.Round((decimal)(weeksLeft / 2), MidpointRounding.ToZero));
                //if we have an odd number of weeks, we'll assume last one is deadly assault (as it has lowest polychromes)
                if (weeksLeft % 2 > 0)
                {
                    //odd number of weeks!
                    deadlyAssaultsLeft += 1;
                } 
            }
            results.TotalPolychromes += deadlyAssaultsLeft * DeadlyAssaultPolychromesPerCycle;

            short tempShiyuPolychromes = ShiyuPolychromesPerCycle;
            if(configManager.AssumeShiyuARank)
            {
                tempShiyuPolychromes -= 80; //if we only get A ranks on shiyu, we miss out on 80 polychromes
            }
            results.TotalPolychromes += shiyusLeft * tempShiyuPolychromes;

            //events!
            results.TotalPolychromes += configManager.RemainingEventPolychromes;

            return results;
        }

        public int PullsNeededForWishlistItem(WishlistItem wishlist)
        {
            int pullsNeeded = 0;
            if (wishlist.NormalBanner)
            {
                if (wishlist.IsWeapon)
                {
                    pullsNeeded = 160;
                    if (!configManager.WonLastWeaponRateUp) //if you lost the pity then you're guarranteed on next S rank
                    {
                        pullsNeeded = pullsNeeded / 2;
                    }
                    pullsNeeded -= configManager.CurrentWeaponPity;
                }
                else
                {
                    pullsNeeded = 180;
                    if (!configManager.WonLastCharacterRateUp) //if you lost the pity then you're guarranteed on next S rank
                    {
                        pullsNeeded = pullsNeeded / 2;
                    }
                    pullsNeeded -= configManager.CurrentCharacterPity;
                }

            }
            else if (wishlist.DiscountBanner)
            {
                //pity doesn't matter
                //discount gives you 10 pull for cost of 8, so 2 free extra pulls essentially
                if (wishlist.IsWeapon)
                {
                    pullsNeeded = 78;
                }
                else
                {
                    pullsNeeded = 88;
                }
            }
           
            return pullsNeeded;
        }
    }
}
