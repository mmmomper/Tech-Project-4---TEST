//Tech Project 4: Echo Group: Marisa Momper, Raleigh Sullivan, Duy Ho, Mardeja Bivens, Josh Palathinkal
using System;

namespace Tech_Project_4

{
    class Program

    {
        static void Main(string[] args)
        {
            //declares a constant to hold the size for the card number array
            const int number = 8;

            //declares a constant to hole the size for the suit array
            const int suit = 4;

            //creates and assigns the designated card numbers to the cards_number array
            string[] cards_number = new string[number] { "A", "K", "Q", "J", "T", "9", "8", "7" };

            //creates and assigns the designated suits to the cards_suit array
            string[] cards_suit = new string[suit] { "S", "H", "D", "C" };

            //creates and assigns a new array which is the same length as the cards_number array. The values assigned are in the appropriate order based on the card number and are the values when the suit is dominant
            int[] dominant_number = new int[number] { 11, 4, 3, 20, 10, 14, 0, 0 };

            //creates and assigns a new array which is the same length as the cards_number array. The values assigned are in the appropriate order based on the card number and are the values when the suit is not dominant
            int[] non_dominant_number = new int[number] { 11, 4, 3, 2, 10, 0, 0, 0 };

            //Asks user for their first line of input which contain the number of hands a space and then the suit
            //Commented Out For Kattis
            //Console.WriteLine("Enter the number of hands and suit with a space between: ");

            //assigns the input the user provides to a string variable
            string user_hand_and_suit = Console.ReadLine();

            //finds the index of the space in the first line input string and assigns the index value to a variable
            int space_index = user_hand_and_suit.IndexOf(" ");

            //assigns the index for the space to a new variable which will be used to designate the length for the characters within the string before the space
            int number_length = space_index;

            //adds one to the value for the space index to a variable which will be used to designate the index within the string that defines the dominant suit
            int suit_index = space_index + 1;

            //takes the users input and assigns a substring of the string which is made up of all of the characters before the space
            string hands_string = user_hand_and_suit.Substring(0,number_length).ToString();

            //converts the substring to an int value
            int hands = int.Parse(hands_string);

            //takes the users input and returns a string of just the value after the space and assigns it to a string variable
            string dominant_suit = user_hand_and_suit[suit_index].ToString();

          
            try
            {
                //Checks to see if the number of hands the user input (represented by the string input that is to the left of the space in the string of the user's first input) is between 1 and 100
                if (hands >= 1 && hands <= 100)
                {
                    //declares a variable to hold the number of hands and calculates the value for the occurence by multiplying the value for hands by 4
                    int number_of_cards = hands * 4;

                    //Declares a variable to hold an index value for the number of card input request interations and starts at 1
                    int index = 1;

                    //Declares a variable to hols the total points
                    int total_points = 0;

                    //while loop which continues interating as long as the value for index does not exceed the total number of cards the user must input based on their number of hands
                    while (index <= number_of_cards)
                    {
                        //Asks the user to input a card
                        //Commented Out For Kattis
                        //Console.WriteLine("Enter a card value");

                        //Assigns the card the user inputs to a variable
                        string current_card = Console.ReadLine();

                        //Assigns the character that is the first element in the string to a variable
                        string current_card_number = current_card[0].ToString();

                        //Assigns the character that is the second element in the string to a variable
                        string current_card_suit = current_card[1].ToString();

                        //Checks to see that the number that the user has input is one of the numbers that is present in the cards_number array
                        if (Array.IndexOf(cards_number, current_card_number) != -1)
                        {
                            //Checks to see that the suit that the use has input is one of the suits that is present in the cards_suit array
                            if (Array.IndexOf(cards_suit, current_card_suit) != -1)
                            {
                                //checks to see if the suit of the current card is the dominant suit
                                if (current_card_suit == dominant_suit)
                                {
                                    //Assigns the index value for the element of the array that contains the current number to a variable
                                    int dominant_number_index = Array.IndexOf(cards_number, current_card_number);

                                    //Assigns the card value for that card number by using the same index number to search in the dominant_number array to a variable
                                    int dominant_value = dominant_number[dominant_number_index];

                                    //Adds the dominant value that was found to the value for total points and then reassigns that new value to total points
                                    total_points += dominant_value;
                                }

                                //Checks to see if the suit is not dominant
                                if (current_card_suit != dominant_suit)
                                {
                                    //Assigns the index value for the element of the array that contains the current number to a variable
                                    int nondominant_number_index = Array.IndexOf(cards_number, current_card_number);

                                    //Assigns the card value for that card number by using the same index number to search in the non_dominant_number array to a variable
                                    int nondominant_value = non_dominant_number[nondominant_number_index];

                                    //Adds the non dominant value that was found to the value for total points and then reassigns that new value to total points
                                    total_points += nondominant_value;

                                }
                            }
                        }
                        //adds 1 to the current value for index to iterate through the while loop again
                        index += 1;
                    }
                    //Outputs the final value for total_points which represent the total score based on the users cards
                    Console.WriteLine(total_points);
                    Console.ReadKey(true);
                }
            }
            //Handles all other cases in which the if statements above were not validated
            catch
            {
                //Asks the user to input new cards or a new initial line designation
                //Console.WriteLine("Please enter new cards or new initial line information");
                //Console.ReadKey(true);
            }
        }
    }
}
