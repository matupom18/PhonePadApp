using System;
using System.Text;

namespace PhonePadApp
{
    public class PhoneKeypad
    {
        private static readonly string[] Keypad = {
            " ",      // 0
            "&'(",    // 1
            "ABC",    // 2
            "DEF",    // 3
            "GHI",    // 4
            "JKL",    // 5
            "MNO",    // 6
            "PQRS",   // 7
            "TUV",    // 8
            "WXYZ"    // 9
        };

        /// <summary>
        /// Converts the input string of keypad presses to the corresponding output string.
        /// </summary>
        /// <param name="input">The string of button presses (e.g., "4433555 555666#").</param>
        /// <returns>The decoded string.</returns>
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            StringBuilder output = new StringBuilder();
            char currentButton = '\0';
            int pressCount = 0;

            foreach (char c in input)
            {
                if (c == '#') break; // End of input

                // Same button pressed again? Increment count.
                if (c == currentButton)
                {
                    pressCount++;
                }
                else
                {
                    // Different button pressed: Process the previous one
                    if (currentButton != '\0' && char.IsDigit(currentButton))
                    {
                        output.Append(GetCharacter(currentButton, pressCount));
                    }

                    // Reset for the new button
                    currentButton = c;
                    pressCount = 1;

                    // Handle special characters immediately after "committing" the previous one
                    if (c == '*')
                    {
                        // Backspace
                        if (output.Length > 0)
                        {
                            output.Length--;
                        }
                        currentButton = '\0';
                        pressCount = 0;
                    }
                    else if (c == ' ')
                    {
                        // Pause / Separator
                        currentButton = '\0';
                        pressCount = 0;
                    }
                }
            }

            // Append the last pending character if ends without # (though # is expected)
            // or if the loop breaks at #, we still need to process the pending button.
            // Wait, if loop breaks at #, we haven't processed the char before # if it was the same as currentButton.
            // But wait! The loop logic:
            // if c == # break. 
            // So if input is "2#", loop:
            // 1. c='2'. else block. current='2', count=1.
            // 2. c='#'. break.
            // After loop: we need to flush '2'.
            
            // IF input "22#":
            // 1. c='2'. else. cur='2', cnt=1.
            // 2. c='2'. if cur==c. cnt=2.
            // 3. c='#'. break.
            // After loop needs flush.

            if (currentButton != '\0' && char.IsDigit(currentButton))
            {
                output.Append(GetCharacter(currentButton, pressCount));
            }

            return output.ToString();
        }

        private static char GetCharacter(char buttonChar, int count)
        {
            int index = buttonChar - '0';
            if (index < 0 || index >= Keypad.Length) return '?'; // Should handle valid digits only

            string letters = Keypad[index];
            if (string.IsNullOrEmpty(letters)) return '?'; // Or ignore

            // Cycle through letters: 1 press -> idx 0, 2 presses -> idx 1
            int letterIndex = (count - 1) % letters.Length;
            return letters[letterIndex];
        }
    }
}
