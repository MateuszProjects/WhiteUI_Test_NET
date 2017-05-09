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
using TestStack.White.UIItems.ListViewItems;
using System.Threading;

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
           
            app = Application.Launch("C:\\Windows7-calculator\\calc.exe");
            win = app.GetWindow("Calculator");
        }

        [TestMethod]
        public void changeWindow()
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
            // TODO Zadanie1: Przetostować zminaę widoku(programmer) na kalkulatorze za 
            // pomocą menu. Zamienić liczbę dziesiętną (10) na postać szesnastkową (Hex) i sprawdzić
            // czy otrzymamy prawidłowy wynik (A)

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
        public void function_x2()
        {
            // TODO Zadanie2: Przetestować zmianę widoku (scientiffic) za pomocą klawiatury.
            // Sprawdzić czy funkcja x^2 (dla x=5) zwróci poprawny wynik 25

            win.Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            win.Keyboard.Enter("2");
            win.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);

            var expectation = "25";

            Button button5 = win.Get<Button>(SearchCriteria.ByAutomationId("135"));
            button5.Click();
            Button button97 = win.Get<Button>(SearchCriteria.ByAutomationId("97"));
            button97.Click();
            Button button2 = win.Get<Button>(SearchCriteria.ByAutomationId("132"));
            button2.Click();
            Button button121 = win.Get<Button>(SearchCriteria.ByAutomationId("121"));
            button121.Click();

            Label textBox = win.Get<Label>(SearchCriteria.ByAutomationId("150"));
            var textBoxData = textBox.Text;

            Assert.AreEqual(expectation, textBoxData);
        }

        [TestMethod]
        public void convert_inch_to_cm()
        {
            // TODO Zadanie3: Sprawdzić konwersję jednostek z cali (2 cale) na centymetry (5.08 cm)

            win.Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            win.Keyboard.Enter("U");
            win.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);
            var expectation = "5,08";

            ComboBox comboBox = win.Get<ComboBox>
                (SearchCriteria.ByAutomationId("221"));
            comboBox.Select("Length");

            TextBox textbox = win.Get<TextBox>(SearchCriteria.ByAutomationId("226"));
            textbox.SetValue(2);


            ComboBox combo_inch = win.Get<ComboBox>(SearchCriteria.ByAutomationId("224"));
            combo_inch.Select("Inch");


            ComboBox combo_cm = win.Get<ComboBox>(SearchCriteria.ByAutomationId("225"));
            combo_cm.Select("Centimeters");

            
            TextBox value = win.Get<TextBox>(SearchCriteria.ByAutomationId("227"));
            var wartosc = value.Text;


            Assert.AreEqual(expectation, wartosc);
            Thread.Sleep(5000);
        }
            
        [TestMethod]
        public void addFigures()
        {
            // TODO Zadanie4: Napisać test dla działania dodawania (4+6=10) 
            // korzystając również z innych kryterów niż automationid oraz klawiatury
            var expectation = "10";

            Button button4 = win.Get<Button>(SearchCriteria.ByText("4"));
            button4.Click();
            Button plus = win.Get<Button>(SearchCriteria.ByText("+"));
            plus.Click();
            Button button6 = win.Get<Button>(SearchCriteria.ByText("6"));
            button6.Click();
            Button suma = win.Get<Button>(SearchCriteria.ByText("="));
            suma.Click();
            Label textBox = win.Get<Label>(SearchCriteria.ByText("10"));
            var textcheckBox = textBox.Text;
            
            Assert.AreEqual(expectation,textcheckBox);

        }

        [TestMethod]
        public void calcDate()
        {
            // TODO Zadanie5: Przetesotwać obliczanie daty. 
            // Sprawdzić czy odjęcie od dzisiejszego dnia 6 miesięcy 
            // zwróci poprawną date (30 września 2016).

            win.Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            win.Keyboard.Enter("E");
            win.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

            var expectation = "9 listopada 2016";

            ComboBox selectDate = win.Get<ComboBox>(SearchCriteria.ByAutomationId("4003"));
            selectDate.Select("Add or subtract a period of time");


            RadioButton subtract = win.Get<RadioButton>(SearchCriteria.ByAutomationId("4016"));
            subtract.Click();

            Spinner spinner = win.Get<Spinner>(SearchCriteria.ByAutomationId("4022"));
            spinner.Increment();
            spinner.Increment();
            spinner.Increment();
            spinner.Increment();
            spinner.Increment();
            spinner.Increment();

            Button calculate = win.Get<Button>(SearchCriteria.ByAutomationId("4015"));
            calculate.Click();


            TextBox value = win.Get<TextBox>(SearchCriteria.ByAutomationId("4013"));
            var wartosc = value.Text;

            Assert.AreEqual(expectation, wartosc);
        }
    }
}
