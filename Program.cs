using System;

namespace PhonePadApp
{
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
}
