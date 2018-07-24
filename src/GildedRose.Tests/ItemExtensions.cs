using System;
using GildedRose.Console;
using GildedRose.Console.Models;

namespace GildedRose.Tests
{
    public static class ItemExtensions
    {
        public static void InvokeOnEachDayCycle(this Items items, int dayCycles, Action invokeOnEachDayCycle)
        {
            for (int i = 0; i < dayCycles; i++)
            {
                Program.UpdateQuality(items);

                invokeOnEachDayCycle.Invoke();
            }
        }

        public static void InvokeOnCompletionOfAllCycles(this Items items, int dayCycles, Action invokeAfterAllCyclesComplete)
        {
            for (int i = 0; i < dayCycles; i++)
            {
                Program.UpdateQuality(items);
            }

            invokeAfterAllCyclesComplete.Invoke();
        }
    }
}