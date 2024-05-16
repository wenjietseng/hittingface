using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RandomUtility
{
    public class Shuffle
    {
        /// <summary>
        /// Input: an integer number (e.g., number of targets for random)
        /// Output: an array of shuffled index for further calls
        /// </summary>

        // usage
        // shuffle = new Shuffle().SampleTrialNums(13);
        // shuffle.printArray(shuffle.shuffledArray);
        public int trialNums;
        public int[] shuffledArray;

        public Shuffle SampleTrialNums(int num)
        {
            Shuffle s = new Shuffle();
            s.trialNums = num;
            s.shuffledArray = new int[num];
            for (int i = 0; i < num; i++) s.shuffledArray[i] = i;

            for (int i = 0; i < num; i++)
            {
                int temp = s.shuffledArray[i];
                int randomIndex = UnityEngine.Random.Range(0, num);
                s.shuffledArray[i] = s.shuffledArray[randomIndex];
                s.shuffledArray[randomIndex] = temp;
            }
            return s;
        }

        public void printArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Debug.Log("Array index " + i + " = " + arr[i]);
            }
        }
    }
}