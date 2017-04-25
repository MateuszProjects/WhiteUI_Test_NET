using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace WhiteUI_Test
{
    [TestClass]
    public class UnitTest1
    {

        Application app;
        Window win;


        [TestInitialize]
        public void init()
        {
            app = Application.Launch("C:\\Informatyka inżynierska UŚ\\Work\\Windows7-calculator\\calc.exe");
            win = app.GetWindow("Calculator");
        }

        [TestMethod]
        public void changeWidnow()
        {
            win.Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            win.Keyboard.Enter("3");
            win.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
        }

        [TestCleanup]
        public void clineUp()
        {
            win.Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            win.Keyboard.Enter("1");
            win.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            app.Close();
        }

        [TestMethod]
        public void TaskOne()
        {
            win.Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            win.Keyboard.Enter("3");
            win.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);

            var expectation = "A";
            Button button1 = win.Get<Button>(SearchCriteria.ByAutomationId("131"));
            button1.Click();
            Button button10 = win.Get<Button>(SearchCriteria.ByAutomationId("130"));
            button10.Click();
            RadioButton buttonHex = win.Get<RadioButton>(SearchCriteria.ByAutomationId("313"));
            buttonHex.Click();
            Label textBox = win.Get<Label>(SearchCriteria.ByAutomationId("150"));
            var textcheckBox = textBox.Text;

            Assert.AreEqual(expectation, textcheckBox);
        }

        [TestMethod]
        public void TaskTwo()
        {

        }
    }
}
