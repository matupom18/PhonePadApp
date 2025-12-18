using NUnit.Framework;
using PhonePadApp;

namespace PhonePadApp.Tests
{
    public class OldPhonePadTests
    {
        [Test]
        public void Test_StandardCase1()
        {
            // 3 -> D, 3 -> E
            Assert.That(PhoneKeypad.OldPhonePad("33#"), Is.EqualTo("E"));
        }

        [Test]
        public void Test_StandardCase2_WithBackspace()
        {
            // 2->A, 2->B, 2->C, 2->A(wrap), 7->P, *-> DEL 7, #
            // Actually: 227*# 
            // 22 -> B
            // 7 -> P
            // * -> Backspace (removes P)
            // Result: B
            Assert.That(PhoneKeypad.OldPhonePad("227*#"), Is.EqualTo("B"));
        }

        [Test]
        public void Test_ComplexCase3()
        {
            // 44 -> H
            // 33 -> E
            // 555 -> L
            // 555 -> L
            // 666 -> O
            Assert.That(PhoneKeypad.OldPhonePad("4433555 555666#"), Is.EqualTo("HELLO"));
        }

        [Test]
        public void Test_ComplexCase4()
        {
            // 8 -> T
            // 88 -> U
            // 777 -> R
            // 444 -> I
            // 666 -> N
            // 666 -> N, * -> DEL N
            // 66 -> N (Wait? 666* is N then DEL. 664 is M G) 
            // Original: 8 88777444666*664#
            // 8 -> T
            // ' ' -> reset
            // 88 -> U
            // 777 -> R
            // 444 -> I
            // 666 -> N
            // * -> DEL N
            // 66 -> N
            // 4 -> G
            // Result: TURING
            Assert.That(PhoneKeypad.OldPhonePad("8 88777444666*664#"), Is.EqualTo("TURING"));
        }

        [Test]
        public void Test_EmptyInput()
        {
            Assert.That(PhoneKeypad.OldPhonePad(""), Is.EqualTo(""));
        }

        [Test]
        public void Test_ImmediateEnd()
        {
            Assert.That(PhoneKeypad.OldPhonePad("#"), Is.EqualTo(""));
        }

        [Test]
        public void Test_BackspaceOnEmpty()
        {
            // Should not crash
            Assert.That(PhoneKeypad.OldPhonePad("*#"), Is.EqualTo(""));
        }

        [Test]
        public void Test_MultipleSpaces()
        {
            // 2 -> A
            // ' ' -> reset
            // ' ' -> reset
            // 2 -> A
            Assert.That(PhoneKeypad.OldPhonePad("2  2#"), Is.EqualTo("AA"));
        }
        
        [Test]
        public void Test_TrailingCharactersIgnored()
        {
            // 22#abc should just be B
            Assert.That(PhoneKeypad.OldPhonePad("22#abc"), Is.EqualTo("B"));
        }    
    }
}
