using System;
using System.Windows.Automation;
using WindowsUIautomation.Patterns;

namespace WindowsUIautomation.Features
{
   public static class ObtainElementsFeature
    {
        public static void ObtainAllElements()
        {
            var desktopChildren = AutomationElement.RootElement.FindAll(TreeScope.Children, Condition.TrueCondition); // diff cond

            foreach (AutomationElement item in desktopChildren)
            {
                if (item != null)
                {
                    Console.WriteLine($"{item.Current.Name}");
                }
            }
            Console.WriteLine();
        }

        public static AutomationElement ObtainOneElementByName(string name)
        {
            var cond = new PropertyCondition(AutomationElement.NameProperty, name);
            var automationElement = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, cond);
            Console.WriteLine($"{automationElement.Current.Name}");
            return automationElement;
        }
        public static AutomationElement ObtainOneElementByName(AutomationElement rootElement, string name)
        {
            var cond = new PropertyCondition(AutomationElement.NameProperty, name);
            var automationElement = rootElement.FindFirst(TreeScope.Descendants, cond);
            Console.WriteLine($"{automationElement.Current.Name}");
            return automationElement;
        }
        public static AutomationElement ObtainOneElementByID(string id)
        {
            var cond = new PropertyCondition(AutomationElement.AutomationIdProperty, id);
            var automationElement = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, cond);
            return automationElement;
        }
        public static AutomationElement ObtainOneElementByID(AutomationElement rootElement, string id)
        {
            var cond = new PropertyCondition(AutomationElement.AutomationIdProperty, id);
            var automationElement = rootElement.FindFirst(TreeScope.Descendants, cond);
            return automationElement;
        }

        public static void ObtainOneElementByTreeWalkerAndNameProperty()
        {
            var cond1 = new PropertyCondition(AutomationElement.IsContentElementProperty, true);
            var cond2 = new PropertyCondition(AutomationElement.IsEnabledProperty, true);
            var cond3 = new PropertyCondition(AutomationElement.NameProperty, "Open");
            TreeWalker treeWalker = new TreeWalker(new AndCondition(cond1, cond2, cond3));
            var openDialogElement = treeWalker.GetFirstChild(AutomationElement.RootElement);
            Console.WriteLine($"{openDialogElement.Current.Name}");
        }

        public static void GetAutomationElementInformation()
        {
            var element = ObtainOneElementByName("Open");
            Console.WriteLine($"{element.Current.ControlType} = {element.Current.ControlType.ProgrammaticName}");
        }

        public static void GetElementInvokeMethodCloseWindow()
        {
            var cond = new PropertyCondition(AutomationElement.NameProperty, "Open");
            var automationElement = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, cond);

           

            cond = new PropertyCondition(AutomationElement.AutomationIdProperty, "RepositoryBrowser");
            var cond1 = new PropertyCondition(AutomationElement.IsContentElementProperty, true);
            var cond2 = new PropertyCondition(AutomationElement.IsEnabledProperty, true);
            TreeWalker treeWalker = new TreeWalker(new AndCondition(cond, cond2, cond1));
            var centerPart = treeWalker.GetFirstChild(AutomationElement.RootElement);

            //var centerPart = automationElement.FindFirst(TreeScope.Descendants, cond);

            Console.WriteLine($"{centerPart.Current.AutomationId}");

            cond = new PropertyCondition(AutomationElement.NameProperty, "Go to Workspace");
            var buttonWorkspace = centerPart.FindFirst(TreeScope.Descendants, cond);

            Console.WriteLine($"{buttonWorkspace.Current.Name}");

            cond = new PropertyCondition(AutomationElement.AutomationIdProperty, "ViewStyleSelectorComboBox");
            var comboBox = centerPart.FindFirst(TreeScope.Descendants, cond);

            Console.WriteLine($" IsEnabledProperty - {comboBox.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty)}");
            Console.WriteLine($" IsExpandCollapsePatternAvailableProperty - {comboBox.GetCurrentPropertyValue(AutomationElement.IsExpandCollapsePatternAvailableProperty)}");
            //var point = comboBox.GetClickablePoint();
            //System.Windows.Forms.Cursor.Position = new System.Drawing.Point((int)clickablePoint.X, (int)clickablePoint.Y);
            PatternsFeatures.InvokeAutomationElement(buttonWorkspace);

            var textInputElement = ObtainOneElementByID("ProfileAttribute Id:1; Name:Client");
            PatternsFeatures.FillTextBoxByTextPattern(textInputElement);




            //var windowPattern = automationElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            //windowPattern.Close();
            //InvokeAutomationElement(buttonWorkspace);
        }

        
    }
}
