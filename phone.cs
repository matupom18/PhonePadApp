using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Test Case 1 (33#): " + PhoneKeypad.OldPhonePad("33#"));         
        Console.WriteLine("Test Case 2 (227*#): " + PhoneKeypad.OldPhonePad("227*#"));         
        Console.WriteLine("Test Case 3 (4433555 555666#): " + PhoneKeypad.OldPhonePad("4433555 555666#")); 
        Console.WriteLine("Test Case 4 (8 88777444666*664#): " + PhoneKeypad.OldPhonePad("8 88777444666*664#")); 
    }
}

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

    public static string OldPhonePad(string input)
    {
        StringBuilder output = new StringBuilder();
        char currentButton = '\0';
        int pressCount = 0;

        foreach (char c in input)
        {
            if (c == '#') break;

            if (c == currentButton)
            {
                pressCount++;
            }
            else
            {
                if (currentButton != '\0' && char.IsDigit(currentButton))
                {
                    output.Append(GetCharacter(currentButton, pressCount));
                }

                currentButton = c;
                pressCount = 1;

                if (c == '*')
                {
                    if (output.Length > 0) output.Length--;
                    currentButton = '\0';
                    pressCount = 0;
                }
                else if (c == ' ')
                {
                    currentButton = '\0';
                    pressCount = 0;
                }
            }
        }

        if (currentButton != '\0' && char.IsDigit(currentButton))
        {
            output.Append(GetCharacter(currentButton, pressCount));
        }

        return output.ToString();
    }

    private static char GetCharacter(char buttonChar, int count)
    {
        int index = buttonChar - '0';
        if (index < 0 || index >= Keypad.Length) return '?';

        string letters = Keypad[index];
        if (string.IsNullOrEmpty(letters)) return '?';

        int letterIndex = (count - 1) % letters.Length;
        return letters[letterIndex];
    }
}