using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add()
        {
            var app = FlaUI.Core.Application.Launch(new FileInfo("..\\..\\..\\Archivarius\\bin\\Debug\\Archivarius.exe").FullName);
            var automation = new UIA3Automation();
            var window = app.GetMainWindow(automation);
            var page = window.FindFirstDescendant(cf => cf.ByAutomationId("MainFrame"))?.AsGrid();
            var loginbox = page.FindFirstDescendant(cf => cf.ByAutomationId("LoginBox"))?.AsTextBox();
            loginbox.Text = "Ivanov";
            var passwordBox = page.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox();
            passwordBox.Text = "123";
            var button = page.FindFirstDescendant(cf => cf.ByAutomationId("AuthButton")).AsButton();
            button.Click();
            var addbutton = window.FindFirstDescendant(cf => cf.ByAutomationId("AddButton")).AsButton();
            addbutton.Click();
            var judgecombobox = page.FindFirstDescendant(cf => cf.ByAutomationId("JudgeComboBox")).AsComboBox();
            judgecombobox.Value = judgecombobox.Items[0].Text;
            var categoryComboBox = page.FindFirstDescendant(cf => cf.ByAutomationId("CategoryComboBox")).AsComboBox();
            categoryComboBox.Value = categoryComboBox.Items[0].Text;
            var articleComboBox = page.FindFirstDescendant(cf => cf.ByAutomationId("ArticleComboBox")).AsComboBox();
            articleComboBox.Value = articleComboBox.Items[0].Text;
            var descBox = page.FindFirstDescendant(cf => cf.ByAutomationId("DescriptionTextBox")).AsTextBox();
            descBox.Text = "123";
            var savebutton = page.FindFirstDescendant(cf => cf.ByAutomationId("SaveButton")).AsButton();
            savebutton.Click();
            savebutton = page.FindFirstDescendant(cf => cf.ByAutomationId("SaveButton")).AsButton();
            savebutton.Click();
            app.Close();
        }
        [TestMethod]
        public void Edit()
        {
            var app = FlaUI.Core.Application.Launch(new FileInfo("..\\..\\..\\Archivarius\\bin\\Debug\\Archivarius.exe").FullName);
            var automation = new UIA3Automation();
            var window = app.GetMainWindow(automation);
            var page = window.FindFirstDescendant(cf => cf.ByAutomationId("MainFrame"))?.AsGrid();
            var loginbox = page.FindFirstDescendant(cf => cf.ByAutomationId("LoginBox"))?.AsTextBox();
            loginbox.Text = "Ivanov";
            var passwordBox = page.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox();
            passwordBox.Text = "123";
            var button = page.FindFirstDescendant(cf => cf.ByAutomationId("AuthButton")).AsButton();
            button.Click();
            var a = page.FindFirstDescendant(cf => cf.ByAutomationId("CaseListView"));
            int i = 0;
            var listview = page.FindAllChildren().First();
            foreach (var item in page.FindAllChildren())
            {
                i++;
                if (i == 4)
                {
                    listview = item;
                }
            }
            var menu = listview.FindAllDescendants(new ConditionFactory(new UIA3PropertyLibrary()).ByText("Выдать"));
            var listviewchildrens = listview.FindAllChildren();
            var listviewchildren = listviewchildrens[0];
            var textboxesinitem = listviewchildren.FindAllChildren();  
            var textboxinitem = textboxesinitem[0];
            textboxinitem.RightClick();
            Mouse.MoveBy(100, 45);
            Mouse.LeftClick();
            Thread.Sleep(1000);
            var descBox = page.FindAllChildren()[4].AsTextBox();
            descBox.Text = "Тесты";
            Thread.Sleep(1000);
            var savebutton = page.FindAllChildren()[5].AsButton();
            savebutton.Click();
            savebutton = page.FindFirstDescendant(cf => cf.ByAutomationId("SaveButton")).AsButton();
            savebutton.Click();
            app.Close();
        }
        [TestMethod]
        public void Print()
        {
            var app = FlaUI.Core.Application.Launch(new FileInfo("..\\..\\..\\Archivarius\\bin\\Debug\\Archivarius.exe").FullName); 
            var automation = new UIA3Automation();
            var window = app.GetMainWindow(automation);
            var page = window.FindFirstDescendant(cf => cf.ByAutomationId("MainFrame"))?.AsGrid();
            var loginbox = page.FindFirstDescendant(cf => cf.ByAutomationId("LoginBox"))?.AsTextBox();
            loginbox.Text = "Ivanov";
            var passwordBox = page.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox();
            passwordBox.Text = "123";
            var button = page.FindFirstDescendant(cf => cf.ByAutomationId("AuthButton")).AsButton();
            button.Click();
            var a = page.FindFirstDescendant(cf => cf.ByAutomationId("CaseListView"));
            int i = 0;
            var listview = page.FindAllChildren().First();
            foreach (var item in page.FindAllChildren())
            {
                i++;
                if (i == 4)
                {
                    listview = item;
                }
            }
            var menu = listview.FindAllDescendants(new ConditionFactory(new UIA3PropertyLibrary()).ByText("Выдать"));
            var listviewchildrens = listview.FindAllChildren();
            var listviewchildren = listviewchildrens[0];
            var textboxesinitem = listviewchildren.FindAllChildren();
            var textboxinitem = textboxesinitem[0];
            textboxinitem.RightClick();
            Mouse.MoveBy(100, 95);
            Mouse.LeftClick();
            Mouse.MoveBy(10, 20);
            Mouse.RightClick();
            Mouse.MoveBy(10, 20);
            Mouse.RightClick();
            Thread.Sleep(1000);
            Mouse.MoveBy(-100, 30);
            Thread.Sleep(1000);
            Mouse.LeftClick();
            Mouse.MoveBy(100, 180);
            Thread.Sleep(1000);
            Mouse.LeftClick();
            Thread.Sleep(5000);
            
            app.Close();
        }
    }
}
