using System;
using WindowsUIautomation.Features;
using System.Windows.Automation;
using System.Threading;

namespace WindowsUIautomation.Patterns
{
    public static class PatternsFeatures
    {
        public static void ExpandComboBoxByExpandCollapsPattern()
        {
            var elementOpen = ObtainElementsFeature.ObtainOneElementByName("Open");
            var elementComboBox = ObtainElementsFeature.ObtainOneElementByID(elementOpen, "ViewStyleSelectorComboBox");
            var expendCollapsPattern = GetExpandCollapsePattern(elementComboBox);
            expendCollapsPattern.Expand(); 
        }

        public static void FillTextBoxByTextPattern(AutomationElement textElement)
        {
            
            object valuePattern = null;
            if (textElement.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern))
            {
                //Thread.Sleep(TimeSpan.FromSeconds(30));
                textElement.SetFocus();
                ((ValuePattern)valuePattern).SetValue("Text");
            }       



       
        }

        public static TextPattern GetTextPattern(AutomationElement targetControl)
        {
            TextPattern textPattern;

            try
            {
                textPattern = targetControl.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
            }
            // Object doesn't support the ExpandCollapsePattern control pattern.
            catch (InvalidOperationException)
            {
                return null;
            }

            return textPattern;
        }
        public static ExpandCollapsePattern GetExpandCollapsePattern(AutomationElement targetControl)
        {
            ExpandCollapsePattern expandCollapsePattern = null;

            try
            {
                expandCollapsePattern = targetControl.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            }
            // Object doesn't support the ExpandCollapsePattern control pattern.
            catch (InvalidOperationException)
            {
                return null;
            }

            return expandCollapsePattern;
        }

        public static void InvokeAutomationElement(AutomationElement automationElement)
        {
            InvokePattern invokePattern = null;
            try
            {
                invokePattern = automationElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }
            catch (ElementNotEnabledException)
            {
                return;
            }
            catch (InvalidOperationException)
            {
                return;
            }
            catch (InvalidCastException)
            {
                return;
            }
            invokePattern.Invoke();
        }
    }
}
