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
    }
}
