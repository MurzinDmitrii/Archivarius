using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add()
        {
            var app = FlaUI.Core.Application.Launch("C:\\Users\\Dmitrii\\Desktop\\Проекты\\Archivarius\\Archivarius\\Archivarius\\bin\\Debug\\Archivarius.exe");
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
        }
        //[TestMethod]
        public void Edit()
        {
            var app = FlaUI.Core.Application.Launch("C:\\Users\\Dmitrii\\Desktop\\Проекты\\Archivarius\\Archivarius\\Archivarius\\bin\\Debug\\Archivarius.exe");
            var automation = new UIA3Automation();
            var window = app.GetMainWindow(automation);
            var page = window.FindFirstDescendant(cf => cf.ByAutomationId("MainFrame"))?.AsGrid();
            var loginbox = page.FindFirstDescendant(cf => cf.ByAutomationId("LoginBox"))?.AsTextBox();
            loginbox.Text = "Ivanov";
            var passwordBox = page.FindFirstDescendant(cf => cf.ByAutomationId("PasswordBox"))?.AsTextBox();
            passwordBox.Text = "123";
            var button = page.FindFirstDescendant(cf => cf.ByAutomationId("AuthButton")).AsButton();
            button.Click();
            foreach(var item in page.FindAllChildren())
            {

            }
            /*var editMenu = page.FindFirstDescendant(cf => cf.ByAutomationId("EditMenu"));
            editMenu.Click();*/
            var a = page.FindFirstDescendant(cf => cf.ByAutomationId("CaseListView"));
            var b = a.FindAllChildren().First();
            //var e = b.FindAllChildren().OfType<MenuItem>();
            ConditionFactory cf1 = new ConditionFactory(new UIA3PropertyLibrary());
            var e = b.FindFirstDescendant(cf1.Menu()).AsMenu();
            var f = e.FindAllChildren().First();
            f.Click();
            var end = 0;
            /*foreach (var item in page.FindAllChildren())
            {
                Console.WriteLine(item.AutomationId);
            }*/
        }
    }
}
